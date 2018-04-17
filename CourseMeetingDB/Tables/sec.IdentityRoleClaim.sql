create table [sec].[IdentityRoleClaim](
    Id [int] Primary Key,
    RoleID [varchar](100),
    ClaimType [varchar](100),
    ClaimValue [varchar](100)
)