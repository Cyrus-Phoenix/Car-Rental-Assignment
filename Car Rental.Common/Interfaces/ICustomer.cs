using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface ICustomer
    {

        public int SSN { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

    }
}
