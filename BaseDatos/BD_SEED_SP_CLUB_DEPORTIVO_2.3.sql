-- =========================================
-- -----------------------------------------
-- BASE DE DATOS CLUB DEPORTIVO
-- -----------------------------------------
-- =========================================


DROP DATABASE IF EXISTS club_deportivo;

CREATE DATABASE club_deportivo;

USE club_deportivo;

-- =========================================
-- TABLA ROLES
-- =========================================

CREATE TABLE roles(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL UNIQUE
);

-- =========================================
-- TABLA PERSONAS
-- =========================================

CREATE TABLE personas(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(40) NOT NULL,
    dni VARCHAR(10) NOT NULL UNIQUE
);

-- =========================================
-- TABLA CLIENTES
-- =========================================

CREATE TABLE clientes(
    id INT AUTO_INCREMENT PRIMARY KEY,
    persona_id INT NOT NULL UNIQUE,
    apto_fisico BOOLEAN NOT NULL DEFAULT TRUE,

    CONSTRAINT fk_clientes_personas
    FOREIGN KEY(persona_id)
    REFERENCES personas(id)
);

-- =========================================
-- TABLA USUARIOS
-- =========================================

CREATE TABLE usuarios(
    id INT AUTO_INCREMENT PRIMARY KEY,
    persona_id INT NOT NULL UNIQUE,
    username VARCHAR(20) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    rol_id INT NOT NULL,
    activo BOOLEAN DEFAULT TRUE,

    CONSTRAINT fk_usuarios_personas
    FOREIGN KEY(persona_id)
    REFERENCES personas(id),

    CONSTRAINT fk_usuarios_roles
    FOREIGN KEY(rol_id)
    REFERENCES roles(id)
);

-- =========================================
-- TABLA SOCIOS
-- =========================================

CREATE TABLE socios(
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL UNIQUE,
    estado BOOLEAN DEFAULT FALSE,

    CONSTRAINT fk_socios_clientes
    FOREIGN KEY(cliente_id)
    REFERENCES clientes(id)
);

-- =========================================
-- TABLA NO SOCIOS
-- =========================================

CREATE TABLE no_socios(
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL UNIQUE,
    acceso_diario BOOLEAN DEFAULT FALSE,

    CONSTRAINT fk_no_socios_clientes
    FOREIGN KEY(cliente_id)
    REFERENCES clientes(id)
);

-- =========================================
-- TABLA INSCRIPCIONES
-- =========================================

CREATE TABLE inscripciones(
    id INT AUTO_INCREMENT PRIMARY KEY,
    socio_id INT NOT NULL,
    fecha_inscripcion DATE NOT NULL,

    CONSTRAINT fk_inscripciones_socios
    FOREIGN KEY(socio_id)
    REFERENCES socios(id)
);

-- =========================================
-- TABLA CARNET
-- =========================================

CREATE TABLE carnet(
    id INT AUTO_INCREMENT PRIMARY KEY,
    inscripcion_id INT NOT NULL UNIQUE,
    fecha_emision DATE NOT NULL,
    estado BOOLEAN DEFAULT TRUE,

    CONSTRAINT fk_carnet_inscripciones
    FOREIGN KEY(inscripcion_id)
    REFERENCES inscripciones(id)
);

-- =========================================
-- TABLA CUOTAS
-- =========================================

CREATE TABLE cuotas(
    id INT AUTO_INCREMENT PRIMARY KEY,
    socio_id INT NOT NULL,
    monto_cuota DECIMAL NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    estado_cuota VARCHAR(20) DEFAULT 'Pendiente',

    CONSTRAINT fk_cuotas_socios
    FOREIGN KEY(socio_id)
    REFERENCES socios(id)
);

CREATE TABLE conceptos_pago(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL
);

CREATE TABLE metodos_pago(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL
);

CREATE TABLE Actividades(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    precio DECIMAL
);

CREATE TABLE Programaciones(
	id INT AUTO_INCREMENT PRIMARY KEY,
    actividad_id INT NOT NULL,
    fecha_hora DATETIME NOT NULL,
    cupos_disponibles INT,
    
    CONSTRAINT fk_programacion_actividades
    FOREIGN KEY(actividad_id)
    REFERENCES actividades(id)
);

CREATE TABLE Reservas(
	id INT AUTO_INCREMENT PRIMARY KEY,
    programacion_id INT NOT NULL,
    cliente_id INT NOT NULL,
    fecha_reserva DATETIME NOT NULL,
    estado VARCHAR(20) NOT NULL DEFAULT 'Pendiente de pago',
    
    CONSTRAINT fk_reservas_programaciones
    FOREIGN KEY (programacion_id)
    REFERENCES programaciones(id),
    
    CONSTRAINT fk_reservas_clientes
    FOREIGN KEY (cliente_id)
    REFERENCES clientes(id)
);


-- =========================================
-- TABLA PAGOS
-- =========================================

CREATE TABLE pagos(
    id INT AUTO_INCREMENT PRIMARY KEY,

    cuota_id INT NULL,
    reserva_id INT NULL,

    fecha_pago DATE NOT NULL,
    monto DECIMAL NOT NULL,

    concepto_id INT NOT NULL,
    metodo_id INT NOT NULL,

    CONSTRAINT fk_pagos_cuotas
    FOREIGN KEY(cuota_id)
    REFERENCES cuotas(id),

    CONSTRAINT fk_pagos_reservas
    FOREIGN KEY(reserva_id)
    REFERENCES reservas(id),
    
    CONSTRAINT fk_pagos_conceptos_pago
    FOREIGN KEY(concepto_id)
    REFERENCES conceptos_pago(id),
    
    CONSTRAINT fk_pagos_metodos_pago
    FOREIGN KEY(metodo_id)
    REFERENCES metodos_pago(id),
    
    CONSTRAINT chk_origen_pago CHECK ( 
    (cuota_id IS NOT NULL AND reserva_id IS NULL) 
    OR (cuota_id IS NULL AND reserva_id IS NOT NULL) )
);

-- =========================================
-- -----------------------------------------
-- SEMILLA: DATOS INICIALES
-- -----------------------------------------
-- =========================================

INSERT INTO roles(nombre)
VALUES
('admin'),
('user');

INSERT INTO personas(nombre, apellido, dni)
VALUES
('Andrea', 'Jiménez', '24753731'),
('Ramiro', 'Meñica', '38333222'),
('Ariel', 'González', '12341234'),
('Gastón', 'Manes', '98765432');

INSERT INTO usuarios(
    persona_id,
    username,
    password,
    rol_id
)
VALUES
(1, 'Andrea', '1234', 1),
(2, 'Ramiro', '1234', 1),
(3, 'Ariel', '1234', 1),
(4, 'Gastón', '1234', 1);


INSERT INTO metodos_pago(nombre)
VALUES
('Efectivo'),
('Cheque'),
('Tarjeta crédito'),
('Mercado Pago');

INSERT INTO conceptos_pago(nombre)
VALUES
('Inscripcion'),
('Cuota'),
('Actividad');

INSERT INTO actividades(nombre, precio) 
VALUES 
('Fútbol', 20000.0), 
('Básquet', 15000.0), 
('Vóley', 15000.0), 
('Tenis', 25000.0), 
('Natación', 10000.0),
('Karate', 8000.0), 
('Taekwondo', 8000.0), 
('Gimnasio', 9000.0), 
('Musculación', 10000.0), 
('Crossfit', 10000.0), 
('Yoga', 7000.0), 
('Pilates', 8500.0), 
('Zumba', 7500.0);


-- =========================================
-- USAR LA BASE DE DATOS
-- =========================================
USE club_deportivo;

-- =========================================
-- 1. VERIFICAR DNIs EXISTENTES PARA EVITAR DUPLICADOS
-- =========================================
SELECT '=== DNIs EXISTENTES (NO UTILIZAR) ===' AS '';
SELECT dni FROM personas;

-- =========================================
-- 2. INSERT DE 100 NUEVAS PERSONAS (DNIs únicos, no existentes)
-- =========================================
INSERT INTO personas (nombre, apellido, dni) VALUES
('María', 'González', '20123456'),
('Carlos', 'Rodríguez', '20234567'),
('Ana', 'Fernández', '20345678'),
('Luis', 'Martínez', '20456789'),
('Laura', 'Pérez', '20567890'),
('Jorge', 'López', '20678901'),
('Marta', 'García', '20789012'),
('Pedro', 'Sánchez', '20890123'),
('Lucía', 'Ramírez', '20901234'),
('Diego', 'Torres', '20112345'),
('Elena', 'Castro', '21123456'),
('Pablo', 'Ortiz', '21234567'),
('Sofía', 'Morales', '21345678'),
('Andrés', 'Vargas', '21456789'),
('Carolina', 'Mendoza', '21567890'),
('Fernando', 'Herrera', '21678901'),
('Natalia', 'Medina', '21789012'),
('Ricardo', 'Flores', '21890123'),
('Patricia', 'Rojas', '21901234'),
('Esteban', 'Guzmán', '21112345'),
('Valeria', 'Salazar', '22123456'),
('Maximiliano', 'Cruz', '22234567'),
('Camila', 'Reyes', '22345678'),
('Sebastián', 'Vega', '22456789'),
('Daniela', 'Molina', '22567890'),
('Alejandro', 'Alvarado', '22678901'),
('Gabriela', 'Cordero', '22789012'),
('Felipe', 'Araya', '22890123'),
('Isabel', 'Pizarro', '22901234'),
('Cristian', 'Sepúlveda', '22112345'),
('Macarena', 'Espinoza', '23123456'),
('Rodrigo', 'Tapia', '23234567'),
('Francisca', 'Gutiérrez', '23345678'),
('Mauricio', 'Maldonado', '23456789'),
('Nicole', 'Soto', '23567890'),
('Alberto', 'Contreras', '23678901'),
('Katherine', 'Cáceres', '23789012'),
('Javier', 'Rivera', '23890123'),
('Constanza', 'Palma', '23901234'),
('Marcelo', 'Muñoz', '23112345'),
('Andrea', 'Silva', '24123456'),
('Héctor', 'Barrientos', '24234567'),
('Paula', 'Leiva', '24345678'),
('Juan Pablo', 'Aranda', '24456789'),
('Tamara', 'Vergara', '24567890'),
('Iván', 'Aguilera', '24678901'),
('Romina', 'Zúñiga', '24789012'),
('Oscar', 'Santibáñez', '24890123'),
('Claudia', 'Orellana', '24901234'),
('Bastián', 'Oyarzún', '24112345'),
('Ximena', 'Mena', '25123456'),
('Adrián', 'Villalobos', '25234567'),
('Marisol', 'Pino', '25345678'),
('César', 'Carrasco', '25456789'),
('Javiera', 'Riquelme', '25567890'),
('Francisco', 'Venegas', '25678901'),
('Rosa', 'Bustamante', '25789012'),
('Eduardo', 'Lara', '25890123'),
('Carla', 'Bravo', '25901234'),
('Gonzalo', 'Opazo', '25112345'),
('Pía', 'Núñez', '26123456'),
('Fabián', 'Astudillo', '26234567'),
('Alicia', 'Escobar', '26345678'),
('Nicolás', 'Sandoval', '26456789'),
('Bárbara', 'Carreño', '26567890'),
('Rafael', 'Toro', '26678901'),
('Carolina', 'Sáez', '26789012'),
('Emilio', 'Fuentes', '26890123'),
('Diana', 'Olivares', '26901234'),
('Eduardo', 'Cortés', '26112345'),
('Mónica', 'Loyola', '27123456'),
('Patricio', 'Gallardo', '27234567'),
('Soledad', 'Retamal', '27345678'),
('Mario', 'Cordero', '27456789'),
('Angélica', 'Godoy', '27567890'),
('Sergio', 'Henríquez', '27678901'),
('Maritza', 'Medel', '27789012'),
('Leonardo', 'Garrido', '27890123'),
('Nancy', 'Peralta', '27901234'),
('Elías', 'Vera', '27112345'),
('Marcela', 'Valenzuela', '28123456'),
('Humberto', 'Delgado', '28234567'),
('Gloria', 'Parra', '28345678'),
('David', 'Santibáñez', '28456789'),
('Angélica', 'Arriagada', '28567890'),
('Luis', 'Fuenzalida', '28678901'),
('Ingrid', 'Acuña', '28789012'),
('Juan Carlos', 'Ramos', '28890123'),
('Eliana', 'Chacón', '28901234'),
('Víctor', 'Pérez', '28112345'),
('Cecilia', 'Alarcón', '29123456'),
('Guillermo', 'Correa', '29234567'),
('Beatriz', 'Martínez', '29345678'),
('Roberto', 'Navarro', '29456789'),
('Cristina', 'Díaz', '29567890'),
('Manuel', 'Romero', '29678901'),
('Raquel', 'Molina', '29789012'),
('Joaquín', 'Hernández', '29890123'),
('Rocío', 'Gómez', '29901234'),
('Miguel', 'Álvarez', '29112345'),
('Ainhoa', 'Sanz', '30123456');

-- =========================================
-- 3. INSERT DE CLIENTES (100 nuevos)
-- =========================================
INSERT INTO clientes (persona_id, apto_fisico) 
SELECT id, TRUE 
FROM personas 
WHERE dni IN (
    '20123456','20234567','20345678','20456789','20567890',
    '20678901','20789012','20890123','20901234','20112345',
    '21123456','21234567','21345678','21456789','21567890',
    '21678901','21789012','21890123','21901234','21112345',
    '22123456','22234567','22345678','22456789','22567890',
    '22678901','22789012','22890123','22901234','22112345',
    '23123456','23234567','23345678','23456789','23567890',
    '23678901','23789012','23890123','23901234','23112345',
    '24123456','24234567','24345678','24456789','24567890',
    '24678901','24789012','24890123','24901234','24112345',
    '25123456','25234567','25345678','25456789','25567890',
    '25678901','25789012','25890123','25901234','25112345',
    '26123456','26234567','26345678','26456789','26567890',
    '26678901','26789012','26890123','26901234','26112345',
    '27123456','27234567','27345678','27456789','27567890',
    '27678901','27789012','27890123','27901234','27112345',
    '28123456','28234567','28345678','28456789','28567890',
    '28678901','28789012','28890123','28901234','28112345',
    '29123456','29234567','29345678','29456789','29567890',
    '29678901','29789012','29890123','29901234','29112345',
    '30123456'
);

-- =========================================
-- 4. INSERT DE SOCIOS (100 nuevos)
-- =========================================
INSERT INTO socios (cliente_id, estado) 
SELECT id, 1 
FROM clientes 
WHERE persona_id IN (SELECT id FROM personas WHERE dni IN (
    '20123456','20234567','20345678','20456789','20567890',
    '20678901','20789012','20890123','20901234','20112345',
    '21123456','21234567','21345678','21456789','21567890',
    '21678901','21789012','21890123','21901234','21112345',
    '22123456','22234567','22345678','22456789','22567890',
    '22678901','22789012','22890123','22901234','22112345',
    '23123456','23234567','23345678','23456789','23567890',
    '23678901','23789012','23890123','23901234','23112345',
    '24123456','24234567','24345678','24456789','24567890',
    '24678901','24789012','24890123','24901234','24112345',
    '25123456','25234567','25345678','25456789','25567890',
    '25678901','25789012','25890123','25901234','25112345',
    '26123456','26234567','26345678','26456789','26567890',
    '26678901','26789012','26890123','26901234','26112345',
    '27123456','27234567','27345678','27456789','27567890',
    '27678901','27789012','27890123','27901234','27112345',
    '28123456','28234567','28345678','28456789','28567890',
    '28678901','28789012','28890123','28901234','28112345',
    '29123456','29234567','29345678','29456789','29567890',
    '29678901','29789012','29890123','29901234','29112345',
    '30123456'
));

-- =========================================
-- 5. VERIFICAR TOTAL DE SOCIOS
-- =========================================
SELECT '=== TOTAL DE SOCIOS NUEVOS CREADOS ===' AS '';
SELECT COUNT(*) AS total_socios_nuevos FROM socios;

-- =========================================
-- 6. INSERTAR CUOTAS CON VENCIMIENTOS EN LOS PRÓXIMOS 30 DÍAS
-- =========================================
-- Eliminar cuotas existentes (opcional, descomentar si es necesario)
-- DELETE FROM cuotas WHERE socio_id IN (SELECT id FROM socios WHERE cliente_id IN (SELECT id FROM clientes WHERE persona_id IN (SELECT id FROM personas WHERE dni LIKE '2%' OR dni LIKE '3%')));

DROP TEMPORARY TABLE IF EXISTS temp_cuotas;
CREATE TEMPORARY TABLE temp_cuotas (
    dni VARCHAR(20),
    monto DECIMAL(10,2),
    fecha_vencimiento DATE,
    estado VARCHAR(20)
);

INSERT INTO temp_cuotas (dni, monto, fecha_vencimiento, estado) VALUES
-- Día 1 (2026-06-19) - 4 socios
('20123456', 1500.00, '2026-06-19', 'Pendiente'),
('20234567', 1500.00, '2026-06-19', 'Pendiente'),
('20345678', 1500.00, '2026-06-19', 'Pendiente'),
('20456789', 1500.00, '2026-06-19', 'Pendiente'),

-- Día 2 (2026-06-20) - 4 socios
('20567890', 1500.00, '2026-06-20', 'Pendiente'),
('20678901', 1500.00, '2026-06-20', 'Pendiente'),
('20789012', 1500.00, '2026-06-20', 'Pendiente'),
('20890123', 1500.00, '2026-06-20', 'Pendiente'),

-- Día 3 (2026-06-21) - 4 socios
('20901234', 1500.00, '2026-06-21', 'Pendiente'),
('20112345', 1500.00, '2026-06-21', 'Pendiente'),
('21123456', 1500.00, '2026-06-21', 'Pendiente'),
('21234567', 1500.00, '2026-06-21', 'Pendiente'),

-- Día 4 (2026-06-22) - 4 socios
('21345678', 1500.00, '2026-06-22', 'Pendiente'),
('21456789', 1500.00, '2026-06-22', 'Pendiente'),
('21567890', 1500.00, '2026-06-22', 'Pendiente'),
('21678901', 1500.00, '2026-06-22', 'Pendiente'),

-- Día 5 (2026-06-23) - 4 socios
('21789012', 1500.00, '2026-06-23', 'Pendiente'),
('21890123', 1500.00, '2026-06-23', 'Pendiente'),
('21901234', 1500.00, '2026-06-23', 'Pendiente'),
('21112345', 1500.00, '2026-06-23', 'Pendiente'),

-- Día 6 (2026-06-24) - 4 socios
('22123456', 1500.00, '2026-06-24', 'Pendiente'),
('22234567', 1500.00, '2026-06-24', 'Pendiente'),
('22345678', 1500.00, '2026-06-24', 'Pendiente'),
('22456789', 1500.00, '2026-06-24', 'Pendiente'),

-- Día 7 (2026-06-25) - 4 socios
('22567890', 1500.00, '2026-06-25', 'Pendiente'),
('22678901', 1500.00, '2026-06-25', 'Pendiente'),
('22789012', 1500.00, '2026-06-25', 'Pendiente'),
('22890123', 1500.00, '2026-06-25', 'Pendiente'),

-- Día 8 (2026-06-26) - 4 socios
('22901234', 1500.00, '2026-06-26', 'Pendiente'),
('22112345', 1500.00, '2026-06-26', 'Pendiente'),
('23123456', 1500.00, '2026-06-26', 'Pendiente'),
('23234567', 1500.00, '2026-06-26', 'Pendiente'),

-- Día 9 (2026-06-27) - 4 socios
('23345678', 1500.00, '2026-06-27', 'Pendiente'),
('23456789', 1500.00, '2026-06-27', 'Pendiente'),
('23567890', 1500.00, '2026-06-27', 'Pendiente'),
('23678901', 1500.00, '2026-06-27', 'Pendiente'),

-- Día 10 (2026-06-28) - 4 socios
('23789012', 1500.00, '2026-06-28', 'Pendiente'),
('23890123', 1500.00, '2026-06-28', 'Pendiente'),
('23901234', 1500.00, '2026-06-28', 'Pendiente'),
('23112345', 1500.00, '2026-06-28', 'Pendiente'),

-- Día 11 (2026-06-29) - 4 socios
('24123456', 1500.00, '2026-06-29', 'Pendiente'),
('24234567', 1500.00, '2026-06-29', 'Pendiente'),
('24345678', 1500.00, '2026-06-29', 'Pendiente'),
('24456789', 1500.00, '2026-06-29', 'Pendiente'),

-- Día 12 (2026-06-30) - 4 socios
('24567890', 1500.00, '2026-06-30', 'Pendiente'),
('24678901', 1500.00, '2026-06-30', 'Pendiente'),
('24789012', 1500.00, '2026-06-30', 'Pendiente'),
('24890123', 1500.00, '2026-06-30', 'Pendiente'),

-- Día 13 (2026-07-01) - 4 socios
('24901234', 1500.00, '2026-07-01', 'Pendiente'),
('24112345', 1500.00, '2026-07-01', 'Pendiente'),
('25123456', 1500.00, '2026-07-01', 'Pendiente'),
('25234567', 1500.00, '2026-07-01', 'Pendiente'),

-- Día 14 (2026-07-02) - 4 socios
('25345678', 1500.00, '2026-07-02', 'Pendiente'),
('25456789', 1500.00, '2026-07-02', 'Pendiente'),
('25567890', 1500.00, '2026-07-02', 'Pendiente'),
('25678901', 1500.00, '2026-07-02', 'Pendiente'),

-- Día 15 (2026-07-03) - 4 socios
('25789012', 1500.00, '2026-07-03', 'Pendiente'),
('25890123', 1500.00, '2026-07-03', 'Pendiente'),
('25901234', 1500.00, '2026-07-03', 'Pendiente'),
('25112345', 1500.00, '2026-07-03', 'Pendiente'),

-- Día 16 (2026-07-04) - 4 socios
('26123456', 1500.00, '2026-07-04', 'Pendiente'),
('26234567', 1500.00, '2026-07-04', 'Pendiente'),
('26345678', 1500.00, '2026-07-04', 'Pendiente'),
('26456789', 1500.00, '2026-07-04', 'Pendiente'),

-- Día 17 (2026-07-05) - 4 socios
('26567890', 1500.00, '2026-07-05', 'Pendiente'),
('26678901', 1500.00, '2026-07-05', 'Pendiente'),
('26789012', 1500.00, '2026-07-05', 'Pendiente'),
('26890123', 1500.00, '2026-07-05', 'Pendiente'),

-- Día 18 (2026-07-06) - 4 socios
('26901234', 1500.00, '2026-07-06', 'Pendiente'),
('26112345', 1500.00, '2026-07-06', 'Pendiente'),
('27123456', 1500.00, '2026-07-06', 'Pendiente'),
('27234567', 1500.00, '2026-07-06', 'Pendiente'),

-- Día 19 (2026-07-07) - 4 socios
('27345678', 1500.00, '2026-07-07', 'Pendiente'),
('27456789', 1500.00, '2026-07-07', 'Pendiente'),
('27567890', 1500.00, '2026-07-07', 'Pendiente'),
('27678901', 1500.00, '2026-07-07', 'Pendiente'),

-- Día 20 (2026-07-08) - 4 socios
('27789012', 1500.00, '2026-07-08', 'Pendiente'),
('27890123', 1500.00, '2026-07-08', 'Pendiente'),
('27901234', 1500.00, '2026-07-08', 'Pendiente'),
('27112345', 1500.00, '2026-07-08', 'Pendiente'),

-- Día 21 (2026-07-09) - 4 socios
('28123456', 1500.00, '2026-07-09', 'Pendiente'),
('28234567', 1500.00, '2026-07-09', 'Pendiente'),
('28345678', 1500.00, '2026-07-09', 'Pendiente'),
('28456789', 1500.00, '2026-07-09', 'Pendiente'),

-- Día 22 (2026-07-10) - 4 socios
('28567890', 1500.00, '2026-07-10', 'Pendiente'),
('28678901', 1500.00, '2026-07-10', 'Pendiente'),
('28789012', 1500.00, '2026-07-10', 'Pendiente'),
('28890123', 1500.00, '2026-07-10', 'Pendiente'),

-- Día 23 (2026-07-11) - 4 socios
('28901234', 1500.00, '2026-07-11', 'Pendiente'),
('28112345', 1500.00, '2026-07-11', 'Pendiente'),
('29123456', 1500.00, '2026-07-11', 'Pendiente'),
('29234567', 1500.00, '2026-07-11', 'Pendiente'),

-- Día 24 (2026-07-12) - 4 socios
('29345678', 1500.00, '2026-07-12', 'Pendiente'),
('29456789', 1500.00, '2026-07-12', 'Pendiente'),
('29567890', 1500.00, '2026-07-12', 'Pendiente'),
('29678901', 1500.00, '2026-07-12', 'Pendiente'),

-- Día 25 (2026-07-13) - 4 socios
('29789012', 1500.00, '2026-07-13', 'Pendiente'),
('29890123', 1500.00, '2026-07-13', 'Pendiente'),
('29901234', 1500.00, '2026-07-13', 'Pendiente'),
('29112345', 1500.00, '2026-07-13', 'Pendiente');

-- Día 26 (2026-07-14) - 4 socios
INSERT INTO temp_cuotas (dni, monto, fecha_vencimiento, estado) VALUES
('30123456', 1500.00, '2026-07-14', 'Pendiente');

-- =========================================
-- 7. INSERTAR LAS CUOTAS
-- =========================================
INSERT INTO cuotas (socio_id, monto_cuota, fecha_vencimiento, estado_cuota)
SELECT 
    s.id,
    t.monto,
    t.fecha_vencimiento,
    t.estado
FROM temp_cuotas t
INNER JOIN personas p ON p.dni = t.dni
INNER JOIN clientes c ON c.persona_id = p.id
INNER JOIN socios s ON s.cliente_id = c.id;

-- =========================================
-- 8. VERIFICACIÓN FINAL
-- =========================================
SELECT '=== DISTRIBUCIÓN DE VENCIMIENTOS ===' AS '';
SELECT 
    DATE(c.fecha_vencimiento) AS fecha_vencimiento,
    COUNT(*) AS cantidad_socios
FROM cuotas c
WHERE c.estado_cuota = 'Pendiente'
  AND c.socio_id IN (SELECT id FROM socios WHERE cliente_id IN (SELECT id FROM clientes WHERE persona_id IN (SELECT id FROM personas WHERE dni LIKE '2%' OR dni LIKE '3%')))
GROUP BY DATE(c.fecha_vencimiento)
ORDER BY fecha_vencimiento ASC;

SELECT '=== LISTADO DE 100 SOCIOS NUEVOS CON CUOTAS ===' AS '';
SELECT 
    ROW_NUMBER() OVER (ORDER BY c.fecha_vencimiento) AS nro,
    p.nombre,
    p.apellido,
    p.dni,
    c.monto_cuota,
    c.fecha_vencimiento,
    DATEDIFF(c.fecha_vencimiento, CURDATE()) AS dias_restantes,
    c.estado_cuota
FROM personas p
INNER JOIN clientes cl ON p.id = cl.persona_id
INNER JOIN socios s ON s.cliente_id = cl.id
INNER JOIN cuotas c ON c.socio_id = s.id
WHERE c.estado_cuota = 'Pendiente'
  AND p.dni LIKE '2%' OR p.dni LIKE '3%'
  AND c.fecha_vencimiento BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)
ORDER BY c.fecha_vencimiento ASC;

SELECT '=== TOTAL ===' AS '';
SELECT COUNT(*) AS total_nuevos_socios FROM socios WHERE cliente_id IN (SELECT id FROM clientes WHERE persona_id IN (SELECT id FROM personas WHERE dni LIKE '2%' OR dni LIKE '3%'));
SELECT COUNT(*) AS total_nuevas_cuotas FROM cuotas c WHERE c.socio_id IN (SELECT id FROM socios WHERE cliente_id IN (SELECT id FROM clientes WHERE persona_id IN (SELECT id FROM personas WHERE dni LIKE '2%' OR dni LIKE '3%')));


INSERT INTO programaciones (actividad_id, fecha_hora, cupos_disponibles)
VALUES

-- FÚTBOL (lunes y miércoles)
(1,'2026-07-15 10:00:00',20),
(1,'2026-07-15 18:00:00',20),
(1,'2026-07-15 20:00:00',20),
(1,'2026-07-20 10:00:00',20),
(1,'2026-07-20 18:00:00',20),
(1,'2026-07-20 20:00:00',20),
(1,'2026-07-22 10:00:00',20),
(1,'2026-07-22 18:00:00',20),
(1,'2026-07-22 20:00:00',20),
(1,'2026-07-27 10:00:00',20),
(1,'2026-07-27 18:00:00',20),
(1,'2026-07-27 20:00:00',20),
(1,'2026-07-29 10:00:00',20),
(1,'2026-07-29 18:00:00',20),
(1,'2026-07-29 20:00:00',20),

-- BÁSQUET (martes y jueves)
(2,'2026-07-16 09:00:00',15),
(2,'2026-07-16 17:00:00',15),
(2,'2026-07-16 19:00:00',15),
(2,'2026-07-21 09:00:00',15),
(2,'2026-07-21 17:00:00',15),
(2,'2026-07-21 19:00:00',15),
(2,'2026-07-23 09:00:00',15),
(2,'2026-07-23 17:00:00',15),
(2,'2026-07-23 19:00:00',15),
(2,'2026-07-28 09:00:00',15),
(2,'2026-07-28 17:00:00',15),
(2,'2026-07-28 19:00:00',15),
(2,'2026-07-30 09:00:00',15),
(2,'2026-07-30 17:00:00',15),
(2,'2026-07-30 19:00:00',15),

-- VÓLEY (miércoles y viernes)
(3,'2026-07-15 11:00:00',18),
(3,'2026-07-15 16:00:00',18),
(3,'2026-07-15 20:00:00',18),
(3,'2026-07-17 11:00:00',18),
(3,'2026-07-17 16:00:00',18),
(3,'2026-07-17 20:00:00',18),
(3,'2026-07-22 11:00:00',18),
(3,'2026-07-22 16:00:00',18),
(3,'2026-07-22 20:00:00',18),
(3,'2026-07-24 11:00:00',18),
(3,'2026-07-24 16:00:00',18),
(3,'2026-07-24 20:00:00',18),
(3,'2026-07-29 11:00:00',18),
(3,'2026-07-29 16:00:00',18),
(3,'2026-07-29 20:00:00',18),
(3,'2026-07-31 11:00:00',18),
(3,'2026-07-31 16:00:00',18),
(3,'2026-07-31 20:00:00',18);

INSERT INTO programaciones (actividad_id, fecha_hora, cupos_disponibles)
VALUES

-- TENIS (martes y sábado)
(4,'2026-07-16 08:00:00',8),
(4,'2026-07-16 10:00:00',8),
(4,'2026-07-16 18:00:00',8),
(4,'2026-07-18 08:00:00',8),
(4,'2026-07-18 10:00:00',8),
(4,'2026-07-18 18:00:00',8),
(4,'2026-07-21 08:00:00',8),
(4,'2026-07-21 10:00:00',8),
(4,'2026-07-21 18:00:00',8),
(4,'2026-07-25 08:00:00',8),
(4,'2026-07-25 10:00:00',8),
(4,'2026-07-25 18:00:00',8),
(4,'2026-07-28 08:00:00',8),
(4,'2026-07-28 10:00:00',8),
(4,'2026-07-28 18:00:00',8),
(4,'2026-07-30 08:00:00',8),
(4,'2026-07-30 10:00:00',8),
(4,'2026-07-30 18:00:00',8),

-- NATACIÓN (lunes y viernes)
(5,'2026-07-15 07:00:00',25),
(5,'2026-07-15 12:00:00',25),
(5,'2026-07-15 19:00:00',25),
(5,'2026-07-18 07:00:00',25),
(5,'2026-07-18 12:00:00',25),
(5,'2026-07-18 19:00:00',25),
(5,'2026-07-20 07:00:00',25),
(5,'2026-07-20 12:00:00',25),
(5,'2026-07-20 19:00:00',25),
(5,'2026-07-22 07:00:00',25),
(5,'2026-07-22 12:00:00',25),
(5,'2026-07-22 19:00:00',25),
(5,'2026-07-25 07:00:00',25),
(5,'2026-07-25 12:00:00',25),
(5,'2026-07-25 19:00:00',25),
(5,'2026-07-27 07:00:00',25),
(5,'2026-07-27 12:00:00',25),
(5,'2026-07-27 19:00:00',25),
(5,'2026-07-29 07:00:00',25),
(5,'2026-07-29 12:00:00',25),
(5,'2026-07-29 19:00:00',25),
(5,'2026-07-31 07:00:00',25),
(5,'2026-07-31 12:00:00',25),
(5,'2026-07-31 19:00:00',25),

-- KARATE (martes y jueves)
(6,'2026-07-16 17:00:00',15),
(6,'2026-07-16 18:00:00',15),
(6,'2026-07-16 20:00:00',15),
(6,'2026-07-21 17:00:00',15),
(6,'2026-07-21 18:00:00',15),
(6,'2026-07-21 20:00:00',15),
(6,'2026-07-23 17:00:00',15),
(6,'2026-07-23 18:00:00',15),
(6,'2026-07-23 20:00:00',15),
(6,'2026-07-28 17:00:00',15),
(6,'2026-07-28 18:00:00',15),
(6,'2026-07-28 20:00:00',15),
(6,'2026-07-30 17:00:00',15),
(6,'2026-07-30 18:00:00',15),
(6,'2026-07-30 20:00:00',15);

INSERT INTO programaciones (actividad_id, fecha_hora, cupos_disponibles)
VALUES

-- TAEKWONDO (miércoles y sábado)
(7,'2026-07-15 16:00:00',15),
(7,'2026-07-15 19:00:00',15),
(7,'2026-07-15 21:00:00',15),
(7,'2026-07-18 16:00:00',15),
(7,'2026-07-18 19:00:00',15),
(7,'2026-07-18 21:00:00',15),
(7,'2026-07-22 16:00:00',15),
(7,'2026-07-22 19:00:00',15),
(7,'2026-07-22 21:00:00',15),
(7,'2026-07-25 16:00:00',15),
(7,'2026-07-25 19:00:00',15),
(7,'2026-07-25 21:00:00',15),
(7,'2026-07-29 16:00:00',15),
(7,'2026-07-29 19:00:00',15),
(7,'2026-07-29 21:00:00',15),

-- GIMNASIO (lunes y jueves)
(8,'2026-07-16 07:00:00',30),
(8,'2026-07-16 13:00:00',30),
(8,'2026-07-16 18:00:00',30),
(8,'2026-07-20 07:00:00',30),
(8,'2026-07-20 13:00:00',30),
(8,'2026-07-20 18:00:00',30),
(8,'2026-07-23 07:00:00',30),
(8,'2026-07-23 13:00:00',30),
(8,'2026-07-23 18:00:00',30),
(8,'2026-07-27 07:00:00',30),
(8,'2026-07-27 13:00:00',30),
(8,'2026-07-27 18:00:00',30),
(8,'2026-07-30 07:00:00',30),
(8,'2026-07-30 13:00:00',30),
(8,'2026-07-30 18:00:00',30),

-- MUSCULACIÓN (martes y viernes)
(9,'2026-07-17 08:00:00',20),
(9,'2026-07-17 14:00:00',20),
(9,'2026-07-17 19:00:00',20),
(9,'2026-07-21 08:00:00',20),
(9,'2026-07-21 14:00:00',20),
(9,'2026-07-21 19:00:00',20),
(9,'2026-07-24 08:00:00',20),
(9,'2026-07-24 14:00:00',20),
(9,'2026-07-24 19:00:00',20),
(9,'2026-07-28 08:00:00',20),
(9,'2026-07-28 14:00:00',20),
(9,'2026-07-28 19:00:00',20),
(9,'2026-07-31 08:00:00',20),
(9,'2026-07-31 14:00:00',20),
(9,'2026-07-31 19:00:00',20);

INSERT INTO programaciones (actividad_id, fecha_hora, cupos_disponibles)
VALUES

-- CROSSFIT (lunes y miércoles)
(10,'2026-07-15 06:30:00',12),
(10,'2026-07-15 17:30:00',12),
(10,'2026-07-15 19:30:00',12),
(10,'2026-07-20 06:30:00',12),
(10,'2026-07-20 17:30:00',12),
(10,'2026-07-20 19:30:00',12),
(10,'2026-07-22 06:30:00',12),
(10,'2026-07-22 17:30:00',12),
(10,'2026-07-22 19:30:00',12),
(10,'2026-07-27 06:30:00',12),
(10,'2026-07-27 17:30:00',12),
(10,'2026-07-27 19:30:00',12),
(10,'2026-07-29 06:30:00',12),
(10,'2026-07-29 17:30:00',12),
(10,'2026-07-29 19:30:00',12),

-- YOGA (martes y jueves)
(11,'2026-07-16 09:00:00',20),
(11,'2026-07-16 18:30:00',20),
(11,'2026-07-16 20:00:00',20),
(11,'2026-07-21 09:00:00',20),
(11,'2026-07-21 18:30:00',20),
(11,'2026-07-21 20:00:00',20),
(11,'2026-07-23 09:00:00',20),
(11,'2026-07-23 18:30:00',20),
(11,'2026-07-23 20:00:00',20),
(11,'2026-07-28 09:00:00',20),
(11,'2026-07-28 18:30:00',20),
(11,'2026-07-28 20:00:00',20),
(11,'2026-07-30 09:00:00',20),
(11,'2026-07-30 18:30:00',20),
(11,'2026-07-30 20:00:00',20),

-- PILATES (miércoles y viernes)
(12,'2026-07-15 09:00:00',18),
(12,'2026-07-15 15:00:00',18),
(12,'2026-07-15 18:00:00',18),
(12,'2026-07-17 09:00:00',18),
(12,'2026-07-17 15:00:00',18),
(12,'2026-07-17 18:00:00',18),
(12,'2026-07-22 09:00:00',18),
(12,'2026-07-22 15:00:00',18),
(12,'2026-07-22 18:00:00',18),
(12,'2026-07-24 09:00:00',18),
(12,'2026-07-24 15:00:00',18),
(12,'2026-07-24 18:00:00',18),
(12,'2026-07-29 09:00:00',18),
(12,'2026-07-29 15:00:00',18),
(12,'2026-07-29 18:00:00',18),
(12,'2026-07-31 09:00:00',18),
(12,'2026-07-31 15:00:00',18),
(12,'2026-07-31 18:00:00',18),

-- ZUMBA (jueves y sábado)
(13,'2026-07-16 10:00:00',25),
(13,'2026-07-16 18:00:00',25),
(13,'2026-07-16 20:00:00',25),
(13,'2026-07-18 10:00:00',25),
(13,'2026-07-18 18:00:00',25),
(13,'2026-07-18 20:00:00',25),
(13,'2026-07-23 10:00:00',25),
(13,'2026-07-23 18:00:00',25),
(13,'2026-07-23 20:00:00',25),
(13,'2026-07-25 10:00:00',25),
(13,'2026-07-25 18:00:00',25),
(13,'2026-07-25 20:00:00',25),
(13,'2026-07-30 10:00:00',25),
(13,'2026-07-30 18:00:00',25),
(13,'2026-07-30 20:00:00',25);


-- =========================================
-- -----------------------------------------
-- PROCEDIMIENTOS ALMACENADOS
-- -----------------------------------------
-- =========================================


-- =========================================
-- PROCEDIMIENTO LOGIN
-- =========================================

DELIMITER //

CREATE PROCEDURE LoginUsuario(
    IN p_username VARCHAR(20),
    IN p_password VARCHAR(255)
)

BEGIN
    SELECT
        u.id,
        u.username,
        u.activo,
        r.id AS rol_id,
        r.nombre AS rol,
        p.nombre,
        p.apellido
    FROM usuarios u
    INNER JOIN personas p
        ON u.persona_id = p.id
    INNER JOIN roles r
        ON u.rol_id = r.id
    WHERE u.username = p_username
    AND u.password = p_password
    AND u.activo = TRUE;

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO REGISTRAR CLIENTE
-- =========================================

DELIMITER //

CREATE PROCEDURE RegistrarCliente(
    IN p_nombre VARCHAR(30),
    IN p_apellido VARCHAR(40),
    IN p_dni VARCHAR(10),
    IN p_apto_fisico BOOLEAN,
    IN p_es_socio BOOLEAN,
    OUT rta INT
)
BEGIN

    DECLARE existe INT DEFAULT 0;
    DECLARE v_persona_id INT;
    DECLARE v_cliente_id INT;
    DECLARE v_no_socio_id INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET rta = -2;
    END;

    START TRANSACTION;

    SELECT COUNT(*)
    INTO existe
    FROM personas
    WHERE dni = p_dni;

    IF existe > 0 THEN

        ROLLBACK;
        SET rta = -1;

    ELSE

        -- Persona
        INSERT INTO personas(nombre, apellido, dni)
        VALUES(p_nombre, p_apellido, p_dni);

        SET v_persona_id = LAST_INSERT_ID();

        -- Cliente
        INSERT INTO clientes(persona_id, apto_fisico)
        VALUES(v_persona_id, p_apto_fisico);

        SET v_cliente_id = LAST_INSERT_ID();

        -- Sólo los no socios se agregan aquí
        IF NOT p_es_socio THEN

            INSERT INTO no_socios(cliente_id, acceso_diario)
            VALUES(v_cliente_id, TRUE);

            SET v_no_socio_id = LAST_INSERT_ID();

        END IF;

        COMMIT;

        -- Siempre devolvemos el cliente_id
        SET rta = v_cliente_id;

    END IF;

END //

DELIMITER ;

-- ===========================================
-- PROCEDIMIENTO FORMALIZAR INSCRIPCIÓN SOCIO 
-- ===========================================

DELIMITER //

CREATE PROCEDURE FormalizarInscripcion(
    IN p_cliente_id INT,
    IN p_monto_cuota DECIMAL(10,2),
    OUT rta INT
)
BEGIN

    DECLARE existe INT DEFAULT 0;
    DECLARE v_socio_id INT;
    DECLARE v_inscripcion_id INT;
    DECLARE v_cuota_id INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET rta = -99;
    END;

    START TRANSACTION;

    -- Verificar si ya es socio
    SELECT COUNT(*)
    INTO existe
    FROM socios
    WHERE cliente_id = p_cliente_id;

    IF existe > 0 THEN

        ROLLBACK;
        SET rta = -1;

    ELSE

        -- Crear socio
        INSERT INTO socios(cliente_id, estado)
        VALUES(p_cliente_id, FALSE);

        SET v_socio_id = LAST_INSERT_ID();

        -- Crear inscripción
        INSERT INTO inscripciones(
            socio_id,
            fecha_inscripcion
        )
        VALUES(
            v_socio_id,
            CURDATE()
        );

        SET v_inscripcion_id = LAST_INSERT_ID();

        -- Crear cuota inicial
        INSERT INTO cuotas(
            socio_id,
            monto_cuota,
            fecha_vencimiento,
            estado_cuota
        )
        VALUES(
            v_socio_id,
            p_monto_cuota,
            DATE_ADD(CURDATE(), INTERVAL 1 MONTH),
            'Pendiente'
        );

        SET v_cuota_id = LAST_INSERT_ID();

        COMMIT;

        SET rta = v_socio_id;

    END IF;

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO BUSCAR CLIENTE
-- =========================================

DROP PROCEDURE IF EXISTS BuscarClientePorDni;
DELIMITER //

CREATE PROCEDURE BuscarClientePorDni(
    IN p_dni VARCHAR(10)
)
BEGIN
    SELECT
        cl.id AS id_cliente,
        p.nombre,
        p.apellido,
        p.dni,
        cl.apto_fisico,
        CASE 
            WHEN s.id IS NOT NULL THEN 'Socio'
            WHEN ns.id IS NOT NULL THEN 'NoSocio'
            ELSE 'Cliente'
        END AS tipo_cliente,
        s.id AS id_socio,
        s.estado AS estado_socio,
        ns.id AS id_no_socio,
        ns.acceso_diario
    FROM clientes cl
    JOIN personas p ON p.id = cl.persona_id
    LEFT JOIN socios s ON s.cliente_id = cl.id
    LEFT JOIN no_socios ns ON ns.cliente_id = cl.id
    WHERE p.dni = p_dni;
END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO REGISTRAR PAGO CUOTA
-- =========================================
DELIMITER //

CREATE PROCEDURE RegistrarPagoCuota(
    IN p_socio_id INT,
    IN p_monto DECIMAL(10,2),
    IN p_concepto_id INT,
    IN p_metodo_id INT,
    OUT rta INT
)
BEGIN
    DECLARE v_cuota_id INT;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET rta = -99;
    END;

    START TRANSACTION;

    SELECT c.id
    INTO v_cuota_id
    FROM cuotas c
    WHERE c.socio_id = p_socio_id
      AND c.estado_cuota = 'Pendiente'
    ORDER BY c.fecha_vencimiento
    LIMIT 1;

    IF v_cuota_id IS NULL THEN
        SET rta = -2;
        ROLLBACK;
    ELSE

        INSERT INTO pagos(
            cuota_id,
            fecha_pago,
            monto,
            concepto_id,
            metodo_id
        )
        VALUES(
            v_cuota_id,
            CURDATE(),
            p_monto,
            p_concepto_id,
            p_metodo_id
        );

        UPDATE cuotas
        SET estado_cuota = 'Pagada'
        WHERE id = v_cuota_id;

        SET rta = LAST_INSERT_ID();
        
        UPDATE socios
        SET estado = TRUE
        WHERE id = p_socio_id;

        COMMIT;
    END IF;

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO REGISTRAR PAGO ACTIVIDAD
-- =========================================

DELIMITER //

CREATE PROCEDURE RegistrarPagoActividad(
IN p_reserva_id INT,
IN p_monto DECIMAL(10,2),
IN p_concepto_id INT,
IN p_metodo_id INT,
OUT rta INT
)
BEGIN

DECLARE v_programacion_id INT;
DECLARE v_hay_cupo BOOLEAN;

DECLARE EXIT HANDLER FOR SQLEXCEPTION
BEGIN
    ROLLBACK;
    SET rta = -99;
END;

START TRANSACTION;

-- Obtener la programación asociada a la reserva
SELECT programacion_id
INTO v_programacion_id
FROM reservas
WHERE id = p_reserva_id;

-- Verificar si aún existen cupos
SELECT cupos_disponibles > 0
INTO v_hay_cupo
FROM programaciones
WHERE id = v_programacion_id;

IF NOT v_hay_cupo THEN

    SET rta = -2;
    ROLLBACK;

ELSE

    -- Registrar el pago
    INSERT INTO pagos(
        reserva_id,
        fecha_pago,
        monto,
        concepto_id,
        metodo_id
    )
    VALUES(
        p_reserva_id,
        CURDATE(),
        p_monto,
        p_concepto_id,
        p_metodo_id
    );

    -- Autorizar la reserva
    UPDATE reservas
    SET estado = 'Pagado'
    WHERE id = p_reserva_id;

    -- Descontar el cupo
    UPDATE programaciones
    SET cupos_disponibles = cupos_disponibles - 1
    WHERE id = v_programacion_id;

    SET rta = LAST_INSERT_ID();

    COMMIT;

END IF;

END //

DELIMITER ;


-- =========================================
-- PROCEDIMIENTO GENERAR CUOTAS MENSUALES
-- =========================================
-- 1. Activar el scheduler para la sesión
SET GLOBAL event_scheduler = ON;

DROP PROCEDURE IF EXISTS InsertarNuevaCuota;

DELIMITER //

CREATE PROCEDURE InsertarNuevaCuota()
BEGIN

    INSERT INTO cuotas (
        socio_id,
        monto_cuota,
        fecha_vencimiento,
        estado_cuota
    )
    SELECT
        ultima.socio_id,
        ultima.monto_cuota,

        DATE_ADD(
            DATE_ADD(
                ultima.fecha_vencimiento,
                INTERVAL 1 MONTH
            ),
            INTERVAL
                CASE
                    WHEN ultima.fecha_pago IS NOT NULL
                         AND ultima.fecha_pago > ultima.fecha_vencimiento
                    THEN 1
                    ELSE 0
                END DAY
        ),

        'Pendiente'

    FROM
    (
        SELECT
            c1.socio_id,
            c1.monto_cuota,
            c1.fecha_vencimiento,
            p.fecha_pago
        FROM cuotas c1

        LEFT JOIN pagos p
            ON p.cuota_id = c1.id

        WHERE c1.fecha_vencimiento =
        (
            SELECT MAX(c2.fecha_vencimiento)
            FROM cuotas c2
            WHERE c2.socio_id = c1.socio_id
        )

    ) ultima

    WHERE ultima.fecha_vencimiento <= CURDATE()

    AND NOT EXISTS
    (
        SELECT 1
        FROM cuotas c
        WHERE c.socio_id = ultima.socio_id
        AND c.fecha_vencimiento =
            DATE_ADD(
                DATE_ADD(
                    ultima.fecha_vencimiento,
                    INTERVAL 1 MONTH
                ),
                INTERVAL
                    CASE
                        WHEN ultima.fecha_pago IS NOT NULL
                             AND ultima.fecha_pago > ultima.fecha_vencimiento
                        THEN 1
                        ELSE 0
                    END DAY
            )
    );

END //

DELIMITER ;

DROP EVENT IF EXISTS ev_generar_cuotas;

CREATE EVENT ev_generar_cuotas
ON SCHEDULE EVERY 1 DAY
STARTS '2026-06-18 06:00:00'
DO
    CALL InsertarNuevaCuota();
  
	
-- =========================================
-- PROCEDIMIENTO BUSCAR CUOTA POR DNI
-- =========================================

DELIMITER //

CREATE PROCEDURE ObtenerCuotasPorDni(
    IN in_dni VARCHAR(10)
)

BEGIN

    SELECT
        p.nombre,
        p.apellido,
        p.dni,
        s.id,
        s.estado AS estado_socio,
        c.id AS id_cuota,
        c.monto_cuota,
        c.estado_cuota,
        c.fecha_vencimiento
    FROM personas p
    INNER JOIN clientes cl
        ON p.id = cl.persona_id
    INNER JOIN socios s
        ON cl.id = s.cliente_id
    INNER JOIN cuotas c
        ON s.id = c.socio_id
    WHERE p.dni = in_dni;
    
END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO GENERAR RESERVA
-- =========================================

DELIMITER //

CREATE PROCEDURE GenerarReserva(
IN p_id_actividad INT,
IN p_cliente_id INT,
IN p_fecha_hora DATETIME,
OUT rta INT
)
BEGIN

DECLARE v_programacion_id INT;
DECLARE v_reserva_id INT;
DECLARE v_es_socio BOOLEAN;
DECLARE v_hay_cupos BOOLEAN;

DECLARE CONTINUE HANDLER FOR NOT FOUND
BEGIN
	SET v_programacion_id = NULL;
END;

-- Ante cualquier excepción se revierte todo
DECLARE EXIT HANDLER FOR SQLEXCEPTION
BEGIN
    ROLLBACK;
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @msg = MESSAGE_TEXT;
    SET rta = -99;
    SELECT @sqlstate, @msg;
END;

START TRANSACTION;

-- Buscar programación
SELECT id
INTO v_programacion_id
FROM programaciones 
WHERE actividad_id = p_id_actividad
  AND fecha_hora = p_fecha_hora
LIMIT 1;

IF v_programacion_id IS NULL THEN

    ROLLBACK;
    SET rta = -1;

ELSE

    -- Verificar que existan cupos
    SELECT cupos_disponibles > 0
    INTO v_hay_cupos
    FROM programaciones
    WHERE id = v_programacion_id;

    IF NOT v_hay_cupos THEN

        ROLLBACK;
        SET rta = -2;

    ELSE

        -- Verificar si el cliente ya posee una reserva
        IF EXISTS(
            SELECT 1
            FROM reservas
            WHERE programacion_id = v_programacion_id
              AND cliente_id = p_cliente_id
        ) THEN

            ROLLBACK;
            SET rta = -3;

        ELSE

            -- Verificar si es socio activo
            SELECT EXISTS(
                SELECT 1
                FROM socios s
                WHERE s.cliente_id = p_cliente_id
                  AND s.estado = TRUE
            )
            INTO v_es_socio;

            IF v_es_socio THEN

                -- Reserva autorizada para socio
                INSERT INTO reservas(
                    programacion_id,
                    cliente_id,
                    fecha_reserva,
                    estado
                )
                VALUES(
                    v_programacion_id,
                    p_cliente_id,
                    NOW(),
                    'Autorizada'
                );

                -- El socio ocupa el cupo inmediatamente
                UPDATE programaciones
                SET cupos_disponibles = cupos_disponibles - 1
                WHERE id = v_programacion_id;

            ELSE

                -- El no socio deberá pagar posteriormente
                INSERT INTO reservas(
                    programacion_id,
                    cliente_id,
                    fecha_reserva,
                    estado
                )
                VALUES(
                    v_programacion_id,
                    p_cliente_id,
					NOW(),
                    'Pendiente de pago'
                );

            END IF;

            SET v_reserva_id = LAST_INSERT_ID();

            COMMIT;

            SET rta = v_reserva_id;

        END IF;

    END IF;

END IF;

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO LISTAR VENCIMIENTOS
-- =========================================

DELIMITER //
CREATE PROCEDURE ListarVencimientos(
	IN p_fecha_vencimiento DATE
)
BEGIN

SELECT 
	p.nombre,
    p.apellido,
    p.dni, 
    c.monto_cuota,
    c.fecha_vencimiento,
    c.estado_cuota
    FROM personas p 
    INNER JOIN clientes cl
    ON p.id = cl.persona_id
    INNER JOIN socios s
    ON s.cliente_id = cl.id
    INNER JOIN cuotas c 
    ON s.id = c.socio_id
    WHERE DATE(c.fecha_vencimiento) = p_fecha_vencimiento;
END //
DELIMITER ;

-- =========================================
-- PROCEDIMIENTO BUSCAR RESERVA POR ID
-- =========================================

DELIMITER // 
CREATE PROCEDURE BuscarReservaPorId(
	IN p_id_reserva INT
)

BEGIN
	SELECT 
		r.id AS id_Reserva, 
        r.estado, 
        r.cliente_id AS id_cliente, 
        p.nombre, 
        p.apellido, 
        p.dni, 
        a.nombre AS actividad, 
        a.precio, 
        pr.fecha_hora
	FROM reservas r 
    INNER JOIN programaciones pr
		ON r.programacion_id = pr.id
	INNER JOIN actividades a 
		ON pr.actividad_id = a.id
	INNER JOIN clientes cl 
		ON r.cliente_id = cl.id
	INNER JOIN personas p 
		ON cl.persona_id = p.id
		WHERE r.id = p_id_reserva;
END //
DELIMITER ;


-- =================================================
-- PROCEDIMIENTO BUSCAR RESERVA POR DNI Y ACTIVIDAD
-- =================================================
DELIMITER //

CREATE PROCEDURE BuscarReservaPorDniYActividad(
    IN p_dni VARCHAR(10),
    IN p_id_actividad INT
)
BEGIN
    SELECT
        r.id AS id_reserva,
        cl.id AS id_cliente,
        p.nombre,
        p.apellido,
        p.dni,
        a.id AS id_actividad,
        a.nombre AS actividad,
        a.precio,
        r.estado,
        pr.fecha_hora
    FROM reservas r
    INNER JOIN programaciones pr
        ON r.programacion_id = pr.id
    INNER JOIN actividades a
        ON pr.actividad_id = a.id
    INNER JOIN clientes cl
        ON r.cliente_id = cl.id
    INNER JOIN personas p
        ON cl.persona_id = p.id
    WHERE p.dni = p_dni
      AND a.id = p_id_actividad
    ORDER BY pr.fecha_hora;
END //

DELIMITER ;


-- =================================================
-- PROCEDIMIENTO BUSCAR RESERVAS
-- =================================================
DELIMITER //

CREATE PROCEDURE BuscarReservas()
BEGIN
    SELECT
        r.id AS id_reserva,
        cl.id AS id_cliente,
        p.nombre,
        p.apellido,
        p.dni,
        a.id AS id_actividad,
        a.nombre AS actividad,
        a.precio,
        r.estado,
        pr.fecha_hora
    FROM reservas r
    INNER JOIN programaciones pr
        ON r.programacion_id = pr.id
    INNER JOIN actividades a
        ON pr.actividad_id = a.id
    INNER JOIN clientes cl
        ON r.cliente_id = cl.id
    INNER JOIN personas p
        ON cl.persona_id = p.id
    ORDER BY pr.fecha_hora;
END //

DELIMITER ;