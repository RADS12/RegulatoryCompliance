using Common.Models;

namespace SqlManager.Interfaces
{
    public  interface ILoanSqlManager
    {
        public Task<int> CreateLoanBase(Loan loan);
        public Task<Loan> GetLoanBaseById(int loanId);
        public Task<bool> UpdateLoanBase(Loan loan);
        public Task<bool> DeleteLoanBase(int loanId);
    }
}
