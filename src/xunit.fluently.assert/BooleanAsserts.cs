// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        // ReSharper disable ConditionIsAlwaysTrueOrFalse
        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is True.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.True(bool)"/>
        public static bool AssertTrue(this bool value)
        {
            Assert.True(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is False.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.False(bool)"/>
        public static bool AssertFalse(this bool value)
        {
            Assert.False(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is True.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.True(bool?)"/>
        public static bool? AssertTrue(this bool? value)
        {
            Assert.True(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is False.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.True(bool?)"/>
        public static bool? AssertFalse(this bool? value)
        {
            Assert.False(value);
            return value;
        }
        // ReSharper restore ConditionIsAlwaysTrueOrFalse
    }
}
