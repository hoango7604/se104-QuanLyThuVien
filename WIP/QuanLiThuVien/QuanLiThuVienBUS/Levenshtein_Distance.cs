using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienBUS
{
    internal static class Levenshtein_Distance
    {
        private static int min3(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, c), b);
        } 
        public static int Distance(string str, string target)
        {
            int[,] h;
            h = new int[str.Length + 1, target.Length + 1];
            for (int i = 0; i <= str.Length; i++)
            {
                h[i, 0] = i;
            }
            for (int i = 0; i <= target.Length; i++)
            {
                h[0, i] = i;
            }
            for (int i = 1; i <= str.Length; i++)
            {
                for (int j = 1; j <= target.Length; j++)
                {

                    byte cost = 1;
                    if (str[i - 1].Equals(target[j - 1]))
                    {
                        cost = 0;
                    }
                    h[i, j] = min3(h[i - 1, j] + 1, h[i, j - 1] + 1, h[i - 1, j - 1] + cost);

                }
            }
            return h[str.Length, target.Length];
        }
    }
}
