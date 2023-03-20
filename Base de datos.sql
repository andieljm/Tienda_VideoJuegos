create database TiendaVG;

use TiendaVG;

--creacion de base de datos con el registro de perfiles generada de el framework
--Video consolas
CREATE TABLE MARCA(
ID_MARCA INT NOT NULL,
nombre_marca VARCHAR(30) NOT NULL,
PRIMARY KEY(ID_MARCA))

CREATE TABLE CONSOLA(
ID_CONSOLA INT NOT NULL,
nombre_consola VARCHAR(30) NOT NULL,
cant_disp INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_MARCA INT NOT NULL,
PRIMARY KEY (ID_CONSOLA),
FOREIGN KEY(ID_MARCA) REFERENCES MARCA(ID_MARCA)on delete cascade);

CREATE TABLE VIDEOJUEGO(
ID_VIDEOJUEGO INT NOT NULL,
nombre_videojuego VARCHAR(60) NOT NULL,
cant_disp INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_CONSOLA INT NOT NULL,
PRIMARY KEY (ID_VIDEOJUEGO),
FOREIGN KEY (ID_CONSOLA) REFERENCES CONSOLA(ID_CONSOLA)on delete cascade);

CREATE TABLE PERIFERICO(
ID_PERIFERICO INT NOT NULL,
nombre_periferico VARCHAR(60) NOT NULL,
cant_disp INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_MARCA INT NOT NULL,
PRIMARY KEY (ID_PERIFERICO),
FOREIGN KEY(ID_MARCA) REFERENCES MARCA(ID_MARCA)on delete cascade)

CREATE TABLE TALLER(
ID_REPARACION INT NOT NULL,
nombre_dispositivo VARCHAR(60) NOT NULL,
detalle VARCHAR(300) NOT NULL,
fecha_ingreso DATE NOT NULL,
ID_USUARIO nvarchar(128) NOT NULL,
PRIMARY KEY (ID_REPARACION),
FOREIGN KEY (ID_USUARIO) REFERENCES AspNetUsers(id)on delete cascade)

CREATE TABLE CITA_REPARACION(
ID_CITA INT NOT NULL,
nombre_empleado VARCHAR(60) NOT NULL,
fecha_asignada DATE NOT NULL,
ID_REPARACION INT NOT NULL,
PRIMARY KEY (ID_CITA),
FOREIGN KEY (ID_REPARACION) REFERENCES TALLER(ID_REPARACION)on delete cascade);

CREATE TABLE DOMICILIO(
ID_DOMICILIO INT NOT NULL,
provincia VARCHAR(30) NOT NULL,
ciudad VARCHAR(30) NOT NULL,
canton VARCHAR(30) NOT NULL,
direccion VARCHAR(100) NOT NULL,
ID_USUARIO nvarchar(128) NOT NULL,
PRIMARY KEY (ID_DOMICILIO),
FOREIGN KEY (ID_USUARIO) REFERENCES AspNetUsers(id)on delete cascade);

CREATE TABLE METODO_PAGO(
ID_METODO INT NOT NULL,
nombre_metodo VARCHAR(30) NOT NULL,
PRIMARY KEY (ID_METODO))

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
CREATE TABLE CARRRITO(
ID_CARRITO INT NOT NULL,
cantidad INT NOT NULL,
ID_USUARIO nvarchar(128) NOT NULL,
ID_CONSOLA INT,
ID_VIDEOJUEGO INT,
ID_PERIFERICO INT,
PRIMARY KEY (ID_CARRITO),
FOREIGN KEY (ID_USUARIO) REFERENCES AspNetUsers(id)on delete cascade,
FOREIGN KEY (ID_CONSOLA) REFERENCES CONSOLA(ID_CONSOLA)on delete cascade,
FOREIGN KEY (ID_VIDEOJUEGO) REFERENCES VIDEOJUEGO(ID_VIDEOJUEGO)on delete cascade,
FOREIGN KEY (ID_PERIFERICO) REFERENCES PERIFERICO(ID_PERIFERICO)on delete cascade);

CREATE TABLE FACTURA(
ID_FACTURA INT NOT NULL,
total DECIMAL(10,2) NOT NULL,
ID_USUARIO nvarchar(128) NOT NULL,
ID_METODO INT NOT NULL,
ID_DOMICILIO INT NOT NULL,
PRIMARY KEY (ID_FACTURA),
FOREIGN KEY (ID_USUARIO) REFERENCES AspNetUsers(id)on delete cascade,
FOREIGN KEY (ID_METODO) REFERENCES METODO_PAGO(ID_METODO)on delete cascade,
FOREIGN KEY (ID_DOMICILIO) REFERENCES DOMICILIO(ID_DOMICILIO)on delete cascade);

CREATE TABLE DETALLE_FACTURA(
ID_DETALLE INT NOT NULL,
cantidad INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_FACTURA INT NOT NULL,
ID_CONSOLA INT,
ID_VIDEOJUEGO INT,
ID_PERIFERICO INT,
PRIMARY KEY (ID_DETALLE),
FOREIGN KEY (ID_FACTURA) REFERENCES FACTURA(ID_FACTURA)on delete cascade,
FOREIGN KEY (ID_CONSOLA) REFERENCES CONSOLA(ID_CONSOLA)on delete cascade,
FOREIGN KEY (ID_VIDEOJUEGO) REFERENCES VIDEOJUEGO(ID_VIDEOJUEGO)on delete cascade,
FOREIGN KEY (ID_PERIFERICO) REFERENCES PERIFERICO(ID_PERIFERICO)on delete cascade);

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

---fin de creacion de base de datos con la creacion del registro del visual 

-- inicio para base de datos con registro de usuario desde 0

CREATE TABLE ROL(
ID_ROL INT not null IDENTITY PRIMARY KEY,
Nombre VARCHAR(30)
);

CREATE TABLE USUARIO(
ID_USUARIO INT NOT NULL,
usuario VARCHAR(10) NOT NULL,
contrasena VARCHAR(10) NOT NULL,
nombre VARCHAR(30) NOT NULL,
apellido VARCHAR(30) NOT NULL,
cedula INT NOT NULL,
ID_ROL INT,
PRIMARY KEY (ID_USUARIO),
FOREIGN KEY(ID_ROL) REFERENCES ROL(ID_ROL)on delete cascade);

CREATE TABLE MARCA(
ID_MARCA INT NOT NULL,
nombre_marca VARCHAR(30) NOT NULL,
PRIMARY KEY(ID_MARCA))

CREATE TABLE CONSOLA(
ID_CONSOLA INT NOT NULL,
nombre_consola VARCHAR(30) NOT NULL,
cant_disp INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_MARCA INT NOT NULL,
PRIMARY KEY (ID_CONSOLA),
FOREIGN KEY(ID_MARCA) REFERENCES MARCA(ID_MARCA)on delete cascade);

CREATE TABLE VIDEOJUEGO(
ID_VIDEOJUEGO INT NOT NULL,
nombre_videojuego VARCHAR(60) NOT NULL,
cant_disp INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_CONSOLA INT NOT NULL,
PRIMARY KEY (ID_VIDEOJUEGO),
FOREIGN KEY (ID_CONSOLA) REFERENCES CONSOLA(ID_CONSOLA)on delete cascade);

CREATE TABLE PERIFERICO(
ID_PERIFERICO INT NOT NULL,
nombre_periferico VARCHAR(60) NOT NULL,
cant_disp INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_MARCA INT NOT NULL,
PRIMARY KEY (ID_PERIFERICO),
FOREIGN KEY(ID_MARCA) REFERENCES MARCA(ID_MARCA)on delete cascade);

CREATE TABLE TALLER(
ID_REPARACION INT NOT NULL,
nombre_dispositivo VARCHAR(60) NOT NULL,
detalle VARCHAR(300) NOT NULL,
fecha_ingreso DATE NOT NULL,
ID_USUARIO INT NOT NULL,
PRIMARY KEY (ID_REPARACION),
FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO)on delete cascade);

CREATE TABLE CITA_REPARACION(
ID_CITA INT NOT NULL,
nombre_empleado VARCHAR(60) NOT NULL,
fecha_asignada DATE NOT NULL,
ID_REPARACION INT NOT NULL,
PRIMARY KEY (ID_CITA),
FOREIGN KEY (ID_REPARACION) REFERENCES TALLER(ID_REPARACION)on delete cascade);

CREATE TABLE DOMICILIO(
ID_DOMICILIO INT NOT NULL,
provincia VARCHAR(30) NOT NULL,
ciudad VARCHAR(30) NOT NULL,
canton VARCHAR(30) NOT NULL,
direccion VARCHAR(100) NOT NULL,
ID_USUARIO INT NOT NULL,
PRIMARY KEY (ID_DOMICILIO),
FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO)on delete cascade);

CREATE TABLE METODO_PAGO(
ID_METODO INT NOT NULL,
nombre_metodo VARCHAR(30) NOT NULL,
PRIMARY KEY (ID_METODO));

CREATE TABLE CARRRITO(
ID_CARRITO INT NOT NULL,
cantidad INT NOT NULL,
ID_USUARIO INT NOT NULL,
ID_CONSOLA INT,
ID_VIDEOJUEGO INT,
ID_PERIFERICO INT,
PRIMARY KEY (ID_CARRITO),
FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO)on delete cascade,
FOREIGN KEY (ID_CONSOLA) REFERENCES CONSOLA(ID_CONSOLA)on delete cascade,
FOREIGN KEY (ID_VIDEOJUEGO) REFERENCES VIDEOJUEGO(ID_VIDEOJUEGO)on delete cascade,
FOREIGN KEY (ID_PERIFERICO) REFERENCES PERIFERICO(ID_PERIFERICO)on delete cascade);

CREATE TABLE FACTURA(
ID_FACTURA INT NOT NULL,
total DECIMAL(10,2) NOT NULL,
ID_USUARIO INT NOT NULL,
ID_METODO INT NOT NULL,
ID_DOMICILIO INT NOT NULL,
PRIMARY KEY (ID_FACTURA),
FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO)on delete cascade,
FOREIGN KEY (ID_METODO) REFERENCES METODO_PAGO(ID_METODO)on delete cascade,
FOREIGN KEY (ID_DOMICILIO) REFERENCES DOMICILIO(ID_DOMICILIO)on delete cascade);

CREATE TABLE DETALLE_FACTURA(
ID_DETALLE INT NOT NULL,
cantidad INT NOT NULL,
precio DECIMAL(10,2) NOT NULL,
ID_FACTURA INT NOT NULL,
ID_CONSOLA INT,
ID_VIDEOJUEGO INT,
ID_PERIFERICO INT,
PRIMARY KEY (ID_DETALLE),
FOREIGN KEY (ID_FACTURA) REFERENCES FACTURA(ID_FACTURA)on delete cascade,
FOREIGN KEY (ID_CONSOLA) REFERENCES CONSOLA(ID_CONSOLA)on delete cascade,
FOREIGN KEY (ID_VIDEOJUEGO) REFERENCES VIDEOJUEGO(ID_VIDEOJUEGO)on delete cascade,
FOREIGN KEY (ID_PERIFERICO) REFERENCES PERIFERICO(ID_PERIFERICO)on delete cascade);

-- fin de la segunda opcio para el registro
