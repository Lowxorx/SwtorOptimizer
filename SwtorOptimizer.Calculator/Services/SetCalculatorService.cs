using SwtorOptimizer.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SwtorOptimizer.Calculator.Services
{
    public class SetCalculatorService
    {
        public SetCalculatorService(int threshold, List<Enhancement> enhancements)
        {
            this.Threshold = threshold;
            this.Enhancements = enhancements;
        }

        private List<Enhancement> Enhancements { get; }
        private int Threshold { get; }

        public List<string> Calculate()
        {
            var tertiaryDataList = this.Enhancements.Select(e => e.Tertiary).ToArray();

            for (var i = 1; i < 7; i++)
            {
                tertiaryDataList.Concat(this.Enhancements.Select(e => e.Tertiary).ToArray());
            }

            var combinations = new List<string>();

            foreach (string s in GetCombinations(tertiaryDataList, this.Threshold, ""))
            {
                combinations.Add(s);
            }

            return combinations;
        }

        private IEnumerable<string> GetCombinations(int[] set, int sum, string values)
        {
            for (int i = 0; i < set.Length; i++)
            {
                int left = sum - set[i];
                string vals = set[i] + " " + values;
                if (left == 0)
                {
                    yield return vals.Trim();
                }
                else
                {
                    int[] possible = set.Take(i).Where(n => n <= sum).ToArray();
                    if (possible.Length > 0)
                    {
                        foreach (string s in GetCombinations(set, left, vals))
                        {
                            yield return s.Trim();
                        }
                    }
                }
            }
        }
    }
}