using Car_Rental.Common.Interfaces;


namespace Car_Rental.Common.Classes;

public class Customer : ICustomer
{
    public int Id { get; set; }

    
    public string SocialSecurityNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    
    public Customer() { }
    public Customer( int id, string ssn, string fName, string lName ) 
        => ( Id, SocialSecurityNumber, FirstName, LastName ) = (id, ssn, fName, lName );


    
}
