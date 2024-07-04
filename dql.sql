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

-- Selecionar produtos com o preço menor que 50
select * from tb_produtos
where preco < 50;

-- Selecionar produtos com o preço menor que 100
select * from tb_produtos
where preco < 100;

-- Selecionar produtos com o preço menor que 150
select * from tb_produtos
where preco < 150;

-- Selecionar produtos com o preço maior que 50
select * from tb_produtos
where preco > 50;

-- Selecionar produtos com o preço maior que 100
select * from tb_produtos
where preco > 100;

-- Selecionar produtos com o preço maior que 150
select * from tb_produtos
where preco > 150;


-- Ordenar produtos por preço
select * from tb_produtos
order by preco asc;

select * from tb_produtos
order by preco desc;

-- Produtos mais comprados
select p.nome_produto, sum(pd.quantidade) as total_compras
from tb_pedidos pd
join tb_produtos p on pd.id_produtos = p.id_produtos
group by p.nome_produto
order by total_comprado desc
limit 10;

-- Produtos menos comprados
select p.nome_produto, sum(pd.quantidade) as total_compras
from tb_pedidos pd
join tb_produtos p on pd.id_produtos = p.id_produtos
group by p.nome_produto
order by total_comprado asc
limit 10;

-- Filtrar por um valor exato
select * from tb_produtos where preco = '100';

-- Filtrar por um valor diferente
select * from tb_produtos where preco != '100';

-- Selecionar clientes que residem em um determinado estado
select * from tb_enderecos where estado in ('São Paulo', 'Rio de Janeiro');

-- Consultar clientes com um determinado nome
select * from tb_usuarios where nome like 'Ana%';

-- Selecionar clientes que fizeram mais de 5 pedidos
select * from tb_usuarios where id_usuario in (
    select id_usuario from tb_pedidos group by id_usuario having count(*) > 5
)

-- Selecionar clientes que fizeram menos de 5 pedidos
select * from tb_usuarios where id_usuario in (
    select id_usuario from tb_pedidos group by id_usuario having count(*) < 5
)

-- Selecionar todos os pedidos feitos no último mês
select * from tb_pedidos where data_pedido >= date_sub(curdate(), interval 1 month)

