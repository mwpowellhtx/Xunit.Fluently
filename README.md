## About xUnit.Fluently.net

*xUnit.Fluently.net* provides a suite of extension methods that make it possible to leverage [*xUnit.net*](https://github.com/xunit/xunit) in a Fluent manner.

At its core, the primary pattern we employ is to perform the appropriate test function and return the anchor actual value involved during that invocation, thus making it possible to string together Fluent assertion sentences involving the anchor subject area.

### Project Goals

Our primary goal is to make the *xUnit.net* experience flow in a more Fluent manner. Our goals do not necessarily include whether to provide feature parity with *xUnit.net*. We started with a handful of fairly commonly leveraged patterns, and we aim to consider further coverage as opportunities arise.

### Gaps, Concerns and Pull Requests

If you find this project interesting and useful, yet have some concerns or gaps, we will consider any and all [Pull Requests](https://github.com/mwpowellhtx/xunit.fluently/pulls) addressing those issues based solely on their merits.

Future goals include the following:

- [ ] There is an open *xUnit.net* issue to [add single precision float support](https://github.com/xunit/xunit/issues/1984). For the time being, actually, that is less critical for us in the current iteration paths, however, should that happen, then we can update for those assertions as well.
- [ ] Ditto ``AssertNotEqual``, or derivative ``Assert`` patterns.
- [ ] Consider *xUnit.net* ``ISet``, ``Range``, ``Property``, ``Event`` coverage.

Some recent additions:

- [x] Updated to include floating point comparisons involving [double](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/double) and [decimal](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/decimal) in a handful of different form factors.
- [x] Also, added the ability to *functionally access actual values* for comparison with an *expected* result.

Although we cannot promise exactly when these goals will be pursued, we evaluate such efforts on the basis of permitted time, suggested opportunity, and, necessarily, dictated requirement, and prioritize accordingly.

Again, to reiterate, *Pull Requests* are welcome especially if you would like to see the support happen sooner than later.
