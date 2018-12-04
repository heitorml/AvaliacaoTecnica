using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoApi.Models;

namespace AvaliacaoApi.Data.Interfaces
{
    public interface ISistemaData
    {
        List<Premiado> GetPremiados();
        Sorteio GetSorteio();
        List<Jogo> GetTodos();
        Jogo AddJogo(Jogo jogo);

    }
}
