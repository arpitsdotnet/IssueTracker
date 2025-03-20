CREATE TABLE [dbo].[sysCategories] (
    [CateId]      INT              IDENTITY (1, 1) NOT NULL,
    [ClientUID]   UNIQUEIDENTIFIER NULL,
    [RowStatus]   CHAR (1)         DEFAULT ('A') NOT NULL,
    [CreatedOn]   DATETIME         DEFAULT (getdate()) NOT NULL,
    [CreatorId]   INT              NOT NULL,
    [ModifiedOn]  DATETIME         NULL,
    [ModifierId]  INT              NULL,
    [CateKey]     VARCHAR (10)     NOT NULL,
    [CateTitle]   VARCHAR (20)     NOT NULL,
    [CateIconUrl] VARCHAR (2000)   NULL,
    PRIMARY KEY CLUSTERED ([CateId] ASC),
    CHECK ([RowStatus]='A' OR [RowStatus]='M' OR [RowStatus]='D')
);

