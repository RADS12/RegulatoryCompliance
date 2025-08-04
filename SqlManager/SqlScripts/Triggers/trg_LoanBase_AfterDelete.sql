use [RegulatoryComplianceDB]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER trg_LoanBase_AfterDelete
ON LoanBase
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO LoanBaseChangeLog (
        LoanId,
        LoanNumber,
        Operation,
        ChangeDate
    )
    SELECT 
        d.LoanId,
        d.LoanNumber,
        'DELETE',
        GETUTCDATE()
    FROM deleted d;
END
GO
