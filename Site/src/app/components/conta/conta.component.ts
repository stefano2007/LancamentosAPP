import { Conta } from './../../../model/Conta';
import { ContaService } from './../../../service/ContaService';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-conta',
  templateUrl: './conta.component.html',
  styleUrls: ['./conta.component.css']
})
export class ContaComponent implements OnInit {

  constructor(private _service:ContaService) { }

  lista : Conta[] = [];

  buscando: boolean = false;

  ngOnInit(): void {
     this.CarregarTodos();
  }

  async CarregarTodos()
  {
    this.buscando = true;
    this.lista = await this._service.getAll();
    console.log(this.lista);
    this.buscando = false;
  }

  async BuscarPorId(id : string){
    this.buscando = true;
    let data = await this._service.getFind(id);
    console.log(data);

    this.buscando = false;
  }


}
