using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("KaficSlike")]
    public class KaficSlike
    {
       [Key]
        public int ID { get; set; }
       [Required]
       [MaxLength(100)]
       public string url{get; set;}
    [JsonIgnore]
        public Kafic Kafic { get; set; }
    }
    
}