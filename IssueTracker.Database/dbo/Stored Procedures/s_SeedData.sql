TRUNCATE TABLE [dbo].[sysCategories]
TRUNCATE TABLE [dbo].[sysSubCategories]


SET IDENTITY_INSERT [dbo].[sysCategories] ON
GO

INSERT INTO [dbo].[sysCategories] ([CateId],[CreatorId],[CateKey],[CateTitle])VALUES
(1,1,'ROWSTATUS','Row status'),
(2,1,'PROJSTUS','Project status'),
(3,1,'PROJTYPE','Project type'),
(4,1,'PROJCTGR','Project category'),
(5,1,'PROJTMPL','Project template'),
(6,1,'ISSUSTUS','Issue status'),
(7,1,'ISSUTYPE','Issue type'),
(8,1,'ISSUPRIRT','Issue priority')
GO

SET IDENTITY_INSERT [dbo].[sysCategories] OFF
GO

SET IDENTITY_INSERT [dbo].[sysSubCategories] ON
GO

--ROWSTATUS
INSERT INTO [dbo].[sysSubCategories] ([SubcId],[CateId],[CreatorId],[SubcKey],[SubcTitle])VALUES
(1,1,1,'A','APPROVED'),
(2,1,1,'M','MODIFIED'),
(3,1,1,'D','DELETED')

--PROJSTUS
INSERT INTO [dbo].[sysSubCategories] ([SubcId],[CateId],[CreatorId],[SubcKey],[SubcTitle])VALUES
(4,2,1,'N','NEW'),
(5,2,1,'I','IN-PROGRESS'),
(6,2,1,'B','BLOCKED'),
(7,2,1,'C','COMPLETED')

--PROJTYPE
INSERT INTO [dbo].[sysSubCategories] ([SubcId],[CateId],[CreatorId],[SubcKey],[SubcTitle])VALUES
(8,3,1,'TEAM','Team-managed'),
(9,3,1,'Company','Company-managed')

--PROJCTGR
INSERT INTO [dbo].[sysSubCategories] ([SubcId],[CateId],[CreatorId],[SubcKey],[SubcTitle])VALUES
(10,4,1,'SOFTMGMT','Software management'),
(11,4,1,'SRVCMGMT','Service management'),
(12,4,1,'WORKMGMT','Work management'),
(13,4,1,'MRKTING','Marketing'),
(14,4,1,'HUMNRSRC','Human resource'),
(15,4,1,'FINANCE','Finance'),
(16,4,1,'DESIGN','Design'),
(17,4,1,'PERSONAL','Personal'),
(18,4,1,'OPRTONS','Operations'),
(19,4,1,'LEGAL','Legal'),
(20,4,1,'SALES','Sales')
GO

--PROJTMPL
INSERT INTO [dbo].[sysSubCategories] ([SubcId],[CateId],[CreatorId],[SubcKey],[SubcTitle])VALUES
(21,5,1,'SCRUM','Scrum'),
(22,5,1,'KANBAN','Kanban'),
(23,5,1,'BUGTRK','Bug tracking')
GO

SET IDENTITY_INSERT [dbo].[sysSubCategories] OFF
GO