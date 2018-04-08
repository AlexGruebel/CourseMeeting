CREATE TABLE [sec].[IdentityUserClaim]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserID] NVARCHAR(100) NULL,
	[ClaimType] NVARCHAR(100) NULL,
	[ClaimValue] NVARCHAR(100) NULL
)
