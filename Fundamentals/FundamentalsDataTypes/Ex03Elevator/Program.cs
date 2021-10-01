using System;

namespace Ex03Elevator
{
    class Program
    {
        static void Main()
        {
            //Calculate how many courses will be needed to elevate n persons by using an elevator of capacity of p persons.
            //The input holds two lines: the number of people n and the capacity p of the elevator.

            int peopleCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int elevatorCourses = (int)Math.Ceiling((double)peopleCount / elevatorCapacity);
            Console.WriteLine(elevatorCourses);
        }
    }
}
