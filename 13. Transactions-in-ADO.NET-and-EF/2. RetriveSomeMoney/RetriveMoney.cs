namespace RetriveSomeMoney
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Transactions;

    using ATM;
    //1. Using transactions write a method which retrieves some money (for example $200) from certain account. The retrieval is successful when the following sequence of sub-operations is completed successfully:
    // - A query checks if the given CardPIN and CardNumber are valid.
    // - The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
    //The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200)
    // - Why does the isolation level need to be set to “repeatable read”?

//3. Extend the project from the previous exercise and add a new table TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount) containing information about all money retrievals on all accounts.
//Modify the program logic so that it saves historical information (logs) in the new table after each successful money withdrawal.

    public class RetriveMoney
    {
        public static decimal RetriveSomeMoney(string cardNumber, string cardPin, decimal amount)
        {
            ATMEntities dbATM = new ATMEntities();
            var transOption = new TransactionOptions();
            transOption.IsolationLevel = IsolationLevel.RepeatableRead;
            var scope = new TransactionScope(TransactionScopeOption.RequiresNew, transOption);

            using (scope)
            {
                foreach (var account in dbATM.CardAccounts)
                {
                    if ((account.CardNumber == cardNumber) && (account.CardPIN == cardPin) && (account.CardCash > amount))
                    {
                        account.CardCash -= amount;

                        var log = new TransactionHistory()
                        {
                            CardNumber = cardNumber,
                            TransactionDate = DateTime.Now,
                            Amount = amount
                        };

                        dbATM.TransactionHistories.Add(log);
                        dbATM.SaveChanges();
                        scope.Complete();

                        return amount;
                    }
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            var retrivedAmount = RetriveSomeMoney("1222422224", "9999      ", 500);
            Console.WriteLine(retrivedAmount);

        }
    }
}
