USE [RateMyPlace]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 12/2/2018 7:49:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[PK_Username] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[PK_Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [RateMyPlace]
GO

/****** Object:  UserDefinedTableType [dbo].[stringTable]    Script Date: 12/2/2018 7:48:46 PM ******/
CREATE TYPE [dbo].[stringTable] AS TABLE(
	[string] [nvarchar](255) NULL
)
GO

USE [RateMyPlace]
GO

/****** Object:  Table [dbo].[Reviews]    Script Date: 12/2/2018 7:51:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reviews](
	[PK_ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Username] [varchar](255) NULL,
	[OverallRating] [int] NOT NULL,
	[Noise] [int] NULL,
	[Safety] [int] NULL,
	[Maintenance] [int] NULL,
	[LeaseStartDate] [date] NULL,
	[LeaseEndDate] [date] NULL,
	[CampusDistance] [float] NULL,
	[Pros] [varchar](max) NULL,
	[Cons] [varchar](max) NULL,
	[StudySpace] [bit] NULL,
	[Shuttle] [bit] NULL,
	[Wifi] [bit] NULL,
	[Furnished] [bit] NULL,
	[TV] [bit] NULL,
	[TrashService] [bit] NULL,
	[Gym] [bit] NULL,
	[Parking] [bit] NULL,
	[ParkingFee] [float] NULL,
	[Pets] [bit] NULL,
	[PetsFee] [float] NULL,
	[MiscFee] [float] NULL,
	[Rent] [float] NOT NULL,
	[Utilities] [float] NOT NULL,
	[HousingComplex] [varchar](255) NOT NULL,
	[SquareFootage] [float] NULL,
	[Location] [int] NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[PK_ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


