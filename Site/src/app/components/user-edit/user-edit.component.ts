import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/model/Usuario';
import { UsuarioService } from 'src/service/UsuarioService';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  constructor(private _service: UsuarioService) { }

  usuarioAtual: Usuario = {}

  async ngOnInit(): Promise<void> {
    this.usuarioAtual = await this._service.getFind("1");
  }

}
