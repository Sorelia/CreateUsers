using System;

namespace CreateUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;

            while (i == 1)
            {
                Console.WriteLine("Write a username");
                string username = Console.ReadLine();
                Console.WriteLine("Write password");
                string pass = Console.ReadLine();
                CUser user = CUser.Create(username, pass);
                Conn.InsertIntoDB(user);
                Console.ReadKey();
            }
        }
    }
}
