CREATE DATABASE vendas_db;

CREATE TABLE clientes (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    telefone VARCHAR(30)
);

CREATE TABLE produtos (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    descricao TEXT,
    preco NUMERIC(10,2) NOT NULL CHECK (preco > 0),
    estoque INT NOT NULL CHECK (estoque >= 0)
);

CREATE TABLE vendas (
    id SERIAL PRIMARY KEY,
    cliente_id INT NOT NULL,
    data_venda TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    total NUMERIC(12,2) NOT NULL,
    CONSTRAINT fk_venda_cliente FOREIGN KEY (cliente_id)
        REFERENCES clientes(id)
);

CREATE TABLE venda_itens (
    id SERIAL PRIMARY KEY,
    venda_id INT NOT NULL,
    produto_id INT NOT NULL,
    quantidade INT NOT NULL CHECK (quantidade > 0),
    preco_unitario NUMERIC(10,2) NOT NULL,
    CONSTRAINT fk_item_venda FOREIGN KEY (venda_id) REFERENCES vendas(id),
    CONSTRAINT fk_item_produto FOREIGN KEY (produto_id) REFERENCES produtos(id)
);

CREATE INDEX idx_cliente_email ON clientes(email);
CREATE INDEX idx_produto_nome ON produtos(nome);
