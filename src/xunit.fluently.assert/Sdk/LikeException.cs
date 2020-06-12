namespace Xunit.Sdk
{
    /// <inheritdoc/>
    public class LikeException : EqualException
    {
        /// <inheritdoc/>
        internal LikeException(object expected, object actual)
            : base(expected, actual)
        {
        }

        /// <inheritdoc/>
        internal LikeException(string expected, string actual, int expectedIndex, int actualIndex)
            : base(expected, actual, expectedIndex, actualIndex)
        {
        }
    }
}
