Fájlból olvasás

- using System
  
- using System.IO

- using System.Collections.Generic

      class Program
        {
        // Egyszerű osztály az adatok tárolására
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main()
        {
            string filePath = "adatok.csv";  // A beolvasandó fájl neve
            if (!File.Exists(filePath))
        {
            Console.WriteLine("A fájl nem található: " + filePath);
            return;
        }
        List<Person> people = new List<Person>();
        // Fájl soronkénti beolvasása
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(',');
            if (parts.Length == 2 && int.TryParse(parts[1], out int age))
            {
                people.Add(new Person { Name = parts[0], Age = age });
            }
        }
        // Kiírás a konzolra
        foreach (var person in people)
        {
            Console.WriteLine($"Név: {person.Name}, Kor: {person.Age}");
        }
        }
        }
Adatbázisból olvasás
-    using System;
-    using System.Collections.Generic;
-    using MySql.Data.MySqlClient;

    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    
        static void Main()
        {
            string connectionString = "server=localhost;user=root;password=yourpassword;database=yourdatabase";
    
            List<Person> people = new List<Person>();
    
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
    
                string sql = "SELECT name, age FROM people";
    
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString("name");
                            int age = reader.GetInt32("age");
    
                            people.Add(new Person { Name = name, Age = age });
                        }
                    }
                }
            }
    
            foreach (var person in people)
            {
                Console.WriteLine($"Név: {person.Name}, Kor: {person.Age}");
            }
        }
    }
