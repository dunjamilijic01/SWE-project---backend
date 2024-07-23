using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Komentar")]
    public class Komentar
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        [Range(0,5)]
        public int Ocena { get; set; }
        [MaxLength(300)]
        public String TextKomentara { get; set; }
        public int PosetilacId { get; set; }
        public Posetilac Posetilac { get; set; }
        [JsonIgnore]
        public Kafic Kafic { get; set; }
        
    }
}