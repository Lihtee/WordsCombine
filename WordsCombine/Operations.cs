using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsCombine
{
    public class Operations
    {
        public List<string> Combine(string wordA, string wordB)
        {
            var commonStrings = FindCommonSubstrings(wordA, wordB).OrderByDescending(x => x.Length()).ToList();
            var res = new List<string>();
            foreach (var commStr in commonStrings)
            {
                int len = commStr.Words.Count();

                for (int leftind = 0; leftind < len; leftind++)
                {
                    for (int rightind = 0; rightind < len; rightind++)
                    {
                        if (leftind != rightind)
                        {
                            string comb1 =
                                $"{commStr.GetBefore(leftind)}" +
                                $"{commStr.GetCommon(leftind)}" +
                                $"{commStr.GetAfter(rightind)}";
                            string comb2 =
                                $"{commStr.GetBefore(leftind)}" +
                                $"{commStr.GetCommon(rightind)}" +
                                $"{commStr.GetAfter(rightind)}";
                            res.Add(comb1);

                            if (comb1 != comb2)
                            {
                                res.Add(comb2);
                            }
                        }
                    }
                }
            }

            return res;
        }

        public List<CommonString> FindCommonSubstrings(string wordA, string wordB)
        {
            if (wordA.Length > wordB.Length)
            {
                var temp = wordB;
                wordB = wordA;
                wordA = temp;
            }

            int lenA = wordA.Length;
            int lenB = wordB.Length;
            var a = new Word { sWord = wordA };
            var b = new Word { sWord = wordB };
            var res = new List<CommonString>();
            for (int aFrst = 0; aFrst < lenA && aFrst < lenB; aFrst++)
            {
                for (int aLast = aFrst; aLast < lenA && aLast < lenB; aLast++)
                {
                    var subStr = new string(wordA.Skip(aFrst).Take(aLast - aFrst + 1).ToArray());
                    for (int i = 0; i < lenB;)
                    {
                        int bFrst = wordB.IndexOf(subStr, i);
                        if (bFrst >= 0)
                        {
                            res.Add(new CommonString
                            {
                                Words = new List<Word> { a, b },
                                StartPoss = new List<int> { aFrst, bFrst },
                                EndPoss = new List<int> { aLast, bFrst + subStr.Length - 1 }
                            });
                            i = bFrst + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            res = res.Distinct().ToList();

            return res;
        }
    }
}
