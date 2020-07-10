using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    using Theoretically;
    using static BindingFlags;

    public abstract class ExtensionMethodTestCasesBase : TestCasesBase
    {
        protected abstract Type ClassType { get; }

        /// <summary>
        /// Very important that this not be Static. That was causing problems conflicting with
        /// other test scenarios accidentally listaning in, as it were, to neighboring unit tests.
        /// </summary>
        private IEnumerable<object[]> _privateCases;

        /// <inheritdoc/>
        protected override IEnumerable<object[]> Cases
        {
            get
            {
                IEnumerable<object[]> GetAll()
                {
                    var type = ClassType;

                    foreach (var method in type.GetMethods(Public | Static))
                    {
                        yield return GetRange<object>(method).ToArray();
                    }
                }

                return _privateCases ?? (_privateCases = GetAll().ToArray());
            }
        }
    }
}
