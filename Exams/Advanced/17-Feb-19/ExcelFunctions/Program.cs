using System;
using System.Linq;

namespace ExcelFunctions
{
    class Program
    {
        static void Main()
        {            
            string[][] matrix = ReadMatrix();                        

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            if (command[0]== "hide")
            {                
                DeleleteColumn(matrix, command[1]);
            }
            else if (command[0]== "sort")
            {
                SortByColumn(matrix, command[1]);
            }
            else if (command[0]== "filter")
            {
                FilterHeaderValue(matrix, command[1], command[2]);
            }            
        }

        private static void FilterHeaderValue(string[][] matrix, string header, string value)
        {
            var indexSearch = -1;
            for (int col = 0; col < matrix[0].Length; col++)
            {
                if (matrix[0][col]==header)
                {
                    indexSearch = col;
                }
            }
            Console.WriteLine(String.Join(" | ",matrix[0]));
            for (int row = 1; row < matrix.Length; row++)
            {
                if (matrix[row][indexSearch]==value)
                {
                    Console.WriteLine(String.Join(" | ",matrix[row]));
                }
            }


        }

        private static void SortByColumn(string[][] matrix, string colName)
        {
            var indexOfSort = -1;
            for (int col = 0; col < matrix[0].Length; col++)
            {
                if (matrix[0][col]==colName)
                {
                    indexOfSort = col;
                }
            }

            var sortedData = matrix.Skip(1).OrderBy(j => j.Skip(indexOfSort).First()).ToArray(); //sort on specific column
            Console.WriteLine(String.Join(" | ", matrix[0]));
            for (int row = 0; row < sortedData.Length; row++)
            {                
                    Console.WriteLine(String.Join(" | ",sortedData[row]));                
            }
        }

        private static void DeleleteColumn(string[][] matrix, string header)
        {
            var indexOfSearchedHeader = -1;
            for (int col = 0; col < matrix[0].Length; col++)
            {                
                if (header==matrix[0][col])
                {
                    indexOfSearchedHeader = col;
                }
                               
            }
            //delete data with indexOfSearchedHeader 
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (col== indexOfSearchedHeader)
                    {
                        matrix[row][col] = "";
                    }
                }
            }
            //print filtered matrix
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col]!="" && indexOfSearchedHeader!=matrix[row].Length-1)
                    {
                        if (col == matrix[row].Length - 1)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        else
                        {
                            Console.Write(matrix[row][col] + " | ");
                        }
                    }
                    else if (matrix[row][col] != "" && indexOfSearchedHeader == matrix[row].Length - 1)
                    {
                        //last column removed
                        if (col == matrix[row].Length - 2)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        else
                        {
                            Console.Write(matrix[row][col] + " | ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (col==matrix[row].Length-1)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(matrix[row][col] + " | ");
                    }                    
                }
                Console.WriteLine();
            }
        }

        private static string[][] ReadMatrix()
        {
            int numberOfRows = int.Parse(Console.ReadLine());            
            var matrix = new string[numberOfRows][];
            for (int row = 0; row < numberOfRows; row++)
            {
                var line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                matrix[row] = line;                               
            }
            return matrix;
        }
    }
}
