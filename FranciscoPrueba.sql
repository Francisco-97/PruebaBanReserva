create database PruebaBr

use PruebaBr

create table Persona(
Id int primary key identity(1,1),
Nombre varchar(40),
FechaDeNacimiento Date
)