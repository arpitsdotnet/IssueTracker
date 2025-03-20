﻿CREATE TABLE [dbo].[sysSubCategories] (
    [SubcId]      SMALLINT         NOT NULL,
    [CateId]      INT              NOT NULL,
    [ClientUID]   UNIQUEIDENTIFIER NULL,
    [ActivatedYN] BIT              DEFAULT ((1)) NOT NULL,
    [RowStatus]   CHAR (1)         DEFAULT ('A') NOT NULL,
    [CreatedOn]   DATETIME         DEFAULT (getdate()) NOT NULL,
    [CreatorId]   INT              NOT NULL,
    [ModifiedOn]  DATETIME         NULL,
    [ModifierId]  INT              NULL,
    [SubcKey]     VARCHAR (10)     NOT NULL,
    [SubcTitle]   VARCHAR (20)     NOT NULL,
    [SubcIconUrl] VARCHAR (2000)   NULL,
    [SubcColour]  VARCHAR (10)     NULL,
    [SubcValue]   VARCHAR (2000)   NULL,
    PRIMARY KEY CLUSTERED ([CateId] ASC, [SubcId] ASC),
    CHECK ([RowStatus]='D' OR [RowStatus]='A' OR [RowStatus]='M')
);

