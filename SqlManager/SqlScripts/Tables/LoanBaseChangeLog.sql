use [RegulatoryComplianceDB]
GO

CREATE TABLE LoanBaseChangeLog (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    LoanId INT NOT NULL,
    LoanNumber BIGINT NOT NULL,
    Operation NVARCHAR(10) NOT NULL,
    ChangeDate DATETIME2 NOT NULL
);

