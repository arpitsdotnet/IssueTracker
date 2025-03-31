CREATE TABLE [dbo].[mstProjects] (
    [ProjId]                INT              IDENTITY (1, 1) NOT NULL,
    [ClientUID]             UNIQUEIDENTIFIER NULL,
    [RowStatus]             CHAR (1)         DEFAULT ('A') NOT NULL,
    [SysDate]               DATETIME         DEFAULT (getdate()) NOT NULL,
    [CreatedOn]             DATETIME         NOT NULL,
    [CreatorId]             INT              NOT NULL,
    [ModifiedOn]            DATETIME         NULL,
    [ModifierId]            INT              NULL,
    [ProjKey]               VARCHAR (10)     NOT NULL,
    [ProjTitle]             VARCHAR (20)     NOT NULL,
    [ProjIconUrl]           VARCHAR (2000)   NULL,
    [ProjStatus]            CHAR (1)         DEFAULT ('N') NOT NULL,
    [ProjCategoryId]        SMALLINT         NULL,
    [ProjTemplateId]        SMALLINT         NULL,
    [ProjTypeId]            SMALLINT         NULL,
    [ProjManagerId]         INT              NULL,
    [ProjDefaultAssigneeId] INT              NULL,
    PRIMARY KEY CLUSTERED ([ProjId] ASC),
    CHECK ([ProjStatus]='C' OR [ProjStatus]='B' OR [ProjStatus]='I' OR [ProjStatus]='N'),
    CHECK ([RowStatus]='A' OR [RowStatus]='M' OR [RowStatus]='D')
);

