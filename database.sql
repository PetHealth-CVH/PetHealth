-- Criei aqui o banco de dados DDL do projeto
create database LojaPet;
create table tb_credenciais (
    id_credencial serial primary key,
    id_usuario serial unique,
    email varchar not null,
    senha varchar not null,

    foreign key (id_usuario) references tb_usuário(id_usuario)
);

create table tb_contato (
    id_contato serial primary key
    celular varchar (14) unique not null
    email int not null

    foreign key (email) references tb_credenciais(email)
);

create table tb_usuarios (
    id_usuario serial primary key,

    
        
          
    

        
        Expand All
    
    @@ -22,7 +30,7 @@ create table tb_usuarios (
  
    credencial serial,
    nome varchar(50) not null,
    sobrenome varchar(50) not null,
    cpf varchar(11) unique not null,
    data_cadastro timestamp defaut NOW,
    contato serial,
    endereço serial,

    -- Aqui ficam as referências desta tabela com outras (FK)
    foreign key (credencial) references tb_credenciais (id_credencial)
)
