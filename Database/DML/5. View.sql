CREATE VIEW develop.view_correspondence
AS
SELECT	c.Description, c.Consecutive, c.Type_Correspondence, ps.First_Name + ' ' + ps.Surname AS 'Sender', 
		pa.First_Name + ' ' + pa.Surname AS 'Addressee', c.Creation_Date AS 'Reception date',
		cf.Name AS 'File name', cf.File_Path AS 'File'
FROM develop.Correspondence c
INNER JOIN develop.Correspondence_Files cf
	ON c.Id = cf.Correspondence_Id 
INNER JOIN develop.Person ps 
	ON ps.Id = c.Sender_Id
INNER JOIN develop.Person pa
	ON pa.Id = c.Addressee_Id
	AND c.Registration_Status = 'Activo'
	AND cf.Registration_Status = 'Activo'
	AND ps.Registration_Status = 'Activo'
	AND pa.Registration_Status = 'Activo';