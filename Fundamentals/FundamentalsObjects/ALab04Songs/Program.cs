using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ALab04Songs
{
    class Program
    {
        static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());


            List<Song> listOfSongs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                List<string> currentSong = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                Song currentSongObject = new Song();

                currentSongObject.typeList = currentSong[0];
                currentSongObject.name = currentSong[1];
                currentSongObject.time = currentSong[2];

                listOfSongs.Add(currentSongObject);
            }

            string filter = Console.ReadLine();

            PrintSongNames(filter, listOfSongs);

            
        }

        private static void PrintSongNames(string filter, List<Song> listOfSongs)
        {
            if (filter == "all")
            {
                foreach (var item in listOfSongs)
                {
                    Console.WriteLine(item.name);
                }
            }
            else
            {
                foreach (var item in listOfSongs)
                {
                    if (item.typeList==filter)
                    {
                        Console.WriteLine(item.name);
                    }
                }
            }
            
        }
    }

    class Song
    {
        public string typeList { get; set; }
        public string name { get; set; }
        public string time { get; set; }
    }
}
