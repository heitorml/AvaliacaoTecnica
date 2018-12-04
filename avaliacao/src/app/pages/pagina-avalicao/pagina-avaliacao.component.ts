import { Component, OnInit } from '@angular/core';
import { Jogo } from 'src/app/models/jogo.model';
import { NgForm } from '@angular/forms';
import { AvaliacaoService } from 'src/app/services/avaliacao.service';
import { Numeros } from 'src/app/models/numeros.model';
import { Premiado } from 'src/app/models/premiado.model';

@Component({
  selector: 'app-pagina-avaliacao',
  templateUrl: './pagina-avaliacao.component.html',
  styleUrls: ['./pagina-avaliacao.component.css']
})
export class PaginaAvaliacaoComponent implements OnInit {
  jogo: Jogo = new Jogo();
  jogos: Jogo[] = [];
 // premiados: Jogo[] = [];
  numeros: any[] = [];
  sorteio: number[] = [];
  numeroMaximo: number;
  mensagem: string;
  premiados: Premiado[] = [];
  constructor(
    private avaliacaoService: AvaliacaoService,
  ) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.avaliacaoService.CarregarNumeroOpcoes(1).subscribe(o => {
      this.numeros = o;
    });
  }
  addNumero(numero: number) {
    if (this.validarNumeros(numero, 1)) {
      const numeroEscolhido: Numeros = new Numeros();
      numeroEscolhido.numero = numero;
      this.jogo.numeros.push(numeroEscolhido);
    }
  }

  ApostaAutomatica() {
    this.jogo.numeros = [];
    for (let _i = 0; this.jogo.numeros.length <= 5; _i++) {
      const numeroEscolhido: Numeros = new Numeros();
      numeroEscolhido.numero = Math.floor(Math.random() * 60 + 1);
      if (this.validarNumeros(numeroEscolhido.numero, 2)) {
        this.jogo.numeros.push(numeroEscolhido);
      } else { _i--; }
    }
  }

  GerarSorteio() {
    this.sorteio = [];
    this.avaliacaoService.GerarSorteio().subscribe(s => {
      this.sorteio = s;
    });
  }

  BuscarPremiados() {
    this.premiados = [];
    this.avaliacaoService.BuscarPremiados().subscribe(p => {
        p.forEach( pr => {
           const premiado = new Premiado();
           premiado.jogoPremiado = pr.jogoPremiado;
           premiado.jogoPremiado.dataHoraTela = new Date(pr.jogoPremiado.dataHora).toLocaleString();
           premiado.sorteio = pr.sorteio;
           premiado.sorteioId = pr.sorteioId;
           premiado.jogoPremiadoId = pr.jogoPremiadoId;
           premiado.acertos = pr.acertos;
           this.premiados.push(premiado);
        });
    });
  }
  EnviarAposta(jogo: Jogo) {
    this.avaliacaoService.AddJogo(jogo).subscribe(response => {
      response.dataHoraTela = new Date(response.dataHora).toLocaleString();
      this.jogos.push(response);
      this.jogo = new Jogo();
      alert('Salvo em memoria');
    },
      error => {
        throw error;
      });
  }

  LimparNumeros() {
    this.jogo = new Jogo();
  }
  LimparSorteio() {
    this.sorteio = [];
  }

  validarNumeros(numero: number, origem: number): any {
    if (this.jogo.numeros.filter(n => n.numero === numero).length > 0) {
      if (origem === 1) {
        this.mensagem = 'O jogo já Possuí o número selecionado';
        alert(this.mensagem);
        return false;
      }
      return false;
    }
    if (this.jogo.numeros.length === 6) {
      if (origem === 1) {
        this.mensagem = 'O jogo já Possuí 6 números';
        alert(this.mensagem);
        return false;
      }
      return false;
    }
    return true;
  }
}
