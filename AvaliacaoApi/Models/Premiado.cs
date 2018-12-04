using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliacaoApi.Models
{
    public class Premiado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int? SorteioId { get; set; }
        public Sorteio Sorteio { get; set; }
        public int? JogoPremiadoId { get; set; }
        public Jogo JogoPremiado { get; set; }
        public int Acertos { get; set; }

    }
}