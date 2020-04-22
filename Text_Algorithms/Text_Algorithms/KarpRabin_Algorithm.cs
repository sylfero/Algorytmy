namespace Text_Algorithms
{
    static class KarpRabin_Algorithm
    {
        private const int prime = 101;
        private const int baseNum = 256;

        public static int Search(string pattern, string text)
        {
            int hashPattern = Hash(pattern);

            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                string subText = text.Substring(i, pattern.Length);
                int hashText = Hash(subText);

                if (hashPattern == hashText)
                    if (subText.Equals(pattern))
                        return i;
            }

            return -1;
        }

        private static int Hash(string pattern)
        {
            int hash = 0;
            
            for (int i = 0; i < pattern.Length; i++)
            {
                hash = (hash + baseNum + pattern[i]) % prime;
            }

            return hash;
        }
    }
}
