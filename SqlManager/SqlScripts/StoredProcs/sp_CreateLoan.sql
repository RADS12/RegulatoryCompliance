use [RegulatoryComplianceDB]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE CreateLoanBase
    @LoanNumber BIGINT,
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
    @CreatedById INT,
    @UpdatedById INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert audit row first
    INSERT INTO EntityAuditHistory (CreatedById, UpdatedById, CreatedDate, UpdatedDate)
    VALUES (@CreatedById, @UpdatedById, GETUTCDATE(), NULL);

    DECLARE @AuditId INT = SCOPE_IDENTITY();

    -- Insert loan row
    INSERT INTO LoanBase (
        LoanNumber, LoanStatus, IsQualifiedLoan, LoanAmount, TermYears,
        InterestRate, APR, ClosingDate, LienPosition, Occupancy,
        PropertyCity, PropertyCounty, PropertyState, TitleCompany,
        IsHELOC, LoanType, AuditId
    )
    VALUES (
        @LoanNumber, @LoanStatus, @IsQualifiedLoan, @LoanAmount, @TermYears,
        @InterestRate, @APR, @ClosingDate, @LienPosition, @Occupancy,
        @PropertyCity, @PropertyCounty, @PropertyState, @TitleCompany,
        @IsHELOC, @LoanType, @AuditId
    );

    SELECT SCOPE_IDENTITY() AS LoanId;
END
GO
