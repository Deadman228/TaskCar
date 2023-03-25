-- Database: Test

-- DROP DATABASE IF EXISTS "Test";

CREATE DATABASE "Test"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Russian_Russia.1251'
    LC_CTYPE = 'Russian_Russia.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
	
	--------------------------------Создание таблиц
CREATE TABLE brand
(
id SERIAL PRIMARY KEY,
name text NOT NULL,
active boolean NOT NULL


);

CREATE TABLE model
(
id SERIAL PRIMARY KEY,
brandid INTEGER,
name text,
active boolean,
FOREIGN KEY (brandid) REFERENCES brand (id)


);

-----------------------Заполнение таблицы brand
INSERT INTO brand (id, name, active)
VALUES
(1,'KIA', TRUE),
(2, 'BMW', TRUE),
(3, 'Toyota', TRUE),
(4, 'Skoda', TRUE),
(5, 'Mersedes', TRUE),
(6, 'Nissan', TRUE),
(7, 'Infiniti', TRUE),
(8, 'Lada', TRUE)
-----------------------Заполнение таблицы model
INSERT INTO model (brandid, name, active)
VALUES
(1, 'RIO', TRUE),
(1, 'Cerato', TRUE),
(1, 'Optima', TRUE),
(2, 'X6', TRUE),
(2, 'E35', TRUE),
(2, 'S40', TRUE),
(3, 'Mark II', TRUE),
(3, 'Corolla', TRUE),
(3, 'Camry', TRUE),
(4, 'Rapid', TRUE),
(4, 'Octavia', TRUE),
(4, 'Superb', TRUE),
(5, 'W140', TRUE),
(5, 'GLE', TRUE),
(5, 'AMG', TRUE),
(6, 'Almera', TRUE),
(6, 'Teana', TRUE),
(6, '240SX', TRUE),
(7, 'Q70', TRUE),
(7, 'Q50', TRUE),
(7, 'QX50', TRUE),
(8, '2114', TRUE),
(8, '21099', TRUE),
(8, '2107', TRUE);
