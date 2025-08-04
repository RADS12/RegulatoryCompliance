using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SqlManager.Interfaces;

namespace SalManager
{
    public class LoanSqlManager : ILoanSqlManager
    {
        private readonly IDbConectionFactory _connectionFactory;

        public LoanSqlManager(IDbConectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateLoanBase(Loan loan)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@LoanNumber", loan.LoanNumber);
            parameters.Add("@LoanStatus", loan.LoanStatus);
            parameters.Add("@IsQualifiedLoan", loan.IsQualifiedLoan);
            parameters.Add("@LoanAmount", loan.LoanAmount);
            parameters.Add("@TermYears", loan.TermYears);
            parameters.Add("@InterestRate", loan.InterestRate);
            parameters.Add("@APR", loan.APR);
            parameters.Add("@ClosingDate", loan.ClosingDate);
            parameters.Add("@LienPosition", loan.LienPosition);
            parameters.Add("@Occupancy", loan.Occupancy);
            parameters.Add("@PropertyCity", loan.PropertyCity);
            parameters.Add("@PropertyCounty", loan.PropertyCounty);
            parameters.Add("@PropertyState", loan.PropertyState);
            parameters.Add("@TitleCompany", loan.TitleCompany);
            parameters.Add("@IsHELOC", loan.IsHELOC);
            parameters.Add("@LoanType", loan.LoanType);
            //parameters.Add("@AuditId", loan.AuditId);
            parameters.Add("@NewLoanId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("sp_CreateLoanBase", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@NewLoanId");
        }

        public async Task<Loan> GetLoanBaseById(int loanId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@LoanId", loanId);

            var loan = await connection.QueryFirstOrDefaultAsync<Loan>(
                "sp_GetLoanBaseById",
                parameters,
                commandType: CommandType.StoredProcedure);

            return loan;
        }

        public async Task<bool> UpdateLoanBase(Loan loan)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@LoanId", loan.LoanId);
            parameters.Add("@LoanNumber", loan.LoanNumber);
            parameters.Add("@LoanStatus", loan.LoanStatus);
            parameters.Add("@IsQualifiedLoan", loan.IsQualifiedLoan);
            parameters.Add("@LoanAmount", loan.LoanAmount);
            parameters.Add("@TermYears", loan.TermYears);
            parameters.Add("@InterestRate", loan.InterestRate);
            parameters.Add("@APR", loan.APR);
            parameters.Add("@ClosingDate", loan.ClosingDate);
            parameters.Add("@LienPosition", loan.LienPosition);
            parameters.Add("@Occupancy", loan.Occupancy);
            parameters.Add("@PropertyCity", loan.PropertyCity);
            parameters.Add("@PropertyCounty", loan.PropertyCounty);
            parameters.Add("@PropertyState", loan.PropertyState);
            parameters.Add("@TitleCompany", loan.TitleCompany);
            parameters.Add("@IsHELOC", loan.IsHELOC);
            parameters.Add("@LoanType", loan.LoanType);
            //parameters.Add("@AuditId", loan.AuditId);

            var rowsAffected = await connection.ExecuteAsync(
                "sp_UpdateLoanBase",
                parameters,
                commandType: CommandType.StoredProcedure);

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteLoanBase(int loanId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@LoanId", loanId);

            var rowsAffected = await connection.ExecuteAsync(
                "sp_DeleteLoanBase",
                parameters,
                commandType: CommandType.StoredProcedure);

            return rowsAffected > 0;
        }
    }
}