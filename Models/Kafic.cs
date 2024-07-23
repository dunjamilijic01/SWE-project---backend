using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Kafic")]
    public class Kafic
    {
        [Key]
        public int ID { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }
         [Required]
        [MaxLength(70)]
        public string Lokacija { get; set; }
        [Required]
        [MaxLength(50)]
        public string RadnoVreme { get; set; }
        [Required]
        public bool VrseRezervacije { get; set; }
        [MaxLength(500)]
        public int BrojMesta { get; set; }
        [Range(0,5)]
        public double srednjaOcena { get; set; }
        public int BrojStolova { get; set; }

        [MaxLength(15)]
        public string BrojTelefona { get; set; }
        [MaxLength(30)]
        public string Instagram { get; set; }
        [MaxLength(50)]
        public string Facebook { get; set; }

        public List<KaficSlike> slike { get; set; }
        [JsonIgnore]
        public List<Sto> Stolovi { get; set; }
        [JsonIgnore]
        public List<Dogadjaj> Dogadjaji { get; set; }
        [JsonIgnore]
        public List<Komentar> Komentari { get; set; }
        [JsonIgnore]
        public List<Radnik> Radnici { get; set; }
        [JsonIgnore]
        public List<Rezervacija> Rezervacije { get; set; }

 
    }
}