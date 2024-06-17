using System.Collections.Generic;
using System.Linq;

// ReSharper disable once IdentifierTypo
namespace Xunit.Theoretically
{
    /// <summary>
    /// Does not provide any actual Test Case elements except to demonstrate how this can actually
    /// be done in a typical usage scenario.
    /// </summary>
    /// <inheritdoc />
    public class SampleTestCases : TestCasesBase
    {
        /// <summary>
        /// We like backing Test Cases with a static field as we find this helps to improve
        /// overall performance. However, we urge you to evaluate the efficacy of backing
        /// with a static field on a case by case basis.
        /// </summary>
        private static IEnumerable<object[]> _privateCases;

        /// <inheritdoc />
        protected override IEnumerable<object[]> Cases
        {
            get
            {
                static IEnumerable<object[]> GetAll()
                {
                    /* This is where you may generate your test cases. Your actual Test Case source
                     * does not need to be a local function, however, we find that this approach lends
                     * itself to Test Case generation rather effectively. */

                    yield break;
                }

                return _privateCases ??= GetAll().ToArray();
            }
        }
    }
}