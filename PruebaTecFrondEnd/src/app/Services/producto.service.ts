import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Producto } from '../Models/Producto';
import { DiccionaryApiService } from './diccionary-api.service';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http: HttpClient) { }

  GetProductos(id: String): Observable<Producto[]>
  {
    return this.http.get<Producto[]>(DiccionaryApiService.URL + DiccionaryApiService.GetProductos + id);
  }

  GetDeleteProducto(id: String): Observable<boolean> {
    return this.http.get<boolean>(DiccionaryApiService.URL + DiccionaryApiService.DeleteProducto + id);
  }
  PostCreareProducto(producto: Producto): Observable<Producto>
  {
    return this.http.post<Producto>(DiccionaryApiService.URL + DiccionaryApiService.PostCreateProducto, producto);
  }
  PostImagen(imagen: File) {

    let formData = new FormData();
    formData.append("imagen", imagen);
    this.http.post(DiccionaryApiService.URL + DiccionaryApiService.SubirImg, formData);
  }
  PostUpdateProducto(producto: Producto): Observable<boolean> {
    return this.http.post<boolean>(DiccionaryApiService.URL + DiccionaryApiService.PostUdateProducto, producto);
  }

}
