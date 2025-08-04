use [RegulatoryComplianceDB]

CREATE TABLE StateRegulatoryTestResult (
    ResultId INT PRIMARY KEY,
    RegulatoryComplianceId INT NOT NULL,
    StateRegulatoryTestInputId BIGINT NOT NULL,
    StateRegulatoryTestId INT NOT NULL,
    StateRegulatoryTestName NVARCHAR(100) NULL,
    DoesTestApply BIT NOT NULL,
    DoesPassStateRegulatoryTest BIT NOT NULL,
    ErrorMessage NVARCHAR(250) NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_StateRegulatoryTestResult_Result FOREIGN KEY (ResultId) REFERENCES RegulatoryTestResult(ResultId),
    CONSTRAINT FK_RegulatoryTestResult_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);