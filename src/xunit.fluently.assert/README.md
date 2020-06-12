## Xunit.Fluently.Assert

We will document interesting points about each project in their respective project folders from now on.

### Added `AssertLike` and `AssertNotLike`

CSharp itself does not support a `Like` operator in the same way that Visual Basic or Structured Query Language (SQL) do. Also, unfortunately, we cannot utilize the [Visual Basic](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.compilerservices.likeoperator) `dotnet` assemblies aligned with the `netstandard` target because the Like operator is not implemented there, either.

So we found ourselves implementing a custom Assertion called `AssertLike` and `AssertNotLike`, for instance:

```C#
const string some = "some fantastic pattern";
const string another = "another obscure pattern";
const string pattern = "some * pattern";
// ...
some.AssertLike(pattern);
// or...
another.AssertNotLike(pattern);
```

With support for wildcard characters in ascending precendence, or strength, if you will.

| Wildcard | Description |
| -------- | ----------- |
| * | Zero or more characters expected. This is the weakest of them all. |
| + | One or more characters expected. Similar to Zero or more, but with the stipulation of at least one. |
| ? | Exactly one character expected. This is the strongest wildcard of them all before at most one character is allowed. |

Possible future directions for this feature is to reduce one or more discovered wildcards according to their precedence.
