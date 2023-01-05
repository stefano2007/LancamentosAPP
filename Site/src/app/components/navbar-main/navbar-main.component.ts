import { UsuarioLogin } from './../../../model/UsuarioLogin';
import { Usuario } from './../../../model/Usuario';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/service/AuthService';

@Component({
  selector: 'app-navbar-main',
  templateUrl: './navbar-main.component.html',
  styleUrls: ['./navbar-main.component.css']
})
export class NavbarMainComponent implements OnInit {

  usuario: UsuarioLogin = {};
  constructor(private router: Router,
            private authService: AuthService) { }

  ngOnInit(): void {
    this.usuario = this.authService.getUsuario();
    //console.log('usuario', this.usuario)
  }

  estaAutenticado(){
    return this.authService.isLoggedIn();
  }

  ehTelaLogin(){
    return this.router.url.startsWith('/login');
  }

  async logout(){
    await this.authService.logout();
    this.router.navigateByUrl("login/auth");
  }

}
