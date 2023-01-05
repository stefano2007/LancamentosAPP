import { AuthService } from './../../../service/AuthService';
import { Usuario } from 'src/model/Usuario';
import { UsuarioService } from 'src/service/UsuarioService';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioRecuperaSenha } from 'src/model/UsuarioRecuperaSenha';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-password',
  templateUrl: './user-password.component.html',
  styleUrls: ['./user-password.component.css']
})
export class UserPasswordComponent implements OnInit {

  usuario:Usuario = {};

  form:FormGroup;
  id:string="";

  constructor(private fb:FormBuilder,
              private usuarioService: UsuarioService,
              private authService: AuthService,
              private activatedRoute: ActivatedRoute) {
    this.usuario = this.authService.getUsuario();

    this.form = this.fb.group({
      email: [this.usuario.email, Validators.required],
      senhaAtual: ['',Validators.required],
      novaSenha: ['',Validators.required],
      confirmaNovaSenha: ['',Validators.required],
      });

  }

  ngOnInit() {
    this.id = this.activatedRoute
                .snapshot.paramMap.get('id') || "";
  }

  async atualizarSenha(){
    const val = this.form.value;
    if (this.form.valid) {
      if(val.novaSenha != val.confirmaNovaSenha){
        console.error("Nova senha diferente da senha confirmada.");
        return;
      }

      let usuarioAtual: UsuarioRecuperaSenha= {};

      usuarioAtual.email = val.email;
      usuarioAtual.senhaAtual = val.senhaAtual;
      usuarioAtual.novaSenha = val.novaSenha;

      let user : Usuario = await this.usuarioService.AtualizarSenhaUsuario(this.id, usuarioAtual)

      if(user.id)
      {
          console.log("Atualizado com sucesso.");
      }
    }
  }

}
