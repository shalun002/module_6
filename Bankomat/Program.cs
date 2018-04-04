using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
using KKB.Bank.Module;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter yuor login: ");
                string login = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                if (login == "admin" && password == "admin")
                {
                    Client client = new Client();

                    Service.createClient(ref client);

                    client.Login = "admin";
                    client.Password = "admin";

                    Console.Clear();
                    Console.WriteLine("1. Список счетов");
                    Console.WriteLine("2. Создать счет");

                    int choise = 0;

                    Int32.TryParse(Console.ReadLine(), out choise);

                    if (choise > 2 || choise < 1)
                    {
                        throw new Exception("Invalid choise");
                    }
                    else
                    {
                        switch (choise)
                        {
                            case 1: { } break;
                            case 2: { } break;
                        }
                    }
                }
                else
                {
                    throw new Exception("Login or password ERROR");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Client> ListClient = new List<Client>();

            GeneratorName.Generator g= new Generator();

            Client c1 = new Client();

            c1.DoB = DateTime.Now.AddYears(-60);
            c1.FullName = g.GenerateDefault(Gender.man);
            c1.IIN = "970131301448";
            c1.Login = "Qwe";
            c1.Password = "123";
            c1.PhoneNumber = "87475458546";

            ListClient.Add(c1);

            c1.ClientInfoPrint();
        }
    }
}
