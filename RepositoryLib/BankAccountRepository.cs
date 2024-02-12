using EnitityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IBankAccountRepository
    {
        bool Add(BankAccount bankAccount);
        IEnumerable<BankAccount> GetAllAccount();
        void Modify(BankAccount bankAccount);
        BankAccount FindById(string accountNO);
        bool Remove(string accountNo);
    }

    // BankAccountRepository class

    namespace RepositoryLib
    {
        public class BankAccountRepository : IBankAccountRepository
        {
            private ProjectDbContext db;

            public BankAccountRepository()
            {
                db = new ProjectDbContext();
            }

            public bool Add(BankAccount bankAccount)
            {
                db.Add(bankAccount);
                db.SaveChanges();
                return true;
            }

            public BankAccount FindById(string accountNo)
            {
                return db.BankAccounts.FirstOrDefault(account => account.AccountNo == accountNo);
            }

            public IEnumerable<BankAccount> GetAllAccount()
            {
                return db.BankAccounts.ToList();
            }

            public void Modify(BankAccount bankAccount)
            {
                BankAccount toBeModify = db.BankAccounts.FirstOrDefault(account => account.AccountNo == bankAccount.AccountNo);

                if (toBeModify != null)
                {
                    toBeModify.AccountHolderName = bankAccount.AccountHolderName;
                    toBeModify.AccountType = bankAccount.AccountType;
                    toBeModify.BankName = bankAccount.BankName;
                    toBeModify.IFSCCode = bankAccount.IFSCCode;

                    db.SaveChanges();
                }
            }

            public bool Remove(string accountNo)
            {
                BankAccount account = FindById(accountNo);

                if (account != null)
                {
                    db.Remove(account);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}