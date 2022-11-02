import { Component, OnInit } from '@angular/core';
import { Lancamento } from 'src/model/Lancamento';
import { LancamentoService } from 'src/service/LancamentoService';

@Component({
  selector: 'app-lancamentos',
  templateUrl: './lancamentos.component.html',
  styleUrls: ['./lancamentos.component.css']
})
export class LancamentosComponent implements OnInit {

  constructor(private _service:LancamentoService) { }

  lista : Lancamento[] = [];

  ngOnInit(): void {
    this.CarregarTodos();
 }

 async CarregarTodos()
 {
   this.lista = await this._service.getAll();
   console.log(this.lista);
 }

 async BuscarPorId(id : string){
   let data = await this._service.getFind(id);
   console.log(data);
 }

}
