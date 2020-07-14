import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tienda',
  templateUrl: './tienda.component.html',
  styleUrls: ['./tienda.component.css']
})
export class TiendaComponent implements OnInit {

  TiendaId: string = "";
  tiendaNom: string = "";
  constructor(private route: ActivatedRoute, private router: Router) {
    
    this.route.queryParams.subscribe(params => {
      this.TiendaId = params["Id"];
      this.tiendaNom = params["nombreTi"];
      
      

    });
  }

  ngOnInit(): void {
  }

}
