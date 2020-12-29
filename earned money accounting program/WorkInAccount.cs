using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earned_money_accounting_program
{
    class WorkInAccount
    {
        public void ChoiseOperation()
        {
            //Создание объекта класса Account
            Account buroPerevodov = new Account("Бюро переводов");

            //выбираем каким образом мы будем получать данные
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Выберите хотите ли вы получать информацию из текстового файла, или вводить все даные сами\n" +
                "Выберите 1: если хотите получить данные из текстового файла \tНажмите 2: если хотите вводить данные вручную");
            Console.ResetColor();

            switch (Console.ReadLine())
            {
                case "1":  buroPerevodov.TextRead(); break;
                case "2": Operation(); break;
                default: Console.WriteLine("Вы ввели некорректное значение"); break;
            }

            // выбор операции внесения или снятия денег
            void Operation()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Если вы хотите внести деньги на баланс напишите 1\n" +
                "Если вы хотите оплатить какие-либо услуги напишите 2\n");
                Console.ResetColor();

                string choiceOperation = Console.ReadLine();

                switch (choiceOperation)
                {
                    case "1":
                        {
                            Console.WriteLine("введите дату платежа в формате (ГГГГ,ММ,ДД)");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Введите сумму платежа");
                            double pay = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите коментарий за что платеж");
                            string note = Console.ReadLine();
                            buroPerevodov.PayForWork(date, pay, note);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("введите дату платежа за услугу в формате (ГГГГ,ММ,ДД)");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Введите сумму платежа за услугу");
                            double pay = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите коментарий за что платеж");
                            string note = Console.ReadLine();
                            buroPerevodov.PaymentForWork(date, pay, note);
                            break;
                        }

                    default:
                        Console.WriteLine("Запрос непонятен попробуйте ещу раз"); Operation();
                        break;
                }
                Console.WriteLine("Выберите 1 если вы хотите продолжить вводить операции или 2 если хотите закончить");
                switch (Console.ReadLine())
                {
                    case "1": Operation(); break;
                    case "2": break;
                    default:
                        Console.WriteLine("Запрос непонятен попробуйте ещу раз"); Operation();
                        break;
                }
            }
            
            string choiseOperation = "";
            while (choiseOperation != "4")
            {
                Console.WriteLine("Выберите операцию:\n" +
                "Нажмите 1: для вывода названия созданного аккаунта\tНажмите 2: для вывода истории " +
                "операции на консоль, создания XML таблицы, а также создания текстового документа" +
                "\tНажмите 3: для записи данных в базу данных\n" +
                "Нажмите 4: для выхода");
                choiseOperation = Console.ReadLine();
                switch (choiseOperation)
                {
                    case "1": buroPerevodov.PrintAccount(); break;
                    case "2": buroPerevodov.history(); break;
                    case "3": buroPerevodov.CreateDB(); break;
                    case "4": break;
                    default: Console.WriteLine("Вы ввели неверный номер операции попробуйте снова"); break;
                }

            }
            
            
        }
    }

}

