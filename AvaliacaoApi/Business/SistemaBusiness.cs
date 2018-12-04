using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AvaliacaoApi.Business.Interfaces;
using AvaliacaoApi.Data.Interfaces;
using AvaliacaoApi.Models;

namespace AvaliacaoApi.Business
{
    public class SistemaBusiness : ISistemaBusiness
    {
        private ISistemaData _data;

        public SistemaBusiness(ISistemaData data)
        {
            _data = data;
        }
        public List<Premiado> GetPremiados()
        {
            return _data.GetPremiados();
        }
        public Sorteio GetSorteio()
        {
            return _data.GetSorteio();
        }
        public List<Jogo> GetTodos()
        {
            return _data.GetTodos();
        }
        public Jogo AddJogo(Jogo jogo)
        {
            return _data.AddJogo(jogo);
        }
    }

}
