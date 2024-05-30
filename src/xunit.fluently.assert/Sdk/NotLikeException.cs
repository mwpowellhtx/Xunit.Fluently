using System;
using System.Reflection;

namespace Xunit.Sdk
{
    using static WildcardException;
    using static WildcardlyStringExtensionMethods;

#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif

    // TODO: may also introduce an intermediate exception
    // TODO: however this starts to diverge from the original intent
    class NotLikeException : WildcardException
    {
        /// <summary>
        /// 
        /// </summary>
        private static MethodInfo? _method;

        /// <summary>
        /// 
        /// </summary>
        private static MethodInfo Method => _method ??= GetSourceMethodCandidate(x => x.Name.Equals(nameof(WildcardlyStringExtensionMethods.AssertNotLike), StringComparison.InvariantCultureIgnoreCase));

        /// <summary>
        /// <see cref="Reason.alike"/>
        /// </summary>
        /// <value>Reason.alike</value>
        private const Reason Alike = Reason.alike;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        internal NotLikeException(string expected, string actual)
            : base(Method, Alike, expected, actual)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="expectedIndex"></param>
        /// <param name="actualIndex"></param>
        internal NotLikeException(string expected, string actual, int expectedIndex, int actualIndex)
            : base(Method, Alike, expected, actual, expectedIndex, actualIndex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="innerException"></param>
        internal NotLikeException(string expected, string actual, Exception innerException)
            : base(Method, Alike, expected, actual, innerException)
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
        internal NotLikeException(string expected, string actual, int expectedIndex, int actualIndex, Exception innerException)
            : base(Method, Alike, expected, actual, expectedIndex, actualIndex, innerException)
        {
        }
    }
}
