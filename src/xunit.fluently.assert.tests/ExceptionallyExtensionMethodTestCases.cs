using System;

// ReSharper disable IdentifierTypo
namespace Xunit
{
    public class ExceptionallyExtensionMethodTestCases : ExtensionMethodTestCasesBase
    {
        protected override Type ClassType { get; } = typeof(ExceptionallyExtensionMethods);
    }
}
// ReSharper restore IdentifierTypo
