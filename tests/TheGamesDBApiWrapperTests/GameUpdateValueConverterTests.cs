using Xunit;
using Shouldly;
using System.Text.Json;
using TheGamesDBApiWrapper.Converter;
using TheGamesDBApiWrapper.Models.Responses.Games;

namespace TheGamesDBApiWrapperTests
{
    /// <summary>
    /// The <c>value</c> field of a game update is whatever the API felt like sending: a string for
    /// most edits, a number for ids, an array for multi-valued fields — and, as a live import found
    /// the hard way, sometimes null.
    ///
    /// <para>An unhandled token throws mid-page, which aborts the whole paginated Updates walk. The
    /// caller never advances its last-edit cursor, so every subsequent run replays the same pages
    /// and dies on the same record: the import can never get past it. That is why these cases are
    /// worth handling rather than letting the exception through.</para>
    /// </summary>
    public class GameUpdateValueConverterTests
    {
        private static GameUpdateValueModel? Read(string json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new GameUpdateValueConverter());
            return JsonSerializer.Deserialize<GameUpdateValueModel>(json, options);
        }

        [Fact]
        public void Reads_a_string_value()
        {
            Read("\"boxart/front/38113-1.jpg\"")!.Value.ShouldBe("boxart/front/38113-1.jpg");
        }

        [Fact]
        public void Reads_a_number_value()
        {
            Read("38113")!.NumberValue.ShouldBe(38113L);
        }

        [Fact]
        public void Reads_an_array_value()
        {
            Read("[\"a\",\"b\"]")!.Values.ShouldNotBeNull();
        }

        /// <summary>
        /// A cleared field. This is the one that killed a live import — the whole run aborted on a
        /// single null, and because the cursor never advanced, every retry hit it again.
        /// </summary>
        [Fact]
        public void Reads_a_null_value_without_throwing()
        {
            Should.NotThrow(() => Read("null"));
            Read("null").ShouldBeNull();
        }

        [Fact]
        public void Reads_a_boolean_value_without_throwing()
        {
            Should.NotThrow(() => Read("true"));
        }

        /// <summary>
        /// An object where a scalar was expected. Not seen in the wild yet, but it costs nothing to
        /// survive and everything to abort a full import over.
        /// </summary>
        [Fact]
        public void Reads_an_object_value_without_throwing()
        {
            Should.NotThrow(() => Read("{\"id\":1}"));
        }

        /// <summary>
        /// When it genuinely cannot cope, the exception must say WHAT it could not cope with.
        ///
        /// <para>The original message was "Unexpected JSON token type." — no token, no position —
        /// so a production stack trace could not identify the offending record, and because the
        /// exception aborts the paginated Updates walk before the caller's cursor advances, every
        /// later run replayed the same pages and died on the same value.</para>
        ///
        /// <para>Every token a value can legally start with is handled now, so this is reached by
        /// driving the converter directly at a structural token — a safety net rather than
        /// something the serializer can still produce.</para>
        /// </summary>
        [Fact]
        public void An_unsupported_token_names_itself()
        {
            var ex = Assert.Throws<JsonException>(() =>
            {
                var reader = new Utf8JsonReader("{\"a\":1}"u8);
                reader.Read();   // StartObject
                reader.Read();   // PropertyName — never a value
                new GameUpdateValueConverter().Read(
                    ref reader, typeof(GameUpdateValueModel), new JsonSerializerOptions());
            });

            ex.Message.ShouldContain("PropertyName");
            ex.Message.ShouldContain("byte");
        }
    }
}
