using System;
using System.Reflection;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    using Abstractions;

    /// <inheritdoc />
    public class FluentlyExtensionMethodTests : ExtensionMethodsTestFixtureBase
    {
        /// <inheritdoc />
        protected override Type ClassType { get; } = typeof(FluentlyExtensionMethods);

        public FluentlyExtensionMethodTests(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

#pragma warning disable xUnit1008
        [ClassData(typeof(FluentlyExtensionMethodTestCases))]
        public override void Verify_Public_Methods_Are_Extension(MethodInfo method)
            => base.Verify_Public_Methods_Are_Extension(method);
#pragma warning restore xUnit1008

    }
}
