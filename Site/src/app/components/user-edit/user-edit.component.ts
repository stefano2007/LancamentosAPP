import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/model/Usuario';
import { UsuarioService } from 'src/service/UsuarioService';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  constructor(private _service: UsuarioService,
              private activatedRoute: ActivatedRoute) { }

  usuarioAtual: Usuario = {}
  id: string = "";

  async ngOnInit(): Promise<void> {
    this.id = this.activatedRoute
                .snapshot.paramMap.get('id') || "";
    await this.buscarUsuario();
  }

  async buscarUsuario(){
    if (this.id){
      this.usuarioAtual = await this._service.getFind(this.id);
    }
  }
}
