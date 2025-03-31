CREATE PROCEDURE [dbo].[sps_SubCategories](
@CategoryId int=0,@CategoryKey varchar(10)='',
@ClientUID varchar(128), @SessionUID varchar(128), 
@R_Success tinyint out,@R_Message varchar(1000) out,@R_Data bigint out) AS
BEGIN

	SET @R_Success = 1
	SET @R_Message = 'SUCCESS'

	SELECT a.SubcId,
		b.CateId,b.CateKey,b.CateTitle,b.CateIconUrl,
		a.SubcKey,a.SubcTitle,a.SubcColour,a.SubcIconUrl,a.SubcValue
	FROM [dbo].[sysSubCategories] a
		INNER JOIN [dbo].[sysCategories] b ON a.CateId=b.CateId
	WHERE a.RowStatus<>'D' AND b.RowStatus<>'D'
		AND (@CategoryId=0 OR b.CateId=@CategoryId)
		AND (@CategoryKey='' OR b.CateKey=@CategoryKey)
		
	SET @R_Data = @@ROWCOUNT
END