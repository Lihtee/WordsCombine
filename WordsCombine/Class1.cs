using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCombine
{
    public static class Patterns
    {
        public static readonly string a = "";
    }
    public class Class1
    {

    }

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

    public class CommonString
    {
        public List<Word> Words;
        public List<int> StartPoss;
        public List<int> EndPoss;
        public int Length()
        {
            return EndPoss[0] - StartPoss[0];
        }

        public string GetBefore(int index)
        {
            return string.Join("", Words[index].sWord.Take(StartPoss[index]));
        }

        public string GetAfter(int index)
        {
            return string.Join("", Words[index].sWord.Skip(EndPoss[index] + 1));
        }

        public string GetCommon(int index)
        {
            return string.Join("", Words[index].sWord.Take(EndPoss[index] + 1).Skip(StartPoss[index]));
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            int len = Words.Count;

            for (int i = 0; i < len; i++)
            {
                var word = Words[i].sWord;
                int strt = StartPoss[i];
                int end = EndPoss[i];
                sb.Append($"    {GetBefore(i)}({GetCommon(i)}){GetAfter(i)}    ");
            }

            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is CommonString other)
            {
                return this.Words.Count == other.Words.Count
                        && StartPoss.Count == other.StartPoss.Count
                        && EndPoss.Count == other.EndPoss.Count
                        && Words.Except(other.Words).Count() == 0
                        && StartPoss.Except(other.StartPoss).Count() == 0
                        && EndPoss.Except(other.EndPoss).Count() == 0;
            }

            return false;
        }
    }

    public class Word
    {
        public string sWord;

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return true;
            }

            if (obj is Word other)
            {
                if (other == null)
                {
                    return false;
                }

                return sWord == other.sWord;
            }

            return false;

        }
    }
}
