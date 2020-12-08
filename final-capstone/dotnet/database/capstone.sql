USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
BEGIN TRANSACTION;

CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE [dbo].[valets](
	[valet_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_valets] PRIMARY KEY CLUSTERED 
(
	[valet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[valets]  WITH CHECK ADD  CONSTRAINT [FK_valets_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])

ALTER TABLE [dbo].[valets] CHECK CONSTRAINT [FK_valets_users]

CREATE TABLE [dbo].[patrons](
	[patron_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[phone_number] [varchar](15) NOT NULL,
	[email_address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_patrons] PRIMARY KEY CLUSTERED 
(
	[patron_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[patrons]  WITH CHECK ADD  CONSTRAINT [FK_patrons_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])

ALTER TABLE [dbo].[patrons] CHECK CONSTRAINT [FK_patrons_users]

CREATE TABLE [dbo].[parking_spots](
	[parking_spot_id] [int] IDENTITY(1,1) NOT NULL,
	[is_occupied] [bit] NOT NULL,
 CONSTRAINT [PK_parking_spots] PRIMARY KEY CLUSTERED 
(
	[parking_spot_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[parking_statuses](
	[parking_status_id] [int] IDENTITY(1,1) NOT NULL,
	[parking_status] [varchar](30) NOT NULL,
 CONSTRAINT [PK_parking_statuses] PRIMARY KEY CLUSTERED 
(
	[parking_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[vehicles](
	[license_plate] [varchar](10) NOT NULL,
	[patron_id] [int] NOT NULL,
	[vehicle_make] [varchar](20) NOT NULL,
	[vehicle_model] [varchar](20) NOT NULL,
	[vehicle_vin] [varchar](30) NOT NULL,
	[vehicle_color] [varchar](20) NOT NULL,
 CONSTRAINT [PK_vehicles] PRIMARY KEY CLUSTERED 
(
	[license_plate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[vehicles]  WITH CHECK ADD  CONSTRAINT [FK_vehicles_patrons] FOREIGN KEY([patron_id])
REFERENCES [dbo].[patrons] ([patron_id])

ALTER TABLE [dbo].[vehicles] CHECK CONSTRAINT [FK_vehicles_patrons]

CREATE TABLE [dbo].[valet_slips](
	[ticket_id] [int] IDENTITY(1,1) NOT NULL,
	[valet_id] [int] NOT NULL,
	[license_plate] [varchar](10) NOT NULL,
	[parking_spot_id] [int] NULL,
	[date] [date] NULL,
	[time_in] [time](7) NULL,
	[time_out] [time](7) NULL,
	[amount_owed] [money] NULL,
	[parking_status_id] [int] NOT NULL,
 CONSTRAINT [PK_valet_slip] PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[valet_slips]  WITH CHECK ADD  CONSTRAINT [FK_valet_slip_parking_spots] FOREIGN KEY([parking_spot_id])
REFERENCES [dbo].[parking_spots] ([parking_spot_id])

ALTER TABLE [dbo].[valet_slips] CHECK CONSTRAINT [FK_valet_slip_parking_spots]

ALTER TABLE [dbo].[valet_slips]  WITH CHECK ADD  CONSTRAINT [FK_valet_slip_parking_statuses] FOREIGN KEY([parking_status_id])
REFERENCES [dbo].[parking_statuses] ([parking_status_id])

ALTER TABLE [dbo].[valet_slips] CHECK CONSTRAINT [FK_valet_slip_parking_statuses]

ALTER TABLE [dbo].[valet_slips]  WITH CHECK ADD  CONSTRAINT [FK_valet_slip_valets] FOREIGN KEY([valet_id])
REFERENCES [dbo].[valets] ([valet_id])

ALTER TABLE [dbo].[valet_slips] CHECK CONSTRAINT [FK_valet_slip_valets]

ALTER TABLE [dbo].[valet_slips]  WITH CHECK ADD  CONSTRAINT [FK_valet_slip_vehicles] FOREIGN KEY([license_plate])
REFERENCES [dbo].[vehicles] ([license_plate])

ALTER TABLE [dbo].[valet_slips] CHECK CONSTRAINT [FK_valet_slip_vehicles]

COMMIT TRANSACTION;