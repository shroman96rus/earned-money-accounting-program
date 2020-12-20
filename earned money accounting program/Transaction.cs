using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earned_money_accounting_program
{
    class Transaction
    {
        //Оюьявление переменных (комент к операции, сумма операции, дата операции)
        public string operationСomment { get; }
        public double summaOperation { get; }
        public DateTime dateOperation { get; }

        //Создаем конструктор
        public Transaction(DateTime dateOperation, double summaOperation, string operationСomment)
        {
            this.dateOperation = dateOperation;
            this.summaOperation = summaOperation;
            this.operationСomment = operationСomment;
        }


    }
}
