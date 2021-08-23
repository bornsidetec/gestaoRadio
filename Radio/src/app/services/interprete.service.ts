import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Interprete } from 'src/app/models/Interprete';

@Injectable({
  providedIn: 'root'
})
export class InterpreteService {

  baseUrl = `${environment.mainUrl}/api/interpretes`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Interprete[]> {
    return this.http.get<Interprete[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Interprete> {
    return this.http.get<Interprete>(`${this.baseUrl}/${id}`);
  }

  getByMusicaId(id: number): Observable<Interprete[]> {
    return this.http.get<Interprete[]>(`${this.baseUrl}/ByMusica/${id}`);
  }  

  getByAlbumId(id: number): Observable<Interprete[]> {
    return this.http.get<Interprete[]>(`${this.baseUrl}/ByAlbum/${id}`);
  }  

  post(interprete: Interprete) {
    return this.http.post(`${this.baseUrl}`, interprete);
  }

  put(interprete: Interprete) {
    return this.http.put(`${this.baseUrl}/${interprete.id}`, interprete);
  }

  delete(id: number): Observable<Interprete> {
    return this.http.delete<Interprete>(`${this.baseUrl}/${id}`);
  }

}
