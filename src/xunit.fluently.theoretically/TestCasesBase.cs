using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once IdentifierTypo
namespace Xunit.Theoretically
{
    /// <summary>
    /// Derive from <see cref="TestCasesBase"/> in order to establish
    /// <see cref="ClassDataAttribute"/> based <see cref="TheoryAttribute"/> test cases.
    /// </summary>
    /// <inheritdoc />
    public abstract class TestCasesBase : IClassDataTestCases
    {
        /// <summary>
        /// Override in order to inform the Cases property.
        /// </summary>
        protected abstract IEnumerable<object[]> Cases { get; }

        /// <inheritdoc />
        public IEnumerator<object[]> GetEnumerator() => Cases.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Returns a new range of <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        protected static IEnumerable<T> GetRange<T>(params T[] values)
        {
            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (var value in values)
            {
                yield return value;
            }
        }

        /// <summary>
        /// Splices the <paramref name="values"/> into each of the <paramref name="original"/>
        /// Test Cases.
        /// </summary>
        /// <typeparam name="T">The Type of the Values to be Spliced.</typeparam>
        /// <param name="original">The Original Test Cases into which the Values will be Spliced.</param>
        /// <param name="values">The Values to Splice into the Original Test Cases.</param>
        /// <returns>A new set of Merged Test Cases incorporating the spliced <paramref name="values"/>.</returns>
        protected static IEnumerable<object[]> MergeCases<T>(IEnumerable<object[]> original, params T[] values)
        {
            foreach (var spliced in values.Select(x => GetRange<object>(x).ToArray()))
            {
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var x in original)
                {
                    yield return x.Concat(spliced).ToArray();
                }
            }
            // ReSharper restore LoopCanBeConvertedToQuery
        }
    }
}
