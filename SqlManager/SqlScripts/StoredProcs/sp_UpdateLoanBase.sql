use [RegulatoryComplianceDB]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateLoanBase
    @LoanId INT,
    @LoanStatus NVARCHAR(50),
    @IsQualifiedLoan BIT,
    @LoanAmount DECIMAL(18,2),
    @TermYears INT,
    @InterestRate FLOAT,
    @APR DECIMAL(8,4),
    @ClosingDate DATETIME2 = NULL,
    @LienPosition NVARCHAR(30) = NULL,
    @Occupancy NVARCHAR(30) = NULL,
    @PropertyCity NVARCHAR(60) = NULL,
    @PropertyCounty NVARCHAR(60) = NULL,
    @PropertyState NVARCHAR(30) = NULL,
    @TitleCompany NVARCHAR(60) = NULL,
    @IsHELOC BIT,
    @LoanType NVARCHAR(30),
    @UpdatedById INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AuditId INT;
    SELECT @AuditId = AuditId FROM LoanBase WHERE LoanId = @LoanId;

    UPDATE LoanBase
    SET 
        LoanStatus = @LoanStatus,
        IsQualifiedLoan = @IsQualifiedLoan,
        LoanAmount = @LoanAmount,
        TermYears = @TermYears,
        InterestRate = @InterestRate,
        APR = @APR,
        ClosingDate = @ClosingDate,
        LienPosition = @LienPosition,
        Occupancy = @Occupancy,
        PropertyCity = @PropertyCity,
        PropertyCounty = @PropertyCounty,
        PropertyState = @PropertyState,
        TitleCompany = @TitleCompany,
        IsHELOC = @IsHELOC,
        LoanType = @LoanType
    WHERE LoanId = @LoanId;

    UPDATE EntityAuditHistory
    SET 
        UpdatedById = @UpdatedById,
        UpdatedDate = GETUTCDATE()
    WHERE AuditId = @AuditId;
END
GO
