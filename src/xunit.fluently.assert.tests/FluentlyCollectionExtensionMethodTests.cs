using System;
using System.Collections.Generic;
using System.Linq;

namespace Xunit
{
    using Abstractions;
    using Sdk;

    public class FluentlyCollectionExtensionMethodTests : TestFixtureBase
    {
        public FluentlyCollectionExtensionMethodTests(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        /// <value>0</value>
        private const int Zero = 0;

        /// <value>1</value>
        private const int One = 1;

        /// <value>3</value>
        private const int Nominal = 3;

        /// <summary>
        /// Gets a Range of <see cref="Nominal"/> <see cref="int"/> values from <see cref="Zero"/>.
        /// </summary>
        private static IEnumerable<int> ZeroBasedNominalRange { get; } = Enumerable.Range(Zero, Nominal);

        /// <summary>
        /// Gets a Range of <see cref="Nominal"/> <see cref="int"/> values from <see cref="One"/>.
        /// </summary>
        private static IEnumerable<int> OneBasedNominalRange { get; } = Enumerable.Range(One, Nominal);

        /// <summary>
        /// Gets a Greater Than Zero Inspector.
        /// </summary>
        private static Action<int> GreaterThanZeroInspector => x => (x > Zero).AssertTrue();

        private static Action GetAssertCollectionAction(IEnumerable<int> actual, IEnumerable<Action<int>> elementInspectors) =>
            () => actual.AssertCollection(elementInspectors.ToArray());

        [Fact]
        public void AssertCollection() =>
            GetAssertCollectionAction(OneBasedNominalRange, Enumerable.Repeat(GreaterThanZeroInspector, Nominal))
                .Invoke();

        [Fact]
        public void AssertCollection_too_few_inspectors_throws() =>
            GetAssertCollectionAction(ZeroBasedNominalRange, GetRange(GreaterThanZeroInspector))
                .AssertThrows<CollectionException>();

        [Fact]
        public void AssertCollection_at_least_one_fails_inspection_throws() =>
            GetAssertCollectionAction(ZeroBasedNominalRange, Enumerable.Repeat(GreaterThanZeroInspector, Nominal))
                .AssertThrows<CollectionException>();

        private static Predicate<int> HasOneZeroOrDefault => x => x == default;

        private static Action GetAssertContainsAnyPredicatedAction(IEnumerable<int> actual, Predicate<int> filter) =>
            () => actual.AssertContainsAny(filter);

        [Fact]
        public void AssertContainsAny_predicated() =>
            GetAssertContainsAnyPredicatedAction(ZeroBasedNominalRange, HasOneZeroOrDefault)
                .Invoke();

        [Fact]
        public void AssertContainsAny_predicated_throws() =>
            GetAssertContainsAnyPredicatedAction(OneBasedNominalRange, HasOneZeroOrDefault)
                .AssertThrows<ContainsException>();

        private static Action GetAssertContainsAllPredicatedAction(IEnumerable<int> actual, Predicate<int> filter) =>
            () => actual.AssertContainsAll(HasOneZeroOrDefault);

        [Fact]
        public void AssertContainsAll_predicated() =>
            GetAssertContainsAllPredicatedAction(Enumerable.Repeat(Zero, Nominal), HasOneZeroOrDefault)
                .Invoke();

        [Fact]
        public void AssertContainsAll_does_not_contain_all_throws() =>
            GetAssertContainsAllPredicatedAction(OneBasedNominalRange, HasOneZeroOrDefault)
                .AssertThrows<ContainsException>();

        private static Action GetAssertContainsAllParamsAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertContainsAll(expected.ToArray());

        [Fact]
        public void AssertContainsAll_params() =>
            GetAssertContainsAllParamsAction(ZeroBasedNominalRange, ZeroBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertContainsAll_params_in_any_order() =>
            GetAssertContainsAllParamsAction(ZeroBasedNominalRange, ZeroBasedNominalRange.Reverse())
                .Invoke();

        [Fact]
        public void AssertContainsAll_params_set_intersection_throws() =>
            GetAssertContainsAllParamsAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .AssertThrows<ContainsException>();

        [Fact]
        public void AssertContainsAll_params_set_complement_throws() =>
            GetAssertContainsAllParamsAction(ZeroBasedNominalRange, Enumerable.Range(-Nominal, Nominal))
                .AssertThrows<ContainsException>();

        private class IntegerEqualityComparer : EqualityComparer<int>
        {
            public override bool Equals(int x, int y) => x == y;

            public override int GetHashCode(int obj) => obj.GetHashCode();
        }

        private static Action GetAssertContainsAllComparerParamsAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertContainsAll(new IntegerEqualityComparer(), expected.ToArray());

        [Fact]
        public void AssertContainsAll_comparer_params() =>
            GetAssertContainsAllComparerParamsAction(ZeroBasedNominalRange, ZeroBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertContainsAll_comparer_params_reversed() =>
            GetAssertContainsAllComparerParamsAction(ZeroBasedNominalRange, ZeroBasedNominalRange.Reverse())
                .Invoke();

        [Fact]
        public void AssertContainsAll_comparer_params_set_intersection_throws() =>
            GetAssertContainsAllComparerParamsAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .AssertThrows<ContainsException>();

        private static Action GetAssertContainsPredicatedAction(IEnumerable<int> actual, Predicate<int> filter) =>
            () => actual.AssertContains(filter);

        [Fact]
        public void AssertContains_predicated() =>
            GetAssertContainsPredicatedAction(ZeroBasedNominalRange, HasOneZeroOrDefault)
                .Invoke();

        [Fact]
        public void AssertContains_predicated_set_intersection_throws() =>
            GetAssertContainsPredicatedAction(OneBasedNominalRange, HasOneZeroOrDefault)
                .AssertThrows<ContainsException>();

        private static Action GetAssertDoesNotContainPredicatedAction(IEnumerable<int> actual, Predicate<int> filter) =>
            () => actual.AssertDoesNotContain(filter);

        [Fact]
        public void AssertDoesNotContain() =>
            GetAssertDoesNotContainPredicatedAction(OneBasedNominalRange, HasOneZeroOrDefault)
                .Invoke();

        [Fact]
        public void AssertDoesNotContain_throws() =>
            GetAssertDoesNotContainPredicatedAction(ZeroBasedNominalRange, HasOneZeroOrDefault)
                .AssertThrows<DoesNotContainException>();

        private static Action GetAssertDoesNotContainAnyPredicatedAction(IEnumerable<int> actual, Predicate<int> filter) =>
            () => actual.AssertDoesNotContainAny(filter);

        [Fact]
        public void AssertDoesNotContainAny_predicated() =>
            GetAssertDoesNotContainAnyPredicatedAction(OneBasedNominalRange, HasOneZeroOrDefault)
                .Invoke();

        [Fact]
        public void AssertDoesNotContainAny_predicated_throws() =>
            GetAssertDoesNotContainAnyPredicatedAction(ZeroBasedNominalRange, HasOneZeroOrDefault)
                .AssertThrows<DoesNotContainException>();

        private static Action GetAssertDoesNotContainAnyParamsAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertDoesNotContainAny(expected.ToArray());

        [Fact]
        public void AssertDoesNotContainAny_params() =>
            GetAssertDoesNotContainAnyParamsAction(OneBasedNominalRange, Enumerable.Repeat(Zero, Nominal))
                .Invoke();

        [Fact]
        public void AssertDoesNotContainAny_params_throws() =>
            GetAssertDoesNotContainAnyParamsAction(ZeroBasedNominalRange, Enumerable.Repeat(Zero, Nominal))
                .AssertThrows<DoesNotContainException>();

        private static Action GetAssertDoesNotContainAnyParamsComparerAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertDoesNotContainAny(new IntegerEqualityComparer(), expected.ToArray());

        [Fact]
        public void AssertDoesNotContainAny_params_comparer() =>
            GetAssertDoesNotContainAnyParamsComparerAction(OneBasedNominalRange, Enumerable.Repeat(Zero, Nominal))
                .Invoke();

        [Fact]
        public void AssertDoesNotContainAny_params_comparer_throws() =>
            GetAssertDoesNotContainAnyParamsComparerAction(ZeroBasedNominalRange, Enumerable.Repeat(Zero, Nominal))
                .AssertThrows<DoesNotContainException>();

        private static Action GetAssertEqualAction(IEnumerable<int> actual) =>
            () => actual.AssertCollectionEmpty();

        [Fact]
        public void AssertCollectionEmpty() =>
            GetAssertEqualAction(GetRange<int>())
                .Invoke();

        [Fact]
        public void AssertCollectionEmpty_throws() =>
            GetAssertEqualAction(ZeroBasedNominalRange)
                .AssertThrows<EmptyException>();

        private static Action GetAssertNotEmptyAction(IEnumerable<int> actual) =>
            () => actual.AssertCollectionNotEmpty();

        [Fact]
        public void AssertCollectionNotEmpty() =>
            GetAssertNotEmptyAction(ZeroBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionNotEmpty_throws() =>
            GetAssertNotEmptyAction(GetRange<int>())
                .AssertThrows<NotEmptyException>();

        private static Action GetAssertEqualAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionEqual(expected);

        [Fact]
        public void AssertCollectionEqual() =>
            GetAssertEqualAction(OneBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionEqual_when_entirely_different_throws() =>
            GetAssertEqualAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .AssertThrows<EqualException>();

        [Fact]
        public void AssertCollectionEqual_when_different_order_throws() =>
            GetAssertEqualAction(OneBasedNominalRange, OneBasedNominalRange.Reverse())
                .AssertThrows<EqualException>();

        private static Action GetAssertEqualParamsAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionEqual(expected.ToArray());

        [Fact]
        public void AssertCollectionEqual_params() =>
            GetAssertEqualParamsAction(OneBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionEqual_params_when_entirely_different_throws() =>
            GetAssertEqualParamsAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .AssertThrows<EqualException>();

        [Fact]
        public void AssertCollectionEqual_params_when_different_order_throws() =>
            GetAssertEqualParamsAction(OneBasedNominalRange, OneBasedNominalRange.Reverse())
                .AssertThrows<EqualException>();

        private static Action GetAssertEqualComparerAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionEqual(expected, new IntegerEqualityComparer());

        [Fact]
        public void AssertCollectionEqual_comparer() =>
            GetAssertEqualComparerAction(OneBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionEqual_comparer_when_entirely_different_throws() =>
            GetAssertEqualComparerAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .AssertThrows<EqualException>();

        [Fact]
        public void AssertCollectionEqual_comparer_when_different_order_throws() =>
            GetAssertEqualComparerAction(OneBasedNominalRange, OneBasedNominalRange.Reverse())
                .AssertThrows<EqualException>();

        private static Action GetEqualComparerParamsAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionEqual(new IntegerEqualityComparer(), expected.ToArray());

        [Fact]
        public void AssertCollectionEqual_params_comparer() =>
            GetEqualComparerParamsAction(OneBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionEqual_params_comparer_when_entirely_different_throws() =>
            GetEqualComparerParamsAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .AssertThrows<EqualException>();

        [Fact]
        public void AssertCollectionEqual_params_comparer_when_different_order_throws() =>
            GetEqualComparerParamsAction(OneBasedNominalRange, OneBasedNominalRange.Reverse())
                .AssertThrows<EqualException>();

        private static Action GetAssertNotEqualAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionNotEqual(expected);

        [Fact]
        public void AssertCollectionNotEqual() =>
            GetAssertNotEqualAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionNotEqualwhen_equal_throws() =>
            GetAssertNotEqualAction(ZeroBasedNominalRange, ZeroBasedNominalRange)
                .AssertThrows<NotEqualException>();

        private static Action GetAssertNotEqualParamsAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionNotEqual(expected.ToArray());

        [Fact]
        public void AssertCollectionNotEqual_params() =>
            GetAssertNotEqualParamsAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionNotEqual_params_when_equal_throws() =>
            GetAssertNotEqualParamsAction(ZeroBasedNominalRange, ZeroBasedNominalRange)
                .AssertThrows<NotEqualException>();

        private static Action GetAssertNotEqualComparerAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionNotEqual(expected, new IntegerEqualityComparer());

        [Fact]
        public void AssertCollectionNotEqual_comparer() =>
            GetAssertNotEqualComparerAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionNotEqual_comparer_when_equal_throws() =>
            GetAssertNotEqualComparerAction(ZeroBasedNominalRange, ZeroBasedNominalRange)
                .AssertThrows<NotEqualException>();

        private static Action GetAssertNotEqualParamsComparerAction(IEnumerable<int> actual, IEnumerable<int> expected) =>
            () => actual.AssertCollectionNotEqual(new IntegerEqualityComparer(), expected.ToArray());

        [Fact]
        public void AssertCollectionNotEqual_params_comparer() =>
            GetAssertNotEqualParamsComparerAction(ZeroBasedNominalRange, OneBasedNominalRange)
                .Invoke();

        [Fact]
        public void AssertCollectionNotEqual_params_comparer_when_equal_throws() =>
            GetAssertNotEqualParamsComparerAction(ZeroBasedNominalRange, ZeroBasedNominalRange)
                .AssertThrows<NotEqualException>();
    }
}