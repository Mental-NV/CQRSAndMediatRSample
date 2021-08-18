USE [TodoDB]
GO

CREATE TABLE [dbo].[TodoList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsComplete] [bit] NOT NULL,
  CONSTRAINT [PK_TodoList] PRIMARY KEY CLUSTERED 
  (
	[Id] ASC
  )
) 
GO

ALTER TABLE [dbo].[TodoList] ADD  CONSTRAINT [DF_TodoList_IsComplete]  DEFAULT ((0)) FOR [IsComplete]
GO