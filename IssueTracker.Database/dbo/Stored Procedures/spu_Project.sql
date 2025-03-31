
CREATE PROCEDURE [dbo].[spu_Project](@ProjId int=0, 
@ProjKey varchar(10), @ProjTitle varchar(20), @ProjIconUrl varchar(2000), 
@ProjStatus char(1), @ProjCategoryId smallint, @ProjTemplateId smallint, 
@ProjTypeId smallint, @ProjManagerId int, @ProjDefaultAssigneeId int, 
@ClientUID uniqueidentifier,  @SessionUID uniqueidentifier, 
@R_Success tinyint out, @R_Message varchar(1000) out, @R_Data bigint out) AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SET @R_Success = 1
	SET @R_Message = 'SUCCESS'

	DECLARE @LoginId INT=1
	
	IF EXISTS(SELECT * FROM [dbo].[mstProjects] WHERE RowStatus <> 'D' 
		AND ClientUID = @ClientUID AND ProjId <> @ProjId AND ProjKey = @ProjKey)
	BEGIN
		SET @R_Success = 0
		SET @R_Message = 'Oops! Duplicate project key found, please choose different key.'
		RETURN;
	END

    IF(@ProjId = 0)
	BEGIN		
		INSERT INTO [dbo].[mstProjects]
           (ClientUID, RowStatus, CreatedOn, CreatorId,
		   ProjKey, ProjTitle, ProjIconUrl, ProjStatus, ProjCategoryId,
		   ProjTemplateId, ProjTypeId, ProjManagerId, ProjDefaultAssigneeId)
		VALUES
			(@ClientUID, 'A', GETDATE(), @LoginId,
			@ProjKey, @ProjTitle, @ProjIconUrl, @ProjStatus, @ProjCategoryId,
			@ProjTemplateId, @ProjTypeId, @ProjManagerId, @ProjDefaultAssigneeId)
			
		SET @R_Data = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		UPDATE [dbo].[mstProjects]
		SET RowStatus = 'M', ModifiedOn = GETDATE(), ModifierId = @LoginId,
			ProjKey = @ProjKey, ProjTitle = @ProjTitle, ProjIconUrl = @ProjIconUrl,
			ProjStatus = @ProjStatus, ProjCategoryId = @ProjCategoryId,
			ProjTemplateId = @ProjTemplateId, ProjTypeId = @ProjTypeId,
			ProjManagerId = @ProjManagerId, ProjDefaultAssigneeId = @ProjDefaultAssigneeId
		WHERE ProjId = @ProjId
		
		SET @R_Data = @ProjId
	END
END
GO
