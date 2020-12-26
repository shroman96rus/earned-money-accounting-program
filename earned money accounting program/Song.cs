using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earned_money_accounting_program
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GropeId { get; set; }

        public virtual Group Group { get; set; }
    }
    

}
