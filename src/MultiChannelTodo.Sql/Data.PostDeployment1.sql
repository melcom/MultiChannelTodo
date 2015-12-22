/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DELETE [TodoItems] WHERE Id = '50DF07C4-A769-4084-BA5B-F4F5FBF28688'
INSERT INTO [TodoItems] VALUES ('50DF07C4-A769-4084-BA5B-F4F5FBF28688','Create ARM Template',0,'2015-12-22 22:05:51.6021448 +00:00','2015-12-22 22:05:51.6021448 +00:00')

DELETE [TodoItems] WHERE Id = '585A4B75-CB85-44E8-BF50-B49AB6965632'
INSERT INTO [TodoItems] VALUES ('585A4B75-CB85-44E8-BF50-B49AB6965632','Publish to Azure',0,'2015-12-22 22:05:51.6021448 +00:00','2015-12-22 22:05:51.6021448 +00:00')

DELETE [TodoItems] WHERE Id = '6DF176EA-E0D4-4C04-ABFA-8533CB4680CE'
INSERT INTO [TodoItems] VALUES ('6DF176EA-E0D4-4C04-ABFA-8533CB4680CE','Build Sample',0,'2015-12-22 22:05:51.6021448 +00:00','2015-12-22 22:05:51.6021448 +00:00')

DELETE [TodoItems] WHERE Id = 'A23A2F75-CC52-4F1A-B459-4F8AB019CB4D'
INSERT INTO [TodoItems] VALUES ('A23A2F75-CC52-4F1A-B459-4F8AB019CB4D','Make Money',0,'2015-12-22 22:05:51.6021448 +00:00','2015-12-22 22:05:51.6021448 +00:00')