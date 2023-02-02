using System.Text.RegularExpressions;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader streamReader = new StreamReader("data.txt");
            string? data;
            bool caretsOver = false;
            Stack<string> caretsInput = new Stack<string>();
            Queue<string> caretsInstruction = new Queue<string>();
            Dictionary<int, Stack<string>> dictCerts = new Dictionary<int, Stack<string>>();
            Dictionary<int, Stack<string>> dictCerts2 = new Dictionary<int, Stack<string>>();

            try
            {
                while ((data = streamReader.ReadLine()) != null)
                {
                    if (data.Length > 0 && !caretsOver)
                    {
                        caretsInput.Push(data);

                    } else if (data.Trim().Length != 0 && caretsOver)
                    {
                        caretsInstruction.Enqueue(data);
                    } else
                    {
                        caretsOver = true;
                    }
                }

                var noOfContainers = caretsInput.Pop().ToString();
                var containers = Regex.Split(noOfContainers.Trim(), @"\s+");
                foreach (String str in containers)
                {
                    dictCerts.Add(Convert.ToInt32(str), new Stack<string>());
                    dictCerts2.Add(Convert.ToInt32(str), new Stack<string>());
                }

                // assign carets to values
                foreach (string str in caretsInput.ToList())
                {
                    var tmpStr = str + " ";
                    int p = 1;
                    for (int i = 0; i < tmpStr.Length; i += 4)
                    {
                        if (tmpStr.Substring(i, 4).Trim().Length > 0)
                        {
                            dictCerts[p].Push(tmpStr.Substring(i + 1, 1));
                            dictCerts2[p].Push(tmpStr.Substring(i + 1, 1));
                        }
                        p++;
                    }
                }

                foreach(string str in caretsInstruction)
                {
                    
                    var part = Regex.Split(str, @"\s");
                                      
                    int no = Convert.ToInt32(part[1]);
                    int from = Convert.ToInt32(part[3]);
                    int to = Convert.ToInt32(part[5]);
                    Stack<string> secondChallenge = new Stack<string>();

                    for (int i = 0; i < no; i++)
                    {
                        dictCerts[to].Push(dictCerts[from].Pop());

                        secondChallenge.Push(dictCerts2[from].Pop());
                    }
                    foreach(string val in secondChallenge)
                    {
                        dictCerts2[to].Push(val);
                    }
                        
                }

                foreach (KeyValuePair<int, Stack<string>> item in dictCerts.AsEnumerable())
                {
                    Console.Write(item.Value.Pop());
                }
                Console.WriteLine();
                foreach (KeyValuePair<int, Stack<string>> item in dictCerts2.AsEnumerable())
                {
                    Console.Write(item.Value.Pop());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

/*
 * foreach (KeyValuePair<int, Stack<string>> item in dictCerts.AsEnumerable())
                {
                    Console.WriteLine(item.Key);
                    foreach (string str in item.Value)
                    {
                        Console.WriteLine(str);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }

*/
