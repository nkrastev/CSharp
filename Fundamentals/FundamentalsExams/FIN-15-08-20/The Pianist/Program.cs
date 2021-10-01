using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();
            // piece Name, list0 piece Composer, list1 piece Key
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                pieces.Add(input[0], new List<string> { input[1], input[2] });
            }

            var instructions = Console.ReadLine();
            while (instructions != "Stop")
            {
                var command = instructions.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "Add")
                {
                    var piece = command[1];
                    var composer = command[2];
                    var key = command[3];
                    AddPiece(pieces, piece, composer, key);
                }
                if (command[0] == "Remove")
                {
                    var piece = command[1];
                    RemovePiece(pieces, piece);
                }
                if (command[0] == "ChangeKey")
                {
                    //•	ChangeKey|{piece}|{new key}
                    var piece = command[1];
                    var newKey = command[2];
                    ChangeKey(pieces, piece, newKey);
                }
                instructions = Console.ReadLine();
            }

            //sorting
            pieces = pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);

            //output
            foreach (var item in pieces)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }

        }

        private static Dictionary<string, List<string>> ChangeKey(Dictionary<string, List<string>> pieces, string piece, string newKey)
        {
            if (pieces.ContainsKey(piece))
            {
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                pieces[piece][1] = newKey;
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
            return pieces;
        }

        private static Dictionary<string, List<string>> RemovePiece(Dictionary<string, List<string>> pieces, string piece)
        {
            if (pieces.ContainsKey(piece))
            {
                pieces.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
            return pieces;
        }

        private static Dictionary<string, List<string>> AddPiece(Dictionary<string, List<string>> pieces, string piece, string composer, string key)
        {
            if (pieces.ContainsKey(piece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }
            else
            {
                pieces.Add(piece, new List<string> { composer, key });
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
            return pieces;
        }
    }
}
