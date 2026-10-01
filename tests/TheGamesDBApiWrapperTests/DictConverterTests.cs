using System.Collections.Generic;
using System.Text.Json;
using Shouldly;
using TheGamesDBApiWrapper.Converter;
using TheGamesDBApiWrapper.Models.Entities;
using TheGamesDBApiWrapper.Models.Responses.Games;
using TheGamesDBApiWrapper.Models.Responses.Genres;
using Xunit;

namespace TheGamesDBApiWrapperTests
{
    /// <summary>
    /// TheGamesDB is PHP, and json_encode writes an empty map as <c>[]</c> instead of <c>{}</c>.
    /// Every dictionary in a response can therefore arrive as an empty array, and without the
    /// factory that fails the whole call — for a perfectly valid 200 response.
    /// </summary>
    public class DictConverterTests
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            Converters = { new DictConverterFactory() }
        };

        [Fact]
        public void Reads_an_empty_array_as_an_empty_dictionary()
        {
            var result = JsonSerializer.Deserialize<Dictionary<int, GameImageModel[]>>("[]", Options);

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Reads_an_empty_object_as_an_empty_dictionary()
        {
            var result = JsonSerializer.Deserialize<Dictionary<int, GameImageModel[]>>("{}", Options);

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Reads_null_as_null()
        {
            JsonSerializer.Deserialize<Dictionary<int, GameImageModel[]>>("null", Options).ShouldBeNull();
        }

        [Fact]
        public void Reads_an_object_with_numeric_keys()
        {
            const string json = """
                {
                  "1": [ { "id": 242, "type": "fanart", "filename": "fanart/1-2.jpg" } ],
                  "17": [ { "id": 3, "type": "boxart", "side": "front", "filename": "boxart/front/17-1.jpg" },
                          { "id": 4, "type": "boxart", "side": "back", "filename": "boxart/back/17-1.jpg" } ]
                }
                """;

            var result = JsonSerializer.Deserialize<Dictionary<int, GameImageModel[]>>(json, Options);

            result.ShouldNotBeNull();
            result.Keys.ShouldBe(new[] { 1, 17 });
            result[1].Length.ShouldBe(1);
            result[17].Length.ShouldBe(2);
            result[17][1].FileName.ShouldBe("boxart/back/17-1.jpg");
        }

        [Fact]
        public void Reads_an_empty_array_inside_a_response_model()
        {
            const string json = """{ "count": 0, "base_url": null, "images": [] }""";

            var result = JsonSerializer.Deserialize<GamesImagesDataModel>(json, Options);

            result.ShouldNotBeNull();
            result.Images.ShouldNotBeNull();
            result.Images.ShouldBeEmpty();
        }

        [Fact]
        public void Reads_an_empty_array_for_a_non_nullable_dictionary()
        {
            var result = JsonSerializer.Deserialize<GenreDataModel>("""{ "count": 0, "genres": [] }""", Options);

            result.ShouldNotBeNull();
            result.Genres.ShouldBeEmpty();
        }

        [Fact]
        public void Rejects_a_non_empty_array_and_says_where()
        {
            var ex = Should.Throw<JsonException>(
                () => JsonSerializer.Deserialize<Dictionary<int, GameImageModel[]>>("[ { \"id\": 1 } ]", Options));

            ex.Message.ShouldContain("non-empty array");
            ex.Message.ShouldContain("byte");
        }

        [Fact]
        public void Rejects_a_scalar_and_names_the_token()
        {
            var ex = Should.Throw<JsonException>(
                () => JsonSerializer.Deserialize<Dictionary<int, GameImageModel[]>>("42", Options));

            ex.Message.ShouldContain("Number");
        }

        [Fact]
        public void Writes_an_object()
        {
            var value = new Dictionary<int, string> { [1] = "a", [17] = "b" };

            JsonSerializer.Serialize(value, Options).ShouldBe("""{"1":"a","17":"b"}""");
        }

        [Fact]
        public void Handles_only_dictionaries()
        {
            var factory = new DictConverterFactory();

            factory.CanConvert(typeof(Dictionary<int, string>)).ShouldBeTrue();
            factory.CanConvert(typeof(Dictionary<string, object>)).ShouldBeTrue();
            factory.CanConvert(typeof(List<int>)).ShouldBeFalse();
            factory.CanConvert(typeof(IDictionary<int, string>)).ShouldBeFalse();
        }
    }
}
