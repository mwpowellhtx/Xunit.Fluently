using System;
using System.Collections.Generic;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        private static object InvokeBinaryWithReturn(Action<object, object> callback
            , object actual, object expected)
        {
            callback.Invoke(expected, actual);
            return actual;
        }

        private static T InvokeBinaryWithReturn<T>(Action<T, T> callback, T actual, T expected)
        {
            callback.Invoke(expected, actual);
            return actual;
        }

        private static TActual InvokeBinaryWithReturn<TActual, TExpected>(Action<TExpected, TActual> callback
            , TActual actual, TExpected expected)
        {
            callback.Invoke(expected, actual);
            return actual;
        }

        private static T InvokeBinaryWithReturn<T>(Func<T, T, T> callback, T actual, T expected)
            => callback.Invoke(expected, actual);

        private static T InvokeBinaryWithReturn<T>(Action<T, T, IEqualityComparer<T>> callback
            , T actual, T expected, IEqualityComparer<T> comparer)
        {
            callback.Invoke(expected, actual, comparer);
            return actual;
        }

        private static T InvokeExpectedWithReturn<T, TExpected>(Action<TExpected, TExpected> callback
            , T actual, TExpected expected, Func<T, TExpected> getter)
        {
            callback.Invoke(expected, getter(actual));
            return actual;
        }

        // ReSharper disable PossibleMultipleEnumeration
        private static IEnumerable<T> InvokeBinaryWithReturn<T>(Action<IEnumerable<T>, IEnumerable<T>> callback
            , IEnumerable<T> actual, IEnumerable<T> expected)
        {
            callback.Invoke(expected, actual);
            return actual;
        }

        private static IEnumerable<T> InvokeBinaryWithReturn<T>(Action<IEnumerable<T>, IEnumerable<T>, IEqualityComparer<T>> callback
            , IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
        {
            callback.Invoke(expected, actual, comparer);
            return actual;
        }

        private static IEnumerable<T> InvokeCollectionWithReturn<T>(Action<T, IEnumerable<T>, IEqualityComparer<T>> callback
            , IEnumerable<T> collection, T expected, IEqualityComparer<T> comparer)
        {
            callback.Invoke(expected, collection, comparer);
            return collection;
        }

        private static IEnumerable<T> InvokeCollectionWithReturn<T>(Action<IEnumerable<T>, Predicate<T>> callback
            , IEnumerable<T> collection, Predicate<T> predicate)
        {
            callback.Invoke(collection, predicate);
            return collection;
        }

        private static IEnumerable<T> InvokeCollectionWithReturn<T>(Action<T, IEnumerable<T>> callback
            , IEnumerable<T> collection, T expected)
        {
            callback.Invoke(expected, collection);
            return collection;
        }
        // ReSharper restore PossibleMultipleEnumeration

        /// <summary>
        /// A bare <see cref="string"/> Invocation.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="actualString"></param>
        /// <param name="expectedSubstring"></param>
        /// <returns><paramref name="actualString"/> following successful <paramref name="callback"/>.</returns>
        private static string InvokeStringComparison(Action<string, string> callback
            , string actualString, string expectedSubstring)
        {
            callback.Invoke(expectedSubstring, actualString);
            return actualString;
        }

        /// <summary>
        /// A <see cref="string"/> Invocation involving a <paramref name="comparison"/>.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="actualString"></param>
        /// <param name="expectedSubstring"></param>
        /// <param name="comparison"></param>
        /// <returns><paramref name="actualString"/> following successful <paramref name="callback"/>.</returns>
        private static string InvokeStringComparison(Action<string, string, StringComparison> callback
            , string actualString, string expectedSubstring, StringComparison comparison)
        {
            callback.Invoke(expectedSubstring, actualString, comparison);
            return actualString;
        }

        /// <summary>
        /// <see cref="string"/> Invocation including additional comparison flags.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="ignoreLineEndingDifferences"></param>
        /// <param name="ignoreWhiteSpaceDifferences"></param>
        /// <returns><paramref name="actual"/> following successful <paramref name="callback"/>.</returns>
        private static string InvokeStringComparison(Action<string, string, bool, bool, bool> callback
            , string actual, string expected, bool ignoreCase = false
            , bool ignoreLineEndingDifferences = false
            , bool ignoreWhiteSpaceDifferences = false)
        {
            callback.Invoke(expected, actual, ignoreCase, ignoreLineEndingDifferences, ignoreWhiteSpaceDifferences);
            return actual;
        }
    }
}
