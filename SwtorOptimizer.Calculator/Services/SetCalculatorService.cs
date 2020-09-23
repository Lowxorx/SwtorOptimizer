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
            var tertiaryDataList = new List<Enhancement>();
            tertiaryDataList.AddRange(this.Enhancements);

            return this.GetCombinations(tertiaryDataList.ToArray(), this.Threshold, string.Empty).ToList();
        }

        private IEnumerable<string> GetCombinations(IReadOnlyList<Enhancement> enhancements, int threshold, string values)
        {
            foreach (var enhancement in enhancements)
            {
                var left = threshold - enhancement.Tertiary;
                if (left < 0)
                {
                    break;
                }
                var vals = enhancement.Id + " " + values;
                if (left == 0)
                {
                    yield return vals.Trim();
                }
                else
                {
                    foreach (var s in this.GetCombinations(enhancements, left, vals))
                    {
                        yield return s.Trim();
                    }
                }
            }
        }
    }
}