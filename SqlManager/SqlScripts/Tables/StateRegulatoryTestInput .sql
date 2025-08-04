use [RegulatoryComplianceDB]

CREATE TABLE StateRegulatoryTestInput (
    InputId INT PRIMARY KEY,
    State NVARCHAR(30) NOT NULL,
    InitialLockDateIndex DECIMAL(10,4) NULL,
    ClosingDateIndex DECIMAL(10,4) NULL,
    IndexName NVARCHAR(50) NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_StateRegulatoryTestInput_Input FOREIGN KEY (InputId) REFERENCES RegulatoryTestInput(InputId),
    CONSTRAINT FK_LoanBase_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);