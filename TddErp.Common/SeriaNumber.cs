using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddErp
{
    public class SeriaNumber
    {
        public static string GetYMTen(string maxId)
        {
            string YMDate = DateTime.Now.ToString("yyyyMM");
            if (maxId != null)
            {  
                string headDate = maxId.Substring(0, 6);
                int lastNumber = int.Parse(maxId.Substring(6));
                if (headDate == YMDate)
                {
                    lastNumber++;
                    return headDate + lastNumber.ToString("0000");
                }
            }
            return YMDate + "0001";
        }

        public static string GetSeq(string maxSeq)
        {
            if (maxSeq != null)
            {
                int lastNumber = int.Parse(maxSeq.Substring(3));
                lastNumber++;
                return lastNumber.ToString("0000");
            }
            return "0001";
        }

        public static string GetThreeID(string maxID)
        {
            if (maxID != null)
            {
                int lastNumber = int.Parse(maxID.Substring(2));
                lastNumber++;
                return lastNumber.ToString("000");
            }
            return "001";
        }
    }
}
