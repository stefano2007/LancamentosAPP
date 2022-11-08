CREATE DATABASE dbLancamentos;
GO
USE dbLancamentos;
GO
CREATE table Usuarios(
  Id        Int identity(1, 1),
  Nome      varchar(60) not null,  
  Sobrenome varchar(60),
  Email     varchar(120) null,
  [dsLogin] varchar(60) not null,
  PassLogin varchar(100) not null,
  DataNascimento datetime,
  Celular varchar(11),
  DataCriacao datetime default getdate() not null,
  Ativo    bit default 1 not null,  
  PRIMARY KEY (Id)
);
GO
Create table TiposLancamentos(
  Id Int identity(1, 1) not null,
  Descricao varchar(60) not null,
  Despesa     bit default 1,--despesas ou Ativo
  ClassIcone       varchar(60),
  DataCriacao datetime default getdate() not null,
  Ativo       bit default 1 not null,
  PRIMARY KEY (Id)
);
GO
Insert into TiposLancamentos(Descricao, Despesa, ClassIcone)
select 'Alimentação' as Descricao, 1 as Despesa, 'fa-solid fa-fork-knife' as ClassIcone
union all
select 'Saúde' as Descricao, 1 as Despesa, 'fa-solid fa-heart-pulse' as ClassIcone
union all
select 'Casa' as Descricao, 1 as Despesa, 'fa-light fa-house-chimney' as ClassIcone
union all
select 'Veiculo' as Descricao, 1 as Despesa, 'fa-regular fa-car-wrench' as ClassIcone
union all
select 'Salario' as Descricao, 0 as Despesa, 'fa-regular fa-sack-dollar' as ClassIcone
union all
select 'Adiantamento' as Descricao, 0 as Despesa, 'fa-regular fa-money-bill-1' as ClassIcone
GO
CREATE TABLE Lancamentos(
  Id Int identity(1, 1),
  UsuarioId int not null, 
  TipoLancamentoId int  not null,
  DataLancamento datetime not null,
  Descricao varchar(60) not null,
  Valor decimal(15,4) not null,
  LancamentoRecorrente bit default 0 not null,
  DataCriacao datetime default getdate() not null,
  Ativo bit default 1 not null,
  PRIMARY KEY (Id),
  CONSTRAINT FK_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
  CONSTRAINT FK_TipoLancamentos FOREIGN KEY (TipoLancamentoId) REFERENCES TiposLancamentos(Id)
);

SET DATEFORMAT DMY
go
print '-- Registros Teste --'

insert into Usuarios(Nome,Email,dsLogin,PassLogin)
select 
'teste' as Nome,
'teste@teste.com' as Email,
'teste_123' as dsLogin,
'123456' as PassLogin

go
insert into Lancamentos(UsuarioId,TipoLancamentoId,DataLancamento,Descricao,Valor)
select 
1 as UsuarioId,
1 as TipoLancamentoId,
'21/08/2022 11:00:00' as  DataLancamento,
'Assai' as Descricao,
317.00 as Valor
go
--11/09/2022 - Alterar Usuario
ALTER TABLE Usuarios ALTER COLUMN Email varchar(120) not null
ALTER TABLE Usuarios ADD Profissao varchar(120)
ALTER TABLE Usuarios ADD ReceberNoficacoesPorEmail bit not null default 0

--06/11/2022 - Adicionar Conta
Create table TiposContas(
  Id Int identity(1, 1) not null,
  Descricao varchar(60) not null,
  ClassIcone       varchar(60),
  DataCriacao datetime default getdate() not null,
  Ativo       bit default 1 not null,
  PRIMARY KEY (Id)
);

GO
CREATE table Contas(
  Id        Int identity(1, 1),
  TipoContaId int not null,
  UsuarioId   int not null,
  Nome      varchar(60) not null,  
  SaldoAtual decimal(15,4) not null,
  DiaFechamentoFatura int, 
  DiaVencimentoFatura int,
  DataCriacao datetime default getdate() not null,
  Ativo    bit default 1 not null,  
  PRIMARY KEY (Id),
  CONSTRAINT FK_TipoContas FOREIGN KEY (TipoContaId) REFERENCES TiposContas(Id),
  CONSTRAINT FK_UsuariosContas FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO

insert into TiposContas(Descricao)
select 'Carteira' union
select 'Conta Corrente' union
select 'Cartão de Credito' union
select 'Poupança' union
select 'Dinheiro' 
go

ALTER TABLE Lancamentos add ContaId int;
GO
ALTER TABLE Lancamentos
ADD FOREIGN KEY (ContaId) REFERENCES Contas(id);
GO
--ALTER TABLE Contas add DiaFechamentoFatura int, DiaVencimentoFatura int
--go

INSERT INTO Contas(TipoContaId,UsuarioId,Nome,SaldoAtual, DiaFechamentoFatura, DiaVencimentoFatura)
select TipoContaId = 1,
       UsuarioId = 1,
	   Nome = 'Cartão Nubank',
	   SaldoAtual = 0,
	   24 as DiaFechamentoFatura, 
	   1 as DiaVencimentoFatura
union all
select TipoContaId = 2,
       UsuarioId = 1,
	   Nome = 'NuConta',
	   SaldoAtual = 10,
	   null as DiaFechamentoFatura, 
	   null as DiaVencimentoFatura


go
update a set contaId = 1
  from Lancamentos a

go

ALTER TABLE Lancamentos alter column ContaId int not null