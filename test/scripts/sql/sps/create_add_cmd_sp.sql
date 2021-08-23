USE CommanderApi;
GO
CREATE PROCEDURE AddCommand
@HowTo VARCHAR(128),
@Line VARCHAR(128),
@Platfrom VARCHAR(128)
AS
INSERT INTO Command (HowTo, Line, Platfrom)
VALUES (@HowTo, @Line, @Platfrom);
SELECT SCOPE_IDENTITY() AS NewId;
GO
