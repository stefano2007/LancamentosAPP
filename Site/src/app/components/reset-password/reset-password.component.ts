import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  enviadoSumit: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  Confirmar(){
    this.enviadoSumit = true;
  }

}
