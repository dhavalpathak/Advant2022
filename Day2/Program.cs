namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader streamReader = new StreamReader("data.txt");
            string? data;
            List<FirstGroup> firstGroup = new List<FirstGroup>();
            List<SecondGroup> secondGroup = new List<SecondGroup>();
            int result = 0;
            try
            {
                while ((data = streamReader.ReadLine()) != null)
                {
                    string[] inputs = data.Trim().Split(" ");
                    Enum.TryParse(inputs[0].ToString(), out FirstGroup firsGroupVal);
                    Enum.TryParse(inputs[1].ToString(), out SecondGroup secondGroupVal);
                    firstGroup.Add(firsGroupVal);
                    secondGroup.Add(secondGroupVal);
                }
                streamReader.Close();
                for (int i = 0; i < firstGroup.Count; i++)
                {
                    result = result + DetermineResult(firstGroup[i], secondGroup[i]);
                }

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int DetermineResult(FirstGroup first, SecondGroup second)
        {
            int result = 0;

            switch (first)
            {
                case FirstGroup.A:
                    switch (second)
                    {
                        case SecondGroup.X:
                            result = Results.Draw + (int)second;
                            break;
                        case SecondGroup.Y:
                            result = Results.Win + (int)second;
                            break;
                        case SecondGroup.Z:
                            result = (int)second;
                            break;
                    }
                    break;
                case FirstGroup.B:
                    switch (second)
                    {
                        case SecondGroup.X:
                            result = (int)second;
                            break;
                        case SecondGroup.Y:
                            result = Results.Draw + (int)second;
                            break;
                        case SecondGroup.Z:
                            result = Results.Win + (int)second;
                            break;
                    }
                    break;
                case FirstGroup.C:
                default:
                    switch (second)
                    {
                        case SecondGroup.X:
                            result = Results.Win + (int)second;
                            break;
                        case SecondGroup.Y:
                            result = (int)second;
                            break;
                        case SecondGroup.Z:
                            result = Results.Draw + (int)second;
                            break;
                    }
                    break;
            }
            return result;
        }
    }
}