using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace earned_money_accounting_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите что выхотите запустить:\n\n" +
                "Тестовая программа выберите\t\t 1\n\n" +
                "Программа учета финансов выберите\t 2");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1": For_lessons test = new For_lessons(); test.ForTest(); break;
                
                case "2": WorkInAccount account = new WorkInAccount(); account.ChoiseOperation(); break;
                
                default:
                    break;
            }

        }
    }
}
