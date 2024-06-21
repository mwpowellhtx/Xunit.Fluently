namespace Xunit
{
    /// <inheritdoc/>
    public class FluentlyClassInstanceTestCases : FluentlyClassInstanceTestCasesBase
    {
        /// <inheritdoc/>
        public FluentlyClassInstanceTestCases()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassInstanceIsNull() =>
            TestClass.NullInstance.AssertClassInstanceNull();

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassInstanceIsNotNull() =>
            TestClass.Instance.AssertClassInstanceNotNull();

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberNull() =>
            TestClass.InstanceNullValue.AssertClassMemberNull(x => x.Value);

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberNotNull() =>
            TestClass.Instance.AssertClassMemberNotNull(x => x.Value);

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberStructNull() =>
            TestClass.InstanceNullValue.AssertClassMemberStructNull(x => x.Value);

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberStructNotNull() =>
            TestClass.Instance.AssertClassMemberStructNotNull(x => x.Value);

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassInstanceIsNotNullCanFluent() =>
            TestClass.Instance.AssertClassInstanceNotNull().AssertIsType<TestClass>();

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberNullCanFluent() =>
            TestClass.InstanceNullValue.AssertClassMemberNull(x => x.Value).AssertIsType<TestClass>();

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberNotNullCanFluent() =>
            TestClass.Instance.AssertClassMemberNotNull(x => x.Value).AssertIsType<TestClass>();

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberStructNullCanFluent() =>
            TestClass.InstanceNullValue.AssertClassMemberStructNull(x => x.Value).AssertIsType<TestClass>();

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public virtual void AssertsClassMemberStructNotNullCanFluent() =>
            TestClass.Instance.AssertClassMemberStructNotNull(x => x.Value).AssertIsType<TestClass>();
    }
}
