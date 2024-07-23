using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Dogadjaj")]
    public class Dogadjaj
    {
       [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public String VrstaDogadjaja { get; set; }
        [Required]
        [MaxLength(100)]
        public String Naziv { get; set; }
        [MaxLength(300)]
        public String Opis { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        [MaxLength(50)]
        public string Vreme { get; set; }
        [JsonIgnore]
        public Kafic Kafic { get; set; }
    }
    
}