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
-- TABLA CLIENTES
-- =========================================

CREATE TABLE clientes(
    id INT AUTO_INCREMENT PRIMARY KEY,
    persona_id INT NOT NULL UNIQUE,
    aptoFisico BOOLEAN NOT NULL DEFAULT TRUE,

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
    cliente_id INT NOT NULL UNIQUE,
    estado BOOLEAN DEFAULT TRUE,

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
    REFERENCES cuotas(id),

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
-- PROCEDIMIENTO REGISTRAR CLIENTE
-- =========================================

DELIMITER //

CREATE PROCEDURE RegistrarCliente(
    IN p_nombre VARCHAR(30),
    IN p_apellido VARCHAR(40),
    IN p_dni INT,
    IN p_aptoFisico BOOLEAN,
    IN p_es_socio BOOLEAN,
    OUT rta INT
)

BEGIN

    DECLARE existe INT DEFAULT 0;
    DECLARE v_persona_id INT;
    DECLARE v_cliente_id INT;
    DECLARE v_id_generado INT;

    -- verificar si ya existe persona
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

        -- insertar cliente
        INSERT INTO clientes(persona_id, aptoFisico)
        VALUES(v_persona_id, p_aptoFisico);

        SET v_cliente_id = LAST_INSERT_ID();

        SET rta = v_id_generado;

    END IF;

END //

DELIMITER ;

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
        r.id AS rol_id,
        r.nombre AS rol,
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
-- PROCEDIMIENTO ASIGNAR TIPO CLIENTE
-- =========================================
DELIMITER //

CREATE PROCEDURE asignarTipoCliente(
    IN p_cliente_id INT,
    IN p_es_socio BOOLEAN
)

BEGIN

    IF p_es_socio = TRUE THEN

        INSERT INTO socios(cliente_id, estado)
        VALUES(p_cliente_id, TRUE);

    ELSE

        INSERT INTO no_socios(cliente_id, acceso_diario)
        VALUES(p_cliente_id, TRUE);

    END IF;

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO FORMALIZAR INSCRIPCIÓN CLIENTE
-- =========================================

DELIMITER //

CREATE PROCEDURE FormalizarInscripcion(
    IN p_socio_id INT,
    OUT rta INT
)

BEGIN

    DECLARE existe INT DEFAULT 0;
    DECLARE v_inscripcion_id INT;

    -- verificar si ya tiene inscripción
    SELECT COUNT(*)
    INTO existe
    FROM inscripciones
    WHERE socio_id = p_socio_id;

    IF existe > 0 THEN

        SET rta = -1;

    ELSE

        -- crear inscripción
        INSERT INTO inscripciones(
            socio_id,
            fecha_inscripcion
        )
        VALUES(
            p_socio_id,
            CURDATE()
        );

        SET v_inscripcion_id = LAST_INSERT_ID();

        -- generar carnet automáticamente
        INSERT INTO carnet(
            inscripcion_id,
            estado
        )
        VALUES(
            v_inscripcion_id,
            TRUE
        );

        SET rta = v_inscripcion_id;

    END IF;

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
    INNER JOIN clientes cl
        ON p.id = cl.persona_id
    INNER JOIN socios s
        ON cl.id = s.cliente_id
    INNER JOIN cuotas c
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

    UPDATE cuotas
    SET estado_pago = 'Pagado'
    WHERE id = p_cuota_id;

END //

DELIMITER ;