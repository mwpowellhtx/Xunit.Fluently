using System;

namespace Xunit
{
    using Sdk;

    public class FluentlyClassInstanceThrowsTestCases : FluentlyClassInstanceTestCasesBase
    {
        /// <inheritdoc/>
        public FluentlyClassInstanceThrowsTestCases()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="instance"></param>
        /// <param name="testCase"></param>
        private static void VerifyAssertThrows<TException>(TestClass instance, Func<TestClass, Action> testCase)
            where TException : Exception =>
            testCase(instance).AssertThrows<TException>();

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassInstanceIsNull() =>
            VerifyAssertThrows<NullException>(TestClass.Instance, x => () => x.AssertClassInstanceNull());

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassInstanceIsNotNull() =>
            VerifyAssertThrows<NotNullException>(TestClass.NullInstance, x => () => x.AssertClassInstanceNotNull());

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberNull() =>
            VerifyAssertThrows<NullException>(TestClass.Instance, x => () => x.AssertClassMemberNull(x => x.Value));

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberNotNull() =>
            VerifyAssertThrows<NotNullException>(TestClass.InstanceNullValue, x => () => x.AssertClassMemberNotNull(x => x.Value));

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberStructNull() =>
            VerifyAssertThrows<NullException>(TestClass.Instance, x => () => x.AssertClassMemberStructNull(x => x.Value));

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberStructNotNull() =>
            VerifyAssertThrows<NotNullException>(TestClass.InstanceNullValue, x => () => x.AssertClassMemberStructNotNull(x => x.Value));
    }
}
