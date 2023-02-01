using System.Text.RegularExpressions;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader streamReader = new StreamReader("data.txt");
            string? data;
            List<Range> range1 = new List<Range>();
            List<Range> range2 = new List<Range>();
            int match = 0;
            int halfMatch = 0;
            
            try
            {
                while ((data = streamReader.ReadLine()) != null)
                {
                    string[] substrings = Regex.Split(data, @"[,]");
                    string[] part1 = Regex.Split(substrings[0], @"[-]");
                    string[] part2 = Regex.Split(substrings[1], @"[-]");
                    Range inputRage = new Range() { start = Convert.ToInt32(part1[0]), end = Convert.ToInt32(part1[1]) };
                    Range inputRage2 = new Range() { start = Convert.ToInt32(part2[0]), end = Convert.ToInt32(part2[1]) };
                    range1.Add(inputRage);
                    range2.Add(inputRage2);
                }
                
                for (int i = 0; i < range1.Count; i++)
                {
                    if (findMatch(range1[i], range2[i]))
                        match++;

                    if (findHalfMatch(range1[i], range2[i]))
                        halfMatch++;
                }

                Console.WriteLine(match);
                Console.WriteLine(halfMatch + match);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool findMatch(Range range1, Range range2)
        {
            if (range1.start <= range2.start && range1.end >= range2.end)
            {
                return true;

            } else if (range2.start <= range1.start && range2.end >= range1.end)
            {
                return true;
            }
            return false;
        }

        public static bool findHalfMatch(Range range1, Range range2)
        {
            if (range1.start < range2.start && range1.end >= range2.start && range1.end < range2.end)
            {
                return true;
            }
            else if (range1.start > range2.start && range1.start <= range2.end && range1.end > range2.end)
            {
                return true;
            } else if (range2.start < range1.start && range2.end >= range1.start && range2.end < range1.end)
            {
                return true;
            }
            else if (range2.start > range1.start && range2.start <= range1.end && range2.end > range1.end)
            {
                return true;
            }
            return false;
        }
    }

    public class Range
    {
        public int start { get; set; }
        public int end { get; set; }
    }
}