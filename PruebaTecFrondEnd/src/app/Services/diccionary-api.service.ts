import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DiccionaryApiService {

  constructor() { }

  //URL
  static URL: string = "https://localhost:44324/";

  //Tiendas
  static GetTiendas: string = "api/Tiendas/GetTiendas/";

  static PostCreateTienda: string = "api/Tiendas/PostCreateTienda/";
}
