using Car_Rental.Common.Interfaces;


namespace Car_Rental.Common.Classes;

public class Customer : ICustomer
{
    public int Id { get; set; }

    //TODO : EJ VIKTIG, Ändra den till sträng eller kanske datetime för att slippa omvandla från int till string för formateringens skull. Fråga Jonas om var omvandlingen skall ske
    public string SocialSecurityNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    
    public Customer() { }
    public Customer( int id, string ssn, string fName, string lName ) 
        => ( Id, SocialSecurityNumber, FirstName, LastName ) = (id, ssn, fName, lName );


    
}
