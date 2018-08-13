namespace WordsCombine
{
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
