import { AuthService } from 'src/service/AuthService';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsuarioLogin } from 'src/model/UsuarioLogin';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Lancamento } from 'src/model/Lancamento';
import { LancamentoService } from 'src/service/LancamentoService';

@Component({
  selector: 'app-lancamentos',
  templateUrl: './lancamentos.component.html',
  styleUrls: ['./lancamentos.component.css']
})
export class LancamentosComponent implements OnInit {

  @ViewChild('closebutton') closebutton:any;
  form:FormGroup;
  usuarioAtual: UsuarioLogin={};
  lancamentoAtual: Lancamento = {};
  tipoAcaoForm: string = "";
  lista : Lancamento[] = [];
  buscando: boolean = false;

  constructor(private _service:LancamentoService,
              private fb:FormBuilder,
              private authService: AuthService) {

    this.form = this.fb.group({
      descricao: ['',Validators.required],
      valor: ['0'],
      });
  }

  ngOnInit(): void {
    this.usuarioAtual = this.authService.getUsuario();
    this.CarregarTodos();
  }

  async CarregarTodos()
  {
    this.lista = await this._service.getAll();
    console.log(this.lista);
  }

  async BuscarPorId(id : string){
    let data = await this._service.getFind(id);
    console.log(data);
  }

  btnNovoClick(){
    this.tipoAcaoForm = "Nova";
    this.LimparCamposForm();
  }

  btnEditarClick(conta: Lancamento){
    this.tipoAcaoForm = "Editar";
    this.LimparCamposForm();
    this.AtualizarRegistroFormulario(conta);
  }

  private LimparCamposForm(){

    this.lancamentoAtual={};
    this.form.controls['descricao'].setValue('');
    this.form.controls['valor'].setValue('');
  }

  private AtualizarRegistroFormulario(lancamentoSelecionada: Lancamento){
    console.log("lancamentoSelecionada", lancamentoSelecionada)

    this.lancamentoAtual= lancamentoSelecionada;

    this.form.controls['descricao'].setValue(lancamentoSelecionada.descricao);
    this.form.controls['valor'].setValue(lancamentoSelecionada.valor);
  }

  async onSubmit(){
    const val = this.form.value;

    var selectConta = (document.getElementById("selectConta")) as HTMLSelectElement;
    var selectTipoLancamento = (document.getElementById("selectTipoLancamento")) as HTMLSelectElement;
    console.log(val)
    if (this.form.valid && selectConta.value != '0' && selectTipoLancamento.value != '0'){
      let lancamento :Lancamento = {... val};
      lancamento.contaId = Number(selectConta.value);
      lancamento.tipoLancamentoId = Number(selectTipoLancamento.value);
      lancamento.usuarioId = this.usuarioAtual.usuarioId;
      lancamento.isLancamentoRecorrente = false;
      lancamento.data = new Date();

      let insert= this.tipoAcaoForm == 'Nova';

      let resultado: Lancamento = {};
      if(insert){
        lancamento.ativo = true;
        let resultado = await this._service.Inserir(lancamento);
      }else{
        lancamento.id = this.lancamentoAtual.id;
        let idConta : string = this.lancamentoAtual.id?.toString() || '';
        let resultado = await this._service.Atualizar(idConta.toString(), lancamento);
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
