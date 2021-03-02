USE [ALPHA_TIC]
GO

/****** Object:  Schema [develop]    Script Date: 28/02/2021 11:59:29 p. m. ******/
CREATE SCHEMA [develop]
GO

/* Creación de la tabla personas */
CREATE TABLE develop.Person (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    First_Name VARCHAR (50) NOT NULL,
	Second_Name VARCHAR (50) NULL,
	Surname VARCHAR (50) NOT NULL,
	Second_Surname VARCHAR (50) NULL,
    Birth_Date DATETIME NOT NULL,
	Document_Type_Id INT NULL,
	Document_Number VARCHAR(20) NOT NULL,
	Phone_Number VARCHAR(15) NOT NULL,
	Email VARCHAR(50) NOT NULL,	
    Creation_Date DATETIME DEFAULT GETDATE() NOT NULL,	
	Creator_Person  INT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	CONSTRAINT Registration_Status_Person CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);

/* Inserción del usuario Administrador para referencias en las siguientes tablas */
INSERT INTO develop.Person (First_Name, Surname, Birth_Date, Document_Number, Phone_Number, Email)
VALUES ('ADMINISTRADOR', 'ADMINISTRADOR', GETDATE(), '0','0','administrador@alphatic.com');

/* Creación de la tabla tipo de documentos */
CREATE TABLE develop.Document_Type (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Name VARCHAR (50) NOT NULL,
	Code VARCHAR (10) NOT NULL,
	Description VARCHAR (100) NULL,	
    Creation_Date DATETIME DEFAULT GETDATE(),	
	Creator_Person  INT NOT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	CONSTRAINT Registration_Status_Document_Type CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo'),
	FOREIGN KEY (Creator_Person) REFERENCES develop.Person (Id),
	FOREIGN KEY (Modifier_Person) REFERENCES develop.Person (Id),
);

/* Inserción de los registros para la tabla parametrica de tipo de documentos */
INSERT INTO develop.Document_Type (Name, Code, Creator_Person)
VALUES  ('Registro Civil', 'RC', (SELECT Id FROM develop.Person where First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo')),
		('Tarjeta de identidad', 'TI', (SELECT Id FROM develop.Person where First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo')),
		('Cédula de ciudadanía', 'CC', (SELECT Id FROM develop.Person where First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo')),
		('Cédula de extranjería', 'CE', (SELECT Id FROM develop.Person where First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo')),
		(' Pasaporte', 'PA', (SELECT Id FROM develop.Person where First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo')),
		('Menor sin identificación', 'MS', (SELECT Id FROM develop.Person where First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo')),
		('Adulto sin identidad', 'AS', (SELECT Id FROM develop.Person where First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo'));
		
/* Actualización del registro de Administrador */		
UPDATE develop.Person 
SET Document_Type_Id = (SELECT Id FROM develop.Document_Type WHERE Code = 'CC' AND Registration_Status = 'Activo')
WHERE First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo';

UPDATE develop.Person 
SET Creator_Person = (SELECT Id FROM develop.Person WHERE First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo')
WHERE First_Name = 'ADMINISTRADOR' AND Surname = 'ADMINISTRADOR' AND Registration_Status = 'Activo';

/* Alteraciones en la tabla de personas para las referencias a ella misma */
ALTER TABLE develop.Person
ALTER COLUMN Document_Type_Id INT NOT NULL;
ALTER TABLE develop.Person
ADD FOREIGN KEY (Document_Type_Id) REFERENCES develop.Document_Type(Id);
ALTER TABLE develop.Person
ALTER COLUMN Creator_Person INT NOT NULL;
ALTER TABLE develop.Person
ADD FOREIGN KEY (Creator_Person) REFERENCES develop.Person(Id);

/* Creación de la tabla permisos */
CREATE TABLE develop.Permit (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Name VARCHAR (50) NOT NULL,
    Code VARCHAR (10) NOT NULL,
	Description VARCHAR (100) NULL,
    Creation_Date DATETIME DEFAULT GETDATE(),	
	Creator_Person  INT NOT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
    FOREIGN KEY (Creator_Person) REFERENCES develop.Person (Id),
	FOREIGN KEY (Modifier_Person) REFERENCES develop.Person (Id),
	CONSTRAINT Registration_Status_Permit CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);

/* Creación de la tabla Roles */
CREATE TABLE develop.Role (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Name VARCHAR (50) NOT NULL,
    Code VARCHAR (10) NOT NULL,
	Description VARCHAR (100) NULL,
	Permit_Id INT NOT NULL,
    Creation_Date DATETIME DEFAULT GETDATE(),	
	Creator_Person  INT NOT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	FOREIGN KEY (Permit_Id) REFERENCES develop.Permit (Id),
    FOREIGN KEY (Creator_Person) REFERENCES develop.Person (Id),
	FOREIGN KEY (Modifier_Person) REFERENCES develop.Person (Id),
	CONSTRAINT Registration_Status_Role CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);

/* Creación de la tabla de los roles y sus permisos */
CREATE TABLE develop.Role_Permissions(
    Id INT PRIMARY KEY IDENTITY (1, 1),
	Role_Id INT NOT NULL,
	Permit_Id INT NOT NULL,
    Creation_Date DATETIME DEFAULT GETDATE(),	
	Creator_Person  INT NOT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	FOREIGN KEY (Role_Id) REFERENCES develop.Role (Id),
	FOREIGN KEY (Permit_Id) REFERENCES develop.Permit (Id),
    FOREIGN KEY (Creator_Person) REFERENCES develop.Person (Id),
	FOREIGN KEY (Modifier_Person) REFERENCES develop.Person (Id),
	CONSTRAINT Registration_Status_Role_Permissions CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);

/* Creación de la tabla Roles y personas */
CREATE TABLE develop.Role_Persons(
    Id INT PRIMARY KEY IDENTITY (1, 1),
	Role_Id INT NOT NULL,
	Person_Id INT NOT NULL,
    Creation_Date DATETIME DEFAULT GETDATE(),	
	Creator_Person  INT NOT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	FOREIGN KEY (Role_Id) REFERENCES develop.Role (Id),
	FOREIGN KEY (Person_Id) REFERENCES develop.Person (Id),
    FOREIGN KEY (Creator_Person) REFERENCES develop.Person (Id),
	FOREIGN KEY (Modifier_Person) REFERENCES develop.Person (Id),
	CONSTRAINT Registration_Status_Role_Persons CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);

/* Creación de la tabla para la correspondencia */
CREATE TABLE develop.Correspondence(
    Id INT PRIMARY KEY IDENTITY (1, 1),
	Description VARCHAR (100) NULL,	
	Consecutive VARCHAR(10) NOT NULL,
	Type_Correspondence VARCHAR(50) NOT NULL,
	Sender_Id INT NOT NULL,
	Addressee_Id INT NOT NULL,
    Creation_Date DATETIME DEFAULT GETDATE(),	
	Creator_Person  INT NOT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	FOREIGN KEY (Sender_Id) REFERENCES develop.Person (Id),
	FOREIGN KEY (Addressee_Id) REFERENCES develop.Person (Id),
    FOREIGN KEY (Creator_Person) REFERENCES develop.Person (Id),
	FOREIGN KEY (Modifier_Person) REFERENCES develop.Person (Id),
	CONSTRAINT Type_Correspondence CHECK (Type_Correspondence = 'Correspondencia interna' OR Type_Correspondence ='Correspondencia externa'),
	CONSTRAINT Registration_Status_Correspondence CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);

/* Creación de la tabla para los archivos de correspondencia */
CREATE TABLE develop.Correspondence_Files(
    Id INT PRIMARY KEY IDENTITY (1, 1),
	Name VARCHAR (100) NULL,	
	File_Type VARCHAR(20) NOT NULL,
	File_Path VARCHAR(250) NOT NULL,
	Correspondence_Id INT NOT NULL,	
    Creation_Date DATETIME DEFAULT GETDATE(),	
	Creator_Person  INT NOT NULL,	
	Modifier_Date DATETIME NULL,	
	Modifier_Person  INT NULL,	
    Registration_Status VARCHAR(20) NOT NULL DEFAULT 'Activo',
	FOREIGN KEY (Correspondence_Id) REFERENCES develop.Correspondence (Id),
    FOREIGN KEY (Creator_Person) REFERENCES develop.Person (Id),
	FOREIGN KEY (Modifier_Person) REFERENCES develop.Person (Id),
	CONSTRAINT Registration_Status_Correspondence_Files CHECK (Registration_Status = 'Activo' OR Registration_Status ='Inactivo')
);

/* Tabla para el control de errores en la base de datos */
CREATE TABLE develop.db_erros
         (ErrorID        INT IDENTITY(1, 1),
          UserName       VARCHAR(100),
          ErrorNumber    INT,
          ErrorState     INT,
          ErrorSeverity  INT,
          ErrorLine      INT,
          ErrorProcedure VARCHAR(MAX),
          ErrorMessage   VARCHAR(MAX),
          ErrorDateTime  DATETIME)
GO