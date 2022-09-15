import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/model/Usuario';
import { UsuarioService } from 'src/service/UsuarioService';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  constructor(private _service: UsuarioService) { }

  usuarioAtual: Usuario = {}

  async ngOnInit(): Promise<void> {
    this.usuarioAtual = await this._service.getFind("1");
  }

}
