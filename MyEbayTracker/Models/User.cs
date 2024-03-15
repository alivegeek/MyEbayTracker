using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<UserItemInterest> UserItemInterests { get; set; }
}