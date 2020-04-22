namespace Text_Algorithms
{
    static class KMP_Algorithm
    {
        public static int Search(string pattern, string text)
        {
            int m = 0;
            int i = 0;
            int[] t = GetArray(pattern);
            
            while (m + i < text.Length)
            {
                if (pattern[i] == text[m + i])
                {
                    i++;
                    if (i == pattern.Length)
                        return m;
                }
                else
                {
                    m = m + i - t[i];
                    if (i > 0)
                        i = t[i];
                }
            }
            return -1;
        }

        private static int[] GetArray(string pattern)
        {
            int i = 2;
            int j = 0;

            int[] output = new int[pattern.Length];
            output[0] = -1;
            output[1] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i - 1] == pattern[j])
                {
                    output[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = output[j];
                    }
                    else
                    {
                        output[i] = 0;
                        i++;
                    }
                }
            }
            return output;
        }
    }
}
