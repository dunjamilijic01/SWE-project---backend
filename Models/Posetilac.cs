using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    
    public class Posetilac: AppUser
    {
        public DateTime DatumRodjenja { get; set; }

        public List<Rezervacija> Rezervacije { get; set; }

        public List<Komentar> Komentari { get; set; }
    }
}