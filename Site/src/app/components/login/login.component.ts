import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioLogin } from 'src/model/UsuarioLogin';
import { AuthService } from 'src/service/AuthService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form:FormGroup;

  constructor(private fb:FormBuilder,
    private authService: AuthService,
    private router: Router) {

    this.form = this.fb.group({
    email: ['',Validators.required],
    password: ['',Validators.required]
    });
}
  ngOnInit(): void {
  }

  async login(){
    const val = this.form.value;

        if (val.email && val.password) {
            let user : UsuarioLogin = await this.authService.login(val.email, val.password)
            if(user.usuarioId)
            {
                console.log("User is logged in");
                this.router.navigateByUrl('/');
            }
        }
  }

}
