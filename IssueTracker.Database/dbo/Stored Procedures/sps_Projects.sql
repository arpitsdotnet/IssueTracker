
CREATE PROCEDURE [dbo].[sps_Projects](
@ProjectId int=0,@ProjectManagerId int=0,
@PageNo int=1,@PageSize smallint=1000,
@ClientUID uniqueidentifier, @SessionUID uniqueidentifier,
@R_RecordCount int out,@R_Success tinyint out,@R_Message varchar(1000) out) AS
BEGIN
	SET NOCOUNT ON;

	SET @R_Success = 1
	SET @R_Message = 'SUCCESS'

	SELECT ProjId,ProjKey,ProjTitle,ProjIconUrl,ProjCategoryId,ProjTemplateId,
		ProjTypeId,ProjManagerId,ProjDefaultAssigneeId,'' ClientName,'' ContactName,
		'' ContactNumber,'' ContactEmail,ProjStatus,
		ISNULL(CreatedOn,'') CreatedOn,CreatedById,'' CreatedByName,
		ISNULL(LastModifiedOn,'') LastModifiedOn,LastModifiedById,'' LastModifiedBy
	FROM [dbo].[Projects] p
		--LEFT JOIN [dbo].[Clients] c ON c.ClientUID = p.ClientUID
		--LEFT JOIN [dbo].[Users] uc ON p.CreatedById = uc.UserId
		--LEFT JOIN [dbo].[Users] um ON p.LastModifiedById = um.UserId
	WHERE ClientUID = @ClientUID
		AND (@ProjectId = 0 OR ProjId = @ProjectId)

	SET @R_RecordCount = @@ROWCOUNT
END
