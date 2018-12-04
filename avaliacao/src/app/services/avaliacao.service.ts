import { Injectable } from '@angular/core';
import { Jogo } from '../models/jogo.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Premiado } from '../models/premiado.model';

@Injectable()
export class AvaliacaoService {
  url = 'http://localhost:5000/api/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };
  constructor(
    private httpClient: HttpClient,
  ) { }

  AddJogo(jogo: Jogo): Observable<Jogo> {
    return this.httpClient.post<Jogo>(this.url + 'Jogo', JSON.stringify(jogo), this.httpOptions);
  }
  GerarSorteio(): Observable<number[]> {
    return this.httpClient.get<number[]>(this.url + 'GerarSorteio');
  }

  CarregarNumeroOpcoes(tipoSorteio: number): Observable<number[]> {

    return this.httpClient.get<number[]>(this.url + `GetNumerosOpcoes/${tipoSorteio}`);
  }

  BuscarJogosInseridos(): Observable<number[]> {
    return this.httpClient.get<number[]>(this.url + 'Jogos');
  }
  BuscarPremiados(): Observable<Premiado[]> {
    return this.httpClient.get<Premiado[]>(this.url + 'GetPremiados');
  }

}
