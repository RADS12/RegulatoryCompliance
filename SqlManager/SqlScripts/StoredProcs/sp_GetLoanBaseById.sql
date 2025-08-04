use [RegulatoryComplianceDB]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetLoanBaseById
    @LoanId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        l.*, 
        a.CreatedById, a.UpdatedById, a.CreatedDate, a.UpdatedDate
    FROM LoanBase l
    INNER JOIN EntityAuditHistory a ON l.AuditId = a.AuditId
    WHERE l.LoanId = @LoanId;
END
GO

