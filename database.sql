-- Criei aqui o banco de dados DDL do projeto

create database LojaPet;

create table tb_usuarios (
    id_usuario serial primary key,
    nome varchar(50) not null,
    sobrenome varchar(50) not null,
    cpf varchar(11) unique not null,
    data_cadastro timestamp defaut NOW,
    id_contato int,
    id_endereco int,

    foreign key (id_contato) references tb_contato (id_contato),
    foreign key (id_endereco) references tb_enderecos (id_endereco),
    foreign key (id_usuario) references tb_pedidos (id_Pedidos)
);

create table tb_credenciais (
    id_credencial serial primary key,
    id_usuario serial unique,
    email varchar not null,
    senha varchar not null,

    foreign key (id_usuario) references tb_usuarios (id_usuario)
);

create table tb_enderecos (
    id_endereco serial primary key,
    cep varchar(9) not null,
    rua varchar(100) not null,
    bairro varchar(100), not null,
    cidade varchar(50) not null,
    estado varchar(50) not null,
    numero varchar(10),
    complemento varchar
);

create table tb_contato (
    id_contato serial primary key,
    celular varchar(14) unique not null,
    email int not null,

    foreign key (email) references tb_credenciais (email)
);


create table tb_produtos (
    id_produtos serial primary key,
    nome_produto varchar not null,
    descricao varchar not null,
    quantidade int(100),
    preco numeric(5,2) not null

);

create table tb_pedidos (
    id_pedidos serial primary key,
    id_usuario serial unique,
    data_pedido timestamp defaut NOW,
    produtos int not null,
    quantidade int(100),
    preco numeric(5,2) not null
);

 b5b899427190f84c32386a545f022280b010a872
