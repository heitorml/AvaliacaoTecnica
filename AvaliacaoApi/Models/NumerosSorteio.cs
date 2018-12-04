using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AvaliacaoApi.Models
{
    public class NumerosSorteio
    {
        [Key]
        public int? id { get; set; }
        public int Numero { get; set; }
        public int? SorteioId { get; set; }
        
        [JsonIgnore]
        public Sorteio Sorteio { get; set; }
    }
}