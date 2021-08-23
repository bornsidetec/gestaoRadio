import { MusicasInterpretes } from "./MusicasInterpretes";

export class Musica {
    constructor() {
        this.id = 0,
        this.nome = '',
        this.ano = 0,
        this.estilo = 0,
        this.tempo = 0, 
        this.musicasInterpretes = []
    }    
    id: number;
    nome: string;
    ano: number;
    estilo: number;
    tempo: number;
    musicasInterpretes: MusicasInterpretes[] = [];
}
