select * from Events;

DECLARE @UNIQUEX UNIQUEIDENTIFIER
SET @UNIQUEX = NEWID();

--insert into Events 
--VALUES (@UNIQUEX, 'Meeting', 'Some description', CONVERT(datetime,'Sep 09 12:18:52 2021'))