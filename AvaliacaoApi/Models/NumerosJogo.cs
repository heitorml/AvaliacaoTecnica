using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AvaliacaoApi.Models
{
    public class NumerosJogo
    {
        [Key]
        public int? id { get; set; }
        public int Numero { get; set; }
        public int? JogoId { get; set; }
        
        [JsonIgnore]
        public Jogo Jogo { get; set; }
    }
}