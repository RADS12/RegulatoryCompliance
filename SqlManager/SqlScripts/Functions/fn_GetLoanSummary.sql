use [RegulatoryComplianceDB]
GO

CREATE FUNCTION dbo.fn_GetLoanSummary(@LoanId INT)
RETURNS NVARCHAR(200)
AS
BEGIN
    DECLARE @summary NVARCHAR(200)
    SELECT @summary = LoanType + ' Loan: Amount=' +
        FORMAT(LoanAmount, 'C') +
        ', Rate=' + FORMAT(InterestRate, 'P') +
        ', Term=' + CAST(TermYears AS NVARCHAR) + ' years'
    FROM LoanBase
    WHERE LoanId = @LoanId

    RETURN @summary
END