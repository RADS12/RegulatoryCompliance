use [RegulatoryComplianceDB]

CREATE TABLE ClientDetails (
    ClientId INT IDENTITY(1,1) PRIMARY KEY,
    LoanNumber BIGINT NOT NULL,  -- FK to LoanBase
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    AddressLine1 NVARCHAR(100) NOT NULL,
    AddressLine2 NVARCHAR(100) NULL,
    City NVARCHAR(50) NOT NULL,
    ZipCode NVARCHAR(20) NOT NULL,
    AuditId INT NOT NULL
    CONSTRAINT FK_ClientDetails_Loan FOREIGN KEY (LoanNumber) REFERENCES LoanBase(LoanNumber),
    CONSTRAINT FK_LoanBase_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);

CREATE INDEX IX_ClientDetails_LoanNumber ON ClientDetails(LoanNumber);