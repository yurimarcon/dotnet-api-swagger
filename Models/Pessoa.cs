using System.ComponentModel.DataAnnotations;

namespace api_1.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public int idade { get; set; }
    }
}