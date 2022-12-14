USE [OnlineTest]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 8/21/2022 1:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Answer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Answer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NOT NULL,
	[Answer] [nvarchar](500) NOT NULL,
	[IsCorrect] [bit] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Question]    Script Date: 8/21/2022 1:09:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Question](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/21/2022 1:09:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Mobile] [nchar](15) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UsersAnswer]    Script Date: 8/21/2022 1:09:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersAnswer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsersAnswer](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerID] [int] NULL,
 CONSTRAINT [PK_UsersAnswer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (2, 1, N'अरण्यकाण्ड', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (3, 1, N'किष्किंधा काण्ड
', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (4, 1, N'सुन्दरकाण्ड', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (5, 1, N'अयोध्याकाण्ड', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (6, 2, N'शिवजी की', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (7, 2, N'रामजी की', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (8, 2, N'सीता माता की', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (9, 2, N'इनमें सभी सही है|', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (10, 3, N'राम जी
', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (11, 3, N'लक्ष्मण जी
', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (12, 3, N'जाम्बवंत जी
', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (13, 3, N'इनमें से कोई भी नहीं |
', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (14, 4, N'4 बार', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (15, 4, N'3 बार', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (16, 4, N'2 बार', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (17, 4, N'1 बार', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (18, 5, N'नील', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (20, 5, N'नल', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (21, 5, N'राम जी
', 0)
INSERT [dbo].[Answer] ([ID], [QuestionID], [Answer], [IsCorrect]) VALUES (22, 5, N'नील-नल
', 0)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([ID], [Question]) VALUES (1, N'रामचरित मानस में हनुमानजी का प्रवेश हुआ|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (2, N'सुन्दरकाण्ड के प्रथम श्लोक में हनुमानजी वंदना करते है|')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (3, N'हनुमान जी को सीता जी का पता लगाने के लिए किसने सबसे पहले कहा-
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (4, N'सुन्दरकाण्ड में हनुमानजी सीता जी से कितनी बार मिले|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (5, N'किनके स्पर्श करने से पत्थर भी समुद्र में तैरने लग गये|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (6, N'किनका गुणगान करने से बिना जहाज के भी भवसागर को पार कर लेंगे|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (7, N'अगर मंत्री लाभ की आशा से हित की बात नहीं बोलकर प्रिय बोलते हैं तो नुकसान होता है|')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (8, N'धर्म का नुकसान होता है|')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (9, N'हनुमानजी में विद्यमान है|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (10, N'सुन्दरकाण्ड में इनमें से किनको मारा गया|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (11, N'हनुमान जी को लंका जाते समय सबसे पहले कौन मिला')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (12, N'जब सुरसा ने सोलह योजन का मुख किया तो हनुमान जी कितने योजन के हो गये|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (13, N'सुरसा को हनुमान जी के पास किसने भेजा था?
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (14, N'जब प्रथम बार हनुमान जी विभीषण से मिले तो रूप धारण किया|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (15, N'जब अशोक वन में रावण सीता जी को मरने दौड़ा तो सीता जी को बचाया|
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (16, N'त्रिजटा को स्वप्न आया कि-
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (17, N'हनुमान जी में इतनी शक्ति थी कि वे सीता जी को रामजी के पास ले जाते| पर क्यों नहीं ले गए -')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (18, N'अंगुठी पर नाम अंकित था -
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (19, N'जब हनुमान जी ने अशोक वाटिका को उजाड़ा तो रावण ने सबसे पहले भेजा
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (20, N'हनुमान जी नागपाश में बंध गए क्योंकि -
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (21, N'दूत को मारना नहीं चाहिए| यह नीति के विरुद्ध है| यह बात किसने कही - ')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (22, N'हनुमान जी अग्नि से नहीं जले क्योंकि  - ')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (23, N'लंका ही एक ऐसा देश है जिनके नाम के पहले श्री लगता है
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (24, N'चूड़ामणि को रामजी ने लगाया -
')
INSERT [dbo].[Question] ([ID], [Question]) VALUES (25, N'हनुमान जी अपने सभी कार्यों का श्रेय देते थे')
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [Email], [Mobile], [Address], [State], [Country], [CreatedDate]) VALUES (1, N'Ankit', N'ankit@gmail.com', N'9876543210     ', N'Gujrat', N'Gujrat', N'India', CAST(N'2022-08-19T10:34:23.550' AS DateTime))
INSERT [dbo].[Users] ([ID], [Name], [Email], [Mobile], [Address], [State], [Country], [CreatedDate]) VALUES (3, N'avinya', N'avinya@gmail.com', N'1234567890     ', N'Surat', N'Gujrat', N'IN', CAST(N'2022-08-21T07:12:08.080' AS DateTime))
INSERT [dbo].[Users] ([ID], [Name], [Email], [Mobile], [Address], [State], [Country], [CreatedDate]) VALUES (4, N'anant', N'anant@gmail.com', N'9874562130     ', N'Mumbai', N'Gujrat', N'IN', CAST(N'2022-08-21T07:22:45.823' AS DateTime))
INSERT [dbo].[Users] ([ID], [Name], [Email], [Mobile], [Address], [State], [Country], [CreatedDate]) VALUES (5, N'Anand', N'anand@gmail.com', N'7838367740     ', N'Surat', N'Gujrat', N'IN', CAST(N'2022-08-21T07:49:50.610' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Answer_Question]') AND parent_object_id = OBJECT_ID(N'[dbo].[Answer]'))
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Answer_Question]') AND parent_object_id = OBJECT_ID(N'[dbo].[Answer]'))
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersAnswer_Answer]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsersAnswer]'))
ALTER TABLE [dbo].[UsersAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UsersAnswer_Answer] FOREIGN KEY([AnswerID])
REFERENCES [dbo].[Answer] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersAnswer_Answer]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsersAnswer]'))
ALTER TABLE [dbo].[UsersAnswer] CHECK CONSTRAINT [FK_UsersAnswer_Answer]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersAnswer_Question]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsersAnswer]'))
ALTER TABLE [dbo].[UsersAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UsersAnswer_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersAnswer_Question]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsersAnswer]'))
ALTER TABLE [dbo].[UsersAnswer] CHECK CONSTRAINT [FK_UsersAnswer_Question]
GO
