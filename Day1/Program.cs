namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader streamReader = new StreamReader("data.txt");
            string data;
            List<int> ints = new List<int>();
            List<CaloryData> lstData = new List<CaloryData>();

            try
            {
                while ((data = streamReader.ReadLine()) != null)
                {

                    if (data.Trim() == string.Empty)
                    {
                        CaloryData caloryData = new CaloryData();
                        caloryData.Calory = ints;
                        lstData.Add(caloryData);
                        ints = new List<int>();
                    }
                    else
                    {
                        ints.Add(System.Convert.ToInt32(((string)data).Trim()));
                    }
                }
                streamReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var newList = lstData.OrderByDescending(x => x.Calory.Sum());

            Console.WriteLine("Part 1 Answer: Highest ELF Value = " + newList.ElementAt(0).Calory.Sum());

        }
    }
}