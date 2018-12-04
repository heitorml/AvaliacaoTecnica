using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoApi.Data.Interfaces;
using AvaliacaoApi.Models;
using AvaliacaoApi.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AvaliacaoApi.Data
{
    public class SistemaData : BaseData, ISistemaData
    {
        public SistemaData(ApiContext context,
            IConfiguration configuration) : base(configuration)
        {
            _ApiContext = context;
        }

        public Jogo AddJogo(Jogo jogo)
        {
            jogo.DataHora = DateTime.Now;
            _ApiContext.Jogos.Add(jogo);
            _ApiContext.SaveChanges();
            return jogo;
        }

        public List<Jogo> GetTodos()
        {
            var retorno = _ApiContext.Jogos.Include(n => n.Numeros).ToList();
            return retorno;
        }


        public Sorteio GetSorteio()
        {
            var sorteio = new Sorteio();
            Random randNum = new Random();
            sorteio.Numeros = new List<NumerosSorteio>();
            for (int i = 0; i <= 5; i++)
            {
                var numero = new NumerosSorteio();
                numero.Numero = randNum.Next(1, 60);
                var teste = sorteio.Numeros.Where(n => n.Numero.Equals(numero.Numero)).FirstOrDefault();
                if (teste == null)
                    sorteio.Numeros.Add(numero);
                else
                    i--;
            }
            sorteio.DataHora = DateTime.Now;
            _ApiContext.Sorteios.AddAsync(sorteio);
            _ApiContext.SaveChangesAsync();
            return sorteio;
        }
        public List<Premiado> GetPremiados()
        {
            var sorteio = _ApiContext.Sorteios.Include(n => n.Numeros).FirstOrDefault();
            var jogos = _ApiContext.Jogos.Include(n => n.Numeros).ToList();
            var premiados = new List<Premiado>();
            foreach (var item in jogos)
            {
                int acertos = 0;
                foreach (var numero in item.Numeros)
                {
                    var teste = sorteio.Numeros.Where(n => n.Numero == numero.Numero).FirstOrDefault();
                    acertos = teste != null ? acertos + 1 : acertos;
                }
                if (acertos > 4)
                {
                    var apostaPremiada = new Premiado();
                    apostaPremiada.Sorteio = sorteio;
                    apostaPremiada.JogoPremiado = item;
                    apostaPremiada.Acertos = acertos;
                    apostaPremiada.JogoPremiadoId = item.Id;
                    apostaPremiada.SorteioId = sorteio.Id;
                    premiados.Add(apostaPremiada);
                }
            }
            return premiados;
        }
    }

}
