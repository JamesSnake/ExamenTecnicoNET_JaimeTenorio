use master
go

create database BDNegocio 
GO

USE BDNegocio
go

CREATE TABLE Banco
(
CodigoBanco INT IDENTITY(1,1) NOT NULL,
Nombre Varchar(50) NOT NULL, 
Direccion varchar(100) NOT NULL,
FechaRegistro Datetime NOT NULL
CONSTRAINT pk_Banco PRIMARY KEY (CodigoBanco asc)
);
go

CREATE TABLE Sucursal
(
CodigoSucursal INT IDENTITY(1,1) NOT NULL,
CodigoBanco INT NOT NULL,
Nombre Varchar(50), 
Direccion varchar(100) NOT NULL,
FechaRegistro Datetime NOT NULL
CONSTRAINT [pk_Sucursal] PRIMARY KEY (CodigoSucursal)
CONSTRAINT fk_Sucursal_Banco FOREIGN KEY (CodigoBanco) REFERENCES Banco(CodigoBanco)
);
go

CREATE TABLE Moneda
(
CodigoMoneda INT IDENTITY(1,1) NOT NULL,
Nombre Varchar(50) NOT NULL,
Abreviatura Varchar(10) NOT NULL
CONSTRAINT pk_Moneda PRIMARY KEY (CodigoMoneda)
);
go

CREATE TABLE Estado
(
CodigoEstado INT IDENTITY(1,1) NOT NULL,
Nombre Varchar(50) NOT NULL,
Abreviatura Varchar(10) NOT NULL
CONSTRAINT pk_Estado PRIMARY KEY (CodigoEstado)
);
go

CREATE TABLE OrdenPago
(
CodigoOrdenPago INT NOT NULL IDENTITY(1,1),
CodigoSucursal int NOT NULL,
Monto decimal NOT NULL,
CodigoMoneda int NOT NULL,
CodigoEstado int NOT NULL,
FechaPago Datetime NOT NULL,
CONSTRAINT pk_OrdenPago PRIMARY KEY (CodigoOrdenPago),
CONSTRAINT fk_OrdenPago_Sucursal FOREIGN KEY (CodigoSucursal) REFERENCES Sucursal(CodigoSucursal),
CONSTRAINT fk_OrdenPago_Moneda FOREIGN KEY (CodigoMoneda) REFERENCES Moneda(CodigoMoneda),
CONSTRAINT fk_OrdenPago_Estado FOREIGN KEY (CodigoEstado) REFERENCES Estado(CodigoEstado)
);
go

INSERT INTO Banco 
(Nombre, 
Direccion,
FechaRegistro)
values
('BCP','San Isidro',GETDATE()),('BBVA','San Isidro',GETDATE()),('Financiero','Miraflores',GETDATE()),('Interbank','La Victoria',GETDATE())
go

insert into Sucursal
(CodigoBanco,
Nombre, 
Direccion,
FechaRegistro)
values (1,'BCP Sede Chorrillos','Chorrillos',GETDATE()),(1,'BCP Sede Molina','Molina',GETDATE()),
(2,'Financiero Sede Lima','Cercado de Lima',GETDATE()),
(3,'Interbank Sede Lima','Cercado de Lima',GETDATE())
go

Insert into Moneda
(Nombre,
Abreviatura)
values ('Soles','PEN'),('Dolares','USD')
go

Insert into Estado
(Nombre,
Abreviatura)
values ('Pagada','Pagada'),('Declinada','Declinada'),('Fallida','Fallida'),('Anulada','Anulada')
go

Insert into OrdenPago
(CodigoSucursal,
Monto,
CodigoMoneda,
CodigoEstado,
FechaPago)
values (1,1200.23,2,1,getdate()),(3,5000,1,3,getdate())
go


CREATE PROCEDURE usp_consultarBanco
(
@CodigoBanco int,
@Nombre varchar(50)
)
as
begin

SELECT CodigoBanco,Nombre,Direccion,FechaRegistro from Banco 
where CodigoBanco= isnull(@CodigoBanco,CodigoBanco) and Nombre like '%'+isnull(@Nombre,'')+'%';

end
GO

CREATE PROCEDURE usp_consultarSucursal
(
@CodigoSucursal int,
@CodigoBanco int,
@Nombre varchar(50)
)
as
begin

SELECT A.CodigoSucursal,
       A.CodigoBanco,
	   B.Nombre as Banco,
	   A.Nombre,
	   A.Direccion,
	   A.FechaRegistro 
from Sucursal A
INNER JOIN Banco B ON B.CodigoBanco=A.CodigoBanco 
where A.CodigoSucursal= isnull(@CodigoSucursal,A.CodigoSucursal) 
and A.CodigoBanco= isnull(@CodigoBanco,A.CodigoBanco) 
and A.Nombre like '%'+isnull(@Nombre,'')+'%';

end
GO

CREATE PROCEDURE usp_consultarMoneda
(
@CodigoMoneda int,
@Nombre varchar(50)
)
as
begin

SELECT CodigoMoneda,Nombre,Abreviatura from Moneda 
where CodigoMoneda= isnull(@CodigoMoneda,CodigoMoneda) and Nombre like '%'+isnull(@Nombre,'')+'%';

end
GO

CREATE PROCEDURE usp_consultarEstado
(
@CodigoEstado int,
@Nombre varchar(50)
)
as
begin

SELECT CodigoEstado,Nombre,Abreviatura from Estado 
where CodigoEstado= isnull(@CodigoEstado,CodigoEstado) and Nombre like '%'+isnull(@Nombre,'')+'%';

end
GO

CREATE PROCEDURE usp_consultarOrdenPago
(
@CodigoOrdenPago int,
@CodigoSucursal int,
@CodigoMoneda int,
@CodigoEstado int
)
as
begin

SELECT A.[CodigoOrdenPago]
      ,A.[CodigoSucursal]
	  ,B.Nombre as Sucursal
      ,A.[Monto]
      ,A.[CodigoMoneda]
	  ,D.Abreviatura as Moneda
      ,A.[CodigoEstado]
	  ,E.Nombre as Estado
      ,A.[FechaPago]
  FROM [dbo].[OrdenPago] A
  INNER JOIN Sucursal B ON B.CodigoSucursal=A.CodigoSucursal
  INNER JOIN Banco C ON C.CodigoBanco=B.CodigoBanco
  INNER JOIN Moneda D ON D.CodigoMoneda=A.CodigoMoneda
  INNER JOIN Estado E ON E.CodigoEstado=A.CodigoEstado
 where A.CodigoOrdenPago = isnull(@CodigoOrdenPago,A.CodigoOrdenPago)
 and A.CodigoSucursal= isnull(@CodigoSucursal,A.CodigoSucursal) 
 and A.CodigoMoneda= isnull(@CodigoMoneda,A.CodigoMoneda)
 and A.CodigoEstado= isnull(@CodigoEstado,A.CodigoEstado);

end
GO

CREATE PROCEDURE usp_InsertarBanco 
(@Nombre varchar(50),
@Direccion varchar(100),
@FechaRegistro datetime)
as
begin
INSERT INTO [dbo].[Banco]
           ([Nombre]
           ,[Direccion]
           ,[FechaRegistro])
     VALUES
           (@Nombre,
		   @Direccion,
		   @FechaRegistro)
end
go

CREATE PROCEDURE usp_ActualizarBanco
(
@CodigoBanco int,
@Nombre varchar(50),
@Direccion varchar(100)
)
as 
begin
UPDATE [dbo].[Banco]
   SET [Nombre] =@Nombre
      ,[Direccion] = @Direccion
      --,[FechaRegistro] = <FechaRegistro, datetime,>
 WHERE CodigoBanco=@CodigoBanco;
 end
GO

CREATE PROCEDURE usp_EliminarBanco(@CodigoBanco int)
as 
begin
DELETE FROM [dbo].[Banco] WHERE CodigoBanco=@CodigoBanco;
end
GO

CREATE PROCEDURE usp_InsertarEstado 
(@Nombre varchar(50),
 @Abreviatura varchar(10))
as
begin
INSERT INTO [dbo].[Estado]
           ([Nombre]
           ,[Abreviatura])
     VALUES
           (@Nombre,
           @Abreviatura)
end
go

CREATE PROCEDURE usp_ActualizarEstado
(@CodigoEstado int,
@Nombre varchar(50),
 @Abreviatura varchar(10))
 as
 begin

UPDATE [dbo].[Estado]
   SET [Nombre] = @Nombre
      ,[Abreviatura] = @Abreviatura
 WHERE CodigoEstado=@CodigoEstado;
 end
GO

CREATE PROCEDURE usp_EliminarEstado(@CodigoEstado int)
as
begin
DELETE FROM [dbo].[Estado] WHERE CodigoEstado=@CodigoEstado;
end
GO

CREATE PROCEDURE usp_InsertarMoneda 
(@Nombre varchar(50),
 @Abreviatura varchar(10))
as
begin
INSERT INTO [dbo].[Moneda]
           ([Nombre]
           ,[Abreviatura])
     VALUES
           (@Nombre,
           @Abreviatura)
end
go

CREATE PROCEDURE usp_ActualizarMoneda
(@CodigoMoneda int,
 @Nombre varchar(50),
 @Abreviatura varchar(10))
 as
 begin
UPDATE [dbo].[Moneda]
   SET [Nombre] = @Nombre
      ,[Abreviatura] = @Abreviatura
 WHERE CodigoMoneda=@CodigoMoneda;
 end
GO

CREATE PROCEDURE usp_EliminarMoneda (@CodigoMoneda int)
as
begin
DELETE FROM [dbo].[Moneda] WHERE CodigoMoneda=@CodigoMoneda;
end
GO

CREATE PROCEDURE usp_InsertarSucursal
(@CodigoBanco int,
 @Nombre varchar(50),
 @Direccion varchar(100),
 @FechaRegistro datetime)
as
begin
INSERT INTO [dbo].[Sucursal]
           ([CodigoBanco]
           ,[Nombre]
           ,[Direccion]
           ,[FechaRegistro])
     VALUES
           (@CodigoBanco,
			@Nombre,
			@Direccion,
			@FechaRegistro);
end
go

CREATE PROCEDURE usp_ActualizarSucursal
(@CodigoSucursal int,
 @CodigoBanco int,
 @Nombre varchar(50),
 @Direccion varchar(100))
as
begin

UPDATE [dbo].[Sucursal]
   SET [CodigoBanco] =@CodigoBanco
      ,[Nombre] = @Nombre
      ,[Direccion] = @Direccion
 WHERE CodigoSucursal=@CodigoSucursal;
end
GO

CREATE PROCEDURE usp_EliminarSucursal(@CodigoSucursal int)
as
begin
DELETE FROM [dbo].[Sucursal] WHERE CodigoSucursal=@CodigoSucursal;
end
GO

CREATE PROCEDURE usp_InsertarOrdenPago
(
@CodigoSucursal int,
@Monto decimal(18,0),
@CodigoMoneda int,
@CodigoEstado int,
@FechaPago datetime
)
as
begin

INSERT INTO [dbo].[OrdenPago]
           ([CodigoSucursal]
           ,[Monto]
           ,[CodigoMoneda]
           ,[CodigoEstado]
           ,[FechaPago])
     VALUES
           (@CodigoSucursal,
            @Monto,
            @CodigoMoneda,
            @CodigoEstado,
            @FechaPago);
end
GO

CREATE PROCEDURE usp_ActualizarOrdenPago
(@CodigoOrdenPago int,
@CodigoSucursal int,
@Monto decimal(18,0),
@CodigoMoneda int,
@CodigoEstado int,
@FechaPago datetime)
as
begin

UPDATE [dbo].[OrdenPago]
   SET [CodigoSucursal] = @CodigoSucursal
      ,[Monto] = @Monto
      ,[CodigoMoneda] = @CodigoMoneda
      ,[CodigoEstado] = @CodigoEstado
      ,[FechaPago] = @FechaPago
 WHERE CodigoOrdenPago=@CodigoOrdenPago;
end
GO

CREATE PROCEDURE usp_EliminarOrdenPago
(@CodigoOrdenPago int
)
as
begin
DELETE FROM [dbo].[OrdenPago] WHERE CodigoOrdenPago=@CodigoOrdenPago
end
GO


