using System;
using System.Linq;
using System.Reflection;

namespace Xunit.Sdk
{
    using static BindingFlags;

#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif

    // TODO: may also introduce an intermediate exception
    // TODO: however this starts to diverge from the original intent
    abstract class WildcardException : XunitException
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _expected;

        /// <summary>
        /// 
        /// </summary>
        private string _notExpected;

        /// <summary>
        /// 
        /// </summary>
        // public string Expected { get; }
        public string Expected => _notExpected ??= $"Not {_expected}";

        /// <summary>
        /// 
        /// </summary>
        public string Actual { get; }

        /// <summary>
        /// -1
        /// </summary>
        /// <value>-1</value>
        private const int DefaultIndex = -1;

        // TODO: may also need to adjust the 'expected index' assuming the "Not {0}" adjustment
        /// <summary>
        /// 
        /// </summary>
        public int ExpectedIndex { get; } = DefaultIndex;

        /// <summary>
        /// 
        /// </summary>
        public int ActualIndex { get; } = DefaultIndex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="reason"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected WildcardException(MethodInfo method, Reason reason, string expected, string actual)
            : this(method, reason, expected, actual, DefaultIndex, DefaultIndex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="reason"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="expectedIndex"></param>
        /// <param name="actualIndex"></param>
        protected WildcardException(MethodInfo method, Reason reason, string expected, string actual, int expectedIndex, int actualIndex)
            : base(ReportMessage(method, reason, expected, actual))
        {
            _expected = expected!;
            Actual = actual!;
            ExpectedIndex = expectedIndex;
            ActualIndex = actualIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="reason"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="innerException"></param>
        protected WildcardException(MethodInfo method, Reason reason, string expected, string actual, Exception innerException)
            : this(method, reason, expected, actual, DefaultIndex, DefaultIndex, innerException)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="reason"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="expectedIndex"></param>
        /// <param name="actualIndex"></param>
        /// <param name="innerException"></param>
        protected WildcardException(MethodInfo method, Reason reason, string expected, string actual, int expectedIndex, int actualIndex, Exception innerException)
            : base(ReportMessage(method, reason, expected, actual), innerException)
        {
            _expected = expected!;
            Actual = actual!;
            ExpectedIndex = expectedIndex;
            ActualIndex = actualIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        protected enum Reason
        {
            /// <summary>
            /// Used when values are &quot;alike&quot;.
            /// </summary>
            alike,

            /// <summary>
            /// Used when values are &quot;dislike&quot;.
            /// </summary>
            dislike,
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        protected static MethodInfo GetSourceMethodCandidate(Func<MethodInfo, bool> predicate)
        {
            var methods = typeof(WildcardlyStringExtensionMethods).GetMethods(Public | Static);
            return methods.FirstOrDefault(predicate);
        }

        // TODO: could get fancier in the rendering but this is the core message, pretty spacing, etc
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="reason"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <returns></returns>
        protected static string ReportMessage(MethodInfo method, Reason reason, string expected, string actual)
            => $"{method.DeclaringType.Name}.{method.Name}(): Failure: Values {reason}\r\nExpected: {expected}\r\nActual: {actual}";
    }
}
