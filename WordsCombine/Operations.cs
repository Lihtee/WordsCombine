using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsCombine
{
    public class Operations
    {
        public List<string> Combine(string wordA, string wordB)
        {
            throw new NotImplementedException();
        }

        public List<CommonString> FindCommonSubstrings(string wordA, string wordB)
        {
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
