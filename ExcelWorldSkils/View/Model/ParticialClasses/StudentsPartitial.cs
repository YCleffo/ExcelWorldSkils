using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWorldSkils.View.Model
{
    public partial class Students
    {
        public string FIO
        {
            get
            {
                return FiestName + " " + LastName + " " + PatronomicName;
            }
        }

    }
}
