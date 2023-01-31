namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader streamReader = new StreamReader("data.txt");
            string? data;
            List<string> fullData = new List<string>();
            List<Rucksack> rucksacks = new List<Rucksack>();
            List<char> chars = new List<char>();
            int result = 0;

            try
            {
                while ((data = streamReader.ReadLine()) != null)
                {

                    fullData.Add(data);
                    string partOne = data.Trim().Substring(0, data.Length / 2);
                    string partTwo = data.Trim().Remove(0, data.Length / 2);

                    Rucksack rucsack = new Rucksack
                    {
                        compartmentOne = partOne,
                        compartmentTwo = partTwo
                    };
                    rucksacks.Add(rucsack);
                }
                streamReader.Close();

                foreach(Rucksack rucksack in rucksacks) 
                {
                    foreach(Char c in FindCommon(rucksack))
                    {
                        chars.Add(c);
                    }
                }

                foreach (Char c in chars)
                {
                    result += GetCharNumber(c);
                }

                Console.WriteLine(result);
                Console.WriteLine(fullData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<char> FindCommon(Rucksack rucksack)
        {
            List<char> chars = new List<char>();    
            foreach(char c in rucksack.compartmentOne)
            {
                if (rucksack.compartmentTwo.Contains(c))
                    if (!chars.Contains(c))
                        chars.Add(c);
            }
            return chars;
        }

        public static int GetCharNumber(char c)
        {
            int result = 0;
            if ((int)c > 64 && (int)c < 91)
            {
                result = (int)c - 64 + 26;
            }
            else if ((int)c > 96 && (int)c < 123)
            {
                result = (int)c - 96;
            }
            else return 0;

            return result;
        }
    }
}

public class Rucksack
{
    public string compartmentOne { get; set; }
    public string compartmentTwo { get; set; }
}