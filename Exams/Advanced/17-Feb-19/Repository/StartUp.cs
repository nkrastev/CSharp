﻿using System;

namespace Repository
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            repository.Add(new Person("George", 10, new DateTime(2009, 05, 04)));
            repository.Add(new Person("Peter", 5, new DateTime(2014, 05, 24)));

            Person foundPerson = repository.Get(0);
            Console.WriteLine($"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");
            //George is 10 years old (04/05/2009)

            Person newPerson = new Person("John", 12, new DateTime(2007, 2, 3));
            Console.WriteLine(repository.Update(2, newPerson)) ; // false
            Console.WriteLine(repository.Update(0, newPerson));  // true

            foundPerson = repository.Get(0);
            Console.WriteLine($"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");
            //John is 12 years old (03/02/2007)

            Console.WriteLine(repository.Count); // 2

            Console.WriteLine(repository.Delete(5)); // false
            Console.WriteLine(repository.Delete(0));
            //repository.Delete(0); // true

            Console.WriteLine(repository.Count); // 1


        }
    }
}
