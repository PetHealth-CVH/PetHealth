insert into tb_produtos(nome_do_produto, descricao, preco, quantidade)
values 
(
    'Vermífugo Vermivet Composto 600mg para cães', 
    'Vermifugo para tratamento e controle de verminoses para cães', 
    9.90, 100
), 

(
    'Antipulgas e Carrapatos para cães de 30 a 60kg', 
    'Proteção contra pulgas, carrapatos, sarna e vermes',
    69.90, 100
),

(
    'Vermífugo Vetmax Plus 700mg para cães e gatos',
    'Indicado no tratamento de vermes gastrointestinais em cães e gatos',
    19.90, 100
),

(   
    'Suplemento Nutrafases Ômega 3 para Cães – 60 Tabletes',
    'Suplemento alimentar, que contém Nano Ômega 3 e o ômega 3 micronizado, extraido
    do óleo de peixe de águas frias, ricos em DHA e EPA e vitamina A;
    Ideal para cães de qualquer idade',
    53.60, 100
),

(
    'Endectocida Mectimax Ivermectina 12mg',
    'É indicado para cães em tratamento da sarna sacóptica, sarna demodécica, otoacaríase e verminoses',]
    9.90, 100
),

(
    'Vermífugo Vetmax Plus 700mg para cães e gatos',
    'Amplo espectro para combate de vermes chatos e redondos em cães e gatos.'
    19.90, 100
),

(
    'Antipulgas e Carrapatos Simparic para cães de 20 a 40kg',
    'Combate carrapatos, pulgas e sarnas. É eficaz, seguro e possui ação rápida
    e sustentada por até 35 dias',
    120.00, 100
),

(
    'Antipulgas e Carrapatos para cães Frontline TopStop 20 à 40kg',
    'Proteção mensal contra pulgas, carrapatos e piolhos mastigadores',
    20.90, 100
),

(
    'Brevecto Antipulgas e Carrapatos 40 a 56kg',
    'Controle e prevenção de infestação de pulgas e carrapatos por um longo período.
    Com ação rápida e prolongada por 12 semanas, seu cachorro ou gato ficam livres
    do incômodo e das doenças causadas por esses parasitas.',
    125.90, 100
),

(
    'Suplemento Ograx Artro 10 para cães e gatos Avert 30 cápsulas',
    'Suplemento Alimentar em cápsulas, com nutrientes essenciais às articulações de cães e gatos de todas as idades e porte',
    89.90, 100
),


-- Obtenção do id do registro das tabelas
select currval(pg_get_serial_sequence('tb_produtos', 'id_produtos')) into id_produtos;
select currval(pg_get_serial_sequence('tb_enderecos', 'id_endereco')) into id_endereco;
select currval(pg_get_serial_sequence('tb_pedidos','id_pedidos')) into id_pedidos;
select currval(pg_get_serial_sequence('tb_usuarios', 'id_usuario')) into id_usuario;
select currval(pg_get_serial_sequence('tb_credenciais','id_credencial')) into id_credencial;
select currval(pg_get_serial_sequence('tb_contato','id_contato')) into id_contato;

--Aqui terá o caminho de um possível usuário que irá acessar o nosso sistema.
--O email e senha serão fictícios

insert into tb_credenciais(email, senha)
values ('ana.mantovani@peth.com.br', 'Password123');

-- registro de usuário
insert into tb_usuarios(nome, sobrenome, cpf, data_cadastro, id_contato, id_endereco)
values ('Ana','Mantovani','12345678900','data_cadastro','id_contato','id_endereco');

-- Registrar uma compra 
insert into tb_pedidos(quantidade, id_usuario, id_produtos)
values (1, 1, 1);

-- atualizar uma compra
update tb_pedidos set quantidade = 5, id_produtos = 1 where id_pedidos  = 1;

-- excluir uma compra
delete from tb_pedidos where id_produtos = 1;






