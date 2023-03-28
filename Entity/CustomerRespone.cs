using System.ComponentModel.DataAnnotations;

namespace Demo_DevOps.Entity
{
    public class CustomerRespone
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
