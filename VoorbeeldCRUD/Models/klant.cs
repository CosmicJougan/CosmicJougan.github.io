using System.ComponentModel.DataAnnotations;

namespace VoorbeeldCRUD.Models
{
    public class klant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht veld")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Verplicht veld")]
        public double? Saldo { get; set; }
    }
}
