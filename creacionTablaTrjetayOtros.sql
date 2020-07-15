alter table usuarios add  respuestaRecuperarContrasena varbinary(300)

create table tarjetaCreditoDebito(
	idtarjetaCreditoDebito int not null,
	numeroTarjeta Varchar(45) not null,
	pin Varbinary(50) not null,
	usuario_idUsuario int not null,

	CONSTRAINT PK_tarjetaCreditoDebito PRIMARY KEY (idtarjetaCreditoDebito ),
	 CONSTRAINT FK_tarjetaCreditoDebito FOREIGN KEY (usuario_idUsuario) REFERENCES usuarios(idUsuario)
)

alter table contrasena add correo varchar(50)

select * from usuarios