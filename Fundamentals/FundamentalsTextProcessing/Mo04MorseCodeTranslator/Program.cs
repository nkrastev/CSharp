using System;
using System.Linq;

namespace Mo04MorseCodeTranslator
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            TranslateWords(words);
            
        }

        private static void TranslateWords(string[] words)
        {
            foreach (var item in words)
            {
                switch (item)
                {
                    case ".-":{ Console.Write('A'); break; }
                    case "-...": { Console.Write('B'); break; }
                    case "-.-.": { Console.Write('C'); break; }
                    case "-..": { Console.Write('D'); break; }
                    case ".": { Console.Write('E'); break; }
                    case "..-.": { Console.Write('F'); break; }
                    case "--.": { Console.Write('G'); break; }
                    case "....": { Console.Write('H'); break; }
                    case "..": { Console.Write('I'); break; }
                    case ".---": { Console.Write('J'); break; }
                    case "-.-": { Console.Write('K'); break; }
                    case ".-..": { Console.Write('L'); break; }
                    case "--": { Console.Write('M'); break; }
                    case "-.": { Console.Write('N'); break; }
                    case "---": { Console.Write('O'); break; }
                    case ".--.": { Console.Write('P'); break; }
                    case "--.-": { Console.Write('Q'); break; }
                    case ".-.": { Console.Write('R'); break; }
                    case "...": { Console.Write('S'); break; }
                    case "-": { Console.Write('T'); break; }
                    case "..-": { Console.Write('U'); break; }
                    case "...-": { Console.Write('V'); break; }
                    case ".--": { Console.Write('W'); break; }
                    case "-..-": { Console.Write('X'); break; }
                    case "-.--": { Console.Write('Y'); break; }
                    case "--..": { Console.Write('Z'); break; }                    
                    case "|": { Console.Write(' '); break; }                    
                }                
            }
        }        
    }
}
