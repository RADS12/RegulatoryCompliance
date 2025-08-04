use [RegulatoryComplianceDB]

CREATE TABLE EntityAuditHistory (
    AuditId INT IDENTITY(1,1) PRIMARY KEY,
    CreatedById INT NOT NULL,
    UpdatedById INT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedDate DATETIME2 NULL
);