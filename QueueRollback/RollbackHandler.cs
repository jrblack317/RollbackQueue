using System;

namespace QueueRollback
{
    public class RollbackHandler
    {
        public void Rollback(RollbackQueue queue)
        {
            foreach (QueueItem item in queue)
            {
                dynamic currentItem = Convert.ChangeType(item.Item, item.Type);
                var orig = currentItem.OriginalValue;
                var newValue = currentItem.NewValue;

                Console.WriteLine(orig);
                Console.WriteLine(newValue);
            }
        }
    }
}
