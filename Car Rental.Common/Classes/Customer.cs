using Car_Rental.Common.Interfaces;


namespace Car_Rental.Common.Classes;

public class Customer : ICustomer
{

    public int SSN { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    public Customer( int ssn, string fName, string lName ) 
        => ( SSN, FName, LName ) = ( ssn, fName, lName );


    
}
