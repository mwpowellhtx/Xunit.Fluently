using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xunit
{
    using Abstractions;
    using Sdk;
    using static WildcardlyStringExtensionMethods;

    public class WildcardlyExtensionMethodTests : TestFixtureBase
    {
        private static Random Rnd { get; } = new Random();

        private static IEnumerable<char> GetIgnoreCharacters()
        {

            for (char x = 'a'; x < 'z'; x++)
            {
                yield return x;
                yield return char.ToUpper(x);
            }

            for (char x = '0'; x < '9'; x++)
            {
                yield return x;
            }
        }

        /// <summary>
        /// Gets the IgnoreCharacters.
        /// </summary>
        private static string IgnoreCharacters { get; } = new string(GetIgnoreCharacters().ToArray());

        public WildcardlyExtensionMethodTests(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        // TODO: TBD: we may want to consider isolating the wildcard extensions in their own class...
        // TODO: TBD: we could also be piece meal forming these from a property source...
        [Theory
            , InlineData("", -1)
            , InlineData("this is a test", -1)
            , InlineData("this is a test*", 14)
            , InlineData("this is a test+", 14)
            , InlineData("this is a test?", 14)
            , InlineData("this is* a test*", 7)
            , InlineData("this is+ a test+", 7)
            , InlineData("this is? a test?", 7)
            , InlineData("*this is* a test*", 0)
            , InlineData("+this is+ a test+", 0)
            , InlineData("?this is? a test?", 0)
            , InlineData("this is\\* a test*", 16)
            , InlineData("this is\\+ a test+", 16)
            , InlineData("this is\\? a test?", 16)
        ]
        public void String_Can_Be_Correctly_Indexed(string given, int expectedIndexOf)
        {
            var wildcards = Wildcards;
            OutputHelper.WriteLine($"given = {given}, wildcards = {wildcards}, expectedIndexOf = {expectedIndexOf}");
            var actualIndexOf = given.NonEscapedIndexOf(wildcards);
            Assert.Equal(expectedIndexOf, actualIndexOf);
        }

        [Theory
            , InlineData("this is a test", "this is a test")
            , InlineData("this is \\\\ a test", "this is \\ a test")
            , InlineData("this is \\? a test", "this is ? a test")
            , InlineData("this is \\+ a test", "this is + a test")
            , InlineData("this is \\* a test", "this is * a test")
            , InlineData("This.Is.A.More.Practical\\+Example", "This.Is.A.More.Practical+Example")
        ]
        public void String_Can_Be_Correctly_Unescaped(string given, string expected)
            => Assert.Equal(expected, given.UnescapeString());

        /// <summary>
        /// This is a very narrow corner case. Really it is the only use case when an exception
        /// might otherwise be expected. Otherwise, whether wildcard is found or not found, we
        /// expect some sort of tuple response.
        /// </summary>
        [Fact]
        public void Null_Wildcard_Pattern_Throws()
        {
            string pattern = null;

            var ex = Assert.Throws<ArgumentException>(() => pattern.TokenizePattern());

            Assert.Equal(nameof(pattern), ex.ParamName);

            var dataEntries = from DictionaryEntry entry in ex.Data select entry;

            Assert.Collection(dataEntries
                , entryDatum =>
                {
                    Assert.Equal(nameof(pattern), entryDatum.Key);
                    Assert.Null(entryDatum.Value);
                }
            );
        }

        /// <summary>
        /// Informs the <see cref="TokenizePatternTestCases"/> values.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<object[]> GetTokenizePatternTestCases()
        {
            const string a = "this is ";
            const string b = "a test";

            yield return GetRange<object>($"{a}{b}", Tuple.Create($"{a}{b}")).ToArray();

            foreach (var wildcard in GetRange(ZeroPlus, OnePlus, ExactlyOne).ToArray())
            {
                yield return GetRange<object>($"{a}{wildcard}{b}", Tuple.Create($"{a}", wildcard)).ToArray();
                yield return GetRange<object>($"{wildcard}{a}", Tuple.Create(wildcard, $"{a}")).ToArray();
                yield return GetRange<object>($"{a}{wildcard}", Tuple.Create($"{a}", wildcard)).ToArray();
                yield return GetRange<object>($"{wildcard}", Tuple.Create(wildcard)).ToArray();
            }
        }

        /// <summary>
        /// Gets the <see cref="Not_Null_Pattern_Yields_ExpectedTokens"/> test cases.
        /// </summary>
        public static IEnumerable<object[]> TokenizePatternTestCases { get; } = GetTokenizePatternTestCases().ToArray();

        /// <summary>
        /// We expect some sort of response whenever <paramref name="pattern"/> is not null.
        /// </summary>
        /// <param name="pattern">The pattern under tokenization consideration.</param>
        /// <param name="expectedTokens">The <see cref="Tuple"/> representing the tokenized response.</param>
        /// <see cref="!:https://xunit.net/faq/theory-data-stability-in-vs"/>
        [Theory
            , MemberData(nameof(TokenizePatternTestCases), DisableDiscoveryEnumeration = true)
        ]
        public void Not_Null_Pattern_Yields_ExpectedTokens(string pattern, object expectedTokens)
        {
            var actualTokens = pattern.TokenizePattern();
            Assert.Equal(expectedTokens, actualTokens);
        }

        /// <summary>
        /// Returns an empty <see cref="string"/>.
        /// </summary>
        /// <returns></returns>
        private static string Empty() => "";

        /// <summary>
        /// Returns a <see cref="string"/> of length <c>1</c> chosen randomly from the
        /// <paramref name="characterSet"/> character set.
        /// </summary>
        /// <param name="characterSet"></param>
        /// <returns></returns>
        private static string Ch(string characterSet) => $"{characterSet[Rnd.Next() % characterSet.Length]}";

        /// <summary>
        /// Returns a <see cref="string"/> of length <c>1</c> chosen randomly from the
        /// <see cref="IgnoreCharacters"/> character set.
        /// </summary>
        /// <returns></returns>
        private static string Ch() => Ch(IgnoreCharacters);

        /// <summary>
        /// 16
        /// </summary>
        /// <remarks>Seems like a nominal number for test purposes.</remarks>
        private const int MaxIgnoreLength = 16;

        /// <summary>
        /// Returns a <see cref="string"/> of <paramref name="maxCount"/> length chosen
        /// at random from the <paramref name="characterSet"/> character set.
        /// </summary>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        private static string Str(int maxCount, string characterSet)
        {
            var result = string.Empty;

            while (maxCount-- > 0)
            {
                result += Ch(characterSet);
            }
            return result;
        }

        /// <summary>
        /// Returns a <see cref="string"/> of <see cref="MaxIgnoreLength"/> length chosen
        /// at random from the <see cref="IgnoreCharacters"/> character set.
        /// </summary>
        /// <returns></returns>
        private static string Str() => Str(MaxIgnoreLength, IgnoreCharacters);

        /// <summary>
        /// Informs the <see cref="AssertLikeNoExceptionsTestCases"/> and
        /// <see cref="AssertNotLikeWithExceptionsTestCases"/> values.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<object[]> GetAssertLikeNoExceptionsTestCases()
        {
            // Does not really matter what content we use for the concrete parts.
            const string s = "this is a test";

            var factories = new Dictionary<char, Func<string>[]>
            {
                { ExactlyOne, GetRange<Func<string>>(Ch).ToArray() },
                { OnePlus, GetRange<Func<string>>(Ch, Str).ToArray() },
                { ZeroPlus, GetRange<Func<string>>(Empty, Ch, Str).ToArray() }
            };

            var manyFacts = factories.SelectMany(x => x.Value.Select(y => new { Wildcard = x.Key, Factory = y })).ToArray();

            // Remember, the parameters ordered: ...(actual, pattern)
            //yield return GetRange<object>(s, s).ToArray();

            foreach (var fact in manyFacts)
            {
                // Wildcard embedded.
                yield return GetRange<object>($"{s}{fact.Factory.Invoke()}{s}", $"{s}{fact.Wildcard}{s}").ToArray();

                // Trailing wildcard.
                yield return GetRange<object>($"{s}{fact.Factory.Invoke()}", $"{s}{fact.Wildcard}").ToArray();

                // Leading wildcard.
                yield return GetRange<object>($"{fact.Factory.Invoke()}{s}", $"{fact.Wildcard}{s}").ToArray();
            }
        }

        /// <summary>
        /// Test cases for the <see cref="Verify_AssertLike_NoExceptions(string, string)"/> tests.
        /// </summary>
        public static IEnumerable<object[]> AssertLikeNoExceptionsTestCases { get; } = GetAssertLikeNoExceptionsTestCases().ToArray();

        /// <summary>
        /// Verifies that <paramref name="actual"/> asserts Like
        /// <paramref name="expectedPattern"/> without exception.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expectedPattern"></param>
        /// <see cref="!:https://xunit.net/faq/theory-data-stability-in-vs"/>
        [Theory
            , MemberData(nameof(AssertLikeNoExceptionsTestCases), DisableDiscoveryEnumeration = true)
        ]
        public void Verify_AssertLike_NoExceptions(string actual, string expectedPattern)
            => Assert.Equal(actual, actual.AssertLike(expectedPattern));

        /// <summary>
        /// Test cases for the <see cref="Verify_AssertNotLike_WithExceptions(string, string)"/>
        /// tests.
        /// </summary>
        public static IEnumerable<object[]> AssertNotLikeWithExceptionsTestCases => AssertLikeNoExceptionsTestCases;

        /// <summary>
        /// Verifies that <paramref name="actual"/> asserts Not Like
        /// <paramref name="unexpectedPattern"/> with exception.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="unexpectedPattern"></param>
        [Theory
            , MemberData(nameof(AssertNotLikeWithExceptionsTestCases), DisableDiscoveryEnumeration = true)
        ]
        public void Verify_AssertNotLike_WithExceptions(string actual, string unexpectedPattern)
        {
            var ex = Assert.Throws<NotLikeException>(() => actual.AssertNotLike(unexpectedPattern));
            Assert.Equal(actual, ex.Actual);
            // The xUnit Sdk decorates the expected string...
            Assert.Equal($"Not {unexpectedPattern}", ex.Expected);
        }

        /// <summary>
        /// Informs the <see cref="AssertNotLikeNoExceptionsTestCases"/> and
        /// <see cref="AssertLikeWithExceptionsTestCases"/> values.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<object[]> GetAssertLikeWithExceptionsTestCases()
        {
            // Does not really matter what content we use for the concrete parts.
            const string s = "this is a test";

            /// These are some factories that should yield exceptions.
            var factories = new Dictionary<char, Func<string>[]>
            {
                { ExactlyOne, GetRange<Func<string>>(Empty, Str).ToArray() },
                { OnePlus, GetRange<Func<string>>(Empty).ToArray() }
            };

            var manyFacts = factories.SelectMany(x => x.Value.Select(y => new { Wildcard = x.Key, Factory = y })).ToArray();

            // Remember, the parameters ordered: ...(actual, pattern)
            yield return GetRange<object>(s, s.Replace("is a", "is not a")).ToArray();

            foreach (var fact in manyFacts)
            {
                // Wildcard embedded.
                yield return GetRange<object>($"{s}{fact.Factory.Invoke()}{s}", $"{s}{fact.Wildcard}{s}").ToArray();

                // Trailing wildcard.
                yield return GetRange<object>($"{s}{fact.Factory.Invoke()}", $"{s}{fact.Wildcard}").ToArray();

                // Leading wildcard.
                yield return GetRange<object>($"{fact.Factory.Invoke()}{s}", $"{fact.Wildcard}{s}").ToArray();
            }
        }

        /// <summary>
        /// Test cases for the <see cref="Verify_AssertLike_WithExceptions(string, string)"/>
        /// tests.
        /// </summary>
        public static IEnumerable<object[]> AssertLikeWithExceptionsTestCases { get; } = GetAssertLikeWithExceptionsTestCases().ToArray();

        /// <summary>
        /// Verifies that <paramref name="actual"/> asserts Like
        /// <paramref name="expectedPattern"/> with exception.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expectedPattern"></param>
        [Theory
            , MemberData(nameof(AssertLikeWithExceptionsTestCases), DisableDiscoveryEnumeration = true)
        ]
        public void Verify_AssertLike_WithExceptions(string actual, string expectedPattern)
        {
            var ex = Assert.Throws<LikeException>(() => Assert.Equal(actual, actual.AssertLike(expectedPattern)));
            Assert.Equal(actual, ex.Actual);
            Assert.Equal(expectedPattern, ex.Expected);
        }

        /// <summary>
        /// Test cases for the <see cref="Verify_AssertNotLike_NoExceptions(string, string)"/>
        /// tests.
        /// </summary>
        public static IEnumerable<object[]> AssertNotLikeNoExceptionsTestCases => AssertLikeWithExceptionsTestCases;

        /// <summary>
        /// Verifies that <paramref name="actual"/> asserts Not Like
        /// <paramref name="unexpectedPattern"/> without exception.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="unexpectedPattern"></param>
        [Theory
            , MemberData(nameof(AssertNotLikeNoExceptionsTestCases), DisableDiscoveryEnumeration = true)
        ]
        public void Verify_AssertNotLike_NoExceptions(string actual, string unexpectedPattern)
            => Assert.Equal(actual, actual.AssertNotLike(unexpectedPattern));

        /// <summary>
        /// Returns the test cases informing the <see cref="EscapeWildcardActualTestCases"/>.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<object[]> GetEscapeWildcardActualTestCases()
        {
            // In so many words...
            var casesMultimap = new Dictionary<char, Func<char, string>[]>
            {
                { ZeroPlus, GetRange<Func<char, string>>(
                        x => ""
                        , x => $"{x}"
                        , x => $"trailing{x}"
                        , x => $"{x}leading"
                        , x => $"embe{x}ded"
                    ).ToArray() },
                { OnePlus, GetRange<Func<char, string>>(
                        x => $"{x}"
                        , x => $"trailing{x}"
                        , x => $"{x}leading"
                        , x => $"embe{x}ded"
                    ).ToArray() },
                { ExactlyOne, GetRange<Func<char, string>>(
                        x => $"{x}"
                        , x => $"a"
                    ).ToArray() },
            };

            var mappedFactories = casesMultimap.SelectMany(mapped => mapped.Value.Select(
                fact => new { Wildcard = mapped.Key, Factory = fact })).ToArray();

            const string a = "this is a test";

            Func<char, string> getThisIsATest = x => $"this is {x} a test".EscapeWildcardActual();

            foreach (var mappedFact in mappedFactories)
            {
                var wildcard = mappedFact.Wildcard;

                // Yielding concrete literals with and without escaped sequences, not only in the wildcard fly over substrings.
                yield return GetRange<object>($"{a}{mappedFact.Factory(wildcard)}{a}", $"{a}{wildcard}{a}").ToArray();

                foreach (var x in Wildcards)
                {
                    var b = getThisIsATest.Invoke(x);
                    yield return GetRange<object>($"{b}{mappedFact.Factory(wildcard)}{b}", $"{b}{wildcard}{b}").ToArray();
                }
            }
        }

        /// <summary>
        /// Informs the data for <see cref="EscapeWildcardActual_Is_Correct(string, string)"/>.
        /// </summary>
        public static IEnumerable<object[]> EscapeWildcardActualTestCases { get; } = GetEscapeWildcardActualTestCases().ToArray();

        /// <summary>
        /// EscapeWildcardActual is verified correctly.
        /// </summary>
        [Theory
            , MemberData(nameof(EscapeWildcardActualTestCases), DisableDiscoveryEnumeration = true)
        ]
        public void EscapeWildcardActual_Is_Correct(string actual, string expectedPattern)
            => actual.AssertLike(expectedPattern);
    }
}
