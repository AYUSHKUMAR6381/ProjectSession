drop database project121
create database project121
use  project121

create schema SMS



CREATE TABLE [SMS].[Admin_Detail](
	[Pk_Admin_ID] [int] IDENTITY(101,1) NOT NULL,
	[Employee_ID] [nvarchar](100) NULL,
	--[Fk_User_ID] [int] NULL,
	[First_Name] [nvarchar](50) NULL,
	[Last_Name] [nvarchar](50) NULL,
	[Date_Of_Birth] [datetime] NULL,
	[Email] [nvarchar](60) NOT NULL unique,
	[Contact] nvarchar(10) unique not null 
check(Contact like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	[Pswd] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Father_Name] [nvarchar](50) NULL,
	[Created_Date] [datetime] NULL default getdate(),
	
	[Is_Active] [bit]  default 0,
	[Is_Deleted] [bit]  default 0,
PRIMARY KEY CLUSTERED 
(
	[Pk_Admin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



---------------------------------------------------------




CREATE TABLE [SMS].[Attendance_Detail](
	[Pk_Attnd_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Stud_ID] [int] NULL,
	[Attendance] [nvarchar](10) NULL,
	[Created_Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pk_Attnd_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



-------------------------------------------------------------------------



CREATE TABLE [SMS].[Faculty_Detail](
	[Pk_Faculty_ID] [int] IDENTITY(1001,1) NOT NULL,
	[Faculty_ID] [nvarchar](100) NULL,
	--[Fk_User_ID] [int] NULL,
	[First_Name] [nvarchar](50) NULL,
	[Last_Name] [nvarchar](50) NULL,
	[Date_Of_Birth] [datetime] NULL,
	[Address] [nvarchar](100) NULL,
	[Email] [nvarchar](60) NOT NULL unique,
	[Contact] nvarchar(10) unique not null 
check(Contact like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	[Pswd] [nvarchar](20) NOT NULL,
	[Fk_Dept_ID] [int] NULL,
	[Father_Name] [nvarchar](50) NULL,
	[Created_Date] [datetime] NULL default getdate(),
	[Is_Active] [bit]  default 0,
	[Is_Deleted] [bit]  default 0,
PRIMARY KEY CLUSTERED 
(
	[Pk_Faculty_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



-----------------------------------------------------------------




CREATE TABLE [SMS].[Marks_Detail](
	[Pk_Marks_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Sem_ID] [int] NULL,
	[Fk_Stud_ID] [int] NULL,
	[Fk_Sub_ID] [int] NULL,
	[Sessional_Marks] [float] NULL,
	[MainExam_Marks] [float] NULL,
	[Total_Marks] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pk_Marks_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-----------------------------------------------------------


CREATE TABLE [SMS].[Mst_Department](
	[Pk_Dept_ID] [int] IDENTITY(1,1) NOT NULL,
	[Department_Name] [nvarchar](20) NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pk_Dept_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------------------------------------



CREATE TABLE [SMS].[Mst_Role](
	[Pk_Role_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [nvarchar](20) NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pk_Role_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------------------------------




CREATE TABLE [SMS].[Mst_Semester](
	[Pk_Sem_ID] [int] IDENTITY(1,1) NOT NULL,
	[Semester] [int] NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pk_Sem_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-------------------------------------------------------------


CREATE TABLE [SMS].[Mst_Subject](
	[Pk_Subject_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Sem_ID] [int] NULL,
	[Subject_Name] [nvarchar](50) NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pk_Subject_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


---------------------------------------------------------




CREATE TABLE [SMS].[Mst_User](
	[Pk_User_ID] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](30) NOT NULL,
	[LName] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](60) NOT NULL,
	[Contact] nvarchar(10) unique not null 
check(Contact like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	[Pswd] [nvarchar](20) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL default getdate(),
	[Fk_Role_ID] [int] NOT NULL,
	
		[Is_Active] [bit]  default 0,
	[Is_Deleted] [bit]  default 0,
PRIMARY KEY CLUSTERED 
(
	[Pk_User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




--------------------------------------------------------------------------

--insert into [SMS].[Student_Detail] values(1,'gasvaha','gaurav','gaurav','10/10/2020','9910347901','gaurav','garsh','betc','gaurav','10/10/2020',0,0)


CREATE TABLE [SMS].[Student_Detail](
	[Pk_Student_ID] [int] IDENTITY(101,1) NOT NULL,
	[Enroll_ID] [nvarchar](100) NULL,
		[Email] [nvarchar](60) NOT NULL unique,
	[First_Name] [nvarchar](50) NULL,
	[Last_Name] [nvarchar](50) NULL,
	[Date_Of_Birth] [datetime] NULL,
	[Contact] nvarchar(10) unique not null 
check(Contact like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	[Address] [nvarchar](100) NULL,
	[Pswd] [nvarchar](20) NOT NULL,
	[Course] [nvarchar](20) NULL,
	[Father_Name] [nvarchar](50) NULL,
	[Created_Date] [datetime] NULL,

		[Is_Active] [bit]  default 0,
	[Is_Deleted] [bit]  default 0,
PRIMARY KEY CLUSTERED 
(
	[Pk_Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-----------------------
--ALTER TABLE [SMS].[Admin_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_User_ID])
--REFERENCES [SMS].[Mst_User] ([Pk_User_ID])


ALTER TABLE [SMS].[Attendance_Detail] ADD  DEFAULT ('Absent') FOR [Attendance]
GO

ALTER TABLE [SMS].[Attendance_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_Stud_ID])
REFERENCES [SMS].[Student_Detail] ([Pk_Student_ID])
GO


ALTER TABLE [SMS].[Faculty_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_Dept_ID])
REFERENCES [SMS].[Mst_Department] ([Pk_Dept_ID])
GO

--ALTER TABLE [SMS].[Faculty_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_User_ID])
--REFERENCES [SMS].[Mst_User] ([Pk_User_ID])
--GO


ALTER TABLE [SMS].[Marks_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_Sem_ID])
REFERENCES [SMS].[Mst_Semester] ([Pk_Sem_ID])
GO

ALTER TABLE [SMS].[Marks_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_Stud_ID])
REFERENCES [SMS].[Student_Detail] ([Pk_Student_ID])
GO

ALTER TABLE [SMS].[Marks_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_Sub_ID])
REFERENCES [SMS].[Mst_Subject] ([Pk_Subject_ID])
GO

--ALTER TABLE [SMS].[Mst_User]  WITH CHECK ADD FOREIGN KEY([Fk_Role_ID])
--REFERENCES [SMS].[Mst_Role] ([Pk_Role_ID])
--GO


ALTER TABLE [SMS].[Mst_Subject]  WITH CHECK ADD FOREIGN KEY([Fk_Sem_ID])
REFERENCES [SMS].[Mst_Semester] ([Pk_Sem_ID])
GO


--ALTER TABLE [SMS].[Student_Detail]  WITH CHECK ADD FOREIGN KEY([Fk_User_ID])
--REFERENCES [SMS].[Mst_User] ([Pk_User_ID])
--GO

create trigger StudentTrig on [SMS].[Student_Detail]
after insert
as
begin
declare @FName nvarchar(30);
 declare @LName nvarchar(30);
declare @Email nvarchar(60);
declare @Contact nvarchar(10);
declare @Pswd nvarchar(20);
declare @DOB datetime ;
declare @Fk_Role_ID int;

select @FName=First_Name from inserted;
select @LName=Last_Name from inserted;
select @Email=Email from inserted;
select @Contact=Contact from inserted;
select @Pswd=Pswd from inserted;
select @DOB=Date_Of_Birth from inserted;
set @Fk_Role_ID=1;
insert into Mst_User (FName,LName,Email,Contact,Pswd,DOB,Fk_Role_ID)
values(@FName,@LName,@Email,@Contact,@Pswd,@DOB,@Fk_Role_ID)
end

create trigger FacultyTrig on [SMS].[Faculty_Detail]
after insert
as
begin
declare @FName nvarchar(30);
 declare @LName nvarchar(30);
declare @Email nvarchar(60);
declare @Contact nvarchar(10);
declare @Pswd nvarchar(20);
declare @DOB datetime ;
declare @Fk_Role_ID int;

select @FName=First_Name from inserted;
select @LName=Last_Name from inserted;
select @Email=Email from inserted;
select @Contact=Contact from inserted;
select @Pswd=Pswd from inserted;
select @DOB=Date_Of_Birth from inserted;
set @Fk_Role_ID=2;
insert into Mst_User (FName,LName,Email,Contact,Pswd,DOB,Fk_Role_ID)
values(@FName,@LName,@Email,@Contact,@Pswd,@DOB,@Fk_Role_ID)
end

create trigger AdminTrig on [SMS].[Admin_Detail]
after insert
as
begin
declare @FName nvarchar(30);
 declare @LName nvarchar(30);
declare @Email nvarchar(60);
declare @Contact nvarchar(10);
declare @Pswd nvarchar(20);
declare @DOB datetime ;
declare @Fk_Role_ID int;

select @FName=First_Name from inserted;
select @LName=Last_Name from inserted;
select @Email=Email from inserted;
select @Contact=Contact from inserted;
select @Pswd=Pswd from inserted;
select @DOB=Date_Of_Birth from inserted;
set @Fk_Role_ID=3;
insert into Mst_User (FName,LName,Email,Contact,Pswd,DOB,Fk_Role_ID)
values(@FName,@LName,@Email,@Contact,@Pswd,@DOB,@Fk_Role_ID)
end


