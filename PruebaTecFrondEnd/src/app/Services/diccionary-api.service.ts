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
  static GetDeleteTienda: string = "api/Tiendas/GetDeleteTienda/";

  //Producto
  static PostCreateProducto: string = "api/Productos/PostCreateProducto/"; 
  static GetProductos: string = "api/Productos/GetProductos/"; 
  static SubirImg: string = "api/Productos/Upload"; 
  static PostUdateProducto: string = "api/Productos/PostUdateProducto"; 
  static DeleteProducto: string = "api/Productos/DeleteProducto/";
  static UpdateUpload: string = "api/Productos/UpdateUpload";
}
