/****** Object:  Table [dbo].[widgets]    Script Date: 06/07/2013 16:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[widgets](
	[widget_id] [int] IDENTITY(1,1) NOT NULL,
	[widget_name] [nvarchar](50) NOT NULL,
	[widget_text] [nvarchar](50) NULL,
	[widget_code] [nvarchar](max) NULL,
	[widget_type] [nvarchar](50) NULL,
 CONSTRAINT [PK_widgets_2] PRIMARY KEY CLUSTERED 
(
	[widget_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 06/07/2013 16:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](max) NOT NULL,
	[user_pass] [nvarchar](max) NOT NULL,
	[user_session] [nvarchar](max) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uploads]    Script Date: 06/07/2013 16:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uploads](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[filepath] [nvarchar](max) NOT NULL,
	[album] [nvarchar](50) NULL,
	[alt] [nvarchar](50) NULL,
 CONSTRAINT [PK_uploads2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[settings]    Script Date: 06/07/2013 16:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[settings](
	[settings_id] [int] NOT NULL,
	[current_theme] [nvarchar](50) NOT NULL,
	[block_sidebar] [int] NOT NULL,
	[block_toolbar] [int] NOT NULL,
	[block_footer] [int] NOT NULL,
	[sidebar_code] [nvarchar](max) NULL,
	[toolbar_code] [nvarchar](max) NULL,
	[footer_code] [nvarchar](max) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[settings] ([settings_id], [current_theme], [block_sidebar], [block_toolbar], [block_footer], [sidebar_code], [toolbar_code], [footer_code]) VALUES (1, N'ajaxy', 1, 0, 0, N'<div class="content-box" style="">
<h2 style="">Welcome to <span style="">MYNX</span>.</h2>

<p style="">MYNX is a <b style="">user-experience focused</b>, <b style="">responsive</b> and <b style="">flexible</b> open-source Content Management System for ASP.Net and C#.</p>

</div>', N'', N'')
/****** Object:  Table [dbo].[pages]    Script Date: 06/07/2013 16:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[slug] [nvarchar](50) NOT NULL,
	[text] [nvarchar](max) NULL,
	[cat] [nvarchar](50) NULL,
	[meta_desc] [nvarchar](max) NULL,
	[meta_keys] [nvarchar](max) NULL,
	[date_published] [datetime] NOT NULL,
	[date_updated] [datetime] NOT NULL,
	[active] [int] NOT NULL,
	[published] [int] NOT NULL,
 CONSTRAINT [PK_pages1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[pages] ON
INSERT [dbo].[pages] ([id], [title], [slug], [text], [cat], [date_published], [date_updated], [active], [published]) VALUES (1, N'Home', N'home', N'

		<div class="content-box resizable movable edit-col col col-100 ui-sortable"><div class="clearfix"></div><div class="col html-col movable resizable edit-col col-66"><h2>Welcome to <span>MYNX</span></h2></div><div class="clearfix"></div><div class="col html-col movable resizable edit-col col-100"><p>To get started, log in with the Username and Password you set during installation <a href="/admin/" class="external">here</a>. The admin area exists at ''yoursite.com/admin/'' - remember this! From here, you can edit every page (start by editing this one), upload images, change the theme and layout, and insert widgets into your pages.</p>

<p>More themes and widgets are available <del><a href="http://mynx.net/extensions/">on the MYNX website</a></del>. You can also download the source code and create your own themes and widgets, then upload them for others to use (or not, if you don''t feel like it!).</p>

<p>So get started! Have fun with MYNX, the <b>user-focused</b> CMS.</p></div><div class="clearfix"></div></div>

	', N'Homepage', '20130701', '20130701', 1, 0)
INSERT [dbo].[pages] ([id], [title], [slug], [text], [cat], [date_published], [date_updated], [active], [published]) VALUES (2, N'404 Not Found', N'404', N'

	<div class="content-box resizable movable edit-col col col-100"><div class="clearfix"></div><div class="col html-col movable resizable edit-col col-75"><h2><span style="font-size: 36px; line-height: 40px;"><b>404 Not Found</b></span></h2></div><div class="col html-col movable resizable edit-col col-100"><p>Terribly sorry about that. By the way, you are looking at the default MYNX 404 page. You can edit this as you would any other page in the MYNX admin!</p></div><div class="clearfix"></div></div>

	', N'Errors', '20130701', '20130701', 1, 0)
SET IDENTITY_INSERT [dbo].[pages] OFF
