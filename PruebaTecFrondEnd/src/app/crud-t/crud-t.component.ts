import { Component, OnInit } from '@angular/core';
import { Tienda } from '../Models/Tienda';
import { TiendaServicesService } from '../Services/tienda-services.service';
import { Router, ActivatedRoute, NavigationExtras } from '@angular/router';


@Component({
  selector: 'app-crud-t',
  templateUrl: './crud-t.component.html',
  styleUrls: ['./crud-t.component.css']
})
export class CrudTComponent implements OnInit {
   nom: string ="";
  fecha: string=  "";

  constructor(private ServicesT: TiendaServicesService, private router: Router, private route: ActivatedRoute ) {
    this.ServicesT.GetTiendas().subscribe(x => { this.Confirmar(x) }, error => console.log(error));
  }
  

  Tiendas: Tienda[];
  ngOnInit() {
    
  }

 
  Confirmar(x: Tienda[]) {
    this.Tiendas = x;
  }

  IrTienda(tienda: Tienda) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        "Id": tienda.id,
        "nombreTi": tienda.nombre
      }
    };
    this.router.navigate(["Tienda"], navigationExtras);
  }
  Borrar(li: Tienda) {
    this.ServicesT.GetBorraT(li.id).subscribe(x => { this.BorrarConfirmar(x) }, e => console.log(e));
  }
    BorrarConfirmar(x: boolean) {
      if (x) {
        this.ServicesT.GetTiendas().subscribe(x => { this.Confirmar(x) }, error => console.log(error));
      }
    }
  CrearTienda() {
    if (this.nom.length != 0 && this.fecha != "") {
      let tienda: any = {};
      tienda.nombre = this.nom;
      tienda.fecha = this.fecha;
      this.ServicesT.PostCreate(tienda).subscribe(x => { this.PostCreateConfirmar(x) }, e => console.log(e));
    }
    else {

      alert("debe introducir los campos nombre y fecha");
    }
  }

    PostCreateConfirmar(x: Tienda)
    {
      console.log(x);
      this.nom = "";
      this.fecha = "";
      this.ServicesT.GetTiendas().subscribe(x => { this.Confirmar(x) }, error => console.log(error));
    }
}
