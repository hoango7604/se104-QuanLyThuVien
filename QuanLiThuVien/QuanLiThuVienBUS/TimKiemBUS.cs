using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienBUS
{
    internal static class TimKiemBUS
    {
        internal struct resultItem
        {
            public int distance;
            public string individual;
        }

        internal static List<string> TimKiem(string input, List<string> sources)
        {
            List<resultItem> result = new List<resultItem>();
            foreach (string individual in sources)
            {
                string[] separators = new string[] { " " };
                string[] inputarr = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string[] idvarr = individual.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                List<string> idvList = new List<string>(idvarr);

                int min = 1000;
                foreach (string inputIdv in inputarr)
                {
                    if (idvList.IndexOf(inputIdv) != -1)
                    {
                        min = Math.Min(min, Levenshtein_Distance.Distance(input, individual));
                    }
                }
                if (min != 1000)
                {
                    resultItem newiten;
                    newiten.distance = (int)(min * 0.8);
                    newiten.individual = individual;
                    if (newiten.distance < newiten.individual.Length / 2)
                    {
                        result.Add(newiten);
                    }
                    continue;
                }

                min = 1000;
                foreach (string inputIdv in inputarr)
                {
                    foreach (string idv in idvList)
                    {
                        if (Levenshtein_Distance.Distance(inputIdv, idv) <= idv.Length / 3)
                        {
                            min = Math.Min(min, Levenshtein_Distance.Distance(input, individual));
                        }
                    }
                }
                if (min != 1000)
                {
                    resultItem newiten;
                    newiten.distance = (int)(min * 1.2);
                    newiten.individual = individual;
                    if (newiten.distance < newiten.individual.Length / 2)
                    {
                        result.Add(newiten);
                    }
                    continue;
                }

                if (Levenshtein_Distance.Distance(individual, input) <= individual.Length / 2)
                {
                    resultItem newiten;
                    newiten.distance = Levenshtein_Distance.Distance(individual, input);
                    newiten.individual = individual;
                    if (newiten.distance < newiten.individual.Length / 2)
                    {
                        result.Add(newiten);
                    }
                }
            }
            result.Sort((s1, s2) => s1.distance.CompareTo(s2.distance));
            List<string> finalresult = new List<string>();
            foreach (resultItem item in result)
            {
                finalresult.Add(item.individual);
            }
            return finalresult;
        }

        internal static int CheckisAvaiable(string input, string source)
        {
            string[] separators = new string[] { " " };
            string[] inputarr = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] idvarr = source.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> idvList = new List<string>(idvarr);

            int min = 1000;
            foreach (string inputIdv in inputarr)
            {
                if (idvList.IndexOf(inputIdv) != -1)
                {
                    min = Math.Min(min, Levenshtein_Distance.Distance(input, source));
                }
            }
            if (min != 1000)
            {
                return (int)(min * 0.8);
            }

            min = 1000;
            foreach (string inputIdv in inputarr)
            {
                foreach (string idv in idvList)
                {
                    if (Levenshtein_Distance.Distance(inputIdv, idv) <= idv.Length / 3)
                    {
                        min = Math.Min(min, Levenshtein_Distance.Distance(input, source));
                    }
                }
            }
            if (min != 1000)
            {
                return (int)(min * 1.2);
            }

            if (Levenshtein_Distance.Distance(source, input) <= source.Length / 2)
            {

                return Levenshtein_Distance.Distance(source, input);
            }
            return -1;
        }

    }


}
