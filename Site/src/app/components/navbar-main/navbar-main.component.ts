import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar-main',
  templateUrl: './navbar-main.component.html',
  styleUrls: ['./navbar-main.component.css']
})
export class NavbarMainComponent implements OnInit {

  usuario:string = 'teste';
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  estaAutenticado(){
    return false;
  }

  ehTelaLogin(){
    return this.router.url.startsWith('/login');
  }

}
