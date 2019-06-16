using System;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    using Abstractions;

    /// <inheritdoc />
    public abstract class TestFixtureBase : IDisposable
    {
        /// <summary>
        /// Gets the OutputHelper.
        /// </summary>
        protected ITestOutputHelper OutputHelper { get; }

        /// <summary>
        /// Protected Constructor.
        /// </summary>
        /// <param name="outputHelper"></param>
        protected TestFixtureBase(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// Gets whether IsDisposed.
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <inheritdoc />
        public void Dispose()
        {
            if (!IsDisposed)
            {
                Dispose(true);
            }

            IsDisposed = true;
        }
    }
}
