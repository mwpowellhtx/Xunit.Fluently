using System;
using System.Threading.Tasks;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class ExceptionallyExtensionMethods
    {
        /// <summary>
        /// Verifies that the <paramref name="action"/> throws the <typeparamref name="T"/>
        /// exception.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Exception"/> being inspected.</typeparam>
        /// <param name="action">The Action being inspected.</param>
        /// <returns>The thrown <typeparamref name="T"/> exception following successful Assertion.</returns>
        /// <see cref="Assert.Throws{T}(Action)"/>
        /// <see cref="Exception"/>
        public static T AssertThrows<T>(this Action action)
            where T : Exception
            => Assert.Throws<T>(action);

        /// <summary>
        /// Verifies that the <paramref name="action"/> throws the <typeparamref name="T"/>
        /// exception, or any exception derived from <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Exception"/> being inspected.</typeparam>
        /// <param name="action">The Action being inspected.</param>
        /// <returns>The thrown <typeparamref name="T"/> exception following successful Assertion.</returns>
        /// <see cref="Assert.Throws{T}(Action)"/>
        /// <see cref="Exception"/>
        public static T AssertThrowsAny<T>(this Action action)
            where T : Exception
            => Assert.ThrowsAny<T>(action);

        /// <summary>
        /// Verifies that the <paramref name="action"/> throws the
        /// <paramref name="exceptionType"/> exception.
        /// </summary>
        /// <param name="action">The Action being inspected.</param>
        /// <param name="exceptionType">The <see cref="Exception"/> type being inspected.</param>
        /// <returns>The thrown <see cref="Exception"/> following successful Assertion.</returns>
        /// <see cref="Assert.Throws(Type,Action)"/>
        /// <see cref="Exception"/>
        public static Exception AssertThrows(this Action action, Type exceptionType)
            => Assert.Throws(exceptionType, action);

        /// <summary>
        /// Verifies that the <paramref name="future"/> throws the <typeparamref name="T"/>
        /// exception asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Exception"/> being inspected.</typeparam>
        /// <param name="future">The <see cref="Func{TResult}"/> being inspected.</param>
        /// <returns>The asynchronously thrown <typeparamref name="T"/> exception following successful Assertion.</returns>
        /// <see cref="Assert.ThrowsAsync{T}(Func{Task})"/>
        /// <see cref="Task{TResult}"/>
        /// <see cref="Exception"/>
        public static Task<T> AssertThrowsAsync<T>(this Func<Task> future)
            where T : Exception
            => Assert.ThrowsAsync<T>(future);

        /// <summary>
        /// Verifies that the <paramref name="future"/> throws the
        /// <paramref name="exceptionType"/> exception.
        /// </summary>
        /// <param name="future">The Future being asynchronously inspected.</param>
        /// <param name="exceptionType">The <see cref="Exception"/> type being inspected.</param>
        /// <returns>The asynchronously thrown <see cref="Exception"/> following successful Assertion.</returns>
        /// <see cref="Assert.ThrowsAsync"/>
        /// <see cref="Exception"/>
        public static Task<Exception> AssertThrowsAsync(this Func<Task> future, Type exceptionType)
            => Assert.ThrowsAsync(exceptionType, future);

        /// <summary>
        /// Verifies that the <paramref name="future"/> throws the <typeparamref name="T"/>
        /// exception, or any exception derived from <typeparamref name="T"/>, asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Exception"/> being inspected.</typeparam>
        /// <param name="future">The <see cref="Func{TResult}"/> being inspected.</param>
        /// <returns>The asynchronously thrown <typeparamref name="T"/> exception following successful Assertion.</returns>
        /// <see cref="Assert.ThrowsAsync{T}(Func{Task})"/>
        /// <see cref="Task{TResult}"/>
        /// <see cref="Exception"/>
        public static Task<T> AssertThrowsAnyAsync<T>(this Func<Task> future)
            where T : Exception
            => Assert.ThrowsAnyAsync<T>(future);
    }
}