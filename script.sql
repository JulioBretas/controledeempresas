﻿CREATE TABLE EMPRESA(
	ID				UNIQUEIDENTIFIER	NOT NULL,
	NOMEFANTASIA	NVARCHAR(150)		NOT NULL,
	RAZAOSOCIAL		NVARCHAR(150)		NOT NULL,
	CNPJ			NVARCHAR(14)		NOT NULL,
	PRIMARY KEY(ID))
GO

CREATE TABLE FUNCIONARIO(
	ID				UNIQUEIDENTIFIER	NOT NULL,
	NOME			NVARCHAR(150)		NOT NULL,
	CPF				NVARCHAR(11)		NOT NULL,
	MATRICULA		NVARCHAR(8)			NOT NULL,
	DATAADMISSAO	DATE				NOT NULL,
	STATUS			INTEGER				NOT NULL,
	IDEMPRESA		UNIQUEIDENTIFIER	NOT NULL,
	PRIMARY KEY(ID),
	FOREIGN KEY(IDEMPRESA) REFERENCES EMPRESA(ID))
GO

CREATE PROCEDURE SP_INSERIR_FUNCIONARIO
	@P_NOME			NVARCHAR(150),
	@P_CPF			NVARCHAR(11),
	@P_MATRICULA	NVARCHAR(8),
	@P_DATAADMISSAO	DATE,
	@P_STATUS		INTEGER,
	@P_IDEMPRESA	UNIQUEIDENTIFIER
AS
BEGIN
	BEGIN TRANSACTION

	INSERT INTO FUNCIONARIO(
		ID,
		NOME,
		CPF,
		MATRICULA,
		DATAADMISSAO,
		STATUS,
		IDEMPRESA)
	VALUES(
		NEWID(),
		@P_NOME,
		@P_CPF,
		@P_MATRICULA,
		@P_DATAADMISSAO,
		@P_STATUS,
		@P_IDEMPRESA
	)

	COMMIT
END
GO