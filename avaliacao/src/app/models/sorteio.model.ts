import { Numeros } from './numeros.model';

export class Sorteio {
    id?: number;
    dataHora?: Date;
    numeros: Numeros[] = [];
    dataHoraTela?: string;
}
