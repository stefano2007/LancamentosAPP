import { UsuarioLogin } from 'src/model/UsuarioLogin';
import { AuthService } from 'src/service/AuthService';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Conta } from 'src/model/Conta';
import { ContaService } from 'src/service/ContaService';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-conta',
  templateUrl: './conta.component.html',
  styleUrls: ['./conta.component.css']
})
export class ContaComponent implements OnInit {

  @ViewChild('closebutton') closebutton:any;
  form:FormGroup;
  usuarioAtual: UsuarioLogin={};
  contaAtual: Conta = {};
  tipoAcaoForm: string = "";
  lista : Conta[] = [];
  buscando: boolean = false;

  constructor(private _service:ContaService,
              private fb:FormBuilder,
              private authService: AuthService) {

    this.form = this.fb.group({
      nome: ['',Validators.required],
      diaFechamentoFatura: [''],
      diaVencimentoFatura: [''],
      saldoAtual: [''],
      });
  }

  ngOnInit(): void {
    this.usuarioAtual = this.authService.getUsuario();
    this.CarregarTodos();
  }

  btnNovoClick(){
    this.tipoAcaoForm = "Nova";
    this.LimparCamposForm();
  }

  btnEditarClick(conta: Conta){
    this.tipoAcaoForm = "Editar";
    this.LimparCamposForm();
    this.AtualizarRegistroFormulario(conta);
  }

  private LimparCamposForm(){

    this.contaAtual={};
    this.form.controls['nome'].setValue('');
    this.form.controls['diaFechamentoFatura'].setValue('');
    this.form.controls['diaVencimentoFatura'].setValue('');
    this.form.controls['saldoAtual'].setValue('');
  }

  private AtualizarRegistroFormulario(contaSelecionada: Conta){
    console.log("contaSelecionada", contaSelecionada)

    this.contaAtual= contaSelecionada;

    this.form.controls['nome'].setValue(contaSelecionada.nome);
    this.form.controls['diaFechamentoFatura'].setValue(contaSelecionada.diaFechamentoFatura);
    this.form.controls['diaVencimentoFatura'].setValue(contaSelecionada.diaVencimentoFatura);
    this.form.controls['saldoAtual'].setValue(contaSelecionada.saldoAtual);
  }

  async CarregarTodos()
  {
    this.buscando = true;
    this.lista = await this._service.getAll();
    this.buscando = false;
  }
/*

  async BuscarPorId(id : string){
    this.buscando = true;
    let data = await this._service.getFind(id);
    console.log(data);
    this.buscando = false;
  }
*/
  async onSubmit(){
    const val = this.form.value;

    var select = (document.getElementById("selectTipoConta")) as HTMLSelectElement;
    console.log(val)
    if (this.form.valid && select.value != '0'){
      let conta :Conta = {... val};
      conta.tipoContaId = Number(select.value);
      conta.usuarioId = this.usuarioAtual.usuarioId;

      let insert= this.tipoAcaoForm == 'Nova';

      let resultado: Conta = {};
      if(insert){
        let resultado = await this._service.Inserir(conta);
      }else{
        conta.id = this.contaAtual.id;
        let idConta : string = this.contaAtual.id?.toString() || '';
        let resultado = await this._service.Atualizar(idConta.toString(), conta);
      }

      if(resultado){
        //fecharmodal;
        this.CarregarTodos();
        this.closebutton.nativeElement.click();
      }else{
        // mensagem de erro
      }
    }
  }
}
