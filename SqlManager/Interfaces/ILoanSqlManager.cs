using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
