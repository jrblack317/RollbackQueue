using System;
using QueueRollback.Models;

namespace QueueRollback
{
    class Program
    {
        static void Main(string[] args)
        {
            var loanWrapper = new QueueItem
            {
                Type = typeof(QueueWrapper<Loan>),
                Item = new QueueWrapper<Loan>
                {
                    OriginalValue = new Loan { Amount = 123M, Type = 1 },
                    NewValue = new Loan { Amount = 444M, Type = 2 }
                }
            };

            var borrowerWrapper = new QueueItem
            {
                Type = typeof(QueueWrapper<Borrower>),
                Item = new QueueWrapper<Borrower>
                {
                    OriginalValue = new Borrower { FirstName = "Person", LastName = "A" },
                    NewValue = new Borrower { FirstName = "Person", LastName = "B" }
                }
            };

            var queue = new RollbackQueue();
            queue.Add(loanWrapper);
            queue.Add(borrowerWrapper);

            var rollbackHandler = new RollbackHandler();
            rollbackHandler.Rollback(queue);

            Console.Read();
        }
    }
}
