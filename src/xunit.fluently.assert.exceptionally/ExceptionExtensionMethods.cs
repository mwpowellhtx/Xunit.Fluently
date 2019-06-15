using System;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    // TODO: TBD: we may put async versions of the same in here eventually...
    public static partial class ExceptionallyExtensionMethods
    {
        /// <summary>
        /// Verifies the <paramref name="exception"/> using <paramref name="verify"/>.
        /// </summary>
        /// <param name="exception">The Exception being inspected.</param>
        /// <param name="verify">The Verify inspection action.</param>
        /// <returns>The <paramref name="exception"/> following successful inspection.</returns>
        public static Exception Verify(this Exception exception, Action<Exception> verify = null)
        {
            Assert.NotNull(exception);
            verify?.Invoke(exception);
            return exception;
        }

        /// <summary>
        /// Verifies the <paramref name="exception"/> using <paramref name="verify"/>.
        /// </summary>
        /// <typeparam name="T">The type of Exception being inspected.</typeparam>
        /// <param name="exception">The <typeparamref name="T"/> Exception being inspected.</param>
        /// <param name="verify">The Verify inspection action.</param>
        /// <returns>The <paramref name="exception"/> following successful inspection.</returns>
        public static T Verify<T>(this T exception, Action<T> verify = null)
            where T : Exception
        {
            Assert.NotNull(exception);
            verify?.Invoke(exception);
            return exception;
        }

        /// <summary>
        /// Verifies the <paramref name="exception"/> using <paramref name="verify"/>.
        /// <paramref name="exception"/> itself may not necessarily be assignable from
        /// <typeparamref name="T"/>, however, should have <typeparamref name="T"/>
        /// somewhere in its family tree.
        /// </summary>
        /// <typeparam name="T">The type of Exception being inspected.</typeparam>
        /// <param name="exception">The <typeparamref name="T"/> Exception being inspected.</param>
        /// <param name="verify">The Verify inspection action.</param>
        /// <returns>The <paramref name="exception"/> following successful inspection.</returns>
        public static T VerifyAny<T>(this Exception exception, Action<T> verify = null)
            where T : Exception
        {
            var actual = exception as T;
            Assert.NotNull(actual);
            verify?.Invoke(actual);
            return actual;
        }
    }
}
