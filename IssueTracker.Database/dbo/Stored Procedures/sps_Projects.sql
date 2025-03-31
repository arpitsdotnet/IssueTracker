
CREATE PROCEDURE [dbo].[sps_Projects](
@ProjectId int=0,@ProjectManagerId int=0,
@PageNo int=1,@PageSize smallint=1000,
@ClientUID uniqueidentifier, @SessionUID uniqueidentifier,
@R_Success tinyint out,@R_Message varchar(1000) out,@R_Data bigint out) AS
BEGIN
	SET NOCOUNT ON;

	SET @R_Success = 1
	SET @R_Message = 'SUCCESS'

	DECLARE @Tbl AS TABLE (RowIndex INT, ProjId Int)

	INSERT INTO @Tbl(RowIndex, ProjId)
	SELECT ROW_NUMBER() OVER (ORDER BY a.SysDate DESC) RowIndex,a.ProjId
	FROM [dbo].[mstProjects] a
	WHERE a.RowStatus<>'D' AND a.ClientUID = @ClientUID
		AND (@ProjectId = 0 OR a.ProjId = @ProjectId)
		AND (@ProjectManagerId = 0 OR a.ProjManagerId = @ProjectManagerId)
		
	SET @R_Data = ISNULL((SELECT COUNT(0) FROM @Tbl),0)



	SELECT a.ProjId,a.ProjKey,a.ProjTitle,a.ProjIconUrl,
		a.ProjCategoryId,a.ProjTemplateId,a.ProjTypeId,
		a.ProjManagerId,a.ProjDefaultAssigneeId,
		'' ClientName,'' ContactName,
		'' ContactNumber,'' ContactEmail,a.ProjStatus,
		ISNULL(a.CreatedOn,'') CreatedOn,a.CreatorId,'' CreatorName,
		ISNULL(a.ModifiedOn,'') ModifiedOn,a.ModifierId,'' ModifierName
	FROM [dbo].[mstProjects] a
		INNER JOIN @Tbl b ON a.ProjId = b.ProjId
		--LEFT JOIN [dbo].[Clients] c ON c.ClientUID = p.ClientUID
		--LEFT JOIN [dbo].[Users] uc ON p.CreatedById = uc.UserId
		--LEFT JOIN [dbo].[Users] um ON p.LastModifiedById = um.UserId

END
