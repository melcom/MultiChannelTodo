CREATE TABLE [TodoItems](
	[Id] [nvarchar](128) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Complete] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NULL,
	[UpdatedAt] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TodoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF))