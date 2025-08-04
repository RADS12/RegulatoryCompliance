use [RegulatoryComplianceDB]

CREATE TABLE SafeHarborTestInput (
    InputId INT PRIMARY KEY,
    HasPrepaymentPenalty BIT NOT NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_SafeHarborTestInput_Input FOREIGN KEY (InputId) REFERENCES RegulatoryTestInput(InputId),
    CONSTRAINT FK_LoanBase_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);