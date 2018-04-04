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
            string login = "";
            string password = "";

            try
            {
                Client client = new Client();

                Service.createClient(ref client);

                client.Login = "admin";
                client.Password = "admin";

                while (!client.isBlocked)
                {
                    Console.Clear();

                    Console.Write("Введите логин ");
                    login = Console.ReadLine(); ;
                    Console.Write("Введите пароль ");
                    password = Console.ReadLine();

                    if (login != client.Login && password != client.Password)
                        client.WrongField++;
                    else
                        break;
                }


                //Console.Clear();

                //Console.WriteLine("Menu");
                //Console.WriteLine("Inter login");
                //Login = Console.ReadLine(); ;
                //Console.WriteLine("Inter Password");
                //Password = Console.ReadLine();

                if (login == client.Login && password == client.Password)
                {
                    if (client.isBlocked)
                    {
                        Console.WriteLine("You arr blocked");
                    }
                    else
                    {
                        #region r
                        Console.Clear();
                        Console.WriteLine(" 1 - Список счетов");
                        Console.WriteLine(" 2 - Создать счет");
                        Console.WriteLine(" 3 - Пополнить счет");

                        int menu = 0;
                        Int32.TryParse(Console.ReadLine(), out menu);

                        if (menu > 6 || menu < 1)
                        {
                            throw new Exception("Нет такого пункта меню");
                        }
                        else
                        {
                            switch (menu)
                            {
                                // список счетов
                                case 1:
                                    {
                                        Console.Clear();
                                        client.PrintAccountInfo();
                                    }
                                    break;
                                    // создать счет
                                case 2:
                                    {
                                        Account acc = Service.createAccount();
                                        client.ListAccount.Add(acc);
                                        Console.WriteLine("Счет добавлен успешно!");
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.Write("Введите номер счета: ");
                                        string accountNumber = Console.ReadLine();
                                        Console.Write("Введите сумму: ");
                                        string accountSumm = Console.ReadLine();
                                    }
                                    break;
                                case 6:
                                    return;
                            }
                        }
                        #endregion
                    }
                }
                else
                    Console.WriteLine("You arr blocked");

            }
            catch (Exception)
            {

                throw;
            }
        }

        //List<Client> ListClient = new List<Client>();

        //GeneratorName.Generator g= new Generator();

        //Client c1 = new Client();

        //c1.DoB = DateTime.Now.AddYears(-60);
        //c1.FullName = g.GenerateDefault(Gender.man);
        //c1.IIN = "970131301448";
        //c1.Login = "Qwe";
        //c1.Password = "123";
        //c1.PhoneNumber = "87475458546";

        //ListClient.Add(c1);

        //c1.ClientInfoPrint();
    }
}

