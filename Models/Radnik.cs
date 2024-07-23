using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Radnik : AppUser
    {
        [MaxLength(30)]
        [Required]
        public string Pozicija { get; set; }

        [Required]
        public bool Vlasnik { get; set; }
        public int KaficId { get; set; }
        [JsonIgnore]
        public Kafic Kafic { get; set; }

    }
}