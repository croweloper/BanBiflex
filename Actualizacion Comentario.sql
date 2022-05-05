select * from BANBIFLEX_RESERVA where ID_USUARIO='1013'

select * from BANBIFLEX_RESERVA_ANULADAS

SELECT * FROM Information_Schema.Columns WHERE TABLE_NAME = 'BANBIFLEX_RESERVA_ANULADAS'

select * from BANBIFLEX_RESERVA_ANULADAS where id_reserva=9413



select * from BANBIFLEX_RESERVA where ID_USUARIO='1013'

select * from BANBIFLEX_RESERVA_ANULADAS

delete BANBIFLEX_RESERVA where id='9508'

select * from BANBIFLEX_USUARIO where id='1013'

9508	1013	2022-05-10	777	NULL	NULL	Bicicleta	NULL	NULL	NULL	NULL	NULL	RESERVADO	09:00	18:00	2022-05-02 21:22:52.217	0

1013	45489379	QUISPE CONTRERAS DIEGO RENEE	14	0	1	0	0	DQUISPE@banbif.com.pe	ADMINISTRADOR	2022-03-02 09:11:54.597	DESARROLLADOR DE LABORATORIO DE INNOVACION	ESTRATEGIA E INNOVACION	SUBGERENCIA DE BANCA DIGITAL

-- Usuario grupo 0   -  - 71598806


Alter PROCEDURE [dbo].[SP_BANBIFLEX_ACTUALIZAR_ESTADO_RESERVA]
@ID_RESERVA INT, @ESTADO VARCHAR(20),@COMENTARIO VARCHAR(500)
AS 
BEGIN
	UPDATE BANBIFLEX_RESERVA SET ESTADO=@ESTADO WHERE ID=@ID_RESERVA;

	INSERT INTO BANBIFLEX_RESERVA_ANULADAS VALUES(@ID_RESERVA,@COMENTARIO,GETDATE());
END
GO