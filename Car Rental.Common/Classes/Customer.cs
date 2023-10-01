using Car_Rental.Common.Interfaces;


namespace Car_Rental.Common.Classes;

internal class Customer : IPerson
{

    public int SSN { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    public Customer( int ssn, string fName, string lName ) => ( SSN, FName, LName ) = ( ssn, fName, lName );


    
}
