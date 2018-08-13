using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsCombine
{
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
}
