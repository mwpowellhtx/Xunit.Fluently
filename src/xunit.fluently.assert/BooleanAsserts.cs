// ReSharper disable once IdentifierTypo

using System;

#if XUNIT_NULLABLE
using System.Diagnostics.CodeAnalysis;
#endif

// Truly is pretty awful when the Xml comments cannot discern #if PP syms.
namespace Xunit
{
    using Sdk;

    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>true</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="TrueException">Thrown when the condition is <c>false</c>.</exception>
        /// <see cref="Assert.True(bool)"/>
#if XUNIT_NULLABLE
        public static bool AssertTrue([DoesNotReturnIf(parameterValue: false)] this bool condition)
#else
        public static bool AssertTrue(this bool condition)
#endif
        {
            Assert.True(condition);
            return condition;
        }

        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>true</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="TrueException">Thrown when the condition is <c>false</c>.</exception>
        /// <see cref="Assert.True(bool?)"/>
#if XUNIT_NULLABLE
        public static bool? AssertTrue([DoesNotReturnIf(parameterValue: false)] this bool? condition)
#else
        public static bool? AssertTrue(this bool? condition)
#endif
        {
            Assert.True(condition);
            return condition;
        }

        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>true</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="userMessage"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="TrueException">Thrown when the condition is <c>false</c>.</exception>
        /// <see cref="Assert.True(bool,string?)"/>
#if XUNIT_NULLABLE
        public static bool AssertTrue([DoesNotReturnIf(parameterValue: false)] this bool condition, string? userMessage)
#else
        public static bool AssertTrue(this bool condition, string userMessage)
#endif
        {
            Assert.True(condition, userMessage);
            return condition;
        }

        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>true</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="userMessage"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="TrueException">Thrown when the condition is <c>false</c>.</exception>
        /// <see cref="Assert.True(bool?,string?)"/>
#if XUNIT_NULLABLE
        public static bool? AssertTrue([DoesNotReturnIf(parameterValue: false)] this bool? condition, string? userMessage)
#else
        public static bool? AssertTrue(this bool? condition, string userMessage)
#endif
        {
            Assert.True(condition, userMessage);
            return condition;
        }

        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="FalseException">Thrown when the condition is <c>true</c>.</exception>
        /// <see cref="Assert.False(bool)"/>
#if XUNIT_NULLABLE
        public static bool AssertFalse([DoesNotReturnIf(parameterValue: true)] this bool condition)
#else
        public static bool AssertFalse(this bool condition)
#endif
        {
            Assert.False(condition);
            return condition;
        }

        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="FalseException">Thrown when the condition is <c>true</c>.</exception>
        /// <see cref="Assert.True(bool?)"/>
#if XUNIT_NULLABLE
        public static bool? AssertFalse([DoesNotReturnIf(parameterValue: true)] this bool? condition)
#else
        public static bool? AssertFalse(this bool? condition)
#endif
        {
            Assert.False(condition);
            return condition;
        }

        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="userMessage"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="FalseException">Thrown when the condition is <c>true</c>.</exception>
        /// <see cref="Assert.False(bool,string?)"/>
#if XUNIT_NULLABLE
        public static bool AssertFalse([DoesNotReturnIf(parameterValue: true)] this bool condition, string? userMessage)
#else
        public static bool AssertFalse(this bool condition, string userMessage)
#endif
        {
            Assert.False(condition, userMessage);
            return condition;
        }

        /// <summary>
        /// Verifies that the <paramref name="condition"/> is <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="userMessage"></param>
        /// <returns>The <paramref name="condition"/> following successful Assertion.</returns>
        /// <exception cref="FalseException">Thrown when the condition is <c>true</c>.</exception>
        /// <see cref="Assert.True(bool?,string?)"/>
#if XUNIT_NULLABLE
        public static bool? AssertFalse([DoesNotReturnIf(parameterValue: true)] this bool? condition, string? userMessage)
#else
        public static bool? AssertFalse(this bool? condition, string userMessage)
#endif
        {
            Assert.False(condition, userMessage);
            return condition;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <exception cref="TrueException">Thrown when <paramref name="evaluation"/> yields false.</exception>
        /// <returns></returns>
        /// <see cref="Assert.True(bool)"/>
#if XUNIT_NULLABLE
        public static T? AssertTrue<T>([AllowNull] this T actual, Func<T?, bool> evaluation)
#else
        public static T AssertTrue<T>(this T actual, Func<T, bool> evaluation)
#endif
        {
            Assert.True(evaluation(actual));
            return actual;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <returns></returns>
        /// <exception cref="TrueException">Thrown when <paramref name="evaluation"/> yields false.</exception>
        /// <see cref="Assert.True(bool?)"/>
#if XUNIT_NULLABLE
        public static T? AssertTrue<T>([AllowNull] this T actual, Func<T?, bool?> evaluation)
#else
        public static T AssertTrue<T>(this T actual, Func<T, bool?> evaluation)
#endif
        {
            Assert.True(evaluation(actual));
            return actual;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <param name="userMessage"></param>
        /// <exception cref="TrueException">Thrown when <paramref name="evaluation"/> yields false.</exception>
        /// <returns></returns>
        /// <see cref="Assert.True(bool,string?)"/>
#if XUNIT_NULLABLE
        public static T? AssertTrue<T>([AllowNull] this T actual, Func<T?, bool> evaluation, string? userMessage)
#else
        public static T AssertTrue<T>(this T actual, Func<T, bool> evaluation, string userMessage)
#endif
        {
            Assert.True(evaluation(actual), userMessage);
            return actual;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <param name="userMessage"></param>
        /// <exception cref="TrueException">Thrown when <paramref name="evaluation"/> yields false.</exception>
        /// <returns></returns>
        /// <see cref="Assert.True(bool?,string?)"/>
#if XUNIT_NULLABLE
        public static T? AssertTrue<T>(this T? actual, Func<T?, bool?> evaluation, string? userMessage)
#else
        public static T AssertTrue<T>(this T actual, Func<T, bool?> evaluation, string userMessage)
#endif
        {
            Assert.True(evaluation(actual), userMessage);
            return actual;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <returns></returns>
        /// <exception cref="FalseException">Thrown when <paramref name="evaluation"/> yields <c>true</c>.</exception>
        /// <see cref="Assert.False(bool)"/>
#if XUNIT_NULLABLE
        public static T? AssertFalse<T>([AllowNull] this T actual, Func<T?, bool> evaluation)
#else
        public static T AssertFalse<T>(this T actual, Func<T, bool> evaluation)
#endif
        {
            Assert.False(evaluation(actual));
            return actual;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <exception cref="FalseException">Thrown when <paramref name="evaluation"/> yields <c>true</c>.</exception>
        /// <returns></returns>
        /// <see cref="Assert.False(bool?)"/>
#if XUNIT_NULLABLE
        public static T? AssertFalse<T>([AllowNull] this T actual, Func<T?, bool?> evaluation)
#else
        public static T AssertFalse<T>(this T actual, Func<T, bool?> evaluation)
#endif
        {
            Assert.False(evaluation(actual));
            return actual;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <param name="userMessage"></param>
        /// <exception cref="FalseException">Thrown when <paramref name="evaluation"/> yields <c>true</c>.</exception>
        /// <returns></returns>
        /// <see cref="Assert.False(bool,string?)"/>
#if XUNIT_NULLABLE
        public static T? AssertFalse<T>([AllowNull] this T actual, Func<T?, bool> evaluation, string? userMessage)
#else
        public static T AssertFalse<T>(this T actual, Func<T, bool> evaluation, string userMessage)
#endif
        {
            Assert.False(evaluation(actual), userMessage);
            return actual;
        }

        /// <summary>
        /// Asserts whether <paramref name="actual"/> meets the <see cref="bool"/>
        /// <paramref name="evaluation"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="evaluation"></param>
        /// <param name="userMessage"></param>
        /// <exception cref="FalseException">Thrown when <paramref name="evaluation"/> yields <c>true</c>.</exception>
        /// <returns></returns>
        /// <see cref="Assert.False(bool?,string?)"/>
#if XUNIT_NULLABLE
        public static T? AssertFalse<T>([AllowNull] this T actual, Func<T?, bool?> evaluation, string? userMessage)
#else
        public static T AssertFalse<T>(this T actual, Func<T, bool?> evaluation, string userMessage)
#endif
        {
            Assert.False(evaluation(actual), userMessage);
            return actual;
        }
    }
}