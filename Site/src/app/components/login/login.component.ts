import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { timeout } from 'rxjs';
import { UsuarioLogin } from 'src/model/UsuarioLogin';
import { AuthService } from 'src/service/AuthService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form:FormGroup;
  returnUrl:string ="";

  constructor(private fb:FormBuilder,
    private authService: AuthService,
    private router: Router,
    private activatedRoute: ActivatedRoute ) {

    this.form = this.fb.group({
    email: ['',Validators.required],
    password: ['',Validators.required]
    });
  }

  ngOnInit(): void {
    this.activatedRoute.queryParams
      .subscribe(params => {
        console.log(params);
        this.returnUrl = params['returnUrl'];
      }
    );
  }

  async login(){
    const val = this.form.value;
    if (val.email && val.password) {
        let user : UsuarioLogin = await this.authService.login(val.email, val.password)
        if(user.usuarioId)
        {
            console.log("User is logged in");

            let returnUrl = this.returnUrl || '/';

            this.router.navigateByUrl(returnUrl).then(
              ()=>{
                //apos redirect da reload na pagina pra recarregar as informações do menu
                window.location.reload();
              }
            );
        }
    }
  }
}
