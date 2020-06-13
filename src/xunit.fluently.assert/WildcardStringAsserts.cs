using System;
using System.Linq;

namespace Xunit
{
    using Sdk;

    /// <summary>
    /// We support Asserting <see cref="string"/> Like operation through this simple vernier of
    /// extension methods. If we require anything more in depth, metrics, analysis, etc, then we
    /// may consirer a more in depth object model, but for now, we think this is perfectly well
    /// suited to the task at hand.
    /// </summary>
    public static partial class WildcardlyStringExtensionMethods
    {
        // TODO: TBD: for now not supporting crazy patterns like "**" or "++" ...
        // TODO: TBD: eventually, perhaps, these should just get reduced I think...
        // TODO: TBD: and minding the escape sequences...

        /// <summary>
        /// &apos;\&apos;
        /// </summary>
        internal const char EscapeDelim = '\\';

        /// <summary>
        /// &apos;*&apos;
        /// </summary>
        internal const char ZeroPlus = '*';

        /// <summary>
        /// &apos;+&apos;
        /// </summary>
        internal const char OnePlus = '+';

        /// <summary>
        /// &apos;?&apos;
        /// </summary>
        internal const char ExactlyOne = '?';

        /// <summary>
        /// The Wildcard characters.
        /// </summary>
        /// <see cref="ZeroPlus"/>
        /// <see cref="OnePlus"/>
        /// <see cref="ExactlyOne"/>
        internal static string Wildcards { get; } = $"{ExactlyOne}{OnePlus}{ZeroPlus}";

        /// <summary>
        /// Returns the next Non Escaped occurrance of <paramref name="value"/> found within
        /// <paramref name="pattern"/>.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="value"></param>
        /// <returns>The zero-based index position of the next non escaped
        /// <paramref name="value"/> found in the <paramref name="pattern"/>, or <c>-1</c> if
        /// it is not.</returns>
        internal static int NonEscapedIndexOf(this string pattern, string value)
        {
            int i;
            var startIndex = 0;

            var values = (from char x in value select x).ToArray();

            for (i = pattern.IndexOfAny(values, startIndex)
                ; i > 0 && pattern[i - 1] == EscapeDelim
                ; startIndex = i + 1, i = pattern.IndexOfAny(values, startIndex))
            {
                // Essentially a no-op loop body, we just want to navigate the indices.
            }

            return i;
        }

        // TODO: TBD: should probably work a couple of escaped sequences into the unit tests...
        /// <summary>
        /// Returns the unescaped string <paramref name="s"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks>We will need to do this when evaluating whether the concrete actual,
        /// unescaped phrase matches the corresponding phrase from the escaped pattern.</remarks>
        internal static string UnescapeString(this string s)
        {
            char? sequence = null;

            var result = s.ToCharArray().Aggregate(string.Empty, (g, x) =>
            {
                if (x == EscapeDelim && !sequence.HasValue)
                {
                    sequence = x;
                }
                else
                {
                    sequence = null;
                    g += x;
                }

                return g;
            });

            return result;
        }

        /// <summary>
        /// Tokenizes the <paramref name="pattern"/> one or two tokens at a time as long as they
        /// are available. When pattern can be tokenized will return either
        /// <see cref="Tuple{T1}"/> or <see cref="Tuple{T1, T2}"/> and in some variation
        /// involving <see cref="char"/> and <see cref="string"/> depending on the position of
        /// the <see cref="Wildcards"/>. Reports the Concrete string field in its unescaped form.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        internal static object TokenizePattern(this string pattern)
        {
            Tuple<T1> CreateSingle<T1>(T1 item1) => Tuple.Create(item1);

            Tuple<T1, T2> CreatePair<T1, T2>(T1 item1, T2 item2) => Tuple.Create(item1, item2);

            if (pattern != null)
            {
                var i = pattern.NonEscapedIndexOf(Wildcards);

                if (i < 0)
                {
                    return CreateSingle(pattern);
                }
                else if (i > 0)
                {
                    return CreatePair(pattern.Substring(0, i), pattern[i]);
                }
                else
                {
                    // We need to look forward a little bit to rule out any follow on wildcards.
                    var remaining = pattern.Substring(1);
                    var j = remaining.NonEscapedIndexOf(Wildcards);

                    if (remaining.Length > 0 && j < 0)
                    {
                        return CreatePair(pattern[0], remaining);
                    }
                    else if (remaining.Length > 0 && j > 0)
                    {
                        // We will not worry about collapsing wildcards at the moment...
                        return CreatePair(pattern[0], remaining.Substring(0, j));
                    }
                    else
                    {
                        return CreateSingle(pattern[0]);
                    }
                }
            }

            /* I'm not sure why we would ever land here? Maybe if pattern were null? Because the
             * cases really do revolve around, wildcards exist or they do not. There is no other
             * case as long as we have a string to tokenize. But to keep the return expectations
             * satisfied, we do this. */

            throw new ArgumentException($"Unexpected pattern cannot be tokenized", nameof(pattern))
            {
                Data = { { nameof(pattern), pattern } }
            };
        }

        /// <summary>
        /// Asserts that the <paramref name="actual"/> <see cref="string"/> is Like the
        /// <paramref name="expectedPattern"/>.
        /// <para>Like is analogous to the Visual Basic <c>Like</c> or Structured Query Language
        /// (SQL) <c>LIKE</c> operators, and we support three such wildcards, in order of
        /// precedence, that is, strength:
        ///     <list type="number">
        ///         <listheader>
        ///             <term>Wildcard</term>
        ///             <description>Description</description>
        ///         </listheader>
        ///         <item>
        ///             <term>*</term>
        ///             <description>Zero or more characters expected. This is the weakest
        ///             wildcard of them all.</description>
        ///         </item>
        ///         <item>
        ///             <term>+</term>
        ///             <description>One or more characters expected. Similar to Zero or more,
        ///             but with the stipulation of at least one.</description>
        ///         </item>
        ///         <item>
        ///             <term>?</term>
        ///             <description>Exactly one character expected. This is the strongest because
        ///             there must be exactly one character.</description>
        ///         </item>
        ///     </list>
        /// </para>
        /// </summary>
        /// <param name="actual">The actual <see cref="string"/> under consideration.</param>
        /// <param name="expectedPattern">The expectedPattern which is expected to match.</param>
        /// <returns></returns>
        public static string AssertLike(this string actual, string expectedPattern)
        {
            // Thrown when the wildcards reject the actual string for any reason.
            EqualException ThrowLikeException(int expectedIndex, int actualIndex) => new LikeException(
                expectedPattern, actual, expectedIndex, actualIndex
            );

            int i, j;
            int[] deltas;

            // Make sure that the indices align properly with actual and expected bits.
            for (i = 0, j = 0; i < actual.Length && j < expectedPattern.Length; i += deltas[0], j += deltas[1])
            {
                int k;

                char wildcard;
                string actualConcrete;
                string expectedConcrete;

                // Minding the indices...
                var tokens = expectedPattern.Substring(j).TokenizePattern();

                // We could use a switch statement, but that is slower, and this is perhaps a bit more effective.
                if (tokens is Tuple<string> concreteToken)
                {
                    expectedConcrete = concreteToken.Item1;
                    // Minding the indices, and throughout...
                    actualConcrete = actual.Substring(i);
                    if (actualConcrete.UnescapeString().IndexOf(expectedConcrete.UnescapeString()) != 0)
                    {
                        throw ThrowLikeException(j, i);
                    }
                    deltas = new int[] { actualConcrete.Length, expectedConcrete.Length };
                    continue;
                }

                if (tokens is Tuple<string, char> concreteWildcardTokens)
                {
                    expectedConcrete = concreteWildcardTokens.Item1;
                    actualConcrete = actual.Substring(i);
                    if (actualConcrete.UnescapeString().IndexOf(expectedConcrete.UnescapeString()) != 0)
                    {
                        throw ThrowLikeException(j, i);
                    }
                    // Remember we are positioned to consider a concrete, adjust accordingly.
                    deltas = new int[] { expectedConcrete.Length, expectedConcrete.Length };
                    continue;
                }

                if (tokens is Tuple<char> wildcardToken)
                {
                    wildcard = wildcardToken.Item1;
                    actualConcrete = actual.Substring(i);
                    if ((wildcard == ExactlyOne && actualConcrete.UnescapeString().Length != 1)
                        || (wildcard == OnePlus && actualConcrete.UnescapeString().Length == 0))
                    {
                        throw ThrowLikeException(j, i);
                    }
                    deltas = new int[] { actualConcrete.Length, 1 };
                    continue;
                }

                if (tokens is Tuple<char, string> wildcardConcreteTokens)
                {
                    wildcard = wildcardConcreteTokens.Item1;
                    expectedConcrete = wildcardConcreteTokens.Item2;
                    actualConcrete = actual.Substring(i);
                    k = actualConcrete.UnescapeString().IndexOf(expectedConcrete.UnescapeString());
                    if ((wildcard == ExactlyOne && k != 1) || (wildcard == OnePlus && k == 0) || k < 0)
                    {
                        throw ThrowLikeException(j, i);
                    }
                    deltas = new int[] { actualConcrete.IndexOf(expectedConcrete), 1 };
                    continue;
                }

                throw ThrowLikeException(i, j);
            }

            // Actual and pattern both exhausted, pattern satisfied, including for empty zero plus wildcard.
            if (actual.Length == i && (
                expectedPattern.Length == j
                    || (expectedPattern.Length == j + 1 && expectedPattern[j] == ZeroPlus)
            ))
            {
                return actual;
            }

            // TODO: TBD: started sketching in this one, but we think it to be extraneous, would be handled naturally during the context of the loop.
            ////We may not need this "corner case", i.e. we would still be consuming space in either string.
            //if (actual.Length > i && expectedPattern.Length > j && new[] { OnePlus }.Contains(expectedPattern[j]))
            //{
            //}

            // One or the other not satisfied, throw the exception.
            throw ThrowLikeException(j, i);
        }

        /// <summary>
        /// Analogous to <see cref="AssertLike(string, string)"/>, but rather Not Like.
        /// </summary>
        /// <param name="actual">The actual <see cref="string"/> under consideration.</param>
        /// <param name="unexpectedPattern">The unexpectedPattern which is expected not to match.</param>
        /// <returns></returns>
        /// <see cref="AssertLike(string, string)"/>
        public static string AssertNotLike(this string actual, string unexpectedPattern)
        {
            Exception actualEx = null;

            try
            {
                actual.AssertLike(unexpectedPattern);
            }
            catch (LikeException lex)
            {
                // The string was "not" Like the pattern, which is what we expected.
                actualEx = lex;
            }

            NotLikeException ThrowNotLikeException() => throw new NotLikeException(unexpectedPattern, actual);

            return actualEx != null ? actual : throw ThrowNotLikeException();
        }

        /// <summary>
        /// Utility provided enabling the caller to Escape an <paramref name="actual"/>
        /// <see cref="string"/> concerning its wildcard likeness.
        /// </summary>
        /// <param name="actual"></param>
        /// <returns></returns>
        /// <see cref="AssertLike(string, string)"/>
        /// <see cref="AssertNotLike(string, string)"/>
        public static string EscapeWildcardActual(this string actual)
            => (from char wildcard in Wildcards select wildcard).Aggregate(actual
                , (g, wildcard) => g.Replace($"{wildcard}", $"\\{wildcard}")
            );
    }
}
