// ReSharper disable once IdentifierTypo
namespace Xunit
{
    // ReSharper disable CommentTypo
    /// <summary>
    /// Furnishes a set of useful Fluent <see cref="Assert"/> extension methods. The essence
    /// of the pattern is captured by the Binary and Unary Invocations. Perform the Callback
    /// involving the Anchor Actual value as well as the Expected, when involved, and return
    /// the Anchor Value in the appropriate form. There are several different Binary and Unary
    /// Invocation shapes represented, but these should all be transparent to the caller.
    /// </summary>
    /// <remarks>The goal of the project is not to achieve feature parity with Xunit, although
    /// there can be gaps in which we would want to provide coverage. We think that chief among
    /// these gaps includes such comparisons as Floating Point <see cref="double"/>,
    /// <see cref="float"/>, or <see cref="decimal"/>, for instance. We do want to provide
    /// these sooner than later as time permits, opportunity suggests, or requirement dictates.
    /// Pull Requests are always welcome, of course.</remarks>
    /// <see cref="Assert"/>
    /// <see cref="!:https://github.com/xunit/assert.xunit">Project is organized more or less
    /// analogous to the Xunit project.</see>
    public static partial class FluentlyExtensionMethods
    {
        // TODO: TBD: there are a handful of bits I do not have any concerns over at the moment...
        // TODO: TBD: if that ever changes, I will reconsider adding Fluent extension methods for them...
        // TODO: TBD: PR's always welcome, of course...
        // TODO: TBD: https://github.com/xunit/assert.xunit/blob/db11c08977f1ecf9b868317073d4255560547c45/SetAsserts.cs
        // TODO: TBD: https://github.com/xunit/assert.xunit/blob/db11c08977f1ecf9b868317073d4255560547c45/RangeAsserts.cs
        // TODO: TBD: https://github.com/xunit/assert.xunit/blob/db11c08977f1ecf9b868317073d4255560547c45/PropertyAsserts.cs
        // TODO: TBD: https://github.com/xunit/assert.xunit/blob/db11c08977f1ecf9b868317073d4255560547c45/EventAsserts.cs
    }
}
