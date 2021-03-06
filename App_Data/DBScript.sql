USE [DoxSolution]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 11/18/2016 2:48:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserProfileID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[GP_COMN_ExecSQL]    Script Date: 11/18/2016 2:48:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GP_COMN_ExecSQL]
(@SQL nvarchar(max))
AS
	exec(@SQL);
RETURN

GO
