using System;
using System.Collections.Generic;

namespace SS_RangeIterationExtension
{
    /// <summary>
    /// Implements GetEnumerator for <see cref="System.Range"/> struct to enable Rust-like iteration syntax
    /// </summary>
    static public class RangeIntIndexesIteratorExtension
    {
        /// <summary>
        /// Enables iteration over a <see cref="System.Range"/> object's ineteger indices
        /// </summary>
        /// <param name="range">The <see cref="System.Range"/> object to iterate over.</param>
        /// <returns>A <see cref="System.Collections.Generic.IEnumerator{int}"/> instance that enables enumeration over the range. </returns>
        public static IEnumerator<int> GetEnumerator(this Range range)
        {
            var nums = new List<int>();
            int start, end;
            if (!range.Start.IsFromEnd)
            {
                start = range.Start.Value;
            }

            else
            {
                start = (int.MaxValue - range.Start.Value);
            }

            if (!range.End.IsFromEnd)
            {
                end = range.End.Value;
            }
            else
            {
                end = (int.MaxValue - range.End.Value);
            }

            for (var i = start; i <= end; i++)
                nums.Add(i);

            nums.TrimExcess();

            return nums.GetEnumerator();
        }
    }
}
