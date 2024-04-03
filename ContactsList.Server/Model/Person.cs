using ContactsList.Server.Model;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int? SubcategoryId { get; set; }
    public Subcategory Subcategory { get; set; }
    public string MobilePhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
}
