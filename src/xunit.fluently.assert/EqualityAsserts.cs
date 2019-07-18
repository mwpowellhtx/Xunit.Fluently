using System;
using System.Collections.Generic;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        // TODO: TBD: there is no `float´ version of the Precision-oriented floating point Equal Assertion?
        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/> given
        /// <paramref name="precision"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="precision">The Precision for use during the Floating Point comparison.</param>
        /// <returns></returns>
        /// <see cref="Assert.Equal(double,double,int)"/>
        public static double AssertEqual(this double actual, double expected, int precision)
            => InvokeBinaryWithReturn<double>((e, a) => Assert.Equal(e, a, precision), actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/> given
        /// <paramref name="precision"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="precision">The Precision for use during the Floating Point comparison.</param>
        /// <returns></returns>
        /// <see cref="Assert.Equal(decimal,decimal,int)"/>
        public static decimal AssertEqual(this decimal actual, decimal expected, int precision)
            => InvokeBinaryWithReturn<decimal>((e, a) => Assert.Equal(e, a, precision), actual, expected);

        // ReSharper disable RedundantTypeArgumentsOfMethod
        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(T,T)"/>
        public static T AssertEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.Equal, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(T,T,IEqualityComparer{T})"/>
        public static T AssertEqual<T>(this T actual, T expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.Equal, actual, expected, comparer);

        /// <summary>
        /// Verifies that the <typeparamref name="TExpected"/> thing behind the
        /// <paramref name="actual"/> Equals <paramref name="expected"/> given the
        /// <paramref name="getter"/> accessor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TExpected"></typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="getter">A functional Getter helper.</param>
        /// <returns></returns>
        public static T AssertEqual<T, TExpected>(this T actual, TExpected expected, Func<T, TExpected> getter)
            => InvokeExpectedWithReturn(Assert.Equal, actual, expected, getter);

        /// <summary>
        /// Verifies that the <see cref="double"/> thing behind the <paramref name="actual"/>
        /// Does Not Equal <paramref name="expected"/> given the <paramref name="getter"/>
        /// accessor and <paramref name="precision"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="precision">The Precision for use during the Floating Point comparison.</param>
        /// <param name="getter">A functional Getter helper.</param>
        /// <returns></returns>
        public static T AssertEqual<T>(this T actual, double expected, int precision, Func<T, double> getter)
            => InvokeExpectedWithReturn((e, a) => Assert.Equal(e, a, precision), actual, expected, getter);

        /// <summary>
        /// Verifies that the <see cref="decimal"/> thing behind the <paramref name="actual"/>
        /// Does Not Equal <paramref name="expected"/> given the <paramref name="getter"/>
        /// accessor and <paramref name="precision"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="precision">The Precision for use during the Floating Point comparison.</param>
        /// <param name="getter">A functional Getter helper.</param>
        /// <returns></returns>
        public static T AssertEqual<T>(this T actual, decimal expected, int precision, Func<T, decimal> getter)
            => InvokeExpectedWithReturn((e, a) => Assert.Equal(e, a, precision), actual, expected, getter);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equals <paramref name="expected"/>
        /// taking into consideration <paramref name="precision"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="precision">The Precision for use during the Floating Point comparison.</param>
        /// <returns></returns>
        public static double AssertNotEqual(this double actual, double expected, int precision)
            => InvokeBinaryWithReturn<double>((e, a) => Assert.NotEqual(e, a, precision), actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equals <paramref name="expected"/>
        /// taking into consideration <paramref name="precision"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="precision">The Precision for use during the Floating Point comparison.</param>
        /// <returns></returns>
        public static decimal AssertNotEqual(this decimal actual, decimal expected, int precision)
            => InvokeBinaryWithReturn<decimal>((e, a) => Assert.NotEqual(e, a, precision), actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(T,T)"/>
        public static T AssertNotEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.NotEqual, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(T,T,IEqualityComparer{T})"/>
        public static T AssertNotEqual<T>(this T actual, T expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.NotEqual, actual, expected, comparer);

        /// <summary>
        /// Verifies that the <typeparamref name="TExpected"/> thing behind the
        /// <paramref name="actual"/> Does Not Equal <paramref name="expected"/> given the
        /// <paramref name="getter"/> accessor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TExpected"></typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="getter">A functional Getter helper.</param>
        /// <returns></returns>
        public static T AssertNotEqual<T, TExpected>(this T actual, TExpected expected, Func<T, TExpected> getter)
            => InvokeExpectedWithReturn(Assert.NotEqual, actual, expected, getter);

        /// <summary>
        /// Verifies that the <see cref="double"/> thing behind the <paramref name="actual"/>
        /// Does Not Equal <paramref name="expected"/> given the <paramref name="getter"/>
        /// accessor and <paramref name="precision"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="getter">A functional Getter helper.</param>
        /// <returns></returns>
        public static T AssertNotEqual<T>(this T actual, double expected, int precision, Func<T, double> getter)
            => InvokeExpectedWithReturn((e, a) => Assert.NotEqual(e, a, precision), actual, expected, getter);

        /// <summary>
        /// Verifies that the <see cref="decimal"/> thing behind the <paramref name="actual"/>
        /// Does Not Equal <paramref name="expected"/> given the <paramref name="getter"/>
        /// accessor and <paramref name="precision"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="precision">The floating point precision.</param>
        /// <param name="getter">A functional Getter helper.</param>
        /// <returns></returns>
        public static T AssertNotEqual<T>(this T actual, decimal expected, int precision, Func<T, decimal> getter)
            => InvokeExpectedWithReturn((e, a) => Assert.NotEqual(e, a, precision), actual, expected, getter);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> AssertEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            => InvokeBinaryWithReturn<T>(Assert.Equal, actual, expected);

        // ReSharper disable PossibleMultipleEnumeration
        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T},IEqualityComparer{T})"/>
        public static IEnumerable<T> AssertEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.Equal, actual, expected, comparer);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> AssertNotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            => InvokeBinaryWithReturn<T>(Assert.NotEqual, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T},IEnumerable{T},IEqualityComparer{T})"/>
        public static IEnumerable<T> AssertNotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.NotEqual, actual, expected, comparer);
        // ReSharper restore PossibleMultipleEnumeration

        /// <summary>
        /// Verifies that <paramref name="actual"/> is Strictly Equal with
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        public static T AssertStrictEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.StrictEqual, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> is Strictly Not Equal with
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        public static T AssertNotStrictEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.NotStrictEqual, actual, expected);
        // ReSharper restore RedundantTypeArgumentsOfMethod
    }
}
