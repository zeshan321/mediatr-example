using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace before.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public double Cost { get; set; }
        public DateTimeOffset ShippedDate { get; set; } = DateTimeOffset.UtcNow;
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}
