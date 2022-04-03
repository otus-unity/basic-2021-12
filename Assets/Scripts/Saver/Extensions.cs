using System;

namespace Saver
{
    public static class Extensions
    {
        public static bool TryBool(this string self)
        {
            return Boolean.TryParse(self, out var res) && res;
        }

        public static float TrySingle(this string self)
        {
            if (Single.TryParse(self, out var res))
            {
                return res;
            }
            return 0;
        }
    }
}
