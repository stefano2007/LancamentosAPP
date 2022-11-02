import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { InterceptorModule } from 'src/Interceptors/interceptor.module';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { AppComponent } from './app.component';
import { TipoLancamentoComponent } from './components/tipo-lancamento/tipo-lancamento.component';
import { LoginComponent } from './components/login/login.component';
import { NavbarMainComponent } from './components/navbar-main/navbar-main.component';
import { HomeComponent } from './components/home/home.component';
import { PageNotfoundComponent } from './components/page-notfound/page-notfound.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { CadastraSeComponent } from './components/cadastra-se/cadastra-se.component';
import { UserEditComponent } from './components/user-edit/user-edit.component';
import { LancamentosComponent } from './components/lancamentos/lancamentos.component';

@NgModule({
  declarations: [
    AppComponent,
    TipoLancamentoComponent,
    LoginComponent,
    NavbarMainComponent,
    HomeComponent,
    PageNotfoundComponent,
    ResetPasswordComponent,
    UserProfileComponent,
    CadastraSeComponent,
    UserEditComponent,
    LancamentosComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent},
      { path: 'tipo-lancamentos', component: TipoLancamentoComponent},
      { path: 'login/auth', component: LoginComponent},
      { path: 'login/resetpassword', component: ResetPasswordComponent},
      { path: 'login/create', component: CadastraSeComponent},
      { path: 'user/profile', component: UserProfileComponent},
      { path: 'user/edit', component: UserEditComponent},
      { path: 'lancamentos', component: LancamentosComponent},
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: '**', component: PageNotfoundComponent},

    ]),
    BsDatepickerModule.forRoot(),
    InterceptorModule,
  ],
  providers: [
    FormBuilder,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
