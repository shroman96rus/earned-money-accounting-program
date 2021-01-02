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

            //Выбор последующих операций
            string choiseOperation = "";
            while (choiseOperation != "9")
            {
                Console.WriteLine("Выберите операцию:\n\n" +
                "Нажмите 1: для вывода названия созданного аккаунта\n" +
                "Нажмите 2: для ввода новых данных\n" +
                "Нажмите 3: для чтения данных из базы данных\n" +
                "Нажмите 4: для создания XML таблицы из базы данных\n" +
                "Нажмите 5: для создания текстового документа\n" +
                "Нажмите 6: для отображения данных по операциям хранящимся в БД за август\n" +
                "Нажмите 0: для выхода из программы");
                choiseOperation = Console.ReadLine();
                switch (choiseOperation)
                {
                    case "1": buroPerevodov.PrintAccount(); break;
                    case "2": InputNewData(); break;
                    case "3": WorkDataBase db = new WorkDataBase(); db.ReadDB();  break;
                    case "4": CreateTable createDb = new CreateTable(); createDb.CreateXMLForDataBase(); break;
                    case "5": buroPerevodov.CreateText(); break;
                    case "6": WorkDataBase dbW = new WorkDataBase(); dbW.WorkDB(); break;
                    case "0": break;
                    default: Console.WriteLine("Вы ввели неверный номер операции попробуйте снова"); break;
                }

            }
            void InputNewData()
            {
                //выбираем каким образом мы будем получать данные
                
                string change = "";
                while (change != "4")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Выберите хотите ли вы получать информацию из текстового файла, или вводить все даные сами\n" +
                        "Нажмите 1: если хотите получить данные из текстового файла \n" +
                        "Нажмите 2: если хотите вводить данные вручную \n" +
                        "Нажмите 3: вывода истории введенных вами операции на консоль и создания XML таблицы\n" +
                        "Нажмите 4: для записи данных в базу данных\n" +
                        "Нажмите 0: для выхода из меню ввода даных");
                    Console.ResetColor();
                    
                    change = Console.ReadLine();
                    switch (change)
                    {
                        case "1": buroPerevodov.TextRead(); break;
                        case "2": Operation(); break;
                        case "3": buroPerevodov.history(); break;
                        case "4": buroPerevodov.CreateDB(); break;
                        case "0": break;
                        default: Console.WriteLine("Вы ввели некорректное значение"); break;
                    }
                }
                return;
            }

            // выбор операции внесения или снятия денег
            void Operation()
            {
                
                string choiceOperation = "";
                while (choiceOperation != "3")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Нажмите 1: Если вы хотите внести деньги на баланс\n" +
                    "Нажмите 2: Если вы хотите оплатить какие-либо услуги\n" +
                    "Нажмите 3: Для выхода из меню выбора операций");
                    Console.ResetColor();

                    choiceOperation = Console.ReadLine();
                    switch (choiceOperation)
                    {
                        case "1":
                            {
                                Console.WriteLine("введите дату платежа в формате");
                                DateTime date = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Введите сумму платежа");
                                double pay = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Введите коментарий за что платеж");
                                string note = Console.ReadLine();
                                buroPerevodov.PayForWork(date, pay, note);
                                Console.WriteLine("Данные успешно занесены\n");
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
                                Console.WriteLine("Данные успешно занесены\n");
                                break;
                            }
                        case "3": break;

                        default:
                            Console.WriteLine("Запрос непонятен попробуйте ещу раз");
                            break;
                    }
                }
                //Console.WriteLine("Нажмите 1: если вы хотите продолжить вводить операции или Нажмите 2: если хотите закончить");
                //switch (Console.ReadLine())
                //{
                //    case "1": Operation(); break;
                //    case "2": break;
                //    default:
                //        Console.WriteLine("Запрос непонятен попробуйте ещу раз"); Operation();
                //        break;
                //}
            }
            
            
            
            
        }
    }

}

