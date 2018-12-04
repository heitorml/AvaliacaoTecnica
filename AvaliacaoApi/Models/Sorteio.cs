using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliacaoApi.Models
{
    public class Sorteio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public DateTime? DataHora { get; set; }
        public List<NumerosSorteio> Numeros { get; set; }
        
    }
}