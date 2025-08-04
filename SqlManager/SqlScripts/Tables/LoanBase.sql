use [RegulatoryComplianceDB]

CREATE TABLE LoanBase (
    LoanId INT IDENTITY(1,1) PRIMARY KEY,
    LoanNumber BIGINT NOT NULL UNIQUE,
    LoanStatus NVARCHAR(50) NOT NULL,
    IsQualifiedLoan BIT NOT NULL,
    LoanAmount DECIMAL(18,2) NOT NULL,
    TermYears INT NOT NULL,
    InterestRate FLOAT NOT NULL,
    APR DECIMAL(8,4) NOT NULL,
    ClosingDate DATETIME2 NULL,
    LienPosition NVARCHAR(30) NULL,
    Occupancy NVARCHAR(30) NULL,
    PropertyCity NVARCHAR(60) NULL,
    PropertyCounty NVARCHAR(60) NULL,
    PropertyState NVARCHAR(30) NULL,
    TitleCompany NVARCHAR(60) NULL,
    IsHELOC BIT NOT NULL,
    LoanType NVARCHAR(30) NOT NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_LoanBase_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);

CREATE UNIQUE INDEX IX_LoanBase_LoanNumber ON LoanBase(LoanNumber);