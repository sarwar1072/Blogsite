USE [TravelBooking]
GO
/****** Object:  User [employee]    Script Date: 3/1/2025 8:34:20 PM ******/
CREATE USER [employee] FOR LOGIN [employee] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [employee]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[BookingType] [nvarchar](max) NULL,
	[TotalPrice] [float] NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
	[ApplicationUserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsultationForms]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultationForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PreferredJourneyDate] [nvarchar](max) NULL,
	[AdditionalRequirements] [nvarchar](max) NULL,
 CONSTRAINT [PK_ConsultationForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelBookings]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelBookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NULL,
	[CheckInDate] [datetime2](7) NOT NULL,
	[CheckOutDate] [datetime2](7) NOT NULL,
	[AirportTransfer] [bit] NOT NULL,
	[BedType] [nvarchar](max) NULL,
	[DecorationsInRoom] [bit] NOT NULL,
	[ExtraBed] [bit] NOT NULL,
	[NoteToProperty] [nvarchar](max) NULL,
	[NumberOfGuests] [int] NOT NULL,
	[RoomOnHigherFloor] [bit] NOT NULL,
	[RoomPreference] [nvarchar](max) NULL,
	[HotelId] [int] NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_HotelBookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelFacilities]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelFacilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessFacilities] [nvarchar](max) NULL,
	[FitnessFacilities] [nvarchar](max) NULL,
	[FoodFacilities] [nvarchar](max) NULL,
	[General] [nvarchar](max) NULL,
	[IndoorFacitilies] [nvarchar](max) NULL,
	[Parking] [nvarchar](max) NULL,
	[Policies] [nvarchar](max) NULL,
	[HotelId] [int] NULL,
 CONSTRAINT [PK_HotelFacilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[HotelUrl] [nvarchar](max) NULL,
	[PricePerNight] [float] NOT NULL,
	[AvailableRooms] [int] NOT NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[AlternativeText] [nvarchar](max) NULL,
	[HotelId] [int] NULL,
	[TourId] [int] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingID] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[PaymentStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [int] NOT NULL,
	[RoomType] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[RoomPhUrl] [nvarchar](max) NULL,
	[HotelId] [int] NOT NULL,
	[Capacity] [int] NULL,
	[Policies] [nvarchar](max) NULL,
	[RoomFacilities] [nvarchar](max) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tours]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TourName] [nvarchar](max) NULL,
	[TourUrl] [nvarchar](max) NULL,
	[Destination] [nvarchar](max) NULL,
	[MaxiMumPeople] [int] NOT NULL,
	[MiniMumPeople] [int] NOT NULL,
	[MapUrl] [nvarchar](max) NULL,
	[Requirements] [nvarchar](max) NULL,
	[CancellationTerm] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[SpotsAvailable] [int] NOT NULL,
	[TourDetailsId] [int] NULL,
 CONSTRAINT [PK_Tours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToursDetails]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToursDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Overview] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Timing] [nvarchar](max) NULL,
	[InclusionExclusion] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AdditionalInformation] [nvarchar](max) NULL,
	[TravelTips] [nvarchar](max) NULL,
	[Options] [nvarchar](max) NULL,
	[Policy] [nvarchar](max) NULL,
 CONSTRAINT [PK_ToursDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserForms]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[applicationUserid] [uniqueidentifier] NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NumberOfTravellers] [int] NULL,
	[DepartureDate] [datetime2](7) NULL,
	[Remark] [nvarchar](max) NULL,
	[VisaId] [int] NOT NULL,
	[ProcessStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visas]    Script Date: 3/1/2025 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VisaType] [nvarchar](max) NULL,
	[VisaMode] [nvarchar](max) NULL,
	[EntryType] [nvarchar](max) NULL,
	[VisaValidity] [int] NULL,
	[ProcessingTime] [int] NULL,
	[MaxiMumStay] [int] NULL,
	[Price] [float] NOT NULL,
	[Requirements] [nvarchar](max) NULL,
	[CardUrl] [nvarchar](max) NULL,
	[CoverUrl] [nvarchar](max) NULL,
	[Destination] [nvarchar](max) NULL,
	[Policy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Visas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241101123748_num1', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241101172410_num2', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241102133012_num3', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241108180109_num4', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241108180536_num5', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241113123136_num6', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241113123846_num7', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241118191222_num8', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241119111330_num9', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241119134459_num10', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241119135625_num11', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241122142430_num12', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241123183242_num13', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250219080714_num14', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250220103055_num15', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250220105314_num16', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250220161738_num17', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250223061113_num18', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250223111248_num19', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250223115701_num20', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250223124918_num21', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250227031806_num22', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250227134457_num23', N'6.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250227135808_num24', N'6.0.19')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2c5e174e-3b0e-446f-86af-483d56fd7210', N'Admin', N'ADMIN', N'638762830885643860')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a', N'User', N'USER', N'638762830885643883')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125', N'2c5e174e-3b0e-446f-86af-483d56fd7210')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7dae29be-da2b-45fe-1d2c-08dd55631272', N'e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ca263363-e32d-4745-b192-08dd5564219b', N'e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6ba97b4f-f431-4e77-d1b6-08dd5564cecd', N'e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8f3d96ce-76ec-4992-911a-33ceb81fa29d', N'e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a')
GO
INSERT [dbo].[AspNetUsers] ([Id], [LastName], [Password], [Role], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName]) VALUES (N'7dae29be-da2b-45fe-1d2c-08dd55631272', N'mahmud', NULL, NULL, N'mahmud@gmail.com', N'MAHMUD@GMAIL.COM', N'mahmud@gmail.com', N'MAHMUD@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEDqOuvF4462gDTkCo39y64f1/P0PGEK3RycaDDbTXro7QP4ClQ+IFRKo0rGGaWRW7A==', N'V52VI3YROXW72UA6VJIRHAJPA6D2DPBK', N'3467f5af-ae25-4f3b-9fef-4eb2068aa3ab', NULL, 0, 0, NULL, 1, 0, N'milon')
INSERT [dbo].[AspNetUsers] ([Id], [LastName], [Password], [Role], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName]) VALUES (N'ca263363-e32d-4745-b192-08dd5564219b', N'milon', NULL, NULL, N'sarwar.cse.diu@gmail.com', N'SARWAR.CSE.DIU@GMAIL.COM', N'sarwar.cse.diu@gmail.com', N'SARWAR.CSE.DIU@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEDQUKePV5DPhDO6RO2XZQuw1gtKDSmk9nbcnoNhkCACJjzeb87PUpubb+GCfjeffsQ==', N'SBAF6N3BKLMF33BT5QHX5COKFI746WTB', N'974ed44e-d7b2-459c-a16d-78c1e7362093', NULL, 0, 0, NULL, 1, 0, N'sarwar mahmud')
INSERT [dbo].[AspNetUsers] ([Id], [LastName], [Password], [Role], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName]) VALUES (N'6ba97b4f-f431-4e77-d1b6-08dd5564cecd', N'hossin', NULL, NULL, N'asad@gmail.com', N'ASAD@GMAIL.COM', N'asad@gmail.com', N'ASAD@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGBmJO35qzkuPCAZRDBIskmq/Urgmmn4aEk8k+SKzpEH2O1y00zOiGUF1HH9Qw4WDQ==', N'YTVHXOESCNY6TEJDJKPAEZM76I7NK2TA', N'0e4925ee-e383-493c-8cc1-41bea26a204e', NULL, 0, 0, NULL, 1, 0, N'asad')
INSERT [dbo].[AspNetUsers] ([Id], [LastName], [Password], [Role], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName]) VALUES (N'e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125', NULL, NULL, NULL, N'admin@gmail.com', N'admin@gmail.com', N'admin@gmail.com', N'admin@gmail.com', 1, N'AQAAAAEAACcQAAAAEGax2Wv0SlL7pI9jxn5Ei2CR2NeSlm1+wm1uCoNLQEnfKXTnDSHDUiTME3sOQCOhiw==', N'7c4be7b2-4da3-4397-bc9c-27afd91a8d6b', N'2da72ac8-f482-4ad3-85dc-766dd3b2501c', N'', 0, 0, NULL, 1, 0, N'Admin')
INSERT [dbo].[AspNetUsers] ([Id], [LastName], [Password], [Role], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName]) VALUES (N'8f3d96ce-76ec-4992-911a-33ceb81fa29d', NULL, NULL, NULL, N'user@gmail.com.com', N'user@gmail.com.com', N'user@gmail.com.com', N'user@gmail.com.com', 1, N'AQAAAAEAACcQAAAAEMzXMKjDn3UAHzJoeAvlOAV1D5b3etatbHCFDZ+RkyNdco3/AUnipzZBe493/jfU+Q==', N'f790ede1-833a-4d55-8c76-eeef622c3eef', N'8e912277-3461-4b26-80aa-087268e89dc8', N'', 0, 0, NULL, 1, 0, N'sarwar')
GO
SET IDENTITY_INSERT [dbo].[ConsultationForms] ON 

INSERT [dbo].[ConsultationForms] ([Id], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [PreferredJourneyDate], [AdditionalRequirements]) VALUES (3, N'sarwar', N'Mahmud', N'milon@gmail.com', N'01909020925', N'2024-11-19', N'dwsf')
INSERT [dbo].[ConsultationForms] ([Id], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [PreferredJourneyDate], [AdditionalRequirements]) VALUES (3021, N'sarwar mahmud', N'milon', N'sarwar.cse.diu@gmail.com', N'01909020925', N'2025-03-07', N'sferg')
SET IDENTITY_INSERT [dbo].[ConsultationForms] OFF
GO
SET IDENTITY_INSERT [dbo].[HotelBookings] ON 

INSERT [dbo].[HotelBookings] ([Id], [RoomId], [CheckInDate], [CheckOutDate], [AirportTransfer], [BedType], [DecorationsInRoom], [ExtraBed], [NoteToProperty], [NumberOfGuests], [RoomOnHigherFloor], [RoomPreference], [HotelId], [UserId]) VALUES (2016, 1, CAST(N'2025-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-03-06T00:00:00.0000000' AS DateTime2), 1, NULL, 1, 0, N'Milon and isra', 2, 0, N'Non-Smoking', 1, N'6ba97b4f-f431-4e77-d1b6-08dd5564cecd')
INSERT [dbo].[HotelBookings] ([Id], [RoomId], [CheckInDate], [CheckOutDate], [AirportTransfer], [BedType], [DecorationsInRoom], [ExtraBed], [NoteToProperty], [NumberOfGuests], [RoomOnHigherFloor], [RoomPreference], [HotelId], [UserId]) VALUES (2017, 5, CAST(N'2025-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-03-06T00:00:00.0000000' AS DateTime2), 1, NULL, 1, 0, N'second booking', 2, 0, N'Smoking', 2, N'6ba97b4f-f431-4e77-d1b6-08dd5564cecd')
INSERT [dbo].[HotelBookings] ([Id], [RoomId], [CheckInDate], [CheckOutDate], [AirportTransfer], [BedType], [DecorationsInRoom], [ExtraBed], [NoteToProperty], [NumberOfGuests], [RoomOnHigherFloor], [RoomPreference], [HotelId], [UserId]) VALUES (2018, 3, CAST(N'2025-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2025-03-08T00:00:00.0000000' AS DateTime2), 1, N'Large Bed', 0, 0, N'with my wife', 2, 0, N'Non-Smoking', 1, N'ca263363-e32d-4745-b192-08dd5564219b')
SET IDENTITY_INSERT [dbo].[HotelBookings] OFF
GO
SET IDENTITY_INSERT [dbo].[HotelFacilities] ON 

INSERT [dbo].[HotelFacilities] ([Id], [BusinessFacilities], [FitnessFacilities], [FoodFacilities], [General], [IndoorFacitilies], [Parking], [Policies], [HotelId]) VALUES (1, N'<p>Business fascilities</p>', N'<P>fitness fascilities</p>', N'<p>Food Fascilities</p>', N'<p>General Fascilities</p>', N'<p>indoor fascilites</p>', N'<p>Indoor fascilities</p>', N'<p>POLICIES</p>', 2)
INSERT [dbo].[HotelFacilities] ([Id], [BusinessFacilities], [FitnessFacilities], [FoodFacilities], [General], [IndoorFacitilies], [Parking], [Policies], [HotelId]) VALUES (2, N'<p>Business fascilities</p>', N'<P>fitness fascilities</p>', N'<p>Food Fascilities</p>', N'<p>General Fascilities</p>', N'<p>indoor fascilites</p>', N'<p>Indoor fascilities</p>', N'<p>POLICIES</p>', 1)
SET IDENTITY_INSERT [dbo].[HotelFacilities] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotels] ON 

INSERT [dbo].[Hotels] ([Id], [Name], [Location], [HotelUrl], [PricePerNight], [AvailableRooms]) VALUES (1, N'Hotel la meridiyana', N'Dhaka', N'/ListOfImages/20241110T112029139.jpg', 12000, 15)
INSERT [dbo].[Hotels] ([Id], [Name], [Location], [HotelUrl], [PricePerNight], [AvailableRooms]) VALUES (2, N'Dalas', N'Cox Bazar', N'/ListOfImages/20241114T090734304.jpg', 1110, 2)
SET IDENTITY_INSERT [dbo].[Hotels] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1, N'/ListOfImages/20241101T143029450.jpg', N'MV masud Rana image', NULL, 1)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (2, N'/ListOfImages/20241101T143029451.jpg', N'MV masud Rana image', NULL, 1)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (3, N'/ListOfImages/20241101T143147103.jpeg', N'Bokdadi Express image', NULL, 2)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (4, N'/ListOfImages/20241101T143147109.jpg', N'Bokdadi Express image', NULL, 2)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1002, N'/ListOfImages/20241109T074046131.jpg', N'Sonargaon image', 1, NULL)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1003, N'/ListOfImages/20241109T074047414.jpg', N'Sonargaon image', 1, NULL)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1004, N'/ListOfImages/20241114T090734316.jpg', N'Sonargaon image', 2, NULL)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1005, N'/ListOfImages/20241114T090734317.jpg', N'Sonargaon image', 2, NULL)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1006, N'/ListOfImages/20250112T045650258.jpg', N'Kayak tours image', NULL, 1002)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1007, N'/ListOfImages/20250112T045650259.jpg', N'Kayak tours image', NULL, 1002)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1008, N'/ListOfImages/20250112T045755086.jpg', N'Sight seeing image', NULL, 1003)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1009, N'/ListOfImages/20250112T045755087.jpg', N'Sight seeing image', NULL, 1003)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1010, N'/ListOfImages/20250112T050901504.jpg', N'Hill Trac image', NULL, 1004)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1011, N'/ListOfImages/20250112T050901506.jpg', N'Hill Trac image', NULL, 1004)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1012, N'/ListOfImages/20250112T051006935.jpg', N'Hill Trac adventure image', NULL, 1005)
INSERT [dbo].[Images] ([Id], [ImageUrl], [AlternativeText], [HotelId], [TourId]) VALUES (1013, N'/ListOfImages/20250112T051006937.jpg', N'Hill Trac adventure image', NULL, 1005)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [RoomNumber], [RoomType], [Price], [RoomPhUrl], [HotelId], [Capacity], [Policies], [RoomFacilities]) VALUES (1, 1, N'Duplex', CAST(12000.00 AS Decimal(18, 2)), N'/ListOfImages/20241109T112917077.jpg', 1, 5, N'Hairdryer  Hot Water  Toiletries,  Air Conditioning', N'Breakfast Included
Complimentary buffet breakfast with airport transfer')
INSERT [dbo].[Rooms] ([Id], [RoomNumber], [RoomType], [Price], [RoomPhUrl], [HotelId], [Capacity], [Policies], [RoomFacilities]) VALUES (3, 2, N'Double', CAST(130000.00 AS Decimal(18, 2)), N'/ListOfImages/20241109T114416467.webp', 1, 4, N'Hairdryer  Hot Water  Toiletries,  Air Conditioning', N'Breakfast Included
Complimentary buffet breakfast with airport transfer')
INSERT [dbo].[Rooms] ([Id], [RoomNumber], [RoomType], [Price], [RoomPhUrl], [HotelId], [Capacity], [Policies], [RoomFacilities]) VALUES (4, 1, N'Single Room', CAST(12230.00 AS Decimal(18, 2)), N'/ListOfImages/20241114T111308924.jpg', 2, 4, N'Hairdryer  Hot Water  Toiletries,  Air Conditioning', N'Breakfast Included
Complimentary buffet breakfast with airport transfer')
INSERT [dbo].[Rooms] ([Id], [RoomNumber], [RoomType], [Price], [RoomPhUrl], [HotelId], [Capacity], [Policies], [RoomFacilities]) VALUES (5, 2, N'Double room', CAST(13450.00 AS Decimal(18, 2)), N'/ListOfImages/20241114T111359385.jpg', 2, 5, N'Hairdryer  Hot Water  Toiletries,  Air Conditioning', N'Breakfast Included
Complimentary buffet breakfast with airport transfer')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Tours] ON 

INSERT [dbo].[Tours] ([Id], [TourName], [TourUrl], [Destination], [MaxiMumPeople], [MiniMumPeople], [MapUrl], [Requirements], [CancellationTerm], [Price], [SpotsAvailable], [TourDetailsId]) VALUES (1, N'MV masud Rana', N'/images/20241101T143029420.jpg', N'Sundarban', 30, 24, N'https://www.bing.com/search?pglt=163&q=location+of+sundarban&cvid=bc1ba6122b6b45d0b6fa760417dfd679&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIGCAEQABhAMgYIAhAAGEAyBggDEAAYQDIGCAQQABhA0gEINjczOGowajGoAgCwAgA&FORM=ANNTA1&PC=HCTS', N'1. Nid and Birth cerf, 2.Not more than 2', N'Bd Weather', 12220, 1, 1)
INSERT [dbo].[Tours] ([Id], [TourName], [TourUrl], [Destination], [MaxiMumPeople], [MiniMumPeople], [MapUrl], [Requirements], [CancellationTerm], [Price], [SpotsAvailable], [TourDetailsId]) VALUES (2, N'Bokdadi Express2', N'/images/20241101T172645434.jpg', N'Cox Bazar ', 40, 35, N'https://www.bing.com/search?pglt=163&q=location+of+sundarban&cvid=bc1ba6122b6b45d0b6fa760417dfd679&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIGCAEQABhAMgYIAhAAGEAyBggDEAAYQDIGCAQQABhA0gEINjczOGowajGoAgCwAgA&FORM=ANNTA1&PC=HCTS', N'1. Nid and Birth cerf, 2.Not more than 2', N'Bad Weather', 1110, 2, 2)
INSERT [dbo].[Tours] ([Id], [TourName], [TourUrl], [Destination], [MaxiMumPeople], [MiniMumPeople], [MapUrl], [Requirements], [CancellationTerm], [Price], [SpotsAvailable], [TourDetailsId]) VALUES (1002, N'Kayak tours', N'/images/20250112T045650249.jpg', N'Sylhet', 10, 7, N'https://www.bing.com/search?pglt=163&q=location+of+sundarban&cvid=bc1ba6122b6b45d0b6fa760417dfd679&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIGCAEQABhAMgYIAhAAGEAyBggDEAAYQDIGCAQQABhA0gEINjczOGowajGoAgCwAgA&FORM=ANNTA1&PC=HCTS', N'1. Passport, 2.Not more than 2', N'before one month', 1000, 3, 1004)
INSERT [dbo].[Tours] ([Id], [TourName], [TourUrl], [Destination], [MaxiMumPeople], [MiniMumPeople], [MapUrl], [Requirements], [CancellationTerm], [Price], [SpotsAvailable], [TourDetailsId]) VALUES (1003, N'Sight seeing', N'/images/20250112T050358939.jpg', N'Sylhet', 20, 10, N'https://www.bing.com/search?pglt=163&q=location+of+sundarban&cvid=bc1ba6122b6b45d0b6fa760417dfd679&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIGCAEQABhAMgYIAhAAGEAyBggDEAAYQDIGCAQQABhA0gEINjczOGowajGoAgCwAgA&FORM=ANNTA1&PC=HCTS', N'1. Passport, 2.Not more than 2', N'before one month', 1000, 3, 1003)
INSERT [dbo].[Tours] ([Id], [TourName], [TourUrl], [Destination], [MaxiMumPeople], [MiniMumPeople], [MapUrl], [Requirements], [CancellationTerm], [Price], [SpotsAvailable], [TourDetailsId]) VALUES (1004, N'Hill Trac', N'/images/20250112T050901496.jpg', N'BandarBan', 20, 10, N'urlmap', N'1. Nid and Birth cerf, 2.Not more than 2', N'before one month', 1110, 10, 1003)
INSERT [dbo].[Tours] ([Id], [TourName], [TourUrl], [Destination], [MaxiMumPeople], [MiniMumPeople], [MapUrl], [Requirements], [CancellationTerm], [Price], [SpotsAvailable], [TourDetailsId]) VALUES (1005, N'Hill Trac adventure', N'/images/20250112T051006933.jpg', N'BandarBan', 30, 20, N'urlmap', N'1. Nid and Birth cerf, 2.Not more than 2', N'before one month', 10000, 5, 1003)
SET IDENTITY_INSERT [dbo].[Tours] OFF
GO
SET IDENTITY_INSERT [dbo].[ToursDetails] ON 

INSERT [dbo].[ToursDetails] ([Id], [Overview], [Location], [Timing], [InclusionExclusion], [Description], [AdditionalInformation], [TravelTips], [Options], [Policy]) VALUES (1, N'Update tour details', N'Sundarban (Khulna bagerhat)', N'10-12', N'Alternatively, you can pick up your ticket in person at our GoZayaan Experience Center. It''s located on Level 2, House 58, Sheltech Ayaan, Banani 11, Dhaka 1213. Google Map Link

', N'Alternatively, you can pick up your ticket in person at our GoZayaan Experience Center. It''s located on Level 2, House 58, Sheltech Ayaan, Banani 11, Dhaka 1213. Google Map Link

', N'Alternatively, you can pick up your ticket in person at our GoZayaan Experience Center. It''s located on Level 2, House 58, Sheltech Ayaan, Banani 11, Dhaka 1213. Google Map Link

', N'Alternatively, you can pick up your ticket in person at our GoZayaan Experience Center. It''s located on Level 2, House 58, Sheltech Ayaan, Banani 11, Dhaka 1213. Google Map Link

', N'Updated', N'Alternatively, you can pick up your ticket in person at our GoZayaan Experience Center. It''s located on Level 2, House 58, Sheltech Ayaan, Banani 11, Dhaka 1213. Google Map Link

')
INSERT [dbo].[ToursDetails] ([Id], [Overview], [Location], [Timing], [InclusionExclusion], [Description], [AdditionalInformation], [TravelTips], [Options], [Policy]) VALUES (2, N'Update tour details', N'Coxs bazar(Merine drive)', N'10-12', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.	', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.	', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.	', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.	', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.	', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.	')
INSERT [dbo].[ToursDetails] ([Id], [Overview], [Location], [Timing], [InclusionExclusion], [Description], [AdditionalInformation], [TravelTips], [Options], [Policy]) VALUES (1003, N'Update tour details', N'BandarBan', N'10-12', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N',Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.')
INSERT [dbo].[ToursDetails] ([Id], [Overview], [Location], [Timing], [InclusionExclusion], [Description], [AdditionalInformation], [TravelTips], [Options], [Policy]) VALUES (1004, N'Update tour details', N'Sylhet', N'10-12', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.', N'Choose your preferred delivery method when booking. We can send your ticket directly to your address within Dhaka for a fee of BDT 5-40. For locations outside Dhaka, the fee is BDT 20-80.')
SET IDENTITY_INSERT [dbo].[ToursDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[UserForms] ON 

INSERT [dbo].[UserForms] ([Id], [applicationUserid], [Phone], [Email], [NumberOfTravellers], [DepartureDate], [Remark], [VisaId], [ProcessStatus]) VALUES (5, N'ca263363-e32d-4745-b192-08dd5564219b', N'+8801909020925', N'sarwar.cse.diu@gmail.com', 3, CAST(N'2025-02-28T00:00:00.0000000' AS DateTime2), N'hgyg', 3, N'Requested')
INSERT [dbo].[UserForms] ([Id], [applicationUserid], [Phone], [Email], [NumberOfTravellers], [DepartureDate], [Remark], [VisaId], [ProcessStatus]) VALUES (6, N'ca263363-e32d-4745-b192-08dd5564219b', N'+8801909020925', N'sarwar@gmail.com', 4, CAST(N'2025-03-07T00:00:00.0000000' AS DateTime2), N'booking second one', 6, N'Requested')
INSERT [dbo].[UserForms] ([Id], [applicationUserid], [Phone], [Email], [NumberOfTravellers], [DepartureDate], [Remark], [VisaId], [ProcessStatus]) VALUES (7, N'6ba97b4f-f431-4e77-d1b6-08dd5564cecd', N'+8801783292530', N'asad@gmail.com', 3, CAST(N'2025-03-01T00:00:00.0000000' AS DateTime2), N'hay i am asad', 3, N'Requested')
INSERT [dbo].[UserForms] ([Id], [applicationUserid], [Phone], [Email], [NumberOfTravellers], [DepartureDate], [Remark], [VisaId], [ProcessStatus]) VALUES (8, N'6ba97b4f-f431-4e77-d1b6-08dd5564cecd', N'+8801783292530', N'asad@gmail.com', 1, CAST(N'2025-03-08T00:00:00.0000000' AS DateTime2), N'second one', 5, N'Requested')
INSERT [dbo].[UserForms] ([Id], [applicationUserid], [Phone], [Email], [NumberOfTravellers], [DepartureDate], [Remark], [VisaId], [ProcessStatus]) VALUES (9, N'6ba97b4f-f431-4e77-d1b6-08dd5564cecd', N'+8801966537922', N'asad@gmail.com', 1, CAST(N'2025-03-05T00:00:00.0000000' AS DateTime2), N'hay hossain', 4, N'Requested')
SET IDENTITY_INSERT [dbo].[UserForms] OFF
GO
SET IDENTITY_INSERT [dbo].[Visas] ON 

INSERT [dbo].[Visas] ([Id], [VisaType], [VisaMode], [EntryType], [VisaValidity], [ProcessingTime], [MaxiMumStay], [Price], [Requirements], [CardUrl], [CoverUrl], [Destination], [Policy]) VALUES (3, N'Tourist', N'E-Visa', N'Multiple', 60, 12, 37, 100000, N'1.Passport
2.PoliceClearance', N'/ListOfImages/20250221T165003779.jpeg', N'/images/20250221T165003771.jpeg', N'Indonesia', N'From Agency')
INSERT [dbo].[Visas] ([Id], [VisaType], [VisaMode], [EntryType], [VisaValidity], [ProcessingTime], [MaxiMumStay], [Price], [Requirements], [CardUrl], [CoverUrl], [Destination], [Policy]) VALUES (4, N'Tourist', N'Sticker Visa', N'Single', 60, 12, 37, 17000, N'1.Passport
2.Police Clearance ', N'/ListOfImages/20250221T165112125.jpeg', N'/images/20250221T165112124.jpeg', N'Philipines', N'From Sponsore')
INSERT [dbo].[Visas] ([Id], [VisaType], [VisaMode], [EntryType], [VisaValidity], [ProcessingTime], [MaxiMumStay], [Price], [Requirements], [CardUrl], [CoverUrl], [Destination], [Policy]) VALUES (5, N'Buniness', N'E-Visa', N'Single', 54, 12, 35, 12340, N'Passport', N'/ListOfImages/20250222T073843808.jpeg', NULL, N'Indonesia', N'Personal')
INSERT [dbo].[Visas] ([Id], [VisaType], [VisaMode], [EntryType], [VisaValidity], [ProcessingTime], [MaxiMumStay], [Price], [Requirements], [CardUrl], [CoverUrl], [Destination], [Policy]) VALUES (6, N'Buniness', N'E-Visa', N'Single', 54, 12, 35, 12230, N'passport', N'/ListOfImages/20250222T080810219.jpeg', NULL, N'Philipines', N'agent')
SET IDENTITY_INSERT [dbo].[Visas] OFF
GO
ALTER TABLE [dbo].[HotelBookings] ADD  DEFAULT (CONVERT([bit],(0))) FOR [AirportTransfer]
GO
ALTER TABLE [dbo].[HotelBookings] ADD  DEFAULT (CONVERT([bit],(0))) FOR [DecorationsInRoom]
GO
ALTER TABLE [dbo].[HotelBookings] ADD  DEFAULT (CONVERT([bit],(0))) FOR [ExtraBed]
GO
ALTER TABLE [dbo].[HotelBookings] ADD  DEFAULT ((0)) FOR [NumberOfGuests]
GO
ALTER TABLE [dbo].[HotelBookings] ADD  DEFAULT (CONVERT([bit],(0))) FOR [RoomOnHigherFloor]
GO
ALTER TABLE [dbo].[HotelBookings] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [UserId]
GO
ALTER TABLE [dbo].[UserForms] ADD  DEFAULT ((0)) FOR [VisaId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[HotelBookings]  WITH CHECK ADD  CONSTRAINT [FK_HotelBookings_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HotelBookings] CHECK CONSTRAINT [FK_HotelBookings_Rooms_RoomId]
GO
ALTER TABLE [dbo].[HotelFacilities]  WITH CHECK ADD  CONSTRAINT [FK_HotelFacilities_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HotelFacilities] CHECK CONSTRAINT [FK_HotelFacilities_Hotels_HotelId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Hotels_HotelId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Tours_TourId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Bookings_BookingID] FOREIGN KEY([BookingID])
REFERENCES [dbo].[Bookings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Bookings_BookingID]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Hotels_HotelId]
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_Tours_ToursDetails_TourDetailsId] FOREIGN KEY([TourDetailsId])
REFERENCES [dbo].[ToursDetails] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_Tours_ToursDetails_TourDetailsId]
GO
ALTER TABLE [dbo].[UserForms]  WITH CHECK ADD  CONSTRAINT [FK_UserForms_AspNetUsers_applicationUserid] FOREIGN KEY([applicationUserid])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserForms] CHECK CONSTRAINT [FK_UserForms_AspNetUsers_applicationUserid]
GO
ALTER TABLE [dbo].[UserForms]  WITH CHECK ADD  CONSTRAINT [FK_UserForms_Visas_VisaId] FOREIGN KEY([VisaId])
REFERENCES [dbo].[Visas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserForms] CHECK CONSTRAINT [FK_UserForms_Visas_VisaId]
GO
