﻿using System;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that the <paramref name="value"/> is of the type <typeparamref name="T"/>,
        /// or a derived type.
        /// </summary>
        /// <typeparam name="T">The Type used during inspection.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The strongly typed <typeparamref name="T"/> <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.IsAssignableFrom{T}(object?)"/>
#if XUNIT_NULLABLE
        public static T AssertIsAssignableFrom<T>(this object? value)
#else
        public static T AssertIsAssignableFrom<T>(this object value)
#endif
            => Assert.IsAssignableFrom<T>(value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> is of the type
        /// <paramref name="expectedType"/>, or a derived type.
        /// </summary>
        /// <param name="value">The Value being inspected.</param>
        /// <param name="expectedType">The Expected Type being inspected.</param>
        /// <returns>The weakly <paramref name="expectedType"/> typed <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.IsAssignableFrom(object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertIsAssignableFrom(this object? value, Type expectedType)
#else
        public static object AssertIsAssignableFrom(this object value, Type expectedType)
#endif
        {
            Assert.IsAssignableFrom(expectedType, value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Not of the Type
        /// <typeparamref name="T"/>, or a derived type.
        /// </summary>
        /// <typeparam name="T">The Type used during inspection.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The weakly typed <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.IsNotType{T}(object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertIsNotType<T>(this object? value)
#else
        public static object AssertIsNotType<T>(this object value)
#endif
        {
            Assert.IsNotType<T>(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Not of the
        /// <paramref name="expectedType"/>, or a derived type.
        /// </summary>
        /// <param name="value">The Value being inspected.</param>
        /// <param name="expectedType">The Expected Type used during inspection.</param>
        /// <returns></returns>
        /// <see cref="Assert.IsNotType(Type,object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertIsNotType(this object? value, Type expectedType)
#else
        public static object AssertIsNotType(this object value, Type expectedType)
#endif
        {
            Assert.IsNotType(expectedType, value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> is of the Type <typeparamref name="T"/>,
        /// or a derived type.
        /// </summary>
        /// <typeparam name="T">The Type used during inspection.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The strongly typed <typeparamref name="T"/> <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.IsNotType{T}(object?)"/>
#if XUNIT_NULLABLE
        public static T AssertIsType<T>(this object? value)
#else
        public static T AssertIsType<T>(this object value)
#endif
            => Assert.IsType<T>(value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> is of the <paramref name="expectedType"/>,
        /// or a derived type.
        /// </summary>
        /// <param name="value">The Value being inspected.</param>
        /// <param name="expectedType">The Expected Type used during inspection.</param>
        /// <returns></returns>
        /// <see cref="Assert.IsType(Type,object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertIsType(this object? value, Type expectedType)
#else
        public static object AssertIsType(this object value, Type expectedType)
#endif
        {
            Assert.IsType(expectedType, value);
            return value;
        }
    }
}