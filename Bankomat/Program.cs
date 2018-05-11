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
                    #region

                    Console.Clear();
                    Console.Write("введите логин:");
                    login = Console.ReadLine();
                    Console.Write("введите пароль:");
                    password = Console.ReadLine();

                    if (login != client.Login && password != client.Password)
                    {
                        client.WrongField++;
                        Console.WriteLine("Неверный пароль. У вас есть {0} попытки", client.WrongField);
                        Console.ReadKey();
                    }
                    else
                        break;
                    #endregion
                }

                if (login == client.Login && password == client.Password)
                {
                    #region
                    if (client.isBlocked)
                    {
                        Console.WriteLine("Пользователь заблокирован!");
                    }
                    else
                    {
                        #region 
                        Console.Clear();
                        Console.WriteLine("1. Список счетов");
                        Console.WriteLine("2. Создать счет");
                        Console.WriteLine("3. Пополнить счёт");
                        Console.WriteLine("4. Снять деньги со счета");
                        Console.WriteLine("6. Выход");

                        int menu = 0;
                        Int32.TryParse(Console.ReadLine(), out menu);
                        if (menu > 6 || menu < 1)
                        {
                            throw new Exception("Нет такого пункта в меню");
                        }
                        else
                        {
                            switch (menu)
                            {
                                //Список счетов
                                case 1:
                                    {
                                        Console.Clear();
                                        client.PrintAccountInfo();
                                    }
                                    break;
                                //Создать счет
                                case 2:
                                    {
                                        Console.Clear();
                                        Account acc = Service.createAccount();
                                        client.ListAccount.Add(acc);
                                        Console.WriteLine("Счёт добавлен успешно!");
                                    }
                                    break;
                                //Пополнить счёт
                                case 3:
                                    {
                                        Console.WriteLine("Введите номер счёта: ");
                                        string accountNumber = Console.ReadLine();
                                        Console.WriteLine("Введите сумму ");
                                        string acconutSum = Console.ReadLine();
                                    }
                                    break;
                                //Снять деньги со счета
                                case 4:
                                    {
                                        Console.WriteLine("Введите номер счёта: ");
                                        string accountNumber = Console.ReadLine();
                                        Console.WriteLine("Введите сумму");
                                        string accountSum = Console.ReadLine();
                                        try
                                        {
                                            foreach (var item in client.ListAccount)
                                            {
                                                if (item.AccountNumber == accountNumber)
                                                {
                                                    if (double.Parse(accountSum) > item.Balance)
                                                    {
                                                        Console.WriteLine("Сумма, введенная вами, выше, чем существует в аккаунте");
                                                    }
                                                    else
                                                    {
                                                        item.Balance -= double.Parse(accountSum);
                                                        Console.WriteLine("Сумма {0} успешна переведена на счёт {1}", accountSum, accountNumber);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                        int choice = 0;
                                        Console.WriteLine("Введите число для продолжения или 0 для выхода");
                                        Int32.TryParse(Console.ReadLine(), out choice);
                                        if (choice == 0)
                                            return;
                                        else
                                            break;
                                    }
                                case 6: return;
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Пользователь заблокирован");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}