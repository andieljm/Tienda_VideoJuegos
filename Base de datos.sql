create database TiendaVG;

use TiendaVG;



--creacion de base de datos con el registro de perfiles generada de el framework
--Video consolas
CREATE TABLE MARCA(
ID_MARCA INT NOT NULL,
nombre_marca VARCHAR(30) NOT NULL,
PRIMARY KEY(ID_MARCA))

insert into MARCA values (1,'Sony');
insert into MARCA values (2,'Microsoft');
insert into MARCA values (3,'Nintendo');

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
PRIMARY KEY (ID_REPARACION));

-- para modificar la tabla sin carrito
alter table taller drop constraint FK__TALLER__ID_USUAR__151B244E; 
alter table taller drop column ID_USUARIO;
alter table taller add Nombre_cliente varchar(60);
alter table taller add telefono varchar(10);



----sin carrito
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

/* Carrito no se us�*/
CREATE TABLE CARRRITO(
ID_CARRITO INT NOT NULL,
cantidad INT NOT NULL,
ID_USUARIO nvarchar(128) NOT NULL,
ID_CONSOLA INT not null,
ID_VIDEOJUEGO INT,
ID_PERIFERICO INT,
PRIMARY KEY (ID_CARRITO),
FOREIGN KEY (ID_USUARIO) REFERENCES AspNetUsers(id)ON DELETE NO ACTION
ON UPDATE NO ACTION,
FOREIGN KEY (ID_CONSOLA) REFERENCES CONSOLA(ID_CONSOLA)ON DELETE NO ACTION
ON UPDATE NO ACTION,
FOREIGN KEY (ID_VIDEOJUEGO) REFERENCES VIDEOJUEGO(ID_VIDEOJUEGO)ON DELETE NO ACTION
ON UPDATE NO ACTION,
FOREIGN KEY (ID_PERIFERICO) REFERENCES PERIFERICO(ID_PERIFERICO)ON DELETE NO ACTION
ON UPDATE NO ACTION);
/* Carrito no se us�*/


SELECT * FROM FACTURA;

CREATE TABLE FACTURA(
ID_FACTURA INT NOT NULL,
nombre_dispositivo VARCHAR(60) NOT NULL,
detalle VARCHAR(300) NOT NULL,
fecha_ingreso DATE NOT NULL,
NOMBRE_CLIENTE VARCHAR(60),
TELEFONO VARCHAR(10),
PRIMARY KEY (ID_FACTURA));

/*Trigger para trabajar con la factura*/
CREATE TRIGGER TR_INSERT_TALLER_TO_FACTURA
ON TALLER
AFTER INSERT
AS
BEGIN
    INSERT INTO FACTURA (ID_FACTURA, nombre_dispositivo, detalle, fecha_ingreso, NOMBRE_CLIENTE, TELEFONO)
    SELECT ID_REPARACION, nombre_dispositivo, detalle, fecha_ingreso, Nombre_cliente, telefono
    FROM INSERTED
END

