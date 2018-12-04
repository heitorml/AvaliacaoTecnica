import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

/**
 * Dados de configuração do sistema.
 */
@Injectable()
export class AppConfig {
  readonly title: string = `Mega Sena - Sistema de Simulação de Sorteios ${environment.production ? '' : ' [dev]'}`;
  readonly version: string = '1.0.0';
}
