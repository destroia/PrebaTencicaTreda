import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tienda } from '../Models/Tienda';
import { DiccionaryApiService } from './diccionary-api.service';
@Injectable({
  providedIn: 'root'
})
export class TiendaServicesService {

  constructor(public http: HttpClient) { }

  GetTiendas(): Observable<Tienda[]> {

    return this.http.get<Tienda[]>(DiccionaryApiService.URL + DiccionaryApiService.GetTiendas);  
  }

  PostCreate(tienda: Tienda): Observable<Tienda>
  {
    return this.http.post<Tienda>(DiccionaryApiService.URL + DiccionaryApiService.PostCreateTienda, tienda);
  }
}
