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

-- =========================================
-- TABLA PAGOS
-- =========================================

CREATE TABLE pagos(
    id INT AUTO_INCREMENT PRIMARY KEY,

    cuota_id INT NULL,
    no_socio_id INT NULL,

    fecha_pago DATE NOT NULL,
    monto DECIMAL NOT NULL,

    concepto_id INT NOT NULL,
    metodo_id INT NOT NULL,

    CONSTRAINT fk_pagos_cuotas
    FOREIGN KEY(cuota_id)
    REFERENCES cuotas(id),

    CONSTRAINT fk_pagos_no_socios
    FOREIGN KEY(no_socio_id)
    REFERENCES no_socios(id),
    
    CONSTRAINT fk_pagos_conceptos_pago
    FOREIGN KEY(concepto_id)
    REFERENCES conceptos_pago(id),
    
    CONSTRAINT fk_pagos_metodos_pago
    FOREIGN KEY(metodo_id)
    REFERENCES metodos_pago(id),
    
    CONSTRAINT chk_origen_pago CHECK ( 
    (cuota_id IS NOT NULL AND no_socio_id IS NULL) 
    OR (cuota_id IS NULL AND no_socio_id IS NOT NULL) )
);


CREATE TABLE actividades(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL
    );
    
CREATE TABLE no_socio_actividad(
	no_socio_id INT NOT NULL,
	actividad_id INT NOT NULL,

	CONSTRAINT fk_no_socios_actividades_no_socios
	FOREIGN KEY(no_socio_id)
	REFERENCES no_socios(id),

	CONSTRAINT fk_no_socios_actividades_no_socios_actividades
	FOREIGN KEY(actividad_id)
	REFERENCES actividades(id)
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

INSERT INTO actividades(nombre) 
VALUES 
('Fútbol'), 
('Básquet'), 
('Vóley'), 
('Tenis'), 
('Natación'),
('Karate'), 
('Taekwondo'), 
('Gimnasio'), 
('Musculación'), 
('Crossfit'), 
('Spinning'), 
('Yoga'), 
('Pilates'), 
('Zumba');

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
        SET rta = -99;
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
-- PROCEDIMIENTO REGISTRAR PAGO
-- =========================================

DELIMITER //

CREATE PROCEDURE RegistrarPago(
	IN p_socio_id INT,
    IN p_no_socio_id INT,
    IN p_monto DECIMAL,
    IN p_concepto_id INT,
    IN p_metodo_id INT,
    OUT rta INT
)

BEGIN
	DECLARE v_cuota_id INT;
	DECLARE v_monto_cuota DECIMAL;
	DECLARE v_id_pago INT;
    DECLARE existe INT;
    
    -- manejo de errores
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET rta = -99;
    END;
    
	START TRANSACTION;
    
    IF p_socio_id IS NULL THEN
		-- se ejecuta el pago de una actividad para no socio
		 INSERT INTO pagos(
			cuota_id,
			no_socio_id,
			fecha_pago,
			monto,
			concepto_id,
			metodo_id
		)
		VALUES(
			NULL,
			p_no_socio_id,
			CURDATE(),
			p_monto,
			p_concepto_id,
			p_metodo_id
		);
		SET v_id_pago = LAST_INSERT_ID();
		SET rta = v_id_pago;
	ELSE 
    -- verifica si hay cuotas pendientes
    SELECT COUNT(*)
		INTO existe
        FROM cuotas
        WHERE socio_id = p_socio_id AND
            estado_cuota = 'Pendiente';
            
		IF existe = 0 THEN
			ROLLBACK;
			SET rta = -2;
		ELSE
			-- busca cuota pendiente más antigua 
				SELECT id, monto_cuota
					INTO v_cuota_id, v_monto_cuota
					FROM cuotas
					WHERE socio_id = p_socio_id AND
					estado_cuota = 'Pendiente'
					ORDER BY fecha_vencimiento ASC
					LIMIT 1;
            
			-- se ejecuta el pago de una cuota
				 INSERT INTO pagos(
					cuota_id,
					no_socio_id,
					fecha_pago,
					monto,
					concepto_id,
					metodo_id
				)
				VALUES(
					v_cuota_id,
					NULL,
					CURDATE(),
					v_monto_cuota,
					p_concepto_id,
					p_metodo_id
				);
				SET v_id_pago = LAST_INSERT_ID();
				
				-- se actualiza estado de la cuota a pagado
				UPDATE cuotas
				SET estado_cuota = 'Pagada'
				WHERE id = v_cuota_id;
                
                SET rta = v_id_pago;
		END IF;
	END IF;
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

CREATE PROCEDURE EstadoCuota(
    IN p_dni VARCHAR(10)
)

BEGIN

    SELECT
        p.nombre,
        p.apellido,
        c.monto_cuota,
        c.fecha_vencimiento,
        c.estado_cuota
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
-- PROCEDIMIENTO LISTAR VENCIMIENTOS
-- =========================================

DELIMITER //
CREATE PROCEDURE listarVencimientos(
	IN p_fecha_vencimiento DATE,
    IN p_estado_cuota VARCHAR(20)
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
    WHERE c.estado_cuota = p_estado_cuota AND
    DATE(c.fecha_vencimiento) = p_fecha_vencimiento;
END //
DELIMITER ;