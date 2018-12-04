using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AvaliacaoApi.Business.Interfaces;
using AvaliacaoApi.Models;

namespace AvaliacaoApi.Business
{
    public class JogoBusiness : IJogoBusiness
    {

        public string ErrosValidacao { get; set; }
        public string ErrosRequisicao { get; set; }


        public bool ValidarJogo(Jogo jogo)
        {
            var duplicados = jogo.Numeros.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if (duplicados.Count > 0)
            {
                ErrosValidacao = "Existem numeros repetidos no jogo.";
                return false;
            }
            if (jogo.Numeros.Count > 6)
            {
                ErrosValidacao = "A quantidadeo dos numeros do jogo esta acima do total esperado.";
                return false;
            }
            return true;
        }

        public List<string> BuscarNumerosOpcoesPorTipoSorteio(int tipoSorteio)
        {
            List<string> opcoes = new List<string>();
            switch (tipoSorteio)
            {
                case 1: // Mega Sena  60 opções
                    for (var i = 1; i <= 60; i++)
                        opcoes.Add(i.ToString("00"));
                    break;
                case 2: // LotoFacil 
                    for (var i = 1; i <= 25; i++)
                         opcoes.Add(i.ToString("00"));
                    break;
            }
            return opcoes;
        }
    }

}
