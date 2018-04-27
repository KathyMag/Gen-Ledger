/****** Object:  Table [dbo].[GLCash]    Script Date: 4/27/2018 10:11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GLCash](
	[cash_id] [int] IDENTITY(1,1) NOT NULL,
	[trans_date] [date] NULL,
	[cashier_staff_id] [int] NULL,
	[full_name] [varchar](50) NULL,
	[dit] [decimal](10, 2) NULL,
	[cash] [decimal](10, 2) NULL,
	[check] [decimal](10, 2) NULL,
	[additional_deposit] [decimal](10, 2) NULL,
	[bank_deposit] [decimal](10, 2) NULL,
	[depository_bank] [varchar](50) NULL,
	[bank_date_validated] [date] NULL,
	[shortage] [decimal](10, 2) NULL,
	[day_count] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/27/2018 10:11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[staff_code] [varchar](50) NULL,
	[email_address] [varchar](50) NOT NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[is_active] [bit] NULL,
	[registration_date] [datetime] NOT NULL,
	[access_level] [int] NULL,
 CONSTRAINT [PK__System_U__3214EC07F6B61CA1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([id], [username], [password], [staff_code], [email_address], [firstname], [lastname], [is_active], [registration_date], [access_level]) VALUES (1, N'admin', N'aRttLn2xjy5IYXnWRaLkVg==', N'CSF1801386', N'kjmagracia@contis.ph', N'kathyc', N'asdf', 1, CAST(0x0000A87F00B9ACBC AS DateTime), 0)
GO
INSERT [dbo].[User] ([id], [username], [password], [staff_code], [email_address], [firstname], [lastname], [is_active], [registration_date], [access_level]) VALUES (2, N'test user', N'XjrmccCsy/0y2jGQCuuJlQ==', N'CSF1801387', N'kathy.magracia@gmail.com', N'kathyg', N'asdf1', 0, CAST(0x0000A89400AC126E AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_is_locked]  DEFAULT ((0)) FOR [is_active]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__System_Us__RegDa__2E1BDC42]  DEFAULT (getdate()) FOR [registration_date]
GO
/****** Object:  StoredProcedure [dbo].[GetDetails_NAVGLEntry]    Script Date: 4/27/2018 10:11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KJM
-- Create date: 2/22/2018
-- Description:	Get GL Entries from Accustom username based on date range
-- EXEC [GetDetails_NAVGLEntry] '11/01/2016', '11/30/2016'
-- =============================================
CREATE PROCEDURE [dbo].[GetDetails_NAVGLEntry]
	 @date_from as varchar(10)
	,@date_to as varchar(10)

AS
	BEGIN

		SET NOCOUNT ON;

		SELECT CONVERT(varchar(10), gle.[Posting Date], 101) as [Posting Date],
				gle.[Document Type],
				gle.[Document No_],
				gle.[G_L Account No_],
				gle.[Description],
				gla.[Name],
				CONVERT(DECIMAL(10,2),gle.[Amount]) as [Amount],
				CONVERT(DECIMAL(10,2),gle.[VAT Amount]) as [VAT Amount]
				--,'false' as [Exclude]
		FROM [NESDB2].[dbo].[ACC$G_L Entry] gle 
		INNER JOIN [NESDB2].[dbo].[ACC$G_L Account] gla ON gle.[G_L Account No_] = gla.[No_] 
		WHERE CONVERT(varchar(10), [Posting Date], 101) 
			BETWEEN CONVERT(varchar(10), @date_from, 101) 
			AND CONVERT(varchar(10), @date_to, 101) 
		--AND
		--	[ACC$G_L Entry] ('Accounts Receivable - Credit Cards','Accounts Receivable - EPS','Accounts Receivable - Corporate')
		AND [G_L Account No_] IN ('11201010','11201015','11201085')

		--corporate
		ORDER BY [Posting Date], gle.[Document No_],gle.[Amount]

	END

GO
/****** Object:  StoredProcedure [dbo].[GetDetails_UserName]    Script Date: 4/27/2018 10:11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KJM
-- Create date: 2/6/2018
-- Description:	Get username based on username
--EXEC [dbo].[GetDetails_UserName] 'admin'
-- =============================================
CREATE PROCEDURE [dbo].[GetDetails_UserName]
	 @username as varchar(50)
	--,@password as varchar(max)

AS
	BEGIN

		SET NOCOUNT ON;

		SELECT [id]
			  ,[username]
			  ,[password]
			  ,[staff_code]
			  ,[email_address]
			  ,[firstname]
			  ,[lastname]
			  ,[is_active]
			  ,[registration_date]
			  ,[access_level]
		FROM [dbo].[User] 
		WHERE [username] = @username --AND [password] = @password

	END


GO