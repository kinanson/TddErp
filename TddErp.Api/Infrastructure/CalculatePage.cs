using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TddErp.Api.Infrastructure
{
    public class CalculatePage
    {
        public static Tuple<int, int> CalculateCurrentPage(int currentPage)
        {
            int takeRow = currentPage == 1 ? 10 : currentPage * 10;
            int skipRow = currentPage == 1 ? 0 : takeRow - 10;
            return Tuple.Create(takeRow, skipRow);
        }
    }
}