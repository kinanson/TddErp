using System;

namespace TddErp.Common.Extension
{
    public static class EnumExtenstion
    {
        public static int ToInt(this Enum s)
        {
            return Convert.ToInt16(s);
        }

        public static char ToChar(this Enum s)
        {
            return Convert.ToChar(s);
        }
    }
}