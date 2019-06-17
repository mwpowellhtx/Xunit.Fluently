using System;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Unary Invocation which returns <paramref name="actual"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback"></param>
        /// <param name="actual"></param>
        /// <returns>The <paramref name="actual"/> value after successful <paramref name="callback"/>.</returns>
        private static bool InvokeUnaryWithReturn(Action<bool> callback, bool actual)
        {
            callback.Invoke(actual);
            return actual;
        }

        /// <summary>
        /// Unary Invocation which returns <paramref name="actual"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback"></param>
        /// <param name="actual"></param>
        /// <returns>The <paramref name="actual"/> value after successful <paramref name="callback"/>.</returns>
        private static bool? InvokeUnaryWithReturn(Action<bool?> callback, bool? actual)
        {
            callback.Invoke(actual);
            return actual;
        }

        /// <summary>
        /// Unary Invocation which returns <paramref name="actual"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback"></param>
        /// <param name="actual"></param>
        /// <returns>The <paramref name="actual"/> value after successful <paramref name="callback"/>.</returns>
        private static T InvokeUnaryWithReturn<T>(Action<T> callback, T actual)
        {
            callback.Invoke(actual);
            return actual;
        }

        /// <summary>
        /// Unary Invocation which makes inferences between <typeparamref name="TActual"/>
        /// and <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="TActual"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback"></param>
        /// <param name="actual"></param>
        /// <returns></returns>
        private static T InvokeUnaryWithReturn<TActual, T>(Func<TActual, T> callback, TActual actual)
            => callback.Invoke(actual);

        /// <summary>
        /// Unary Invocation which returns <paramref name="actual"/>. In this case, we allow
        /// an <typeparamref name="TInner"/> and a <typeparamref name="TOuter"/> value to inform
        /// the Invocation.
        /// </summary>
        /// <typeparam name="TOuter"></typeparam>
        /// <typeparam name="TInner"></typeparam>
        /// <param name="callback"></param>
        /// <param name="actual"></param>
        /// <param name="innerCallback"></param>
        /// <returns>The <paramref name="actual"/> value after successful <paramref name="callback"/>.</returns>
        private static TInner InvokeUnaryWithReturn<TOuter, TInner>(Action<TOuter> callback, TInner actual, Func<TInner, TOuter> innerCallback)
        {
            callback.Invoke(innerCallback.Invoke(actual));
            return actual;
        }
    }
}
