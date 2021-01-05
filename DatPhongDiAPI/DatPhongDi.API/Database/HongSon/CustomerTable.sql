USE [DatPhongDiDb]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 1/1/2021 2:30:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[PhoneNum] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Passport] [varchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


