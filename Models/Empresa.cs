using System.ComponentModel.DataAnnotations;

namespace api_1.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public string Razao { get; set; }
    }
}