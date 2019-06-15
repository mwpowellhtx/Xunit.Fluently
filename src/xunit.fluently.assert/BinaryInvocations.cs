using System;
using System.Collections.Generic;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    // ReSharper disable once CommentTypo
    /// <summary>
    /// Furnishes a set of useful Fluent <see cref="Assert"/> extension methods.
    /// </summary>
    /// <see cref="Assert"/>
    /// <see cref="!:https://github.com/xunit/assert.xunit">Project is organized more or less analogous to the Xunit project.</see>
    public static partial class FluentlyExtensionMethods
    {
        private static T InvokeBinaryWithReturn<T>(Action<T, T> callback, T actual, T expected)
        {
            callback.Invoke(expected, actual);
            return actual;
        }

        private static T InvokeBinaryWithReturn<T, TExpected>(Action<TExpected, T> callback, T actual, TExpected expected)
        {
            callback.Invoke(expected, actual);
            return actual;
        }

        private static T InvokeBinaryWithReturn<T>(Func<T, T, T> callback, T actual, T expected)
            => callback.Invoke(expected, actual);

        private static T InvokeBinaryWithReturn<T>(Action<T, T, IEqualityComparer<T>> callback, T actual, T expected, IEqualityComparer<T> comparer)
        {
            callback.Invoke(expected, actual, comparer);
            return actual;
        }

        // ReSharper disable PossibleMultipleEnumeration
        private static IEnumerable<T> InvokeBinaryWithReturn<T>(Action<IEnumerable<T>, IEnumerable<T>> callback, IEnumerable<T> actual, IEnumerable<T> expected)
        {
            callback.Invoke(expected, actual);
            return actual;
        }

        private static IEnumerable<T> InvokeBinaryWithReturn<T>(Action<IEnumerable<T>, IEnumerable<T>, IEqualityComparer<T>> callback, IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
        {
            callback.Invoke(expected, actual, comparer);
            return actual;
        }

        private static IEnumerable<T> InvokeCollectionWithReturn<T>(Action<T, IEnumerable<T>, IEqualityComparer<T>> callback, IEnumerable<T> collection, T expected, IEqualityComparer<T> comparer)
        {
            callback.Invoke(expected, collection, comparer);
            return collection;
        }

        private static IEnumerable<T> InvokeCollectionWithReturn<T>(Action<IEnumerable<T>, Predicate<T>> callback, IEnumerable<T> collection, Predicate<T> predicate)
        {
            callback.Invoke(collection, predicate);
            return collection;
        }

        private static IEnumerable<T> InvokeCollectionWithReturn<T>(Action<T, IEnumerable<T>> callback, IEnumerable<T> collection, T expected)
        {
            callback.Invoke(expected, collection);
            return collection;
        }
        // ReSharper restore PossibleMultipleEnumeration

        private static string InvokeStringComparison(Action<string, string, StringComparison> callback, string actualString, string expectedSubstring, StringComparison comparison)
        {
            callback.Invoke(expectedSubstring, actualString, comparison);
            return actualString;
        }

        private static string InvokeStringComparison(Action<string, string, bool, bool, bool> callback, string actual, string expected
            , bool ignoreCase = false, bool ignoreLineEndingDifferences = false, bool ignoreWhiteSpaceDifferences = false)
        {
            callback.Invoke(expected, actual, ignoreCase, ignoreLineEndingDifferences, ignoreWhiteSpaceDifferences);
            return actual;
        }
    }
}
