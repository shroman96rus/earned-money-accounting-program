using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;



namespace earned_money_accounting_program
{
    public class UserContext : DbContext
    {
        public UserContext() : base ("DbConnection")
        {
        }

        public DbSet<Transaction> Transactions { get; set; }




    }
}
