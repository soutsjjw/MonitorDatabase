
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfos]') AND type in (N'U'))
DROP TABLE [dbo].[UserInfos]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserInfos](
	[Uid] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Tel] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[Area] [varchar](50) NULL,
	[ImageUrl] [varchar](50) NULL,
	[Remake] [varchar](50) NULL,
	[CreateTime] [datetime] NULL
) ON [PRIMARY]
GO


INSERT dbo.UserInfos VALUES (1, N'AAA', '1', '1', '1', '1', '1', '20210812 18:18:01:953')
INSERT dbo.UserInfos VALUES (2, N'BBB', '1', '1', '1', '1', '1', '20210812 18:18:03:430')
INSERT dbo.UserInfos VALUES (3, N'CCC', '1', '1', '1', '1', '1', '20210812 18:18:05:090')
INSERT dbo.UserInfos VALUES (4, N'DDD', '1', '1', '1', '1', '1', '20210812 18:18:06:373')
INSERT dbo.UserInfos VALUES (5, N'EEE', '1', '1', '1', '1', '1', '20210812 18:18:07:627')
INSERT dbo.UserInfos VALUES (6, N'FFF', '1', '1', '1', '1', '1', '20210812 18:18:08:830')
INSERT dbo.UserInfos VALUES (7, N'GGG', '1', '1', '1', '1', '1', '20210812 18:18:16:660')
INSERT dbo.UserInfos VALUES (8, N'HHH', '1', '1', '1', '1', '1', '20210812 18:18:19:437')
