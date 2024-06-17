using System;

#if XUNIT_NULLABLE
using System.Diagnostics.CodeAnalysis;
#endif

namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argName"></param>
        /// <param name="argValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>
        /// Templated after the internal <em>xunit</em> method by the same name, fit around
        /// the same sort of purpose.
        /// </remarks>
#if XUNIT_NULLABLE
        [return: NotNull]
#endif
        internal static T GuardArgumentNotNull<T>(
            string argName
#if XUNIT_NULLABLE
            , [NotNull] T? argValue)
#else
			, T argValue)
#endif
        {
            if (argValue == null)
                throw new ArgumentNullException(argName.TrimStart('@'));

            return argValue;
        }

    }
}