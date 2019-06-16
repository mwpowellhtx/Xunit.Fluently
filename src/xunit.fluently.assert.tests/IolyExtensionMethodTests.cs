using System;
using System.Reflection;

// ReSharper disable IdentifierTypo
namespace Xunit
{
    using Abstractions;

    /// <inheritdoc />
    public class IolyExtensionMethodTests : ExtensionMethodsTestFixtureBase
    {
        /// <inheritdoc />
        protected override Type ClassType { get; } = typeof(IolyExtensionMethods);

        public IolyExtensionMethodTests(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

#pragma warning disable xUnit1008
        [ClassData(typeof(IolyExtensionMethodTestCases))]
        public override void Verify_Public_Methods_Are_Extension(MethodInfo method)
            => base.Verify_Public_Methods_Are_Extension(method);
#pragma warning restore xUnit1008

    }
}
// ReSharper restore IdentifierTypo
