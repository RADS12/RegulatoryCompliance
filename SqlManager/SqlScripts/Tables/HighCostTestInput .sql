use [RegulatoryComplianceDB]

CREATE TABLE HighCostTestInput (
    InputId INT PRIMARY KEY,  -- Inherits RegulatoryTestInput PK
    HasBalloonPayment BIT NOT NULL,
    HasNegativeAmortization BIT NOT NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_HighCostTestInput_Input FOREIGN KEY (InputId) REFERENCES RegulatoryTestInput(InputId),
    CONSTRAINT FK_LoanBase_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);