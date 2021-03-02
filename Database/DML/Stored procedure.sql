/* Procedimiento para el registro de la documentación */
CREATE PROCEDURE develop.Ins_Correspondence 
	(@Descripcion VARCHAR (100),
	 @Type_Correspondence VARCHAR(50),
	 @Sender_Id INT,
	 @Addressee_Id INT,
	 @Creator_Person INT,
	 @Id INT OUTPUT)
AS
BEGIN
	-- Declaración de variables SP
	BEGIN 
		DECLARE @number BIGINT;
		DECLARE @sequence VARCHAR(10);
	END
	-- Bloque para obtener el consecutivo de la correspondencia interna
	BEGIN 
		IF @Type_Correspondence = 'Correspondencia interna' 
			BEGIN
				SET @number = NEXT VALUE FOR develop.Internal_Documentation_Sequence;
				SET @sequence = RIGHT('CI0000000' +CAST(@number AS VARCHAR(10)), 10);
			END
		-- Bloque para obtener el consecutivo de la correspondencia externa
		ELSE
			BEGIN
				SET @number = NEXT VALUE FOR develop.Internal_Documentation_Sequence;
				SET @sequence = RIGHT('CE0000000' +CAST(@number AS VARCHAR(10)), 10);
			END
	END
	-- Bloque para inserción de registro
	BEGIN 
		INSERT INTO develop.Correspondence(Description, 
					 Consecutive, 
					 Type_Correspondence, 
					 Sender_Id, 
					 Addressee_Id, 
					 Creation_Date, 
					 Creator_Person)
		VALUES (@Descripcion,
				@sequence, 
				@Type_Correspondence, 
				@Sender_Id, 
				@Addressee_Id, 
				GETDATE(),
				@Creator_Person);
		SET @Id = SCOPE_IDENTITY();
	END
END;


DECLARE @Id int;
EXEC develop.Ins_Correspondence 'Descripcion de la correspondencia', 'Correspondencia interna', 1, 1,1, @Id output;
SELECT @Id;

/* Procedimiento para registrar la relación de los archivos de correspondencia */
CREATE PROCEDURE develop.Ins_Correspondence_Files
	(@Name VARCHAR (100),
	 @File_Type VARCHAR(20),
	 @File_Path VARCHAR(250),
	 @Correspondence_Id INT,
	 @Creator_Person INT,
	 @Id INT OUTPUT)
AS
BEGIN
	-- Bloque para inserción de registro
	BEGIN 
		INSERT INTO develop.Correspondence_Files(Name, 
					 File_Type, 
					 File_Path, 
					 Correspondence_Id, 
					 Creation_Date,
					 Creator_Person)
		VALUES (@Name,
				@File_Type, 
				@File_Path, 
				@Correspondence_Id, 
				GETDATE(),
				@Creator_Person);
		SET @Id = SCOPE_IDENTITY();
	END
END;

/* Procedimiento para registrar personas */
CREATE PROCEDURE develop.Ins_Person
	(@First_Name VARCHAR(50),
	 @Second_Name VARCHAR(50),
	 @Surname VARCHAR (50),
	 @Second_Surname VARCHAR(50),
     @Birth_Date DATETIME,
	 @Document_Type_Id INT,
	 @Document_Number VARCHAR(20),
	 @Phone_Number VARCHAR(15),
	 @Email VARCHAR(50),	
	 @Creator_Person INT,	
	 @Id INT OUTPUT)
AS
BEGIN
	-- Bloque para inserción de registro
	BEGIN 
		BEGIN TRY
			INSERT INTO develop.Person 
				(First_Name,
				Second_Name,
				Surname,
				Second_Surname,
				Birth_Date,
				Document_Type_Id,
				Document_Number,
				Phone_Number,
				Email,
				Creation_Date,
				Creator_Person)		 
			VALUES(@First_Name,
				   @Second_Name,
				   @Surname,
				   @Second_Surname,
				   @Birth_Date,
				   @Document_Type_Id,
				   @Document_Number,
				   @Phone_Number,
				   @Email,
				   GETDATE(),
				   @Creator_Person);
				   SET @Id = SCOPE_IDENTITY();
		  END TRY
		  BEGIN CATCH
			INSERT INTO dbo.DB_Errors
			VALUES
		  (@Creator_Person,
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE());
		  END CATCH
	END
END;