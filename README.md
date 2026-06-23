# Club Deportivo Estrella del Sur — Sistema de Gestión

Sistema de escritorio desarrollado en **C# / Windows Forms (.NET Framework 4.7.2)** para la administración integral de un club deportivo. Permite gestionar socios, reservas de actividades, pagos de cuotas, generación de carnets y control de vencimientos, con conexión a una base de datos **MySQL**.

---

## Características principales

- **Autenticación de usuarios** con control de intentos fallidos (máximo 3 intentos antes del bloqueo).
- **Registro de clientes**, diferenciando entre socios y no socios.
- **Reservas de actividades** con validación de apto físico, cupos disponibles, vigencia de programación y estado del socio.
- **Gestión de pagos**: pago de cuotas para socios y pago de actividades para no socios.
- **Generación de carnets en PDF** con formato de tarjeta de crédito (85.6 × 53.98 mm) usando QuestPDF.
- **Comprobantes de reserva y pago** generados automáticamente.
- **Panel de vencimientos** para el seguimiento de socios morosos.
- **Dashboard central** con acceso rápido a todos los módulos.

---

## Tecnologías y dependencias

| Componente | Detalle |
|---|---|
| Plataforma | .NET Framework 4.7.2 — Windows Forms |
| Base de datos | MySQL |
| Conector MySQL | `MySql.Data` 9.7.0 / `MySqlConnector` 2.5.0 |
| Generación de PDF | `QuestPDF` 2026.6.0 (licencia Community) |
| Otros | `BouncyCastle.Cryptography`, `System.Configuration.ConfigurationManager` |

---

## Estructura del proyecto

```
ClubDeportivoApp/
├── BaseDatos/
│   ├── Conexion.cs               # Modelo de datos de conexión
│   ├── ConexionMySql.cs          # Gestión de conexión MySQL
│   └── SQL_C_DEPORTIVO_2.2.sql   # Script de creación de la base de datos
│
├── Modelos/                      # Entidades del dominio
│   ├── Persona.cs
│   ├── Cliente.cs
│   ├── Socio.cs
│   ├── NoSocio.cs
│   ├── Usuario.cs / Rol.cs
│   ├── Actividad.cs / Programacion.cs
│   ├── Reserva.cs
│   ├── Pago.cs / Cuota.cs
│   ├── Inscripcion.cs
│   ├── ConceptoPago.cs / MetodoPago.cs
│   └── Carnet.cs
│
├── DTOS/
│   ├── CuotaDTO.cs
│   └── ReservaDTO.cs
│
├── Interfaces/
│   ├── IListado.cs
│   └── IPago.cs
│
├── Repositorios/                 # Acceso a datos (SQL directo)
│   ├── LoginRepo.cs
│   ├── ClienteRepo.cs
│   ├── PagosRepo.cs
│   ├── ReservaRepo.cs
│   ├── CuotaRepo.cs
│   ├── ActividadRepo.cs
│   ├── InscripcionRepo.cs
│   ├── ProgramacionRepo.cs
│   ├── VencimientoRepo.cs
│   ├── ConceptoPagoRepo.cs
│   └── MetodoPagoRepo.cs
│
├── Servicios/                    # Lógica de negocio
│   ├── LoginServ.cs
│   ├── ClienteServ.cs
│   ├── ReservaServ.cs
│   ├── PagoCuotaServ.cs
│   ├── PagoActividad.cs
│   ├── CuotaServ.cs
│   ├── InscripcionSocioServ.cs
│   ├── ProgramacionServ.cs
│   └── ListadosMaestrosServ.cs
│
├── Documentos/                   # Generación de documentos
│   ├── GeneradorCarnet.cs
│   ├── GeneradorComprobantes.cs
│   └── GeneradorContrato.cs
│
├── Formularios/                  # Formularios Windows Forms
│   ├── AccesoBDForm              # Pantalla de configuración de conexión
│   ├── LoginForm                 # Login con control de intentos
│   ├── DashboardForm             # Panel principal
│   ├── RegistroClientesForm      # Alta de clientes
│   ├── ReservaForm               # Gestión de reservas
│   ├── SeleccionPagoForm         # Selección tipo de pago
│   ├── PagoSocioForm             # Pago de cuotas
│   ├── PagoNoSocioForm           # Pago de actividades
│   ├── CarnetForm                # Generación de carnet PDF
│   ├── FormalizacionSocioForm    # Alta formal de socio
│   ├── VencimientosForm          # Control de morosos
│   └── PopUpPersonalizadoForm    # Diálogos personalizados
│
├── Helpers/
│   └── ValidacionDatos.cs
│
├── Program.cs                    # Punto de entrada
└── App.config                    # Configuración de la aplicación
```

---

## Modelo de dominio

La jerarquía principal de entidades es:

```
Persona
└── Cliente
    ├── Socio        (tiene cuotas, inscripciones, carnet)
    └── NoSocio      (paga por actividad individual)
└── Usuario          (operador del sistema, tiene Rol)
```

Las **reservas** vinculan un `Cliente` con una `Programacion` (instancia de una `Actividad` con fecha, hora y cupos). Los socios activos no pagan la actividad al reservar; los no socios deben abonarla.

---

## Base de datos

El script `BaseDatos/SQL_C_DEPORTIVO_2.2.sql` crea la base de datos `club_deportivo` con las siguientes tablas principales:

`roles` · `personas` · `usuarios` · `clientes` · `socios` · `no_socios` · `inscripciones` · `actividades` · `programaciones` · `reservas` · `cuotas` · `pagos` · `conceptos_pago` · `metodos_pago`

---

## Configuración e instalación

### Requisitos previos

- Windows con .NET Framework 4.7.2 o superior.
- Servidor MySQL accesible desde la máquina donde se ejecuta la aplicación.
- Visual Studio 2019 o superior (para compilar desde código fuente).

### Pasos

1. Clonar o descomprimir el repositorio.
2. Ejecutar el script SQL en el servidor MySQL:
   ```sql
   SOURCE ruta/BaseDatos/SQL_C_DEPORTIVO_2.2.sql;
   ```
3. Abrir `ClubDeportivoApp.slnx` en Visual Studio.
4. Restaurar los paquetes NuGet (`packages.config`).
5. Compilar y ejecutar. Al iniciar, la aplicación presenta el formulario **AccesoBDForm** donde se ingresan los datos de conexión (servidor, base de datos, usuario y contraseña MySQL).
6. Iniciar sesión con un usuario registrado en la tabla `usuarios`.

---

## Arquitectura

El proyecto sigue una separación en capas:

- **Formularios** → presentación e interacción con el usuario.
- **Servicios** → lógica de negocio y validaciones de dominio.
- **Repositorios** → acceso a datos mediante consultas SQL directas con `MySqlConnection`.
- **Modelos / DTOs** → entidades del dominio y objetos de transferencia de datos.

La inyección de dependencias se realiza manualmente pasando instancias por constructor (sin contenedor IoC).

---

## Licencia

Este proyecto utiliza **QuestPDF** bajo licencia Community (gratuita para proyectos de código abierto y uso no comercial). Consultar [questpdf.com/license](https://www.questpdf.com/license.html) para más detalles.
