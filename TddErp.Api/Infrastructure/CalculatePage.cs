using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TddErp.Api.Infrastructure
{
    public class CalculatePage
    {
        public static Tuple<int, int> CalculateCurrentPage(int CurrentPage)
        {
            int takeRow = CurrentPage == 1 ? 10 : CurrentPage * 10;
            int skipRow = CurrentPage == 1 ? 0 : takeRow - 10;
            return Tuple.Create(takeRow, skipRow);
        }
    }
}