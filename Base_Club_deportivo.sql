DROP DATABASE IF EXISTS ClubDeportivo;

CREATE DATABASE ClubDeportivo;

USE ClubDeportivo;

-- =========================================
-- TABLA ROLES
-- =========================================

CREATE TABLE roles(
    RolUsu INT,
    NomRol VARCHAR(30),

    CONSTRAINT pk_roles
    PRIMARY KEY(RolUsu)
);

INSERT INTO roles VALUES
(100,'Administrador'),
(101,'Empleado');

-- =========================================
-- TABLA USUARIOS
-- =========================================

CREATE TABLE usuario(
    CodUsu INT AUTO_INCREMENT,
    NombreUsu VARCHAR(20),
    PassUsu VARCHAR(20),
    RolUsu INT,
    Activo BOOLEAN DEFAULT TRUE,

    CONSTRAINT pk_usuario
    PRIMARY KEY(CodUsu),

    CONSTRAINT fk_usuario
    FOREIGN KEY(RolUsu)
    REFERENCES roles(RolUsu)
);

INSERT INTO usuario(NombreUsu,PassUsu,RolUsu)
VALUES
('admin','1234',100);

-- =========================================
-- TABLA PERSONA
-- =========================================

CREATE TABLE persona(
    IdPersona INT,
    Nombre VARCHAR(30),
    Apellido VARCHAR(40),
    DNI INT,

    CONSTRAINT pk_persona
    PRIMARY KEY(IdPersona),

    CONSTRAINT uq_persona_dni
    UNIQUE(DNI)
);

-- =========================================
-- TABLA SOCIO
-- =========================================

CREATE TABLE socio(
    IdSocio INT,
    IdPersona INT,
    Estado BOOLEAN DEFAULT TRUE,

    CONSTRAINT pk_socio
    PRIMARY KEY(IdSocio),

    CONSTRAINT fk_socio_persona
    FOREIGN KEY(IdPersona)
    REFERENCES persona(IdPersona)
);

-- =========================================
-- TABLA NO SOCIO
-- =========================================

CREATE TABLE noSocio(
    IdNoSocio INT,
    IdPersona INT,
    AccesoDiario BOOLEAN DEFAULT FALSE,

    CONSTRAINT pk_noSocio
    PRIMARY KEY(IdNoSocio),

    CONSTRAINT fk_noSocio_persona
    FOREIGN KEY(IdPersona)
    REFERENCES persona(IdPersona)
);

-- =========================================
-- TABLA CARNET
-- =========================================

CREATE TABLE carnet(
    IdCarnet INT,
    IdSocio INT,
    Estado BOOLEAN DEFAULT TRUE,

    CONSTRAINT pk_carnet
    PRIMARY KEY(IdCarnet),

    CONSTRAINT fk_carnet_socio
    FOREIGN KEY(IdSocio)
    REFERENCES socio(IdSocio)
);

-- =========================================
-- TABLA CUOTA
-- =========================================

CREATE TABLE cuota(
    IdCuota INT,
    IdSocio INT,
    MesVigencia VARCHAR(20),
    FechaVencimiento DATE,
    EstadoPago VARCHAR(20),

    CONSTRAINT pk_cuota
    PRIMARY KEY(IdCuota),

    CONSTRAINT fk_cuota_socio
    FOREIGN KEY(IdSocio)
    REFERENCES socio(IdSocio)
);

-- =========================================
-- TABLA PAGO
-- =========================================

CREATE TABLE pago(
    IdPago INT,
    IdCuota INT,
    FechaPago DATE,
    Monto FLOAT,
    TipoPago VARCHAR(30),
    MetodoPago VARCHAR(30),

    CONSTRAINT pk_pago
    PRIMARY KEY(IdPago),

    CONSTRAINT fk_pago_cuota
    FOREIGN KEY(IdCuota)
    REFERENCES cuota(IdCuota)
);

-- =========================================
-- TABLA INSCRIPCION
-- =========================================

CREATE TABLE inscripcion(
    IdInscripcion INT,
    IdSocio INT,
    FechaInscripcion DATE,

    CONSTRAINT pk_inscripcion
    PRIMARY KEY(IdInscripcion),

    CONSTRAINT fk_inscripcion_socio
    FOREIGN KEY(IdSocio)
    REFERENCES socio(IdSocio)
);

-- PROCEDIMIENTOS

-- Procedimiento nuevosocio
 
DELIMITER //

CREATE PROCEDURE NuevoSocio(
    IN Nom VARCHAR(30),
    IN Ape VARCHAR(40),
    IN Doc INT,
    OUT rta INT
)

BEGIN

    DECLARE filas INT DEFAULT 0;
    DECLARE existe INT DEFAULT 0;

    SET existe = (
        SELECT COUNT(*)
        FROM persona
        WHERE DNI = Doc
    );

    IF existe = 0 THEN

        SET filas = (
            SELECT IFNULL(MAX(IdPersona),0) + 1
            FROM persona
        );

        INSERT INTO persona
        VALUES(filas,Nom,Ape,Doc);

        INSERT INTO socio
        VALUES(filas,filas,TRUE);

        SET rta = filas;

    ELSE

        SET rta = -1;

    END IF;

END //

DELIMITER ;

-- Procedimiento login

DELIMITER //

CREATE PROCEDURE LoginUsuario(
    IN Usu VARCHAR(20),
    IN Passw VARCHAR(20)
)

BEGIN

    SELECT *
    FROM usuario
    WHERE NombreUsu = Usu
    AND PassUsu = Passw
    AND Activo = TRUE;

END //

DELIMITER ;

-- Procedimiento Estadocuota

DELIMITER //

CREATE PROCEDURE EstadoCuota(
    IN Doc INT
)

BEGIN

    SELECT
        p.Nombre,
        p.Apellido,
        c.MesVigencia,
        c.FechaVencimiento,
        c.EstadoPago
    FROM persona p
    INNER JOIN socio s
        ON p.IdPersona = s.IdPersona
    INNER JOIN cuota c
        ON s.IdSocio = c.IdSocio
    WHERE p.DNI = Doc;

END //

DELIMITER ;

-- Procedimiento Registrarpago

DELIMITER //

CREATE PROCEDURE RegistrarPago(
    IN idC INT,
    IN mon FLOAT,
    IN tip VARCHAR(30),
    IN met VARCHAR(30)
)

BEGIN

    DECLARE nuevoPago INT;

    SET nuevoPago = (
        SELECT IFNULL(MAX(IdPago),0) + 1
        FROM pago
    );

    INSERT INTO pago
    VALUES(
        nuevoPago,
        idC,
        CURDATE(),
        mon,
        tip,
        met
    );

    UPDATE cuota
    SET EstadoPago = 'Pagado'
    WHERE IdCuota = idC;

END //

DELIMITER ;