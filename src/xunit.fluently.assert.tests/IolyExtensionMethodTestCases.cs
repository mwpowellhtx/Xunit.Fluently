using System;

// ReSharper disable IdentifierTypo
namespace Xunit
{
    public class IolyExtensionMethodTestCases : ExtensionMethodTestCasesBase
    {
        protected override Type ClassType { get; } = typeof(IolyExtensionMethods);
    }
}
// ReSharper restore IdentifierTypo
