using KKB.Bank.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Bankomat
{
    class Service
    {
        private static Random rand = new Random();
        public static void createClient(ref Client client)
        {
            Generator gen = new Generator();
            client.FullName = gen.GenerateDefault(Gender.woman);
            client.IIN = "860905300951";
            client.PhoneNumber = "7772798927";
            client.DoB = DateTime.Now;

            for (int i = 0; i < rand.Next(1, 8); i++)
            {
                client.ListAccount.Add(createAccount());
            }
        }

        
        public static Account createAccount ()
        {
            
            Account acc = new Account();

            acc.AccountNumber = "KZ" + rand.Next(11111, 120000);
            acc.Balance = double.Parse(rand.Next(1000, 9999).ToString());
            acc.CreateDate = DateTime.Now.AddMonths(-rand.Next(1, 56));

            return acc;       
        }
    }
}
