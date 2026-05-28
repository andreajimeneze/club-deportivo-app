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
    dni INT NOT NULL UNIQUE
);

-- =========================================
-- TABLA USUARIOS
-- =========================================

CREATE TABLE usuarios(
    id INT AUTO_INCREMENT PRIMARY KEY,
    persona_id INT NOT NULL UNIQUE,
    username VARCHAR(20) NOT NULL UNIQUE,
    password VARCHAR(20) NOT NULL,
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
    persona_id INT NOT NULL UNIQUE,
    estado BOOLEAN DEFAULT TRUE,

    CONSTRAINT fk_socios_personas
    FOREIGN KEY(persona_id)
    REFERENCES personas(id)
);

-- =========================================
-- TABLA NO SOCIOS
-- =========================================

CREATE TABLE no_socios(
    id INT AUTO_INCREMENT PRIMARY KEY,
    persona_id INT NOT NULL UNIQUE,
    acceso_diario BOOLEAN DEFAULT FALSE,

    CONSTRAINT fk_no_socios_personas
    FOREIGN KEY(persona_id)
    REFERENCES personas(id)
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
    inscripcion_id INT NOT NULL,
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
    socio_id INT NOT NULL,
    mes_vigencia VARCHAR(20) NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    estado_pago VARCHAR(20) DEFAULT 'Pendiente',

    CONSTRAINT fk_cuotas_socios
    FOREIGN KEY(socio_id)
    REFERENCES socios(id)
);

-- =========================================
-- TABLA PAGOS
-- =========================================

CREATE TABLE pagos(
    id INT AUTO_INCREMENT PRIMARY KEY,

    cuota_id INT NULL,
    no_socio_id INT NULL,

    fecha_pago DATE NOT NULL,
    monto FLOAT NOT NULL,

    tipo_pago VARCHAR(30),
    metodo_pago VARCHAR(30),

    CONSTRAINT fk_pagos_cuotas
    FOREIGN KEY(cuota_id)
    REFERENCES cuota(id),

    CONSTRAINT fk_pagos_no_socios
    FOREIGN KEY(no_socio_id)
    REFERENCES no_socios(id)
);

-- =========================================
-- DATOS INICIALES
-- =========================================

INSERT INTO roles(nombre)
VALUES
('admin'),
('user');

INSERT INTO personas(nombre, apellido, dni)
VALUES
('Andrea', 'Jiménez', 24753731),
('Angélica', 'Dos Reis', 38333222);

INSERT INTO usuarios(
    persona_id,
    username,
    password,
    rol_id
)
VALUES
(1, 'andrea', '1234', 1),
(2, 'angelica', '5678', 2);

-- =========================================
-- PROCEDIMIENTO NUEVO SOCIO
-- =========================================

DELIMITER //

CREATE PROCEDURE RegistrarPersonaBasico(
    IN p_nombre VARCHAR(30),
    IN p_apellido VARCHAR(40),
    IN p_dni INT,
    IN p_es_socio BOOLEAN,
    OUT rta INT
)

BEGIN

    DECLARE existe INT DEFAULT 0;
    DECLARE v_persona_id INT;
    DECLARE v_id_generado INT;

    -- verificar si existe persona
    SELECT COUNT(*)
    INTO existe
    FROM personas
    WHERE dni = p_dni;

    IF existe > 0 THEN
        SET rta = -1;
    ELSE

        -- insertar persona
        INSERT INTO personas(nombre, apellido, dni)
        VALUES(p_nombre, p_apellido, p_dni);

        SET v_persona_id = LAST_INSERT_ID();

        -- si es socio
        IF p_es_socio = TRUE THEN

            INSERT INTO socios(persona_id, estado)
            VALUES(v_persona_id, TRUE);

            SET v_id_generado = LAST_INSERT_ID();

        -- si es no socio
        ELSE

            INSERT INTO no_socios(persona_id, acceso_diario)
            VALUES(v_persona_id, TRUE);

            SET v_id_generado = LAST_INSERT_ID();

        END IF;

        SET rta = v_id_generado;

    END IF;

END 
// DELIMITER ;

-- =========================================
-- PROCEDIMIENTO LOGIN
-- =========================================

DELIMITER //

CREATE PROCEDURE LoginUsuario(
    IN p_username VARCHAR(20),
    IN p_password VARCHAR(20)
)

BEGIN

    SELECT
        u.id,
        u.username,
        u.activo,
        r.id,
        p.nombre,
        p.apellido,
        p.dni
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
-- PROCEDIMIENTO ESTADO CUOTA
-- =========================================

DELIMITER //

CREATE PROCEDURE EstadoCuota(
    IN p_dni INT
)

BEGIN

    SELECT
        p.nombre,
        p.apellido,
        c.mes_vigencia,
        c.fecha_vencimiento,
        c.estado_pago
    FROM personas p
    INNER JOIN socios s
        ON p.id = s.persona_id
    INNER JOIN cuota c
        ON s.id = c.socio_id
    WHERE p.dni = p_dni;

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO REGISTRAR PAGO
-- =========================================

DELIMITER //

CREATE PROCEDURE RegistrarPago(
    IN p_cuota_id INT,
    IN p_monto FLOAT,
    IN p_tipo_pago VARCHAR(30),
    IN p_metodo_pago VARCHAR(30)
)

BEGIN

    INSERT INTO pagos(
        cuota_id,
        fecha_pago,
        monto,
        tipo_pago,
        metodo_pago
    )
    VALUES(
        p_cuota_id,
        CURDATE(),
        p_monto,
        p_tipo_pago,
        p_metodo_pago
    );

    UPDATE cuota
    SET estado_pago = 'Pagado'
    WHERE id = p_cuota_id;

END //

DELIMITER ;