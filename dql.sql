-- Consultar usuários
select 
    u.id_usuario,
    u.nome,
    u.sobrenome,
    u.cpf,
    u.data_cadastro,
    e.rua,
    e.bairro,
    e.cidade,
from 
    tb_usuarios u 
left join
    tb_enderecos e
on
    u.id_endereco = e.id_endereco;

--Consultar total de usuários cadastrados
select count(*) as total_usuarios
from tb_usuarios;

--Consultar usuários que nunca realizarão a compra
select *
from tb_usuarios u
left join tb_pedidos p
on u.id_usuario = p.id_usuario
where c.id_usuario is null;

--Consultar total de compras realizadas por um usuário
select
    p.id_pedidos,
    p.data_pedido,
    p.produtos as nome_produto,
    p.preco,
from
    tb_pedidos pd
join
    tb_produtos p
on
    pd.id_produtos = p.id_produtos
where
    pd.id_usuario = 1;

--Consultar total de compras filtradas por id do produto

select
    p.produtos, count(pd.id_pedidos) as total_compras
from tb_pedidos pd
join tb_produtos p
on pd.id_produtos = p.id_produtos
where pd.id_produtos = 1
group by p.produtos;

--Consultar produtos a partir do valor base

select id_produtos, nome_produto, descricao, preco
from tb_produtos
where preco >= 50 and preco <=100;
