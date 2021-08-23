USE CommanderApi;
GO
CREATE PROCEDURE GetCommandById @Id INT
AS
SELECT * FROM Command WHERE CommandId = @Id;
GO
