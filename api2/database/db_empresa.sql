	use master
go

if db_id('db_empresa') is not null
	begin
		drop database [db_empresa]
	end
go

create database [db_empresa]
go

use [db_empresa]
go

create schema [Accounts]
go

create schema [Company]
go

create schema [Counters]
go

set quoted_identifier on
go

create table [Company].[Sectors](
	[sector_id] int not null,
	[sector_description] varchar(30) NULL
)
go

alter table [Company].[Sectors] add constraint pk_sector primary key ([sector_id])
go

insert into [Company].[Sectors]([sector_id], [sector_description]) values
	(1, 'Tecnología'),
	(2, 'Costura'),
	(3, 'Comida'),
	(4, 'Naturaleza')
go

create table [Company].[Business](
	[business_id] int identity not null,
	[sector_id] int not null,
	[business_name] varchar(50) not null,
	[business_description] text not null,
	[business_location] varchar(30) null
)
go

alter table [Company].[Business] add constraint pk_business primary key ([business_id])
go

insert into [Company].[Business]([sector_id], [business_name], [business_description]) values
	('3', 'Vivian', 'The best restaurant'),
	('1', 'Lucki Tecno', 'Tecnologia actualizada'),
	('4', 'Plant Zom', 'Cuidemos a la naturaleza, es parte de nuestro mundo')
go

create table [Accounts].[Company](
	[company_id] int identity not null, -- O
	[rol_id] char(1) default(3) not null, -- O
	[business_id] int null,
	[company_name] varchar(20) not null, -- O
	[company_time_open] varchar(15) null,
	[company_time_close] varchar(15) null,
	[company_age] char(2) null,
	[company_email] varchar(50) not null, -- O
	[company_password] varchar(50) not null,
	[company_paypal_email] varchar(50) null,
	[company_mastercard_email] varchar(50) null,
	[company_phone] varchar(30) null
)
go

alter table [Accounts].[Company] add constraint pk_company primary key ([company_id])
go

insert into [Accounts].[Company]([rol_id], [business_id], [company_name], [company_time_open], [company_time_close], 
[company_age], [company_email], [company_password], [company_paypal_email], [company_mastercard_email], [company_phone])
values
	(default, 1, 'Vivian', null, null, 3, 'vivian@gmail.com', 'vivian123', null, null, '913242570'),
	(default, 3, 'Plantam', null, null, 1, 'plant@google.pe', 'plant123', null, null, '987654321'),
	(default, 2, 'Cansia', null, null, 2, 'cansia@google.pe', 'cansia123', null, null, '987654321')
go

create table [Accounts].[CreditCards] (
	[credit_id] [int] not null,
	[credit_type] [varchar](20) not null
)
go

alter table [Accounts].[CreditCards] add constraint pk_credit primary key ([credit_id])
go

create table [Accounts].[Customer] (
	[user_id] int identity not null,
	[rol_id] char(1) default 1 not null,
	[user_name] varchar(20) not null,
	[user_lastname] varchar(20) NULL,
	--[user_photo] [varbinary](max) NULL,
	[user_age] char(2) NULL,
	[user_phone] varchar(30) NULL,
	[user_email] varchar(50) not null,
	[user_password] varchar(50) not null
)
go

alter table [Accounts].[Customer] add constraint pk_user primary key ([user_id])
go

create table [Accounts].[Employees](
	[id_employee] int not null,
	[user_id] int not null,
	[rol_id] char(1) not null,
	[company_id] int not null,
	[employee_number] varchar(20) null,
	[employee_email] varchar(40) not null
)
go

alter table [Accounts].[Employees] add constraint fk_company 
foreign key([company_id]) references [Accounts].[Company]([company_id])
go

alter table [Accounts].[Employees] add constraint pk_employee primary key ([id_employee])
go

create table [Accounts].[PhotoImage](
	[fakeId] int not null,
	[user_id] int not null,
	[rol_id] char(1) not null,
	[imageTypeId] char(1) not null
)
go

alter table [Accounts].[PhotoImage] add constraint pk_image primary key ([fakeId])
go

create table [Accounts].[Profesional] (
	[user_id] int identity not null,
	[rol_id] char(1) default(2) not null,
	[business_id] int NULL,
	[user_name] varchar(20) not null, -- O
	[user_lastname] varchar(20) not null, -- O
	[user_age] char(2) null,
	[user_email] varchar(50) not null, -- O
	[user_password] varchar(50) not null, -- O
	[credit_id] int null,
	[user_card_email] varchar(50) null,
	[user_phone] varchar(20) null
)
go

alter table [Accounts].[Profesional] add constraint pk_user2 primary key ([user_id])
go

create table [Accounts].[TypeImage](
	[imageTypeId] char(1) not null,
	[imageTypeDescription] text not null
)
go

alter table [Accounts].[TypeImage] add constraint pk_tipe_image primary key ([imageTypeId])
go

create table [Company].[RolUsers](
	[rol_id] char(1) not null,
	[rol_description] varchar(20) not null
)
go

insert into [Company].[RolUsers](rol_id, rol_description) values
	(1, 'Customer'),
	(2, 'Profesional'),
	(3, 'Employee')

alter table [Company].[RolUsers] add constraint pk_rol primary key ([rol_id])
go

create table [Counters].[PayMethod](
	[pay_id] int not null,
	[payMethod] varchar(1) not null,
	[counter] int not null
)
go

alter table [Counters].[PayMethod] add constraint pk_pay_method primary key ([pay_id])
go

create table [Counters].[Suscriptions](
	[rol_id] int not null,
	[suscription_type] varchar(1) not null,
	[counter] int not null
)
go

create table [Company].[Jornadas] (
	tipoJornadaId int not null,
	jornada varchar(30)
)
go

insert into [Company].[Jornadas](tipoJornadaId, jornada) values
	(1, 'Completa'),
	(2, 'Parcial'),
	(3, 'Reducida'),
	(4, 'Laboral continua'),
	(5, 'Festivo')
go

alter table [Company].[Jornadas] add constraint pk_jornada primary key (tipoJornadaId)
go

create table [Company].[Advertisements] (
	jobId int identity, -- no mostrar
	[title] varchar(50),
	[company_id] int, -- obtener en procedimiento almacenado
	[description] text,
	tipoJornadaId int,
	fechaCreada varchar(30) -- en el procedimiento almacenado
)
go

alter table [Company].[Advertisements] add constraint pk_job primary key ([jobId])
go

alter table [Company].[Advertisements] add constraint fk_jornada foreign key ([tipoJornadaId]) references [Company].[Jornadas]
go

alter table [Company].[Advertisements] add constraint fk_company foreign key ([company_id]) references [Accounts].[Company]
go

create table [Company].[Tasks] (
	task_id int identity,
	company_id int,
	title varchar(50),
	fechaInicio varchar(30),
	fechaTerminada varchar(30)
)
go

alter table [Company].[Tasks] add constraint pk_task primary key(task_id)
go

alter table [Company].[Tasks] add constraint fk_company_task 
foreign key (company_id) references [Accounts].[Company](company_id)
go


insert into [Company].[Advertisements] ([title], [company_id], [description], tipoJornadaId, fechaCreada) values
	('Mesero', 1, 'Se busca mesero con hasta 2 años de experiencia', 1, convert(date, getdate())),
	('Cuidador de Plantas', 2, 'Se buscan estudiantes botánicos para practicante', 2, convert(date, getdate())),
	('Repostero', 1, 'Se buscan estudiantes botánicos para practicante', 2, convert(date, getdate())),
	('FullStack Developer x10', 3, 
	'Si te gusta trabajar en equipo, este es el trabajo que buscas. Si cumples con los requerimientos, avisanos! te necesitamos!', 2, convert(date, getdate())),
	('Senior Java', 3, 'desarrollador java', 1, convert(date, getdate())),
	('Senior Java', 3, 'desarrollador java', 2, convert(date, getdate()))
go

alter table [Accounts].[Company] add constraint [fk_bussiness2] foreign key([business_id])
references [Company].[Business] ([business_id])
go

alter table [Accounts].[Customer] add constraint [fk_rol1] foreign key([rol_id])
references [Company].[RolUsers] ([rol_id])
go

alter table [Accounts].[Employees] add constraint [fk_rol2] foreign key([rol_id])
references [Company].[RolUsers] ([rol_id])
go

alter table [Accounts].[PhotoImage] add constraint [fk_rol3] foreign key([rol_id])
references [Company].[RolUsers] ([rol_id])
go

alter table [Accounts].[PhotoImage] add constraint [fk_type_image] foreign key([imageTypeId])
references [Accounts].[TypeImage] ([imageTypeId])
go

alter table [Accounts].[Profesional] add constraint [fk_bussiness] foreign key([business_id])
references [Company].[Business] ([business_id])
go

alter table [Accounts].[Profesional] add constraint [fk_credit_card] foreign key([credit_id])
references [Accounts].[CreditCards] ([credit_id])
go

alter table [Company].[Business] add constraint [fk_sector] foreign key([sector_id])
references [Company].[Sectors] ([sector_id])
go

