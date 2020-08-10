CREATE SCHEMA LOS_SIMULADORES

----------------------------------------- CREATE TABLES --------------------------------------------------------
GO
CREATE TABLE LOS_SIMULADORES.Funcionalidad( 
	idFunc				int identity(1,1),
	Descripcion			nvarchar(50)
	constraint "funcnPK" PRIMARY KEY ("idFunc")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Rol( 
	idRol				int identity(1,1),
	Nombre				nvarchar(50),
	Estado				bit
	constraint "rolPK" PRIMARY KEY ("idRol")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.FuncionalidadXRol( 
	idFuncionalidadXRol	int identity(1,1),
	Funcionalidad		int,
	Rol					int
	constraint "funcnXrolPK" PRIMARY KEY ("idFuncionalidadXRol")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Usuario( 
	idUsuario			nvarchar(50),
	"Password"			varbinary(32),
	Cliente				numeric(18,0),
	Empresa				nvarchar(255)
	constraint "usuarioPK" PRIMARY KEY ("idUsuario")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.UsuarioXRol( 
	idUsuarioXRol		int identity(1,1),
	Usuario				nvarchar(50),
	Rol					int
	constraint "usrXrolPK" PRIMARY KEY ("idUsuarioXRol")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Grado( 
	Peso				int,
	Descripcion			nvarchar(50),
	Estado				bit
	constraint "gradoPK" PRIMARY KEY ("Peso")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Cliente(
	Dni					numeric(18,0),
	Apellido			nvarchar(255),
	Nombre				nvarchar(255),
	Tipo_dni			nvarchar(50),
	Cuil				nvarchar(50),
	Fecha_Nacimiento	datetime,
	Mail				nvarchar(50),
	Telefono			nvarchar(50),
	Calle				nvarchar(50),
	Numero				numeric(5,0),
	Piso				nvarchar(50),
	Departamento		nvarchar(50),
	Codigo_postal		nvarchar(50),
	Fecha_creacion		datetime,
	Tarjeta				nvarchar(50),
	Puntos				numeric(18,0),
	Estado				bit
	constraint "ClientePK" PRIMARY KEY ("Dni")
	ON [PRIMARY]
)



GO
CREATE TABLE LOS_SIMULADORES.Empresa(
	Cuit				nvarchar(255),
	Razon_Social		nvarchar(255),
	Fecha_Creacion		datetime,
	Mail				nvarchar(50),
	Calle				nvarchar(50),
	Numero				numeric(5,0),
	Piso				nvarchar(50),
	Departamento		nvarchar(50),
	Codigo_postal		nvarchar(50),
	Telefono			nvarchar(50),
	Ciudad				nvarchar(50),
	Estado				bit
	constraint "EmpresaPK" PRIMARY KEY ("Cuit")
	ON [PRIMARY]
)



GO
CREATE TABLE LOS_SIMULADORES.Espectaculo(
	Cod					int identity(1,1),
	Descripcion			nvarchar(255),
	Fecha				datetime,
	Fecha_Venc			datetime,
	Empresa				nvarchar(255),
	Estado				nvarchar(255),
	Rubro				int,
	Direccion			nvarchar(255),
	Grado				int
	constraint "espectaculoPK" PRIMARY KEY ("Cod")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Rubro(
	idRubro				int identity(1,1),
	Descripcion			nvarchar(255),
	constraint "rubroPK" PRIMARY KEY ("idRubro")
	ON [PRIMARY]
)	


GO
CREATE TABLE LOS_SIMULADORES.Ubicacion(
	Espectaculo			int,
	Fila				varchar(3),
	Asiento				numeric(18,0),
	Sin_numerar			bit,
	Precio				numeric(18,0),
	Tipo				nvarchar(255)
	constraint "ubicacionPK" PRIMARY KEY ("Fila","Asiento","Espectaculo")
	ON [PRIMARY]
)


GO
CREATE TABLE LOS_SIMULADORES.Tarjeta(
	Numero				nvarchar(50),
	Nombre				nvarchar(255),
	Vencimiento			nvarchar(255),
	Codigo				numeric(4,0)
	constraint "tarjetaPK" PRIMARY KEY ("Numero")
	ON [PRIMARY]
)


GO
CREATE TABLE LOS_SIMULADORES.Compra(
	Codigo				int identity(1,1),
	Fecha				datetime,
	Cantidad			numeric(18,0),
	Cliente				numeric(18,0),
	Medio				nvarchar(255),
	Espectaculo			int,
	Fila				varchar(3),
	Asiento				numeric(18,0),
	Precio				numeric(18,2)
	constraint "compraPK" PRIMARY KEY ("Codigo")
 ON [PRIMARY]
)


GO
CREATE TABLE LOS_SIMULADORES.Rendicion( 
	idRendicion			int identity(1,1),
	Factura				numeric(18,0)
	constraint "rendicionPK" PRIMARY KEY ("idRendicion")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Factura(
	Nro					numeric(18,0) identity(1,1),
	Fecha				datetime,
	Total				numeric(18,2),
	Empresa				nvarchar(255)
	constraint "facturaPK" PRIMARY KEY ("Nro")
	ON [PRIMARY]
)


GO
CREATE TABLE LOS_SIMULADORES.Item_factura(
	Nro					int identity(1,1),
	Factura				numeric(18,0),
	Precio				numeric(18,2),
	Cantidad			numeric(18,0),
	Espectaculo			int,
	Fila				varchar(3),
	Asiento				numeric(18,0)
	constraint "itamFacturaPK" PRIMARY KEY ("Nro","Factura")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Punto( 
	idPunto				int identity(1,1),
	Cliente				numeric(18,0),
	Cantidad			float,
	Vencimiento			datetime
	constraint "PuntoPK" PRIMARY KEY ("idPunto")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Premio( 
	idPremio			int identity(1,1),
	Cliente				numeric(18,0),
	Descripcion			nvarchar(50),
	Fecha				datetime,
	Puntos				int
	constraint "PremioPK" PRIMARY KEY ("idPremio")
	ON [PRIMARY]
)

GO
CREATE TABLE LOS_SIMULADORES.Intentos( 
	idIntento			int identity(1,1),
	Usuario				nvarchar(50),
	Intentos			int
	constraint "IntentosPK" PRIMARY KEY ("idIntento")
	ON [PRIMARY]
)


----------------------------------------- ALTER TABLES --------------------------------------------------------


GO
ALTER TABLE LOS_SIMULADORES.Intentos
	ADD FOREIGN KEY(Usuario)
	REFERENCES LOS_SIMULADORES.Usuario(idUsuario)

GO
ALTER TABLE LOS_SIMULADORES.Usuario
	ADD FOREIGN KEY(Cliente)
	REFERENCES LOS_SIMULADORES.Cliente(Dni)


GO
ALTER TABLE LOS_SIMULADORES.Espectaculo
	ADD FOREIGN KEY(Grado)
	REFERENCES LOS_SIMULADORES.Grado(Peso)


GO
ALTER TABLE LOS_SIMULADORES.Usuario
	ADD FOREIGN KEY(Empresa)
	REFERENCES LOS_SIMULADORES.Empresa(Cuit)

GO
ALTER TABLE LOS_SIMULADORES.FuncionalidadXRol
	ADD FOREIGN KEY(Funcionalidad)
	REFERENCES LOS_SIMULADORES.Funcionalidad(idFunc)

GO
ALTER TABLE LOS_SIMULADORES.FuncionalidadXRol
	ADD FOREIGN KEY(Rol)
	REFERENCES LOS_SIMULADORES.Rol(idRol)

GO
ALTER TABLE LOS_SIMULADORES.UsuarioXRol
	ADD FOREIGN KEY(Usuario)
	REFERENCES LOS_SIMULADORES.Usuario(idUsuario)

GO
ALTER TABLE LOS_SIMULADORES.UsuarioXRol
	ADD FOREIGN KEY(Rol)
	REFERENCES LOS_SIMULADORES.Rol(idRol)

GO
ALTER TABLE LOS_SIMULADORES.Cliente
	ADD FOREIGN KEY(Tarjeta)
	REFERENCES LOS_SIMULADORES.Tarjeta(Numero)


GO
ALTER TABLE LOS_SIMULADORES.Espectaculo
	ADD FOREIGN KEY(Empresa)
	REFERENCES LOS_SIMULADORES.Empresa(Cuit)


GO
ALTER TABLE LOS_SIMULADORES.Espectaculo
	ADD FOREIGN KEY(Rubro)
	REFERENCES LOS_SIMULADORES.Rubro(idRubro)

GO
ALTER TABLE LOS_SIMULADORES.Ubicacion
	ADD FOREIGN KEY(Espectaculo)
	REFERENCES LOS_SIMULADORES.Espectaculo(Cod)

GO
ALTER TABLE LOS_SIMULADORES.Factura
	ADD FOREIGN KEY(Empresa)
	REFERENCES LOS_SIMULADORES.Empresa(Cuit)

GO
ALTER TABLE LOS_SIMULADORES.Item_Factura
	ADD FOREIGN KEY(Factura)
	REFERENCES LOS_SIMULADORES.Factura(Nro)

GO
ALTER TABLE LOS_SIMULADORES.Item_Factura
	ADD FOREIGN KEY(Espectaculo)
	REFERENCES LOS_SIMULADORES.Espectaculo(Cod)

GO
ALTER TABLE LOS_SIMULADORES.Compra
	ADD FOREIGN KEY(Fila, Asiento, Espectaculo)
	REFERENCES LOS_SIMULADORES.Ubicacion(Fila, Asiento, Espectaculo)

GO
ALTER TABLE LOS_SIMULADORES.Compra
	ADD FOREIGN KEY(Cliente)
	REFERENCES LOS_SIMULADORES.Cliente(Dni)

GO
ALTER TABLE LOS_SIMULADORES.Compra
	ADD FOREIGN KEY(Espectaculo)
	REFERENCES LOS_SIMULADORES.Espectaculo(Cod)

GO
ALTER TABLE LOS_SIMULADORES.Compra
	ADD FOREIGN KEY(Fila, Asiento, Espectaculo)
	REFERENCES LOS_SIMULADORES.Ubicacion(Fila, Asiento, Espectaculo)

GO
ALTER TABLE LOS_SIMULADORES.Rendicion
	ADD FOREIGN KEY(Factura)
	REFERENCES LOS_SIMULADORES.Factura(Nro)

GO
ALTER TABLE LOS_SIMULADORES.Punto
	ADD FOREIGN KEY(Cliente)
	REFERENCES LOS_SIMULADORES.Cliente(Dni)

GO
ALTER TABLE LOS_SIMULADORES.Premio
	ADD FOREIGN KEY(Cliente)
	REFERENCES LOS_SIMULADORES.Cliente(Dni)

-------------------------------- MIGRACION -------------------------------------------------------------------------------------------------------

GO
	-- Migrar cliente
	INSERT INTO LOS_SIMULADORES.Cliente
	SELECT distinct Cli_Dni,Cli_Apeliido,Cli_Nombre,null,null,Cli_Fecha_Nac,Cli_Mail,null,
	Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal,GETDATE(),null,null,1
	FROM gd_esquema.Maestra
	where Cli_Dni is not null

GO
	-- Migrar empresa
	INSERT INTO LOS_SIMULADORES.Empresa
	SELECT distinct Espec_Empresa_Cuit,Espec_Empresa_Razon_Social,
	Espec_Empresa_Fecha_Creacion,Espec_Empresa_Mail,
	Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, Espec_Empresa_Piso, Espec_Empresa_Depto, Espec_Empresa_Cod_Postal
	,null,null,1
	FROM gd_esquema.Maestra


GO
	-- Migrar rubro
	INSERT INTO LOS_SIMULADORES.Rubro
	SELECT distinct Espectaculo_Rubro_Descripcion
	FROM gd_esquema.Maestra

GO
	-- Migrar Grado
	INSERT INTO LOS_SIMULADORES.Grado values(100,'Alta',1)
	INSERT INTO LOS_SIMULADORES.Grado values(50,'Media',1)
	INSERT INTO LOS_SIMULADORES.Grado values(0,'Baja',1)


GO
	-- Migrar espectaculo
	SET IDENTITY_INSERT LOS_SIMULADORES.Espectaculo ON;
	INSERT INTO LOS_SIMULADORES.Espectaculo (Cod, Descripcion, Fecha, Fecha_Venc, Empresa, Estado, Rubro, Direccion, Grado)
	SELECT distinct Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc,
	convert(nvarchar(50),Espec_Empresa_Cuit),Espectaculo_Estado,
	(select idRubro from LOS_SIMULADORES.Rubro r where r.Descripcion = Espectaculo_Rubro_Descripcion), null, 50
	FROM gd_esquema.Maestra
	SET IDENTITY_INSERT LOS_SIMULADORES.Espectaculo OFF;


GO
	-- Migrar ubicacion
	INSERT INTO LOS_SIMULADORES.Ubicacion
	SELECT distinct Espectaculo_Cod,Ubicacion_Fila,Ubicacion_Asiento,Ubicacion_Sin_numerar,Ubicacion_Precio, Ubicacion_Tipo_Descripcion
	FROM gd_esquema.Maestra

GO
	-- Migrar factura
	SET IDENTITY_INSERT LOS_SIMULADORES.Factura ON;
	INSERT INTO LOS_SIMULADORES.Factura (Nro, Fecha, Total, Empresa)
	SELECT distinct Factura_Nro,Factura_Fecha,Factura_Total, Espec_Empresa_Cuit
	FROM gd_esquema.Maestra
	where Factura_Nro is not null
	SET IDENTITY_INSERT LOS_SIMULADORES.Factura OFF;

GO
	-- Migrar item_factura
	INSERT INTO LOS_SIMULADORES.Item_factura
	SELECT distinct Factura_Nro,Item_Factura_Monto,Item_Factura_Cantidad,Espectaculo_Cod, Ubicacion_Fila, Ubicacion_Asiento
	FROM gd_esquema.Maestra
	where Item_Factura_Descripcion is not null

GO
	-- Migrar compra
	INSERT INTO LOS_SIMULADORES.Compra
	SELECT distinct Compra_Fecha,Compra_Cantidad,Cli_Dni,Forma_Pago_Desc,Espectaculo_Cod, Ubicacion_Fila, Ubicacion_Asiento, Ubicacion_Precio
	FROM gd_esquema.Maestra
	where Compra_Fecha is not null and Forma_Pago_Desc is not null

GO
	--MIGRAR PUNTOS
	INSERT INTO LOS_SIMULADORES.Punto
	
	SELECT Cliente, Precio*0.1, DATEADD(month,6,c.Fecha)
	FROM LOS_SIMULADORES.Compra c


GO
	--Insertar roles
	INSERT INTO LOS_SIMULADORES.Rol VALUES ('Cliente',1)
	INSERT INTO LOS_SIMULADORES.Rol VALUES ('Empresa',1)
	INSERT INTO LOS_SIMULADORES.Rol VALUES ('Admin',1)
	INSERT INTO LOS_SIMULADORES.Rol VALUES ('Vacio',1)

GO
	--Insertar Funcionalidades
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('ABM Cliente')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('ABM Empresa Espectaculo')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('ABM Rol')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('ABM Rubro')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('Comprar')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('Canje Puntos')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('Editar Publicacion')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('Generar Publicacion')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('ABM Grado')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('Historial Cliente')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('Generar Rendicion Comisiones')
	INSERT INTO LOS_SIMULADORES.Funcionalidad VALUES ('Listado Estadistico')
	
	
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (5,1)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (6,1)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (10,1)

	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (7,2)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (8,2)

	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (1,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (2,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (3,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (4,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (5,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (6,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (7,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (8,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (9,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (11,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (10,3)
	INSERT INTO LOS_SIMULADORES.FuncionalidadXRol VALUES (12,3)
	

insert into LOS_SIMULADORES.Usuario values('admin',HASHBYTES('SHA2_256','123'),null,null)
insert into LOS_SIMULADORES.UsuarioXRol values('admin', 3)
insert into LOS_SIMULADORES.Intentos values('admin',0)

----------------------------------------------------TRIGGER-----------------------------------------------------------------------------------------------
GO
CREATE TRIGGER rolEmpresaInhabilitado  
ON LOS_SIMULADORES.Empresa
AFTER INSERT   
AS  
   update LOS_SIMULADORES.UsuarioXRol set rol = 4 where exists(select 1 from LOS_SIMULADORES.Rol where rol = idRol and estado = 0)   

GO
CREATE TRIGGER LOS_SIMULADORES.rolClienteInhabilitado  
ON LOS_SIMULADORES.cliente
AFTER INSERT   
AS  
   update LOS_SIMULADORES.UsuarioXRol set rol = 4 where exists(select 1 from LOS_SIMULADORES.Rol where rol = idRol and estado = 0)   



----------------------------------------------------SPS--------------------------------------------------------------------------------------------------

--Insertar/Editar Cliente
GO
CREATE PROCEDURE	LOS_SIMULADORES.actualizarCliente @Dni numeric(18,0), @Apellido nvarchar(255),	@Nombre	nvarchar(255), @Tipo_dni nvarchar(50),
								   @cuil nvarchar(50), @fechaNac datetime, @Mail nvarchar(50), @Telefono nvarchar(50), @Calle nvarchar(50), @Numero numeric(5,0), 
								   @Piso nvarchar(50), @Departamento nvarchar(50), @Codigo_postal nvarchar(50), @fechaCreacion datetime, @tarjeta nvarchar(50)
AS

if not exists (select 1 from LOS_SIMULADORES.Cliente c where c.Dni = @Dni)
insert into LOS_SIMULADORES.Cliente values (@Dni, @Apellido, @Nombre, @Tipo_dni,@cuil,@fechaNac, @Mail, @Telefono, @Calle, 
											@Numero, @Piso, @Departamento, @Codigo_postal,@fechaCreacion, @tarjeta, null,1) 

else
update LOS_SIMULADORES.Cliente set Apellido=@Apellido, Nombre=@Nombre, Tipo_dni=@Tipo_dni, Cuil = @cuil, Fecha_creacion=@fechaCreacion, Fecha_Nacimiento = Fecha_Nacimiento,
								   Mail=@Mail, Telefono=@Telefono, Calle=@Calle, Numero=@Numero, Piso=@Piso, Departamento=@Departamento, Codigo_postal=@Codigo_postal, Tarjeta = @tarjeta
where Dni = @Dni

--Eliminar Cliente
GO
CREATE PROCEDURE LOS_SIMULADORES.eliminarCliente @Dni numeric(18,0)
AS
update LOS_SIMULADORES.Cliente set estado = 0 where dni = @Dni

--Eliminar Empresa
GO
CREATE PROCEDURE LOS_SIMULADORES.eliminarEmpresa @Cuit nvarchar(255)
AS
update LOS_SIMULADORES.Empresa set estado = 0 where cuit = @Cuit

--Insertar/Editar Empresa
GO
CREATE PROCEDURE LOS_SIMULADORES.actualizarEmpresa @Cuit nvarchar(255), @Razon_Social nvarchar(255), @Fecha_Creacion datetime, @Mail nvarchar(50), @Calle nvarchar(50),
								   @Numero numeric(5,0), @Piso nvarchar(50), @Departamento nvarchar(50), @Codigo_postal nvarchar(50), @Telefono nvarchar(50), @Ciudad nvarchar(50)
AS

if not exists (select 1 from LOS_SIMULADORES.Empresa e where e.Cuit = @Cuit)
insert into LOS_SIMULADORES.Empresa values (@Cuit, @Razon_Social, @Fecha_Creacion, @Mail, @Calle, @Numero, @Piso, @Departamento, 
											@Codigo_postal, @Telefono, @Ciudad,1) 

else
update LOS_SIMULADORES.Empresa set Razon_Social = @Razon_Social, Fecha_Creacion = @Fecha_Creacion, Mail = @Mail, calle = @Calle, numero = @Numero, piso = @Piso, 
								   Departamento = @Departamento, Codigo_postal = @Codigo_postal, Telefono = @Telefono, Ciudad = @Ciudad
where Cuit = @Cuit

--Insertar/Editar Espectaculo
GO
CREATE PROCEDURE LOS_SIMULADORES.actualizarEspectaculo @Cod int, @Desc nvarchar(255), @Fecha_venc datetime, @Empresa nvarchar(255), @Estado nvarchar(255), @Direccion nvarchar(255), @Grado nvarchar(255), @Fecha_Crea datetime
AS

if not exists (select 1 from LOS_SIMULADORES.Espectaculo e where e.Cod = @Cod)
insert into LOS_SIMULADORES.Espectaculo values (@Desc , @Fecha_Crea , @Fecha_venc , @Empresa , @Estado , 1 , @Direccion, @Grado) 

else
update LOS_SIMULADORES.Espectaculo set Descripcion = @Desc, Fecha = @Fecha_Crea, Fecha_Venc = @Fecha_venc, Empresa = @Empresa, Estado = @Estado, Rubro = 1, Direccion = @Direccion, Grado = @Grado
									   
where Cod = @Cod

--Eliminar Rol
GO
CREATE PROCEDURE LOS_SIMULADORES.eliminarRol @id int
AS
update LOS_SIMULADORES.UsuarioXRol set rol = 4 where rol = @id
update LOS_SIMULADORES.Rol set Estado = 0 WHERE idRol = @id

--Eliminar Grado
GO
CREATE PROCEDURE LOS_SIMULADORES.eliminarGrado @peso int
AS
update LOS_SIMULADORES.grado set estado = 0 where peso = @peso

--Insertar funcionalidadXrol
GO
CREATE PROCEDURE LOS_SIMULADORES.insertarFuncXRol @func nvarchar(255), @rol int
AS
if not exists (select 1 from LOS_SIMULADORES.FuncionalidadXRol x where (select idFunc from LOS_SIMULADORES.Funcionalidad where Descripcion = @func) = x.Funcionalidad and @rol = Rol)
insert into LOS_SIMULADORES.FuncionalidadXRol values((select idFunc from LOS_SIMULADORES.Funcionalidad where Descripcion = @func),@rol)


--Insertar intento
GO
CREATE PROCEDURE LOS_SIMULADORES.insertarIntento @usr nvarchar(50), @i int
AS
if @i=0
update Intentos set Intentos += 1 where Usuario = @usr

if @i=1
update Intentos set Intentos = 0 where Usuario = @usr

--Comprobar contraseña
GO
CREATE PROCEDURE LOS_SIMULADORES.comprobar @usr nvarchar(50), @pass varchar(255)
AS
select 1 from LOS_SIMULADORES.Usuario where idUsuario = @usr and "Password" = HASHBYTES('SHA2_256',@pass)


--Comprobar Ubicaciones
GO
CREATE PROCEDURE LOS_SIMULADORES.comprobarUbicaciones @espectaculo int
AS
if (select sum(1) from LOS_SIMULADORES.Compra where Espectaculo = @espectaculo) = (select sum(1) from LOS_SIMULADORES.Ubicacion where Espectaculo = @espectaculo)
update LOS_SIMULADORES.Espectaculo set Estado = 'Finalizada' where Cod = @espectaculo

--Top Empresas
GO
CREATE PROCEDURE LOS_SIMULADORES.topEmpresa @fechaIni datetime, @fechaFin datetime, @grado nvarchar(50)
AS
select top 5 Cuit,count(u.Asiento) as LocalidadesNoVendidas from LOS_SIMULADORES.Empresa em
join LOS_SIMULADORES.Espectaculo es on em.Cuit = es.Empresa
join LOS_SIMULADORES.Ubicacion u on u.Espectaculo = es.Cod
where es.Fecha > @fechaIni and es.Fecha < @fechaFin and em.estado = 1  and not exists 
(select 1 from LOS_SIMULADORES.Compra c 
where c.Espectaculo = es.Cod and u.Asiento = c.Asiento and u.Fila = c.Fila and c.Fecha > @fechaIni and c.Fecha < @fechaFin)
and (select Descripcion from LOS_SIMULADORES.Grado where es.Grado = Peso) = @grado
group by Cuit
order by count(u.Asiento) desc

--Top compradores
GO
CREATE PROCEDURE LOS_SIMULADORES.topCompradores @fechaIni datetime, @fechaFin datetime
AS
select top 5 dni, count(co.Codigo) as CantCompras from LOS_SIMULADORES.Cliente cl
join LOS_SIMULADORES.Compra co on cl.Dni = co.Cliente
where co.Fecha > @fechaIni and co.Fecha < @fechaFin and cl.estado = 1
group by dni
order by count(co.Codigo) desc


--Top Puntos Vencidos
GO
CREATE PROCEDURE LOS_SIMULADORES.topVencidos @fechaIni datetime, @fechaFin datetime
AS
select top 5 dni, ROUND((sum(p.Cantidad) - (select isnull(sum(puntos),0) from LOS_SIMULADORES.Premio pr where pr.Cliente = cl.dni and pr.Fecha < @fechaFin and pr.Fecha > @fechaIni)),2) as PuntosVencidos
from LOS_SIMULADORES.Cliente cl
join LOS_SIMULADORES.Punto p on p.Cliente = cl.Dni
where Vencimiento < @fechaFin and Vencimiento > @fechaIni and cl.estado =1
group by dni
order by PuntosVencidos desc 


--Puntos

GO
CREATE PROCEDURE LOS_SIMULADORES.puntos @usr nvarchar(50), @fecha datetime
AS
select 
ROUND((select isnull(sum(cantidad),0) from LOS_SIMULADORES.punto 
where vencimiento > @fecha and cliente = (select Dni from LOS_SIMULADORES.Cliente c join LOS_SIMULADORES.Usuario u on c.Dni = u.Cliente where u.idUsuario = @usr))
-
(select isnull(sum(puntos),0) from LOS_SIMULADORES.Premio
where fecha <= @fecha and fecha > DATEADD(month, -6,@fecha) and cliente = (select Dni from LOS_SIMULADORES.Cliente c join LOS_SIMULADORES.Usuario u on c.Dni = u.Cliente where u.idUsuario = @usr)),2)


--Generar itemFactura

GO
CREATE PROCEDURE LOS_SIMULADORES.itemFactura @factura int, @precio float, @grado float, @cantidad int, @espectaculo int, @fila varchar(3), @asiento numeric(18,0)
AS
insert into LOS_SIMULADORES.Item_Factura values(@factura, @precio * 0.001 * @grado, @cantidad, @espectaculo, @fila, @asiento)



-----------------------------------------------------------------------DROPS---------------------------------------------------------------------------------
/*

DROP TABLE LOS_SIMULADORES.Intentos;
DROP TABLE LOS_SIMULADORES.Item_factura;
DROP TABLE LOS_SIMULADORES.Rendicion;
DROP TABLE LOS_SIMULADORES.FuncionalidadXRol;
DROP TABLE LOS_SIMULADORES.UsuarioXRol;
DROP TABLE LOS_SIMULADORES.Punto;
DROP TABLE LOS_SIMULADORES.Premio;
DROP TABLE LOS_SIMULADORES.Compra;
DROP TABLE LOS_SIMULADORES.Factura; 
DROP TABLE LOS_SIMULADORES.Ubicacion; 
DROP TABLE LOS_SIMULADORES.Usuario; 
DROP TABLE LOS_SIMULADORES.Rol; 
DROP TABLE LOS_SIMULADORES.Funcionalidad; 
DROP TABLE LOS_SIMULADORES.Cliente; 
DROP TABLE LOS_SIMULADORES.Espectaculo; 
DROP TABLE LOS_SIMULADORES.Tarjeta; 
DROP TABLE LOS_SIMULADORES.Rubro; 
DROP TABLE LOS_SIMULADORES.Empresa; 
DROP TABLE LOS_SIMULADORES.Grado;


DROP PROCEDURE LOS_SIMULADORES.actualizarCliente;
DROP PROCEDURE LOS_SIMULADORES.actualizarEmpresa;
DROP PROCEDURE LOS_SIMULADORES.actualizarEspectaculo;
DROP PROCEDURE LOS_SIMULADORES.eliminarCliente;
DROP PROCEDURE LOS_SIMULADORES.eliminarEmpresa;
DROP PROCEDURE LOS_SIMULADORES.eliminarRol;
DROP PROCEDURE LOS_SIMULADORES.insertarFuncXRol;
DROP PROCEDURE LOS_SIMULADORES.insertarIntento;
DROP PROCEDURE LOS_SIMULADORES.comprobar;
DROP PROCEDURE LOS_SIMULADORES.comprobarUbicaciones;
DROP PROCEDURE LOS_SIMULADORES.topCompradores;
DROP PROCEDURE LOS_SIMULADORES.topEmpresa;
DROP PROCEDURE LOS_SIMULADORES.topVencidos;
DROP PROCEDURE LOS_SIMULADORES.puntos;
DROP PROCEDURE LOS_SIMULADORES.itemFactura;
DROP PROCEDURE LOS_SIMULADORES.eliminarGrado;


DROP SCHEMA LOS_SIMULADORES;

*/