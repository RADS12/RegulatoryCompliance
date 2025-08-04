use [RegulatoryComplianceDB]

CREATE TABLE PointsAndFeesTestOutput (
    ResultId INT PRIMARY KEY,
    RegulatoryComplianceId INT NOT NULL,
    AffiliatedAppraisalFeeAmount DECIMAL(18,2) NULL,
    AffiliatedTitleFeesAmount DECIMAL(18,2) NULL,
    AreQMAffiliatedFeesFinanced BIT NOT NULL,
    AuditId INT NOT NULL,
    CONSTRAINT FK_PointsAndFeesTestOutput_Result FOREIGN KEY (ResultId) REFERENCES RegulatoryTestResult(ResultId),
    CONSTRAINT FK_RegulatoryTestResult_Audit FOREIGN KEY (AuditId) REFERENCES EntityAuditHistory(AuditId)
);

CREATE INDEX IX_ClientDetails_LoanNumber ON ClientDetails(LoanNumber);