USE CommanderApi;
GO
CREATE TABLE [Command] (
  [CommandId] INT IDENTITY(1,1),
  [HowTo] VARCHAR(128),
  [Line] VARCHAR(128),
  [Platfrom] VARCHAR(128),
  PRIMARY KEY ([CommandId])
);
GO
