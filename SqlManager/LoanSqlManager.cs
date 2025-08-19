using Common.Models;
using Dapper;
using SqlManager.Interfaces;
using System.Data;

namespace SalManager
{
    public class LoanSqlManager : ILoanSqlManager
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private static readonly SemaphoreSlim _dbSemaphore = new SemaphoreSlim(5);
        private static readonly object _loanCacheLock = new object();
        private static readonly Dictionary<int, Loan> _loanCache = new Dictionary<int, Loan>();

        public LoanSqlManager(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateLoanBase(Loan loan)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(1);  //This will act like a lock as well
            await semaphore.WaitAsync();

            try
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

                var response = await connection.ExecuteAsync(
                    "sp_CreateLoanBase", 
                    parameters, 
                    commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("@NewLoanId");
            }
            finally
            {
                _dbSemaphore.Release();
            }
        }

        public async Task<Loan> GetLoanBaseById(int loanId)
        {
            lock (_loanCacheLock)
            {
                if (_loanCache.TryGetValue(loanId, out var cachedLoan))
                {
                    return cachedLoan;
                }
            }

            await _dbSemaphore.WaitAsync();

            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@LoanId", loanId);

                var loan = await connection.QueryFirstOrDefaultAsync<Loan>(
                    "sp_GetLoanBaseById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                lock (_loanCacheLock)
                {
                    if (loan != null)
                        _loanCache[loanId] = loan;
                }

                return loan;
            }
            finally { 
                _dbSemaphore.Release(); 
            }
        }

        public async Task<bool> UpdateLoanBase(Loan loan)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(1);
            await semaphore.WaitAsync();

            try
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

                if (rowsAffected > 0)
                {
                    lock (_loanCacheLock)
                    {
                        _loanCache[loan.LoanId] = loan;
                    }
                }

                return rowsAffected > 0;
            }
            finally
            {
                _dbSemaphore.Release();
            }
        }

        public async Task<bool> DeleteLoanBase(int loanId)
        {
            await _dbSemaphore.WaitAsync();
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@LoanId", loanId);

                var rowsAffected = await connection.ExecuteAsync(
                    "sp_DeleteLoanBase",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (rowsAffected > 0)
                {
                    lock (_loanCacheLock)
                    {
                        _loanCache.Remove(loanId);
                    }
                }

                return rowsAffected > 0;
            }
            finally { 
                _dbSemaphore.Release(); 
            }

        }
    }
}