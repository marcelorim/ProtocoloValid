USE [ProtocoloDB]
GO

DROP TABLE [dbo].[TB_PROTOCOLO]
GO

/****** Object:  Table [dbo].[TB_PROTOCOLO]    Script Date: 03/04/2023 17:56:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_PROTOCOLO](
	[ID] [uniqueidentifier] NOT NULL,
	[NUM_PROTOCOLO] [bigint] NOT NULL,
	[NUM_VIA_DOC] [int] NOT NULL,
	[NUM_CPF] [bigint] NOT NULL,
	[NUM_RG] [bigint] NOT NULL,
	[NOME] [varchar](200) NOT NULL,
	[NOME_MAE] [varchar](200) NULL,
	[NOME_PAI] [varchar](200) NULL,
	[FOTO] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


