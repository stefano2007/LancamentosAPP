import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoLancamentoComponent } from './tipo-lancamento.component';

describe('TipoLancamentoComponent', () => {
  let component: TipoLancamentoComponent;
  let fixture: ComponentFixture<TipoLancamentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipoLancamentoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipoLancamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
