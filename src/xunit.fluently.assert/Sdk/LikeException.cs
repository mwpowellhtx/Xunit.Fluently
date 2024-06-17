using System;
using System.Reflection;

namespace Xunit.Sdk
{
    using static WildcardException;

#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif

    class LikeException : WildcardException
    {
        /// <summary>
        /// 
        /// </summary>
#if XUNIT_NULLABLE
        private static MethodInfo? _method;
#else
        private static MethodInfo _method;
#endif

        /// <summary>
        /// Gets the Method for which we are reporting.
        /// </summary>
        /// <remarks>
        /// Note that we do so via Reflection.
        /// </remarks>
        private static MethodInfo Method => _method ??= GetSourceMethodCandidate(x => x.Name.ToLower() == nameof(WildcardlyStringExtensionMethods.AssertLike).ToLower());

        /// <summary>
        /// <see cref="Reason.alike"/>
        /// </summary>
        /// <value>Reason.alike</value>
        private const Reason Dislike = Reason.dislike;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        internal LikeException(string expected, string actual)
            : base(Method, Dislike, expected, actual)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="expectedIndex"></param>
        /// <param name="actualIndex"></param>
        internal LikeException(string expected, string actual, int expectedIndex, int actualIndex)
            : base(Method, Dislike, expected, actual, expectedIndex, actualIndex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="innerException"></param>
        internal LikeException(string expected, string actual, Exception innerException)
            : base(Method, Dislike, expected, actual, innerException)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="expectedIndex"></param>
        /// <param name="actualIndex"></param>
        /// <param name="innerException"></param>
        internal LikeException(string expected, string actual, int expectedIndex, int actualIndex, Exception innerException)
            : base(Method, Dislike, expected, actual, expectedIndex, actualIndex, innerException)
        {
        }
    }
}