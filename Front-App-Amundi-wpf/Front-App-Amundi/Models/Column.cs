using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front_App_Amundi.Models
{
    public class Column
    {
        public Column(string initialColumn,string modifyColumn)
        {
            this.initialColumn = initialColumn;
            this.modifyColumn = modifyColumn;
        }
        public string initialColumn { get; set; }
        public string modifyColumn { get; set; }

    }
}
