create database test;

use test;

create table product
(
    id BIGINT PRIMARY KEY,
    name NVARCHAR(1024)
);

create table category
(
    id BIGINT PRIMARY KEY,
    name NVARCHAR(1024)
);

create table product_category
(
    product_id BIGINT REFERENCES product,
    category_id BIGINT REFERENCES category,
    primary key (product_id, category_id)
);