using System;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public class FluentlyExtensionMethodTestCases : ExtensionMethodTestCasesBase
    {
        protected override Type ClassType { get; } = typeof(FluentlyExtensionMethods);
    }
}
