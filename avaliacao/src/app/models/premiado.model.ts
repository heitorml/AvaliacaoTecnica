import { Sorteio } from './sorteio.model';
import { Jogo } from './jogo.model';

export class Premiado {
    id ?: number;
    acertos: number;
    jogoPremiado: Jogo;
    jogoPremiadoId?: number;
    sorteio: Sorteio;
    sorteioId?: number;
}
