// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileNameExtension.cs" company="Rudolf Kotulán">
//   Copyright © Rudolf Kotulán All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class FileNameExtension
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }

        public static string ToShortFileName(this string fileName)
        {
            var parts = fileName.Split(new[] { '/' });

            if (parts.Length <= 1)
            {
                return fileName;
            }

            return parts.TakeLast(2).Aggregate((current, next) => current + "/" + next);
        }
    }
}