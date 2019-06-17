// ReSharper disable once IdentifierTypo

using System;

namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is True.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.True(bool)"/>
        public static bool AssertTrue(this bool value)
            => InvokeUnaryWithReturn(Assert.True, value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is False.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.False(bool)"/>
        public static bool AssertFalse(this bool value)
            => InvokeUnaryWithReturn(Assert.False, value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is True.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.True(bool?)"/>
        public static bool? AssertTrue(this bool? value)
            => InvokeUnaryWithReturn(Assert.True, value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> Condition is False.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.True(bool?)"/>
        public static bool? AssertFalse(this bool? value)
            => InvokeUnaryWithReturn(Assert.False, value);

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="callback"/> condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// <see cref="Assert.True(bool)"/>
        public static T AssertTrue<T>(this T actual, Func<T, bool> callback)
            => InvokeUnaryWithReturn(Assert.True, actual, callback.Invoke);

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="callback"/> condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// <see cref="Assert.True(bool?)"/>
        public static T AssertTrue<T>(this T actual, Func<T, bool?> callback)
            => InvokeUnaryWithReturn(Assert.True, actual, callback.Invoke);

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="callback"/> condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// <see cref="Assert.False(bool)"/>
        public static T AssertFalse<T>(this T actual, Func<T, bool> callback)
            => InvokeUnaryWithReturn(Assert.False, actual, callback.Invoke);

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="callback"/> condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// <see cref="Assert.False(bool?)"/>
        public static T AssertFalse<T>(this T actual, Func<T, bool?> callback)
            => InvokeUnaryWithReturn(Assert.False, actual, callback.Invoke);
    }
}
