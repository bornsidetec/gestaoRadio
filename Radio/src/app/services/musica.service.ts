import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Musica } from '../models/Musica';

@Injectable({
  providedIn: 'root'
})
export class MusicaService {

  baseUrl = `${environment.mainUrl}/api/musicas`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Musica[]> {
    return this.http.get<Musica[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Musica> {
    return this.http.get<Musica>(`${this.baseUrl}/${id}`);
  }

  getByInterpreteId(id: number): Observable<Musica[]> {
    return this.http.get<Musica[]>(`${this.baseUrl}/ByInterprete/${id}`);
  }

  post(musica: Musica) {
    return this.http.post(`${this.baseUrl}`, musica);
  }

  put(musica: Musica) {
    return this.http.put(`${this.baseUrl}/${musica.id}`, musica);
  }

  delete(id: number): Observable<Musica> {
    return this.http.delete<Musica>(`${this.baseUrl}/${id}`);
  }

}
