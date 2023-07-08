using System;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string? text, string? pattern, bool overlap)
        {
            if (text is null || pattern is null)
            {
                throw new ArgumentException("Text or pattern is null.");
            }

            List<int> array = new List<int>();
            if (overlap)
            {
                int index = 0;
                while (true)
                {
                    int temp = text.IndexOf(pattern, index, StringComparison.InvariantCultureIgnoreCase);
                    if (temp < 0)
                    {
                        break;
                    }

                    array.Add(temp + 1);
                    index = temp + 1;
                    if (index >= text.Length)
                    {
                        break;
                    }
                }
            }
            else
            {
                int index = 0;
                while (true)
                {
                    int temp = text.IndexOf(pattern, index, StringComparison.InvariantCultureIgnoreCase);
                    if (temp < 0)
                    {
                        break;
                    }

                    array.Add(temp + 1);
                    index = temp + pattern.Length;
                    if (index >= text.Length)
                    {
                        break;
                    }
                }
            }

            return array.ToArray();
        }
    }
}
