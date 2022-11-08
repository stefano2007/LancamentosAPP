import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/service/AuthService';

@Component({
  selector: 'app-navbar-main',
  templateUrl: './navbar-main.component.html',
  styleUrls: ['./navbar-main.component.css']
})
export class NavbarMainComponent implements OnInit {

  usuario:string = 'teste';
  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    this.usuario = this.authService.getNomeUsuario();
  }

  estaAutenticado(){
    return this.authService.isLoggedIn();
  }

  ehTelaLogin(){
    return this.router.url.startsWith('/login');
  }

  logout(){
    this.authService.logout();
  }

}
