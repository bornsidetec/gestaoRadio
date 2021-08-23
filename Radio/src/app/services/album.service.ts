import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Album } from '../models/Album';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  baseUrl = `${environment.mainUrl}/api/albuns`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Album[]> {
    return this.http.get<Album[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Album> {
    return this.http.get<Album>(`${this.baseUrl}/${id}`);
  }

  getByInterpreteId(id: number): Observable<Album[]> {
    return this.http.get<Album[]>(`${this.baseUrl}/ByInterprete/${id}`);
  }  

  post(album: Album) {
    return this.http.post(`${this.baseUrl}`, album);
  }

  put(album: Album) {
    return this.http.put(`${this.baseUrl}/${album.id}`, album);
  }

  delete(id: number): Observable<Album> {
    return this.http.delete<Album>(`${this.baseUrl}/${id}`);
  }

}
