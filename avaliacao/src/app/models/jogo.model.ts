import { Numeros } from './numeros.model';

export class Jogo {
    id?: number;
    dataHora?: Date;
    numeros: Numeros[] = [];
    dataHoraTela?: string;
}
