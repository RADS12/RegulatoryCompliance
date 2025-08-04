use [RegulatoryComplianceDB]

CREATE TABLE SafeHarborTestResults (
    ResultId INT PRIMARY KEY,
    RegulatoryComplianceId INT NOT NULL,
    DoesPassSafeHarborTest BIT NOT NULL,
    MaximumAPRForSafeHarbor DECIMAL(8,4) NULL,
    TotalFeesToBeRecouped DECIMAL(18,2) NULL,
    SafeHarborSeasonRequirementMet BIT NOT NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_SafeHarborTestResults_Result FOREIGN KEY (ResultId) REFERENCES RegulatoryTestResult(ResultId),
    CONSTRAINT FK_RegulatoryTestResult_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);