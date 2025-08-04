use [RegulatoryComplianceDB]

CREATE TABLE HighCostTestResult (
    ResultId INT PRIMARY KEY,  -- Inherits from RegulatoryTestResult PK
    RegulatoryComplianceId INT NOT NULL,
    PassFedHCFeesTest BIT NOT NULL,
    PassFedHCTest BIT NOT NULL,
    PassFedYieldComparison BIT NOT NULL,
    PassStateHCFeesTest BIT NOT NULL,
    PassStateHCTest BIT NOT NULL,
    PassStateYieldComparison BIT NOT NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_HighCostTestResult_Result FOREIGN KEY (ResultId) REFERENCES RegulatoryTestResult(ResultId),
    CONSTRAINT FK_RegulatoryTestResult_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);