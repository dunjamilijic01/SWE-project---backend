using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Rezervacija")]
    public class Rezervacija
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [MaxLength(10)]
        [Required]
        public String VremeIsteka { get; set; }

        [MaxLength(10)]
        [Required]
        public String ZakazanoVreme { get; set; }

        [Required]
        public bool Obradjen { get; set; }

        [JsonIgnore]
        public Posetilac Posetilac { get; set; }
        [JsonIgnore]

        [ForeignKey("StoFK")]
        public Sto Sto { get; set; }
        public Kafic Kafic { get; set; }
        
        
    }
}