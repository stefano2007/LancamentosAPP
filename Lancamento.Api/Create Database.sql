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
  DataCriacao datetime default getdate() not null,
  Ativo       bit default 1 not null,
  PRIMARY KEY (Id)
);
GO
Insert into TiposLancamentos(Descricao, Despesa)
select 'Alimentação' as Descricao, 1 as Despesa
union all
select 'Saúde' as Descricao, 1 as Despesa
union all
select 'Casa' as Descricao, 1 as Despesa
union all
select 'Veiculo' as Descricao, 1 as Despesa
union all
select 'Salario' as Descricao, 0 as Despesa
union all
select 'Adiantamento' as Descricao, 0 as Despesa
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