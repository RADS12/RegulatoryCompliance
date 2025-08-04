use [RegulatoryComplianceDB]

CREATE TABLE PointsAndFeesTestInput (
    InputId INT PRIMARY KEY,
    PointsPaid DECIMAL(18,2) NOT NULL,
    OtherFees DECIMAL(18,2) NOT NULL,
    APR DECIMAL(8,4) NOT NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_PointsAndFeesTestInput_Input FOREIGN KEY (InputId) REFERENCES RegulatoryTestInput(InputId),
    CONSTRAINT FK_LoanBase_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);

CREATE UNIQUE INDEX IX_LoanBase_LoanNumber ON LoanBase(LoanNumber);