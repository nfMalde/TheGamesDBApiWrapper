using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Exceptions
{
    /// <summary>
    /// TheGamesDBApiException
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class TheGamesDBApiException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheGamesDBApiException"/> class.
        /// </summary>
        public TheGamesDBApiException(): base("Uncaught TheGamesDB Exception")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TheGamesDBApiException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TheGamesDBApiException(string message): base(message)
        {

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TheGamesDBApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public TheGamesDBApiException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
