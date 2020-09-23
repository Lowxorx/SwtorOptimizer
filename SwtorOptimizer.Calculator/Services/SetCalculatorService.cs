using System;
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

            //for (var i = 1; i < 7; i++)
            //{
            //    tertiaryDataList.AddRange(this.Enhancements);
            //}

            var combinations = new List<string>();

            foreach (var s in this.GetCombinations(tertiaryDataList.ToArray(), this.Threshold, string.Empty))
            {
                combinations.Add(s);
            }

            return combinations;
        }

        private IEnumerable<string> GetCombinations(Enhancement[] enhancements, int threshold, string values)
        {
            for (int i = 0; i < enhancements.Length; i++)
            {
                int left = threshold - enhancements[i].Tertiary;
                if (left < 0)
                {
                    break;
                }
                string vals = enhancements[i].Id + " " + values;
                if (left == 0)
                {
                    yield return vals.Trim();
                }
                else
                {
                    //var possible = enhancements.Take(i).Where(n => n.Tertiary <= threshold).ToArray();
                    //     if (possible.Length > 0)
                    //     {
                    foreach (string s in GetCombinations(enhancements, left, vals))
                    {
                        yield return s.Trim();
                    }
                    // }
                }
            }
        }
    }
}