using System.Collections.Generic;

namespace Xunit
{
    using Theoretically;

    /// <inheritdoc/>
    public abstract class FluentlyClassInstanceTestCasesBase : TestCasesBase
    {
        /// <inheritdoc/>
        protected override IEnumerable<object[]> Cases { get; } = [];

        /// <summary>
        /// 
        /// </summary>
        protected class TestClass
        {
            /// <summary>
            /// <c>3</c>
            /// </summary>
            /// <value>3</value>
            internal const int ValueDefault = 3;

            /// <summary>
            /// Gets or Sets the Value.
            /// </summary>
            public int? Value { get; set; } = ValueDefault;

            /// <summary>
            /// 
            /// </summary>
            internal static TestClass Instance => new();

            /// <summary>
            /// 
            /// </summary>
            internal static TestClass NullInstance => null;

            /// <summary>
            /// 
            /// </summary>
            internal static TestClass InstanceNullValue => new() { Value = null };
        }
    }
}
