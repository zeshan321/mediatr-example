using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace before.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
