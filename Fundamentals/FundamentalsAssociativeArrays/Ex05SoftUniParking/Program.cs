using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05SoftUniParking
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string commandItem = command[0];

                if (commandItem== "register")
                {
                    string username = command[1];
                    string carPlate = command[2];
                    RegisterVehicle(parking, username, carPlate);
                }

                if (commandItem== "unregister")
                {
                    string username = command[1];
                    UnregisterVehicle(parking, username);
                }
            }

            PrintDictionary(parking);
        }

        private static void PrintDictionary(Dictionary<string, string> parking)
        {
            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");

            }
        }

        private static Dictionary<string,string> UnregisterVehicle(Dictionary<string, string> parking, string username)
        {
            if (parking.ContainsKey(username))
            {
                parking.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }
            else
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            return parking;
        }

        private static Dictionary<string,string> RegisterVehicle(Dictionary<string, string> parking, string username, string carPlate)
        {
            if (parking.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {carPlate}");
            }
            else
            {
                parking.Add(username, carPlate);
                Console.WriteLine($"{username} registered {carPlate} successfully");
            }
            return parking;
        }
    }
}
