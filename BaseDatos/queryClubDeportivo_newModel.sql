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
    pagada BOOLEAN DEFAULT false,
    
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

INSERT INTO programaciones (actividad_id, fecha_hora, cupos_disponibles)
VALUES
(1, '2026-06-09 18:00:00', 20),
(1, '2026-06-11 18:00:00', 15),
(1, '2026-06-13 18:00:00', 10),
(1, '2026-06-16 18:00:00', 0),
(1, '2026-06-20 18:00:00', 0),
(2, '2026-06-10 19:00:00', 12),
(2, '2026-06-12 19:00:00', 8),
(2, '2026-06-15 19:00:00', 5),
(2, '2026-06-18 19:00:00', 0),
(2, '2026-06-22 19:00:00', 0),
(3, '2026-06-09 20:00:00', 18),
(3, '2026-06-12 20:00:00', 10),
(3, '2026-06-14 20:00:00', 7),
(3, '2026-06-17 20:00:00', 0),
(3, '2026-06-21 20:00:00', 0),
(4, '2026-06-10 10:00:00', 4),
(4, '2026-06-12 10:00:00', 3),
(4, '2026-06-15 10:00:00', 2),
(4, '2026-06-18 10:00:00', 0),
(4, '2026-06-22 10:00:00', 0),
(5, '2026-06-09 08:00:00', 25),
(5, '2026-06-11 08:00:00', 20),
(5, '2026-06-14 08:00:00', 15),
(5, '2026-06-17 08:00:00', 0),
(5, '2026-06-20 08:00:00', 0),
(6, '2026-06-10 17:00:00', 15),
(6, '2026-06-13 17:00:00', 10),
(6, '2026-06-16 17:00:00', 5),
(6, '2026-06-19 17:00:00', 0),
(6, '2026-06-22 17:00:00', 0),
(7, '2026-06-09 19:00:00', 15),
(7, '2026-06-12 19:00:00', 10),
(7, '2026-06-15 19:00:00', 6),
(7, '2026-06-18 19:00:00', 0),
(7, '2026-06-21 19:00:00', 0),
(8, '2026-06-09 07:00:00', 30),
(8, '2026-06-12 07:00:00', 25),
(8, '2026-06-15 07:00:00', 20),
(8, '2026-06-18 07:00:00', 0),
(8, '2026-06-22 07:00:00', 0),
(9, '2026-06-10 08:00:00', 20),
(9, '2026-06-13 08:00:00', 15),
(9, '2026-06-16 08:00:00', 10),
(9, '2026-06-19 08:00:00', 0),
(9, '2026-06-22 08:00:00', 0),
(10, '2026-06-09 06:30:00', 12),
(10, '2026-06-12 06:30:00', 8),
(10, '2026-06-15 06:30:00', 4),
(10, '2026-06-18 06:30:00', 0),
(10, '2026-06-21 06:30:00', 0),
(11, '2026-06-10 18:30:00', 20),
(11, '2026-06-13 18:30:00', 15),
(11, '2026-06-16 18:30:00', 10),
(11, '2026-06-19 18:30:00', 0),
(11, '2026-06-22 18:30:00', 0),
(12, '2026-06-09 09:00:00', 18),
(12, '2026-06-12 09:00:00', 12),
(12, '2026-06-15 09:00:00', 8),
(12, '2026-06-18 09:00:00', 0),
(12, '2026-06-21 09:00:00', 0),
(13, '2026-06-10 20:00:00', 25),
(13, '2026-06-13 20:00:00', 18),
(13, '2026-06-16 20:00:00', 12),
(13, '2026-06-19 20:00:00', 0),
(13, '2026-06-22 20:00:00', 0);


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
    IN p_aptoFisico BOOLEAN,
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

        SET rta = v_cliente_id;

    END IF;

END //

DELIMITER ;


-- =========================================
-- PROCEDIMIENTO ASIGNAR TIPO CLIENTE
-- =========================================
DELIMITER //

CREATE PROCEDURE asignarTipoCliente(
    IN p_cliente_id INT,
    IN p_es_socio BOOLEAN,
    OUT rta INT
)

BEGIN
    IF p_es_socio = TRUE THEN
		-- si es socio se ingresa a tabla socios
        INSERT INTO socios(cliente_id, estado)
        VALUES(p_cliente_id, TRUE);
            
	SET rta = LAST_INSERT_ID();
    ELSE
		-- si no es socio se ingresa a tabla no_socios
        INSERT INTO no_socios(cliente_id, acceso_diario)
        VALUES(p_cliente_id, TRUE);
        
        SET rta = LAST_INSERT_ID();

    END IF;

END //

DELIMITER ;

-- ===========================================
-- PROCEDIMIENTO FORMALIZAR INSCRIPCIÓN SOCIO 
-- ===========================================

DELIMITER //

CREATE PROCEDURE FormalizarInscripcion(
    IN p_socio_id INT,
    IN p_monto_cuota DECIMAL,
    OUT rta INT
)

BEGIN
    DECLARE existe INT DEFAULT 0;
    DECLARE v_inscripcion_id INT;
    DECLARE v_cuota_id INT;
    
    -- manejo de errores
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
BEGIN
    ROLLBACK;
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @msg = MESSAGE_TEXT;
    SET rta = -99;
    SELECT @sqlstate, @msg;
END;
    
	START TRANSACTION;

    -- verificar si ya tiene inscripción
    SELECT COUNT(*)
    INTO existe
    FROM inscripciones
    WHERE socio_id = p_socio_id;

    IF existe > 0 THEN
		ROLLBACK;
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
			
		-- definir cuota inicial con estado pendiente
		INSERT INTO cuotas(
			socio_id,
			monto_cuota,
			fecha_vencimiento,
			estado_cuota
		)
		VALUES(
			p_socio_id,
			p_monto_cuota,
			CURDATE(),
			'Pendiente'
			);
			
		SET v_cuota_id = LAST_INSERT_ID();
		
		COMMIT;
		
		SET rta = v_inscripcion_id;
			
    END IF;

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

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET rta = -99;
    END;

    START TRANSACTION;

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

    UPDATE reservas
    SET pagada = TRUE
    WHERE id = p_reserva_id;

    SET rta = LAST_INSERT_ID();

    COMMIT;

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO GENERAR CUOTAS MENSUALES
-- =========================================

DELIMITER //
CREATE PROCEDURE InsertarNuevaCuota(
)
BEGIN
		INSERT INTO cuotas (
		socio_id,
		monto_cuota,
		fecha_vencimiento,
		estado_cuota
	)
	SELECT
		s.id,
		c.mono_cuota, 
		DATE_FORMAT(CURDATE(), '%Y-%m-05'),
		'Pendiente'
	FROM socios s
    INNER JOIN cuotas c 
    ON c.socio_id = s.id
	WHERE NOT EXISTS (
		SELECT 1
		FROM cuota c
		WHERE c.socio_id = s.id
		  AND YEAR(c.fecha_vencimiento) = YEAR(CURDATE())
		  AND MONTH(c.fecha_vencimiento) = MONTH(CURDATE())
);
END //
DELIMITER ;
	
-- =========================================
-- PROCEDIMIENTO ESTADO CUOTA POR SOCIO
-- =========================================

DELIMITER //

CREATE PROCEDURE ObtenerCuotaPendiente(
    IN in_dni VARCHAR(10)
)

BEGIN

    SELECT
        p.nombre,
        p.apellido,
        p.dni,
        s.id,
        s.estado,
        c.id AS 'id_cuota',
        c.monto_cuota,
        c.fecha_vencimiento
    FROM personas p
    INNER JOIN clientes cl
        ON p.id = cl.persona_id
    INNER JOIN socios s
        ON cl.id = s.cliente_id
    INNER JOIN cuotas c
        ON s.id = c.socio_id
    WHERE p.dni = in_dni
    AND c.estado_cuota = 'Pendiente';

END //

DELIMITER ;

-- =========================================
-- PROCEDIMIENTO RESERVA
-- =========================================

DELIMITER //
CREATE PROCEDURE generarReserva(
	IN p_id_actividad INT,
	IN p_cliente_id INT,
	IN p_fecha_hora DATETIME,
	OUT rta INT
)
BEGIN
	DECLARE v_programacion_id INT;
	DECLARE v_reserva_id INT;

	SELECT p.id 
		INTO v_programacion_id
		FROM programaciones p
		WHERE actividad_id = p_id_actividad
		AND fecha_hora = p_fecha_hora
		LIMIT 1;
        
	IF v_programacion_id IS NULL THEN
		SET rta = -1;
	ELSE
		IF EXISTS(
			SELECT 1
			FROM reservas
			WHERE programacion_id = v_programacion_id
			  AND cliente_id = p_cliente_id
		) THEN
			SET rta = -2;
		ELSE
			INSERT INTO reservas(
				programacion_id, 
				cliente_id, 
				fecha_reserva, 
				pagada
			) 
			VALUES(
				v_programacion_id,
				p_cliente_id,
				NOW(),
				FALSE
			);
			
			SET v_reserva_id = LAST_INSERT_ID();
			SET rta = v_reserva_id;
		END IF;
	END IF;
END //
DELIMITER ;

-- =========================================
-- PROCEDIMIENTO LISTAR VENCIMIENTOS
-- =========================================

DELIMITER //
CREATE PROCEDURE listarVencimientos(
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
