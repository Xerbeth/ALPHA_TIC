/* Trigger para cuando se lancen delete sobre la tabla Correspondence */
CREATE TRIGGER Trigger_Delete_Correspondence
ON develop.Correspondence
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO develop.AuditData
        SELECT *, 
                GETDATE(), 
                'Delete'
        FROM deleted;
END;

/* Trigger para cuando se lancen update sobre la tabla Correspondence */
CREATE TRIGGER Trigger_Update_Correspondence
ON develop.Correspondence
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO develop.AuditData
        SELECT *, 
                GETDATE(), 
                'Before Update'
        FROM deleted;
    INSERT INTO develop.AuditData
        SELECT *, 
                GETDATE(), 
                'After Update'
        FROM inserted;
END;
GO

/* Trigger para cuando se lancen insert sobre la tabla Correspondence */
CREATE TRIGGER Trigger_Insert_Correspondence
 ON develop.Correspondence
AFTER INSERT
AS
     BEGIN
         SET NOCOUNT ON;
         INSERT INTO develop.AuditData
                SELECT *, 
                       GETDATE(), 
                       'Insert'
                FROM inserted;
     END;
GO