
/****** Object:  Database [WeiXinDB]    Script Date: 11/18/2015 10:44:24 ******/
CREATE DATABASE [WeiXinDB] ON  PRIMARY 
( NAME = N'WeiXinDB', FILENAME = N'E:\zxl0715\MyProject\ZXL.WeiXin\ZXL.WeiXinWeb\App_Data\WeiXinDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WeiXinDB_log', FILENAME = N'E:\zxl0715\MyProject\ZXL.WeiXin\ZXL.WeiXinWeb\App_Data\WeiXinDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [WeiXinDB]
GO
 

CREATE TABLE [dbo].[SysSample](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
	[Bir] [datetime] NULL,
	[Photo] [varchar](50) NULL,
	[Note] [text] NULL,
	[CreateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSample', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSample', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSample', @level2type=N'COLUMN',@level2name=N'Age'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSample', @level2type=N'COLUMN',@level2name=N'Bir'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSample', @level2type=N'COLUMN',@level2name=N'Photo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSample', @level2type=N'COLUMN',@level2name=N'Note'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSample', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO




INSERT INTO [dbo].[SysSample]([Id],[Name],[Age],[Bir],[Photo],[Note],[CreateTime])
VALUES ('10001' ,'张三' ,18 ,'1985-02-05',13777777770 ,'无' ,GETDATE())
GO
INSERT INTO [dbo].[SysSample]([Id],[Name],[Age],[Bir],[Photo],[Note],[CreateTime])
VALUES ('10002' ,'李四' ,20 ,'1985-02-05',13777777771 ,'无' ,GETDATE())
GO
INSERT INTO [dbo].[SysSample]([Id],[Name],[Age],[Bir],[Photo],[Note],[CreateTime])
VALUES ('10003' ,'王五' ,16,'1985-02-05',13777777772 ,'无' ,GETDATE())
GO
INSERT INTO [dbo].[SysSample]([Id],[Name],[Age],[Bir],[Photo],[Note],[CreateTime])
VALUES ('10004' ,'陈米哦' ,41 ,'1985-02-05',13777777773 ,'无' ,GETDATE())
GO
INSERT INTO [dbo].[SysSample]([Id],[Name],[Age],[Bir],[Photo],[Note],[CreateTime])
VALUES ('10005' ,'巍峨' ,26 ,'1985-02-05',13777777774 ,'无' ,GETDATE())
GO