# Coffee Shop 


### Entities

#### **Employees**
- `id` (Primary Key)
- `full_name`
- `position`

#### **Products** 
- `id` (Primary Key)
- `product_name`
- `price`
- `category`

#### **Customers**
- `id` (Primary Key)
- `full_name`
- `phone_number`

#### **Orders**
- `id` (Primary Key)
- `customer_id` (Foreign Key)
- `employee_id` (Foreign Key)
- `order_date`
- `total_amount`
- `payment_method`

#### **Order Details**
- `id` (Primary Key)
- `order_id` (Foreign Key)
- `product_id` (Foreign Key)
- `quantity`
- `unit_price`
