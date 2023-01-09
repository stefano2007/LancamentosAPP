import { Router } from '@angular/router';
import { Usuario } from './../../../model/Usuario';
import { UsuarioInsert } from 'src/model/UsuarioInsert';
import { UsuarioService } from 'src/service/UsuarioService';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cadastra-se',
  templateUrl: './cadastra-se.component.html',
  styleUrls: ['./cadastra-se.component.css']
})
export class CadastraSeComponent implements OnInit {
  form:FormGroup;
  usuario:UsuarioInsert = {};

  constructor(
    private router:Router,
    private _service:UsuarioService,
    private fb:FormBuilder) {
      this.form = this.fb.group({
        nome: ['',Validators.required],
        sobrenome: [''],
        email: ['',Validators.required],
        senha: ['',Validators.required],
        senhaConfirm: ['',Validators.required],
        dataNascimento: ['',Validators.required],
        celular: [''],
        profissao: [''],
        receberNoficacoesPorEmail: [''],
        });
  }

  ngOnInit(): void {
  }

  async criarConta(){
    console.log('criarConta')
    if(this.form.valid){
      this.setUsuario();
      let usuairoResponse : Usuario = await this._service.CriaUsuario(this.usuario);
      if(usuairoResponse.id){
        console.log('cadastrado com sucesso')
        this.router.navigateByUrl('login/auth');
      }
    }else{
      console.error("Erro no form");
    }
  }

  setUsuario(){
    const val = this.form.value;
    this.usuario = {... val};

    console.log(this.usuario);
  }

  private LimparCamposForm(){

    this.usuario={};
    this.form.controls['name'].setValue('');
    this.form.controls['email'].setValue('');
  }
}
