CREATE DATABASE DB_CONTACTOS

USE DB_CONTACTOS

CREATE TABLE CONTACTOS(
IdContacto int identity,
Nombre varchar(100),
Apellido varchar(100),
Numero varchar(100),
Correo varchar(100)
)

insert into CONTACTOS(Nombre, Apellido, Numero, Correo) values
('John','Doe','1123123','john.doe@example.com'),
('Jane','Smith','1434232','jane.smith@example.com'),
('Emily','Johnson','1233123','emily.johnson@example.com'),
('Michael','Brown','6452344','michael.brown@example.com'),
('Daniel','Davis','652345','daniel.davis@example.com'),
('Laura','Miller','87356','laura.miller@example.com'),
('David','Wilson','123456357','david.wilson@example.com'),
('Sarah','Moore','6452438','sarah.moore@example.com'),
('James','Taylor','6456549','james.taylor@example.com'),
('Maria','Anderson','4233410','maria.anderson@example.com')

Select * from CONTACTOS

create procedure sp_Registrar(
@Nombre varchar(100),
@Apellido varchar(100),
@Numero varchar(100),
@Correo varchar(100)
)
as
begin
	insert into CONTACTOS(Nombre, Apellido, Numero, Correo) values
	(@Nombre, @Apellido, @Numero, @Correo)
end

create procedure sp_Editar(
@idContacto int,
@Nombre varchar(100),
@Apellido varchar(100),
@Numero varchar(100),
@Correo varchar(100)
)
as
begin
	UPDATE CONTACTOS set Nombre = @Nombre, Apellido = @Apellido, Numero = @Numero, Correo = @Correo
	WHERE IdContacto = @idContacto
end

create procedure sp_Eliminar(
@idContacto int
)
as
begin
	DELETE From CONTACTOS
	WHERE IdContacto = @idContacto
end