using System;
using System.Collections.Generic;
using System.Text;

namespace LeftJoin.Classes
{
    public class LeftJoinNode
    {
        public string LeftValue { get; set; }

        public string RightValue { get; set; }

        /// <summary>
        /// Instantiates a new LeftJoinNode that holds a left join's two column values. Requires a LeftValue, RightValue is optional.
        /// </summary>
        /// <param name="leftValue">
        /// string: the left value for a left join
        /// </param>
        public LeftJoinNode(string leftValue)
        {
            LeftValue = leftValue;
            RightValue = "";
        }
    }
}
