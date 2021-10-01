using System;
using System.Linq;
using System.Text;

namespace Mo01ExtractPersonInformation
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                ExtractData(input);
            }
        }

        private static void ExtractData(string input)
        {
            StringBuilder name = new StringBuilder();
            StringBuilder age = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='@')
                {
                    //start of name found
                    
                    for (int j = i+1; j < input.Length; j++)
                    {                        
                        if(input[j]!='|')
                        {
                            name.Append(input[j]);
                        }
                        else
                        {
                            break;
                        }
                    }                    
                }
                if (input[i]=='#')
                {
                    //start of age found                    
                    for (int j = i+1; j < input.Length; j++)
                    {
                        if (input[j]!='*')
                        {
                            age.Append(input[j]);
                        }
                        else
                        {
                            break;
                        }
                    }                    
                }
                //output
                if (age.Length!=0 && name.Length!=0)
                {
                    Console.WriteLine($"{name.ToString()} is {age.ToString()} years old.");
                    name.Clear();
                    age.Clear();
                }
            }            
        }
    }
}
