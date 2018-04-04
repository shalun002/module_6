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
        public static void createClient(ref Client client)
        {
            Generator gen = new Generator();
            client.FullName = gen.GenerateDefault(Gender.woman);
            client.IIN = "860905300951";
            client.PhoneNumber = "7772798927";
            client.DoB = DateTime.Now;
        }
    }
}
