
#region Assembly xunit.assert, Version=2.4.1.0, Culture=neutral, PublicKeyToken=8d05b1bb7a6fdb6c
// G:\Source\Spikes\Xunit.Fluently\Prototype\src\packages\xunit.assert\2.4.1\lib\netstandard1.1\xunit.assert.dll
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Xunit
{
    //
    // Summary:
    //     Contains various static methods that are used to verify that conditions are met
    //     during the process of running tests.
    public class Assert
    {
        //
        // Summary:
        //     Initializes a new instance of the Xunit.Assert class.
        protected Assert();

        //
        // Summary:
        //     Verifies that all items in the collection pass when executed against action.
        //
        // Parameters:
        //   collection:
        //     The collection
        //
        //   action:
        //     The action to test each item against
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.AllException:
        //     Thrown when the collection contains at least one non-matching element
        public static void All<T>(IEnumerable<T> collection, Action<T> action);
        //
        // Summary:
        //     Verifies that a collection contains exactly a given number of elements, which
        //     meet the criteria provided by the element inspectors.
        //
        // Parameters:
        //   collection:
        //     The collection to be inspected
        //
        //   elementInspectors:
        //     The element inspectors, which inspect each element in turn. The total number
        //     of element inspectors must exactly match the number of elements in the collection.
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        public static void Collection<T>(IEnumerable<T> collection, params Action<T>[] elementInspectors);
        //
        // Summary:
        //     Verifies that a dictionary contains a given key.
        //
        // Parameters:
        //   expected:
        //     The object expected to be in the collection.
        //
        //   collection:
        //     The collection to be inspected.
        //
        // Type parameters:
        //   TKey:
        //     The type of the keys of the object to be verified.
        //
        //   TValue:
        //     The type of the values of the object to be verified.
        //
        // Returns:
        //     The value associated with expected.
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the object is not present in the collection
        public static TValue Contains<TKey, TValue>(TKey expected, IReadOnlyDictionary<TKey, TValue> collection);
        //
        // Summary:
        //     Verifies that a string contains a given sub-string, using the current culture.
        //
        // Parameters:
        //   expectedSubstring:
        //     The sub-string expected to be in the string
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the sub-string is not present inside the string
        public static void Contains(string expectedSubstring, string actualString);
        //
        // Summary:
        //     Verifies that a collection contains a given object.
        //
        // Parameters:
        //   collection:
        //     The collection to be inspected
        //
        //   filter:
        //     The filter used to find the item you're ensuring the collection contains
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the object is not present in the collection
        public static void Contains<T>(IEnumerable<T> collection, Predicate<T> filter);
        //
        // Summary:
        //     Verifies that a collection contains a given object, using an equality comparer.
        //
        // Parameters:
        //   expected:
        //     The object expected to be in the collection
        //
        //   collection:
        //     The collection to be inspected
        //
        //   comparer:
        //     The comparer used to equate objects in the collection with the expected object
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the object is not present in the collection
        public static void Contains<T>(T expected, IEnumerable<T> collection, IEqualityComparer<T> comparer);
        //
        // Summary:
        //     Verifies that a collection contains a given object.
        //
        // Parameters:
        //   expected:
        //     The object expected to be in the collection
        //
        //   collection:
        //     The collection to be inspected
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the object is not present in the collection
        public static void Contains<T>(T expected, IEnumerable<T> collection);
        //
        // Summary:
        //     Verifies that a string contains a given sub-string, using the given comparison
        //     type.
        //
        // Parameters:
        //   expectedSubstring:
        //     The sub-string expected to be in the string
        //
        //   actualString:
        //     The string to be inspected
        //
        //   comparisonType:
        //     The type of string comparison to perform
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the sub-string is not present inside the string
        public static void Contains(string expectedSubstring, string actualString, StringComparison comparisonType);
        //
        // Summary:
        //     Verifies that a dictionary contains a given key.
        //
        // Parameters:
        //   expected:
        //     The object expected to be in the collection.
        //
        //   collection:
        //     The collection to be inspected.
        //
        // Type parameters:
        //   TKey:
        //     The type of the keys of the object to be verified.
        //
        //   TValue:
        //     The type of the values of the object to be verified.
        //
        // Returns:
        //     The value associated with expected.
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the object is not present in the collection
        public static TValue Contains<TKey, TValue>(TKey expected, IDictionary<TKey, TValue> collection);
        //
        // Summary:
        //     Verifies that a collection does not contain a given object.
        //
        // Parameters:
        //   collection:
        //     The collection to be inspected
        //
        //   filter:
        //     The filter used to find the item you're ensuring the collection does not contain
        //
        // Type parameters:
        //   T:
        //     The type of the object to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotContainException:
        //     Thrown when the object is present inside the container
        public static void DoesNotContain<T>(IEnumerable<T> collection, Predicate<T> filter);
        //
        // Summary:
        //     Verifies that a dictionary does not contain a given key.
        //
        // Parameters:
        //   expected:
        //     The object expected to be in the collection.
        //
        //   collection:
        //     The collection to be inspected.
        //
        // Type parameters:
        //   TKey:
        //     The type of the keys of the object to be verified.
        //
        //   TValue:
        //     The type of the values of the object to be verified.
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotContainException:
        //     Thrown when the object is present in the collection
        public static void DoesNotContain<TKey, TValue>(TKey expected, IReadOnlyDictionary<TKey, TValue> collection);
        //
        // Summary:
        //     Verifies that a dictionary does not contain a given key.
        //
        // Parameters:
        //   expected:
        //     The object expected to be in the collection.
        //
        //   collection:
        //     The collection to be inspected.
        //
        // Type parameters:
        //   TKey:
        //     The type of the keys of the object to be verified.
        //
        //   TValue:
        //     The type of the values of the object to be verified.
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotContainException:
        //     Thrown when the object is present in the collection
        public static void DoesNotContain<TKey, TValue>(TKey expected, IDictionary<TKey, TValue> collection);
        //
        // Summary:
        //     Verifies that a string does not contain a given sub-string, using the current
        //     culture.
        //
        // Parameters:
        //   expectedSubstring:
        //     The sub-string which is expected not to be in the string
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotContainException:
        //     Thrown when the sub-string is present inside the string
        public static void DoesNotContain(string expectedSubstring, string actualString);
        //
        // Summary:
        //     Verifies that a string does not contain a given sub-string, using the current
        //     culture.
        //
        // Parameters:
        //   expectedSubstring:
        //     The sub-string which is expected not to be in the string
        //
        //   actualString:
        //     The string to be inspected
        //
        //   comparisonType:
        //     The type of string comparison to perform
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotContainException:
        //     Thrown when the sub-string is present inside the given string
        public static void DoesNotContain(string expectedSubstring, string actualString, StringComparison comparisonType);
        //
        // Summary:
        //     Verifies that a collection does not contain a given object, using an equality
        //     comparer.
        //
        // Parameters:
        //   expected:
        //     The object that is expected not to be in the collection
        //
        //   collection:
        //     The collection to be inspected
        //
        //   comparer:
        //     The comparer used to equate objects in the collection with the expected object
        //
        // Type parameters:
        //   T:
        //     The type of the object to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotContainException:
        //     Thrown when the object is present inside the container
        public static void DoesNotContain<T>(T expected, IEnumerable<T> collection, IEqualityComparer<T> comparer);
        //
        // Summary:
        //     Verifies that a collection does not contain a given object.
        //
        // Parameters:
        //   expected:
        //     The object that is expected not to be in the collection
        //
        //   collection:
        //     The collection to be inspected
        //
        // Type parameters:
        //   T:
        //     The type of the object to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotContainException:
        //     Thrown when the object is present inside the container
        public static void DoesNotContain<T>(T expected, IEnumerable<T> collection);
        //
        // Summary:
        //     Verifies that a string does not match a regular expression.
        //
        // Parameters:
        //   expectedRegexPattern:
        //     The regex pattern expected not to match
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotMatchException:
        //     Thrown when the string matches the regex pattern
        public static void DoesNotMatch(string expectedRegexPattern, string actualString);
        //
        // Summary:
        //     Verifies that a string does not match a regular expression.
        //
        // Parameters:
        //   expectedRegex:
        //     The regex expected not to match
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.DoesNotMatchException:
        //     Thrown when the string matches the regex
        public static void DoesNotMatch(Regex expectedRegex, string actualString);
        //
        // Summary:
        //     Verifies that a collection is empty.
        //
        // Parameters:
        //   collection:
        //     The collection to be inspected
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when the collection is null
        //
        //   T:Xunit.Sdk.EmptyException:
        //     Thrown when the collection is not empty
        public static void Empty(IEnumerable collection);
        //
        // Summary:
        //     Verifies that a string ends with a given string, using the given comparison type.
        //
        // Parameters:
        //   expectedEndString:
        //     The string expected to be at the end of the string
        //
        //   actualString:
        //     The string to be inspected
        //
        //   comparisonType:
        //     The type of string comparison to perform
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the string does not end with the expected string
        public static void EndsWith(string expectedEndString, string actualString, StringComparison comparisonType);
        //
        // Summary:
        //     Verifies that a string ends with a given string, using the current culture.
        //
        // Parameters:
        //   expectedEndString:
        //     The string expected to be at the end of the string
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the string does not end with the expected string
        public static void EndsWith(string expectedEndString, string actualString);
        //
        // Summary:
        //     Verifies that two objects are equal, using a default comparer.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the objects are not equal
        public static void Equal<T>(T expected, T actual);
        //
        // Summary:
        //     Verifies that two System.Double values are equal, within the number of decimal
        //     places given by precision. The values are rounded before comparison.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        //   precision:
        //     The number of decimal places (valid values: 0-15)
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the values are not equal
        public static void Equal(double expected, double actual, int precision);
        //
        // Summary:
        //     Verifies that two objects are equal, using a custom equatable comparer.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        //   comparer:
        //     The comparer used to compare the two objects
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the objects are not equal
        public static void Equal<T>(T expected, T actual, IEqualityComparer<T> comparer);
        //
        // Summary:
        //     Verifies that two System.Decimal values are equal, within the number of decimal
        //     places given by precision. The values are rounded before comparison.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        //   precision:
        //     The number of decimal places (valid values: 0-28)
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the values are not equal
        public static void Equal(decimal expected, decimal actual, int precision);
        //
        // Summary:
        //     Verifies that two System.DateTime values are equal, within the precision given
        //     by precision.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        //   precision:
        //     The allowed difference in time where the two dates are considered equal
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the values are not equal
        public static void Equal(DateTime expected, DateTime actual, TimeSpan precision);
        //
        // Summary:
        //     Verifies that two sequences are equivalent, using a custom equatable comparer.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        //   comparer:
        //     The comparer used to compare the two objects
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the objects are not equal
        public static void Equal<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer);
        //
        // Summary:
        //     Verifies that two sequences are equivalent, using a default comparer.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the objects are not equal
        public static void Equal<T>(IEnumerable<T> expected, IEnumerable<T> actual);
        //
        // Summary:
        //     Verifies that two strings are equivalent.
        //
        // Parameters:
        //   expected:
        //     The expected string value.
        //
        //   actual:
        //     The actual string value.
        //
        //   ignoreCase:
        //     If set to true, ignores cases differences. The invariant culture is used.
        //
        //   ignoreLineEndingDifferences:
        //     If set to true, treats \r\n, \r, and \n as equivalent.
        //
        //   ignoreWhiteSpaceDifferences:
        //     If set to true, treats spaces and tabs (in any non-zero quantity) as equivalent.
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the strings are not equivalent.
        public static void Equal(string expected, string actual, bool ignoreCase = false, bool ignoreLineEndingDifferences = false, bool ignoreWhiteSpaceDifferences = false);
        //
        // Summary:
        //     Verifies that two strings are equivalent.
        //
        // Parameters:
        //   expected:
        //     The expected string value.
        //
        //   actual:
        //     The actual string value.
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the strings are not equivalent.
        public static void Equal(string expected, string actual);
        //
        // Summary:
        //     Do not call this method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This is an override of Object.Equals(). Call Assert.Equal() instead.", true)]
        public static bool Equals(object a, object b);
        //
        // Summary:
        //     Verifies that the condition is false.
        //
        // Parameters:
        //   condition:
        //     The condition to be tested
        //
        //   userMessage:
        //     The message to show when the condition is not false
        //
        // Exceptions:
        //   T:Xunit.Sdk.FalseException:
        //     Thrown if the condition is not false
        public static void False(bool? condition, string userMessage);
        //
        // Summary:
        //     Verifies that the condition is false.
        //
        // Parameters:
        //   condition:
        //     The condition to be tested
        //
        //   userMessage:
        //     The message to show when the condition is not false
        //
        // Exceptions:
        //   T:Xunit.Sdk.FalseException:
        //     Thrown if the condition is not false
        public static void False(bool condition, string userMessage);
        //
        // Summary:
        //     Verifies that the condition is false.
        //
        // Parameters:
        //   condition:
        //     The condition to be tested
        //
        // Exceptions:
        //   T:Xunit.Sdk.FalseException:
        //     Thrown if the condition is not false
        public static void False(bool? condition);
        //
        // Summary:
        //     Verifies that the condition is false.
        //
        // Parameters:
        //   condition:
        //     The condition to be tested
        //
        // Exceptions:
        //   T:Xunit.Sdk.FalseException:
        //     Thrown if the condition is not false
        public static void False(bool condition);
        //
        // Summary:
        //     Verifies that a value is within a given range.
        //
        // Parameters:
        //   actual:
        //     The actual value to be evaluated
        //
        //   low:
        //     The (inclusive) low value of the range
        //
        //   high:
        //     The (inclusive) high value of the range
        //
        // Type parameters:
        //   T:
        //     The type of the value to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.InRangeException:
        //     Thrown when the value is not in the given range
        public static void InRange<T>(T actual, T low, T high) where T : IComparable;
        //
        // Summary:
        //     Verifies that a value is within a given range, using a comparer.
        //
        // Parameters:
        //   actual:
        //     The actual value to be evaluated
        //
        //   low:
        //     The (inclusive) low value of the range
        //
        //   high:
        //     The (inclusive) high value of the range
        //
        //   comparer:
        //     The comparer used to evaluate the value's range
        //
        // Type parameters:
        //   T:
        //     The type of the value to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.InRangeException:
        //     Thrown when the value is not in the given range
        public static void InRange<T>(T actual, T low, T high, IComparer<T> comparer);
        //
        // Summary:
        //     Verifies that an object is of the given type or a derived type.
        //
        // Parameters:
        //   object:
        //     The object to be evaluated
        //
        // Type parameters:
        //   T:
        //     The type the object should be
        //
        // Returns:
        //     The object, casted to type T when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.IsAssignableFromException:
        //     Thrown when the object is not the given type
        public static T IsAssignableFrom<T>(object @object);
        //
        // Summary:
        //     Verifies that an object is of the given type or a derived type.
        //
        // Parameters:
        //   expectedType:
        //     The type the object should be
        //
        //   object:
        //     The object to be evaluated
        //
        // Exceptions:
        //   T:Xunit.Sdk.IsAssignableFromException:
        //     Thrown when the object is not the given type
        public static void IsAssignableFrom(Type expectedType, object @object);
        //
        // Summary:
        //     Verifies that an object is not exactly the given type.
        //
        // Parameters:
        //   expectedType:
        //     The type the object should not be
        //
        //   object:
        //     The object to be evaluated
        //
        // Exceptions:
        //   T:Xunit.Sdk.IsNotTypeException:
        //     Thrown when the object is the given type
        public static void IsNotType(Type expectedType, object @object);
        //
        // Summary:
        //     Verifies that an object is not exactly the given type.
        //
        // Parameters:
        //   object:
        //     The object to be evaluated
        //
        // Type parameters:
        //   T:
        //     The type the object should not be
        //
        // Exceptions:
        //   T:Xunit.Sdk.IsNotTypeException:
        //     Thrown when the object is the given type
        public static void IsNotType<T>(object @object);
        //
        // Summary:
        //     Verifies that an object is exactly the given type (and not a derived type).
        //
        // Parameters:
        //   object:
        //     The object to be evaluated
        //
        // Type parameters:
        //   T:
        //     The type the object should be
        //
        // Returns:
        //     The object, casted to type T when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.IsTypeException:
        //     Thrown when the object is not the given type
        public static T IsType<T>(object @object);
        //
        // Summary:
        //     Verifies that an object is exactly the given type (and not a derived type).
        //
        // Parameters:
        //   expectedType:
        //     The type the object should be
        //
        //   object:
        //     The object to be evaluated
        //
        // Exceptions:
        //   T:Xunit.Sdk.IsTypeException:
        //     Thrown when the object is not the given type
        public static void IsType(Type expectedType, object @object);
        //
        // Summary:
        //     Verifies that a string matches a regular expression.
        //
        // Parameters:
        //   expectedRegexPattern:
        //     The regex pattern expected to match
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.MatchesException:
        //     Thrown when the string does not match the regex pattern
        public static void Matches(string expectedRegexPattern, string actualString);
        //
        // Summary:
        //     Verifies that a string matches a regular expression.
        //
        // Parameters:
        //   expectedRegex:
        //     The regex expected to match
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.MatchesException:
        //     Thrown when the string does not match the regex
        public static void Matches(Regex expectedRegex, string actualString);
        //
        // Summary:
        //     Verifies that a collection is not empty.
        //
        // Parameters:
        //   collection:
        //     The collection to be inspected
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when a null collection is passed
        //
        //   T:Xunit.Sdk.NotEmptyException:
        //     Thrown when the collection is empty
        public static void NotEmpty(IEnumerable collection);
        //
        // Summary:
        //     Verifies that two objects are not equal, using a default comparer.
        //
        // Parameters:
        //   expected:
        //     The expected object
        //
        //   actual:
        //     The actual object
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotEqualException:
        //     Thrown when the objects are equal
        public static void NotEqual<T>(T expected, T actual);
        //
        // Summary:
        //     Verifies that two System.Decimal values are not equal, within the number of decimal
        //     places given by precision.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        //   precision:
        //     The number of decimal places (valid values: 0-28)
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the values are equal
        public static void NotEqual(decimal expected, decimal actual, int precision);
        //
        // Summary:
        //     Verifies that two System.Double values are not equal, within the number of decimal
        //     places given by precision.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        //   precision:
        //     The number of decimal places (valid values: 0-15)
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the values are equal
        public static void NotEqual(double expected, double actual, int precision);
        //
        // Summary:
        //     Verifies that two objects are not equal, using a custom equality comparer.
        //
        // Parameters:
        //   expected:
        //     The expected object
        //
        //   actual:
        //     The actual object
        //
        //   comparer:
        //     The comparer used to examine the objects
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotEqualException:
        //     Thrown when the objects are equal
        public static void NotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer);
        //
        // Summary:
        //     Verifies that two sequences are not equivalent, using a default comparer.
        //
        // Parameters:
        //   expected:
        //     The expected object
        //
        //   actual:
        //     The actual object
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotEqualException:
        //     Thrown when the objects are equal
        public static void NotEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual);
        //
        // Summary:
        //     Verifies that two sequences are not equivalent, using a custom equality comparer.
        //
        // Parameters:
        //   expected:
        //     The expected object
        //
        //   actual:
        //     The actual object
        //
        //   comparer:
        //     The comparer used to compare the two objects
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotEqualException:
        //     Thrown when the objects are equal
        public static void NotEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer);
        //
        // Summary:
        //     Verifies that a value is not within a given range, using a comparer.
        //
        // Parameters:
        //   actual:
        //     The actual value to be evaluated
        //
        //   low:
        //     The (inclusive) low value of the range
        //
        //   high:
        //     The (inclusive) high value of the range
        //
        //   comparer:
        //     The comparer used to evaluate the value's range
        //
        // Type parameters:
        //   T:
        //     The type of the value to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotInRangeException:
        //     Thrown when the value is in the given range
        public static void NotInRange<T>(T actual, T low, T high, IComparer<T> comparer);
        //
        // Summary:
        //     Verifies that a value is not within a given range, using the default comparer.
        //
        // Parameters:
        //   actual:
        //     The actual value to be evaluated
        //
        //   low:
        //     The (inclusive) low value of the range
        //
        //   high:
        //     The (inclusive) high value of the range
        //
        // Type parameters:
        //   T:
        //     The type of the value to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotInRangeException:
        //     Thrown when the value is in the given range
        public static void NotInRange<T>(T actual, T low, T high) where T : IComparable;
        //
        // Summary:
        //     Verifies that an object reference is not null.
        //
        // Parameters:
        //   object:
        //     The object to be validated
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotNullException:
        //     Thrown when the object is not null
        public static void NotNull(object @object);
        //
        // Summary:
        //     Verifies that two objects are not the same instance.
        //
        // Parameters:
        //   expected:
        //     The expected object instance
        //
        //   actual:
        //     The actual object instance
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotSameException:
        //     Thrown when the objects are the same instance
        public static void NotSame(object expected, object actual);
        //
        // Summary:
        //     Verifies that two objects are strictly not equal, using the type's default comparer.
        //
        // Parameters:
        //   expected:
        //     The expected object
        //
        //   actual:
        //     The actual object
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.NotEqualException:
        //     Thrown when the objects are equal
        public static void NotStrictEqual<T>(T expected, T actual);
        //
        // Summary:
        //     Verifies that an object reference is null.
        //
        // Parameters:
        //   object:
        //     The object to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.NullException:
        //     Thrown when the object reference is not null
        public static void Null(object @object);
        //
        // Summary:
        //     Verifies that a set is a proper subset of another set.
        //
        // Parameters:
        //   expectedSuperset:
        //     The expected superset
        //
        //   actual:
        //     The set expected to be a proper subset
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the actual set is not a proper subset of the expected set
        public static void ProperSubset<T>(ISet<T> expectedSuperset, ISet<T> actual);
        //
        // Summary:
        //     Verifies that a set is a proper superset of another set.
        //
        // Parameters:
        //   expectedSubset:
        //     The expected subset
        //
        //   actual:
        //     The set expected to be a proper superset
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the actual set is not a proper superset of the expected set
        public static void ProperSuperset<T>(ISet<T> expectedSubset, ISet<T> actual);
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("You must call Assert.PropertyChangedAsync (and await the result) when testing async code.", true)]
        public static void PropertyChanged(INotifyPropertyChanged @object, string propertyName, Func<Task> testCode);
        //
        // Summary:
        //     Verifies that the provided object raised System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        //     as a result of executing the given test code.
        //
        // Parameters:
        //   object:
        //     The object which should raise the notification
        //
        //   propertyName:
        //     The property name for which the notification should be raised
        //
        //   testCode:
        //     The test code which should cause the notification to be raised
        //
        // Exceptions:
        //   T:Xunit.Sdk.PropertyChangedException:
        //     Thrown when the notification is not raised
        public static void PropertyChanged(INotifyPropertyChanged @object, string propertyName, Action testCode);
        //
        // Summary:
        //     Verifies that the provided object raised System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        //     as a result of executing the given test code.
        //
        // Parameters:
        //   object:
        //     The object which should raise the notification
        //
        //   propertyName:
        //     The property name for which the notification should be raised
        //
        //   testCode:
        //     The test code which should cause the notification to be raised
        //
        // Exceptions:
        //   T:Xunit.Sdk.PropertyChangedException:
        //     Thrown when the notification is not raised
        [AsyncStateMachine(typeof(<PropertyChangedAsync>d__76))]
        public static Task PropertyChangedAsync(INotifyPropertyChanged @object, string propertyName, Func<Task> testCode);
        //
        // Summary:
        //     Verifies that a event with the exact event args is raised.
        //
        // Parameters:
        //   attach:
        //     Code to attach the event handler
        //
        //   detach:
        //     Code to detach the event handler
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the event arguments to expect
        //
        // Returns:
        //     The event sender and arguments wrapped in an object
        //
        // Exceptions:
        //   T:Xunit.Sdk.RaisesException:
        //     Thrown when the expected event was not raised.
        public static RaisedEvent<T> Raises<T>(Action<EventHandler<T>> attach, Action<EventHandler<T>> detach, Action testCode) where T : EventArgs;
        //
        // Summary:
        //     Verifies that an event with the exact or a derived event args is raised.
        //
        // Parameters:
        //   attach:
        //     Code to attach the event handler
        //
        //   detach:
        //     Code to detach the event handler
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the event arguments to expect
        //
        // Returns:
        //     The event sender and arguments wrapped in an object
        //
        // Exceptions:
        //   T:Xunit.Sdk.RaisesException:
        //     Thrown when the expected event was not raised.
        public static RaisedEvent<T> RaisesAny<T>(Action<EventHandler<T>> attach, Action<EventHandler<T>> detach, Action testCode) where T : EventArgs;
        //
        // Summary:
        //     Verifies that an event with the exact or a derived event args is raised.
        //
        // Parameters:
        //   attach:
        //     Code to attach the event handler
        //
        //   detach:
        //     Code to detach the event handler
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the event arguments to expect
        //
        // Returns:
        //     The event sender and arguments wrapped in an object
        //
        // Exceptions:
        //   T:Xunit.Sdk.RaisesException:
        //     Thrown when the expected event was not raised.
        [AsyncStateMachine(typeof(Assert.<RaisesAnyAsync>d__49<>))]
        public static Task<RaisedEvent<T>> RaisesAnyAsync<T>(Action<EventHandler<T>> attach, Action<EventHandler<T>> detach, Func<Task> testCode) where T : EventArgs;
        //
        // Summary:
        //     Verifies that a event with the exact event args (and not a derived type) is raised.
        //
        // Parameters:
        //   attach:
        //     Code to attach the event handler
        //
        //   detach:
        //     Code to detach the event handler
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the event arguments to expect
        //
        // Returns:
        //     The event sender and arguments wrapped in an object
        //
        // Exceptions:
        //   T:Xunit.Sdk.RaisesException:
        //     Thrown when the expected event was not raised.
        [AsyncStateMachine(typeof(Assert.<RaisesAsync>d__48<>))]
        public static Task<RaisedEvent<T>> RaisesAsync<T>(Action<EventHandler<T>> attach, Action<EventHandler<T>> detach, Func<Task> testCode) where T : EventArgs;
        //
        // Summary:
        //     Do not call this method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This is an override of Object.ReferenceEquals(). Call Assert.Same() instead.", true)]
        public static bool ReferenceEquals(object a, object b);
        //
        // Summary:
        //     Verifies that two objects are the same instance.
        //
        // Parameters:
        //   expected:
        //     The expected object instance
        //
        //   actual:
        //     The actual object instance
        //
        // Exceptions:
        //   T:Xunit.Sdk.SameException:
        //     Thrown when the objects are not the same instance
        public static void Same(object expected, object actual);
        //
        // Summary:
        //     Verifies that the given collection contains only a single element of the given
        //     type.
        //
        // Parameters:
        //   collection:
        //     The collection.
        //
        // Type parameters:
        //   T:
        //     The collection type.
        //
        // Returns:
        //     The single item in the collection.
        //
        // Exceptions:
        //   T:Xunit.Sdk.SingleException:
        //     Thrown when the collection does not contain exactly one element.
        public static T Single<T>(IEnumerable<T> collection);
        //
        // Summary:
        //     Verifies that the given collection contains only a single element of the given
        //     type.
        //
        // Parameters:
        //   collection:
        //     The collection.
        //
        // Returns:
        //     The single item in the collection.
        //
        // Exceptions:
        //   T:Xunit.Sdk.SingleException:
        //     Thrown when the collection does not contain exactly one element.
        public static object Single(IEnumerable collection);
        //
        // Summary:
        //     Verifies that the given collection contains only a single element of the given
        //     type which matches the given predicate. The collection may or may not contain
        //     other values which do not match the given predicate.
        //
        // Parameters:
        //   collection:
        //     The collection.
        //
        //   predicate:
        //     The item matching predicate.
        //
        // Type parameters:
        //   T:
        //     The collection type.
        //
        // Returns:
        //     The single item in the filtered collection.
        //
        // Exceptions:
        //   T:Xunit.Sdk.SingleException:
        //     Thrown when the filtered collection does not contain exactly one element.
        public static T Single<T>(IEnumerable<T> collection, Predicate<T> predicate);
        //
        // Summary:
        //     Verifies that the given collection contains only a single element of the given
        //     value. The collection may or may not contain other values.
        //
        // Parameters:
        //   collection:
        //     The collection.
        //
        //   expected:
        //     The value to find in the collection.
        //
        // Returns:
        //     The single item in the collection.
        //
        // Exceptions:
        //   T:Xunit.Sdk.SingleException:
        //     Thrown when the collection does not contain exactly one element.
        public static void Single(IEnumerable collection, object expected);
        //
        // Summary:
        //     Verifies that a string starts with a given string, using the current culture.
        //
        // Parameters:
        //   expectedStartString:
        //     The string expected to be at the start of the string
        //
        //   actualString:
        //     The string to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the string does not start with the expected string
        public static void StartsWith(string expectedStartString, string actualString);
        //
        // Summary:
        //     Verifies that a string starts with a given string, using the given comparison
        //     type.
        //
        // Parameters:
        //   expectedStartString:
        //     The string expected to be at the start of the string
        //
        //   actualString:
        //     The string to be inspected
        //
        //   comparisonType:
        //     The type of string comparison to perform
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the string does not start with the expected string
        public static void StartsWith(string expectedStartString, string actualString, StringComparison comparisonType);
        //
        // Summary:
        //     Verifies that two objects are strictly equal, using the type's default comparer.
        //
        // Parameters:
        //   expected:
        //     The expected value
        //
        //   actual:
        //     The value to be compared against
        //
        // Type parameters:
        //   T:
        //     The type of the objects to be compared
        //
        // Exceptions:
        //   T:Xunit.Sdk.EqualException:
        //     Thrown when the objects are not equal
        public static void StrictEqual<T>(T expected, T actual);
        //
        // Summary:
        //     Verifies that a set is a subset of another set.
        //
        // Parameters:
        //   expectedSuperset:
        //     The expected superset
        //
        //   actual:
        //     The set expected to be a subset
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the actual set is not a subset of the expected set
        public static void Subset<T>(ISet<T> expectedSuperset, ISet<T> actual);
        //
        // Summary:
        //     Verifies that a set is a superset of another set.
        //
        // Parameters:
        //   expectedSubset:
        //     The expected subset
        //
        //   actual:
        //     The set expected to be a superset
        //
        // Type parameters:
        //   T:
        //     The type of the object to be verified
        //
        // Exceptions:
        //   T:Xunit.Sdk.ContainsException:
        //     Thrown when the actual set is not a superset of the expected set
        public static void Superset<T>(ISet<T> expectedSubset, ISet<T> actual);
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("You must call Assert.ThrowsAsync<T> (and await the result) when testing async code.", true)]
        public static T Throws<T>(Func<Task> testCode) where T : Exception;
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type).
        //     Generally used to test property accessors.
        //
        // Parameters:
        //   exceptionType:
        //     The type of the exception expected to be thrown
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static Exception Throws(Type exceptionType, Func<object> testCode);
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type).
        //     Generally used to test property accessors.
        //
        // Parameters:
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the exception expected to be thrown
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static T Throws<T>(Func<object> testCode) where T : Exception;
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("You must call Assert.ThrowsAsync<T> (and await the result) when testing async code.", true)]
        public static T Throws<T>(string paramName, Func<Task> testCode) where T : ArgumentException;
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type),
        //     where the exception derives from System.ArgumentException and has the given parameter
        //     name.
        //
        // Parameters:
        //   paramName:
        //     The parameter name that is expected to be in the exception
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static T Throws<T>(string paramName, Func<object> testCode) where T : ArgumentException;
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type),
        //     where the exception derives from System.ArgumentException and has the given parameter
        //     name.
        //
        // Parameters:
        //   paramName:
        //     The parameter name that is expected to be in the exception
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static T Throws<T>(string paramName, Action testCode) where T : ArgumentException;
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type).
        //
        // Parameters:
        //   exceptionType:
        //     The type of the exception expected to be thrown
        //
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static Exception Throws(Type exceptionType, Action testCode);
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type).
        //
        // Parameters:
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the exception expected to be thrown
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static T Throws<T>(Action testCode) where T : Exception;
        //
        // Summary:
        //     Verifies that the exact exception or a derived exception type is thrown.
        //
        // Parameters:
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the exception expected to be thrown
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static T ThrowsAny<T>(Action testCode) where T : Exception;
        //
        // Summary:
        //     Verifies that the exact exception or a derived exception type is thrown. Generally
        //     used to test property accessors.
        //
        // Parameters:
        //   testCode:
        //     A delegate to the code to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the exception expected to be thrown
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        public static T ThrowsAny<T>(Func<object> testCode) where T : Exception;
        //
        // Summary:
        //     Verifies that the exact exception or a derived exception type is thrown.
        //
        // Parameters:
        //   testCode:
        //     A delegate to the task to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the exception expected to be thrown
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        [AsyncStateMachine(typeof(Assert.<ThrowsAnyAsync>d__59<>))]
        public static Task<T> ThrowsAnyAsync<T>(Func<Task> testCode) where T : Exception;
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type),
        //     where the exception derives from System.ArgumentException and has the given parameter
        //     name.
        //
        // Parameters:
        //   paramName:
        //     The parameter name that is expected to be in the exception
        //
        //   testCode:
        //     A delegate to the task to be tested
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        [AsyncStateMachine(typeof(Assert.<ThrowsAsync>d__68<>))]
        public static Task<T> ThrowsAsync<T>(string paramName, Func<Task> testCode) where T : ArgumentException;
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type).
        //
        // Parameters:
        //   testCode:
        //     A delegate to the task to be tested
        //
        // Type parameters:
        //   T:
        //     The type of the exception expected to be thrown
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        [AsyncStateMachine(typeof(Assert.<ThrowsAsync>d__56<>))]
        public static Task<T> ThrowsAsync<T>(Func<Task> testCode) where T : Exception;
        //
        // Summary:
        //     Verifies that the exact exception is thrown (and not a derived exception type).
        //
        // Parameters:
        //   exceptionType:
        //     The type of the exception expected to be thrown
        //
        //   testCode:
        //     A delegate to the task to be tested
        //
        // Returns:
        //     The exception that was thrown, when successful
        //
        // Exceptions:
        //   T:Xunit.Sdk.ThrowsException:
        //     Thrown when an exception was not thrown, or when an exception of the incorrect
        //     type is thrown
        [AsyncStateMachine(typeof(<ThrowsAsync>d__62))]
        public static Task<Exception> ThrowsAsync(Type exceptionType, Func<Task> testCode);
        //
        // Summary:
        //     Verifies that an expression is true.
        //
        // Parameters:
        //   condition:
        //     The condition to be inspected
        //
        //   userMessage:
        //     The message to be shown when the condition is false
        //
        // Exceptions:
        //   T:Xunit.Sdk.TrueException:
        //     Thrown when the condition is false
        public static void True(bool condition, string userMessage);
        //
        // Summary:
        //     Verifies that an expression is true.
        //
        // Parameters:
        //   condition:
        //     The condition to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.TrueException:
        //     Thrown when the condition is false
        public static void True(bool? condition);
        //
        // Summary:
        //     Verifies that an expression is true.
        //
        // Parameters:
        //   condition:
        //     The condition to be inspected
        //
        // Exceptions:
        //   T:Xunit.Sdk.TrueException:
        //     Thrown when the condition is false
        public static void True(bool condition);
        //
        // Summary:
        //     Verifies that an expression is true.
        //
        // Parameters:
        //   condition:
        //     The condition to be inspected
        //
        //   userMessage:
        //     The message to be shown when the condition is false
        //
        // Exceptions:
        //   T:Xunit.Sdk.TrueException:
        //     Thrown when the condition is false
        public static void True(bool? condition, string userMessage);
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("You must call Record.ExceptionAsync (and await the result) when testing async code.", true)]
        protected static Exception RecordException(Func<Task> testCode);
        //
        // Summary:
        //     Records any exception which is thrown by the given code.
        //
        // Parameters:
        //   testCode:
        //     The code which may thrown an exception.
        //
        // Returns:
        //     Returns the exception that was thrown by the code; null, otherwise.
        protected static Exception RecordException(Action testCode);
        //
        // Summary:
        //     Records any exception which is thrown by the given code that has a return value.
        //     Generally used for testing property accessors.
        //
        // Parameters:
        //   testCode:
        //     The code which may thrown an exception.
        //
        // Returns:
        //     Returns the exception that was thrown by the code; null, otherwise.
        protected static Exception RecordException(Func<object> testCode);
        //
        // Summary:
        //     Records any exception which is thrown by the given task.
        //
        // Parameters:
        //   testCode:
        //     The task which may thrown an exception.
        //
        // Returns:
        //     Returns the exception that was thrown by the code; null, otherwise.
        [AsyncStateMachine(typeof(<RecordExceptionAsync>d__84))]
        protected static Task<Exception> RecordExceptionAsync(Func<Task> testCode);

        //
        // Summary:
        //     Represents a raised event after the fact.
        //
        // Type parameters:
        //   T:
        //     The type of the event arguments.
        public class RaisedEvent<T> where T : EventArgs
        {
            //
            // Summary:
            //     Creates a new instance of the Xunit.Assert.RaisedEvent`1 class.
            //
            // Parameters:
            //   sender:
            //     The sender of the event.
            //
            //   args:
            //     The event arguments
            public RaisedEvent(object sender, T args);

            //
            // Summary:
            //     The sender of the event.
            public object Sender { get; }
            //
            // Summary:
            //     The event arguments.
            public T Arguments { get; }
        }
    }
}

