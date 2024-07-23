using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models
{
    [Table("Sto")]
    public class Sto
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Range(1,50)]
        public int BrojLjudi { get; set; }
        public bool display { get; set; }
        public bool Zauzet { get; set; }
        public bool Slobodan { get; set; }

        public List<Rezervacija> Rezervacija { get; set; }
        
        [ForeignKey("KaficID")]
        public Kafic Kafic { get; set; }
    }
}