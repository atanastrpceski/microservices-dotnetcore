using Banking.Data.Context;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDBContext _context;

        public AccountRepository(BankingDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }
    }
}
