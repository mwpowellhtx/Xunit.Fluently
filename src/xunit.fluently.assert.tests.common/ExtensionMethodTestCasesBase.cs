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

        private static IEnumerable<object[]> _privateCases;

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
