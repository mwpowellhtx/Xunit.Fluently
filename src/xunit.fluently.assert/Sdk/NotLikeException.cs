namespace Xunit.Sdk
{
    /// <inheritdoc/>
    public class NotLikeException : NotEqualException
    {
        /// <inheritdoc/>
        internal NotLikeException(string expected, string actual)
            : base(expected, actual)
        {
        }
    }
}
