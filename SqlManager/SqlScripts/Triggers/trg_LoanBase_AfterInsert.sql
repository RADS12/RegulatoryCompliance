use [RegulatoryComplianceDB]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER trg_LoanBase_AfterInsert
ON LoanBase
AFTER INSERT
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
        i.LoanId,
        i.LoanNumber,
        'INSERT',
        GETUTCDATE()
    FROM inserted i;
END
GO
