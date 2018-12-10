using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ThesisPrototype.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Splits a IEnumerable<T> into a new list of lists, with each list containing <size> T's.
        /// </summary>
        public static List<List<T>> Split<T>(this IEnumerable<T> collection, int size)
        {
            var chunks = new List<List<T>>();
            var count = 0;
            var temp = new List<T>();

            foreach (var element in collection)
            {
                if (count++ == size)
                {
                    chunks.Add(temp);
                    temp = new List<T>();
                    count = 1;
                }
                temp.Add(element);
            }
            chunks.Add(temp);

            return chunks;
        }

        /// <summary>
        /// Gets the 00:00:00 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Gets the 11:59:59 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// Converts a DateTime to the amount of milliseconds passed since January the first, 1970.
        /// </summary>
        public static long ToUnixMilliTs(this DateTime dt)
        {
            return (Int64)(dt.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }

        /// <summary>
        /// Converts the given amount of milliseconds passed since January the first, 1970 to a DateTime.
        /// </summary>
        public static DateTime FromUnixMilliTs(this long unixTs)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(unixTs); 
        }
    }
}