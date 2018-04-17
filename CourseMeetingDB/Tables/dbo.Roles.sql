﻿CREATE TABLE [sec].[Roles](
	[RID] [varchar](100) NOT NULL,
	[RName] [nvarchar](20) NOT NULL,
	[NormalizedName] [nvarchar](20) NOT NULL,
	[ConcurrencyStamp] text null,
	[RDescription] [nvarchar](100) NULL
) ON [PRIMARY]

GO
ALTER TABLE [sec].[Roles] ADD PRIMARY KEY CLUSTERED 
(
	[RID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
