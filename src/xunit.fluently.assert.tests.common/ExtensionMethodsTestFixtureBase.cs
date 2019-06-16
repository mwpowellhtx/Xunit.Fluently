using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    using Abstractions;

    /// <summary>
    ///The irony of ironies is that we will utilize the <see cref="Assert"/> static
    /// methods directly in order to verify aspects of our extension methods.
    /// </summary>
    /// <inheritdoc />
    public abstract class ExtensionMethodsTestFixtureBase : TestFixtureBase
    {
        /// <summary>
        /// Gets the ClassType.
        /// </summary>
        protected abstract Type ClassType { get; }

        protected Type ExtensionAttributeType { get; } = typeof(ExtensionAttribute);

        /// <inheritdoc />
        protected ExtensionMethodsTestFixtureBase(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        protected void Verify_ClassType() => Assert.NotNull(ClassType);

        [Fact]
        protected void Verify_ExtensionAttribute()
        {
            Assert.NotNull(ExtensionAttributeType);
            Assert.Equal(nameof(ExtensionAttribute), ExtensionAttributeType.Name);
        }

#pragma warning disable xUnit1003
        /// <summary>
        /// Verifies that the <paramref name="method"/> is correct.
        /// </summary>
        /// <param name="method"></param>
        [Theory]
        public virtual void Verify_Public_Methods_Are_Extension(MethodInfo method)
        {
            Assert.Equal(ClassType, method.DeclaringType);
            Assert.NotNull(method);
            Assert.True(method.IsPublic);
            Assert.True(method.IsStatic);
            Assert.True(method.IsDefined(ExtensionAttributeType));
        }
#pragma warning restore xUnit1003

    }
}
