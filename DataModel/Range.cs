using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Range
    {
        [Range(0, int.MaxValue)]
        public int startIdx;

        [Range(0, int.MaxValue)]
        public int count;
    }
}
