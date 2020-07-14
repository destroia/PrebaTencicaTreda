import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductoService } from '../Services/producto.service';
import { Producto } from '../Models/Producto';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { DiccionaryApiService } from '../Services/diccionary-api.service';

@Component({
  selector: 'app-tienda',
  templateUrl: './tienda.component.html',
  styleUrls: ['./tienda.component.css']
})
export class TiendaComponent implements OnInit {
  
  productos: Producto[];

  nom: string = "";
  valor: number = 0;
  descrip: string = "";
  fecha: string ="";

  TiendaId: string = "";
  tiendaNom: string = "";
  constructor(private route: ActivatedRoute, private router: Router, private serviceP: ProductoService, private http: HttpClient) {
    
    this.route.queryParams.subscribe(params => {
      this.TiendaId = params["Id"];
      this.tiendaNom = params["nombreTi"];
    });
    this.formData = null;
    this.GetProductos();
  }

  ngOnInit(): void {
  }
  Productos: Producto[];
  ConfirmarInit(x: Producto[]) {
    console.log(x);
    this.Productos = x; 

  }
  pro: any = {};
  CreatePor() {
    
    if (this.nom.length >= 4 && this.valor >= 1000 && this.descrip.length >= 10 && this.fecha != "") {

      
      this.pro.nombre = this.nom;
      this.pro.descripcion = this.descrip;
      this.pro.valor = this.valor;
      this.pro.fecha = this.fecha;
      this.pro.tiendaId = this.TiendaId;
      
      this.formData.append('producto', JSON.stringify(this.pro));

      this.http.post(DiccionaryApiService.URL + DiccionaryApiService.SubirImg, this.formData, { reportProgress: true, observe: 'events' })
        .subscribe(event => {
          if (event.type === HttpEventType.UploadProgress)
            this.progress = Math.round(100 * event.loaded / event.total);
          else if (event.type === HttpEventType.Response) {
            this.message = 'Upload success.';
            this.serviceP.GetProductos(this.TiendaId).subscribe(x => { this.ConfirmarInit(x) }, e => console.log(e));
            this.onUploadFinished.emit(event.body);
          }
        });
      this.formData = null;
      this.nom ="";
      this.descrip ="";
      this.valor =0;
      this.fecha = "";
      this.visible = false;
    
    }
    else {
      alert("Debe llenar todos los campos");
    }
  }
  ConfirmarCreate(x: Producto) {
    this.productos.push(x);
    }



  formData = new FormData();

  visible: boolean = false;
  public uploadFile = (files) => {
    
    this.formData = new FormData();
    //if (files.length === 0) {
    //  return;
    //}
    this.visible = true;
    let fileToUpload = <File>files[0];
    
    this.formData.append('file', fileToUpload, fileToUpload.name);
  }

  Borrar(li: Producto) {
    this.serviceP.GetDeleteProducto(li.sku).subscribe(x => { this.ConfirmarEli(x) }, e => console.log(e));
  }
    ConfirmarEli(x: boolean) {
      if (x) {
        this.GetProductos();
      }
    }
  vis: boolean = false;
  nomE: string = "";
  valorE: number = 0;
  descripE: string = "";
  fechaE: string = "";
  IdE: string = "";
  TiendaIdE: string = "";
  imagen: string = "";
  Detalles(li : Producto) {
    this.vis = true;
    this.nomE = li.nombre;
    this.valorE = li.valor;
    this.descripE = li.descripcion;
    this.fechaE = li.fecha;
    this.IdE = li.sku;
    console.log(this.IdE);
    this.TiendaIdE = li.tiendaId;
    this.imagen = li.imagen;
    
  }
  EditasPor() {
    if (this.nomE.length >= 4 && this.valorE >= 1000 && this.descripE.length >= 10 && this.fechaE != "") {

      this.pro.sku = this.IdE;
      
      this.pro.nombre = this.nomE;
      this.pro.descripcion = this.descripE;
      this.pro.valor = this.valorE;
      this.pro.fecha = this.fechaE;
      this.pro.tiendaId = this.TiendaIdE;
      this.pro.imagen = this.imagen;

      if (this.formData == null) {

        this.serviceP.PostUpdateProducto(this.pro).subscribe(x => { this.ConfirmacioEdicion(x) }, e => console.log(e));
      }
      else {

        this.formData.append("producto", JSON.stringify(this.pro));
        this.http.post(DiccionaryApiService.URL + DiccionaryApiService.UpdateUpload, this.formData, { reportProgress: true, observe: 'events' })
          .subscribe(event => {
            if (event.type === HttpEventType.UploadProgress)
              this.progress = Math.round(100 * event.loaded / event.total);
            else if (event.type === HttpEventType.Response) {
              this.message = 'Upload success.';
              this.GetProductos();
              this.onUploadFinished.emit(event.body);
            }
          });
      }
    }
    else {
      alert();
    }
  }
  public UpdateuploadFile = (files) => {

    this.formData = new FormData();
    //if (files.length === 0) {
    //  return;
    //}
    
    let fileToUpload = <File>files[0];

    this.formData.append('file', fileToUpload, fileToUpload.name);
  }
  ConfirmacioEdicion(x: boolean) {
    if (x) {
      this.GetProductos();
    }
    else {
      alert("NO FUE POSIBLE HACER LA ACTUALIZACION");
    }
      
  }

  GetProductos() {
    this.serviceP.GetProductos(this.TiendaId).subscribe(x => { this.ConfirmarInit(x) }, e => console.log(e));
  }

  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

}
