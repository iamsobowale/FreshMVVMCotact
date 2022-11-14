using System;

namespace ContactUsingFreshMvvm.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
    }
    
}