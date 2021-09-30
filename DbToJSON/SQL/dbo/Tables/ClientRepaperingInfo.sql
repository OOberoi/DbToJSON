CREATE TABLE [dbo].[ClientRepaperingInfo] (
    [ID]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [PackageID]         NCHAR (50)     NULL,
    [ClientID]          NCHAR (10)     NULL,
    [PackageInstanceID] NCHAR (50)     NULL,
    [Comments]          NVARCHAR (250) NULL,
    [JSON]              NVARCHAR (MAX) NULL,
    [DateCreated]       DATETIME       NULL,
    [DateUpdated]       DATETIME       NULL,
    CONSTRAINT [PK_ClientRepaperingInfo] PRIMARY KEY CLUSTERED ([ID] ASC)
);

