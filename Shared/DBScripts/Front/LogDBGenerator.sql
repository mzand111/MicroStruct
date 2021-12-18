
    CREATE TABLE [dbo].[Log](  
        [Id] [int] IDENTITY(1,1) NOT NULL,  
        [Message] [nvarchar](max) NULL,  
        [MessageTemplate] [nvarchar](max) NULL,  
        [Level] [nvarchar](128) NULL,  
        [TimeStamp] [datetimeoffset](7) NOT NULL,  
        [Exception] [nvarchar](max) NULL,  
        [Properties] [xml] NULL,  
        [LogEvent] [nvarchar](max) NULL,  
        [UserName] [nvarchar](200) NULL,  
        [IP] [varchar](200) NULL,  
        [SystemActionId] [int],
        [UserActionId] [int]
     CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED   
    (  
        [Id] ASC  
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  