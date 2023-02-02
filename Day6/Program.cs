namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader streamReader = new StreamReader("data.txt");
            string? data;
            string input = string.Empty;

            try
            {
                while ((data = streamReader.ReadLine()) != null)
                {
                    input = data;
                }
                
                Console.WriteLine("First Answer :=  " +  FindStream(input));
                Console.WriteLine("First Answer :=  " + FindLongerStream(input));

                streamReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static int FindStream(string input)
        {
            var chars = input.ToCharArray();
            int result = 0;

            for (int i = 0; i < chars.Length - 3; i++)
            {
                List<char> list = new List<char>();
                list.Add(chars[i]);
                list.Add(chars[i + 1]);
                list.Add(chars[i + 2]);
                list.Add(chars[i + 3]);

                if (list.Distinct().ToList().Count == 4)
                {
                    result = i + 4;
                    break;
                }

            }
            return result;
        }

        public static int FindLongerStream(string input)
        {
            var chars = input.ToCharArray().ToList();
            int result = 0;

            for (int i = 0; i < chars.Count - 14; i++)
            {
                List<char> list = new List<char>();
                list.AddRange(chars.GetRange(i, 14));

                if (list.Distinct().ToList().Count == 14)
                {
                    result = i + 14;
                    break;
                }

            }
            return result;
        }
    }
}