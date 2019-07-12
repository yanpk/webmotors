CREATE TABLE [dbo].[tb_AnuncioWebmotors] (
    [ID]            INT          IDENTITY (1, 1) NOT NULL,
    [marca]         VARCHAR (45) NOT NULL,
    [modelo]        VARCHAR (45) NOT NULL,
    [versao]        VARCHAR (45) NOT NULL,
    [ano]           INT          NOT NULL,
    [quilometragem] INT          NOT NULL,
    [observacao]    TEXT         NOT NULL
);

