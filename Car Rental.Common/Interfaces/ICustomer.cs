using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface ICustomer
    {
        public int Id { get; }

        public int SocialSecurityNumber { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; } 

    }
}
