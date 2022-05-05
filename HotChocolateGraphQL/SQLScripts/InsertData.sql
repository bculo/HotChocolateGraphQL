-- DUMMY DATA

-- INSERT INTO Platfomrs TABLE
INSERT INTO Platforms VALUES('.NET 5', NULL);
INSERT INTO Platforms VALUES('Docker', NULL);
INSERT INTO Platforms VALUES('Windows', '789879798798787');

-- INSERT INTO COMMANDS TABLE
INSERT INTO [dbo].[Commands]([HowTo], [CommandLine], [PlatformId]) VALUES('How To 1', 'Command 1', 1);
INSERT INTO [dbo].[Commands]([HowTo], [CommandLine], [PlatformId]) VALUES('How To 2', 'Command 2', 1);
INSERT INTO [dbo].[Commands]([HowTo], [CommandLine], [PlatformId]) VALUES('How To 3', 'Command 3', 2);
INSERT INTO [dbo].[Commands]([HowTo], [CommandLine], [PlatformId]) VALUES('How To 4', 'Command 4', 3);
INSERT INTO [dbo].[Commands]([HowTo], [CommandLine], [PlatformId]) VALUES('How To 5', 'Command 5', 2);