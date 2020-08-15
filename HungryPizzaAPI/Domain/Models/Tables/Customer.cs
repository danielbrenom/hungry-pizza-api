using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizzaAPI.Domain.Models.Tables
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}