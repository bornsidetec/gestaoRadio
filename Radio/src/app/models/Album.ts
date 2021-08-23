import { AlbunsInterpretes } from "./AlbunsInterpretes";

export class Album {
    constructor() {
        this.id = 0,
        this.nome = '',  
        this.ano = 0,
        this.imagem = '',
        this.albunsInterpretes = []        
    }
    id: number;
    nome: string;
    ano: number;
    imagem: string;
    albunsInterpretes: AlbunsInterpretes[];
}
