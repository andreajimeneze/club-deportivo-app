use club_deportivo;

DROP DATABASE IF EXISTS Club_deportivo;

CREATE DATABASE club_deportivo;

USE club_deportivo;

-- =========================================
-- TABLA ROLES
-- =========================================

CREATE TABLE roles(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30)
);

INSERT INTO roles(nombre)  VALUES
('admin'),
('user');

-- =========================================
-- TABLA USUARIOS
-- =========================================

CREATE TABLE usuarios(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(20),
    password VARCHAR(20),
    rol_id INT,
    activo BOOLEAN DEFAULT TRUE,

    CONSTRAINT fk_usuarios_roles
    FOREIGN KEY(role_id)
    REFERENCES roles(id)
);

INSERT INTO usuario(nombre, password, rol_id)
VALUES
('Andrea Jiménez','1234', 1);

-- =========================================
-- TABLA PERSONAS
-- =========================================

CREATE TABLE personas(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30),
    apellido VARCHAR(40),
    dni INT UNIQUE
);

-- =========================================
-- TABLA SOCIOS
-- =========================================

CREATE TABLE socios(
    persona_id INT PRIMARY KEY,
    estado BOOLEAN DEFAULT TRUE,

    CONSTRAINT fk_socios_personas
    FOREIGN KEY(persona_id)
    REFERENCES personas(id)
);

-- =========================================
-- TABLA NO SOCIOS
-- =========================================

CREATE TABLE no_socios(
    persona_id INT PRIMARY KEY,
    acceso_diario BOOLEAN DEFAULT FALSE,
    
    CONSTRAINT fk_no_socios_personas
    FOREIGN KEY(persona_id)
    REFERENCES persona(id)
);

-- =========================================
-- TABLA INSCRIPCIONES
-- =========================================

CREATE TABLE inscripciones(
    id INT AUTO_INCREMENT PRIMARY KEY,
    socio_id INT,
    fecha_inscripcion DATE,

    CONSTRAINT fk_inscripciones_socios
    FOREIGN KEY(socio_id)
    REFERENCES socios(id)
);

-- =========================================
-- TABLA CARNET
-- =========================================

CREATE TABLE carnet(
    id INT AUTO_INCREMENT PRIMARY KEY,
    inscripcion_id INT,
    estado BOOLEAN DEFAULT TRUE,

    CONSTRAINT fk_carnet_inscripciones
    FOREIGN KEY(inscripcion_id)
    REFERENCES inscripciones(id)
);

-- =========================================
-- TABLA CUOTAS
-- =========================================

CREATE TABLE cuota(
    id INT AUTO_INCREMENT PRIMARY KEY,
    socio_id INT,
    mes_vigencia VARCHAR(20),
    fecha_vencimiento DATE,
    estado_pago VARCHAR(20),

    CONSTRAINT fk_cuotaS_socioS
    FOREIGN KEY(socio_id)
    REFERENCES socios(id)
);

-- =========================================
-- TABLA PAGO
-- =========================================

CREATE TABLE pagos(
    id INT AUTO_INCREMENT PRIMARY KEY,
    cuota_id INT,
    fecha_pago DATE,
    monto FLOAT,
    tipo_pago VARCHAR(30),
    metodo_pago VARCHAR(30),

    CONSTRAINT fk_pagos_cuotas
    FOREIGN KEY(cuota_id)
    REFERENCES cuota(id)
);



