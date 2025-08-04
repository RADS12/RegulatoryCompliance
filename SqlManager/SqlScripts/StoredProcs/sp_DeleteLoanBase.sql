use [RegulatoryComplianceDB]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DeleteLoanBase
    @LoanId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AuditId INT;
    SELECT @AuditId = AuditId FROM LoanBase WHERE LoanId = @LoanId;

    DELETE FROM LoanBase WHERE LoanId = @LoanId;

END
GO
