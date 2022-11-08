
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AuthGuard } from 'src/guard/AuthGuard';

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
import { ContaComponent } from './components/conta/conta.component';
import { TipoContaComponent } from './components/tipo-conta/tipo-conta.component';

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
    LancamentosComponent,
    ContaComponent,
    TipoContaComponent
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
      { path: 'user/profile', component: UserProfileComponent, canActivate: [AuthGuard]},
      { path: 'user/edit', component: UserEditComponent, canActivate: [AuthGuard]},
      { path: 'lancamentos', component: LancamentosComponent, canActivate: [AuthGuard]},
      { path: 'tipo-contas', component: TipoContaComponent},
      { path: 'contas', component: ContaComponent, canActivate: [AuthGuard]},
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: '**', component: PageNotfoundComponent},

    ]),
    BsDatepickerModule.forRoot(),
  ],
  providers: [
    FormBuilder,
    AuthGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
