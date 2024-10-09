use test;

select p.name, c.name
from product p
         left join product_category pc on p.id = pc.product_id
         left join category c on c.id = pc.category_id;