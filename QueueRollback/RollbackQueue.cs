using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueRollback
{
    public class RollbackQueue : IEnumerable<QueueItem>
    {
        private readonly Queue<QueueItem> _queue;

        public RollbackQueue()
        {
            _queue = new Queue<QueueItem>();
        }

        public void Add(QueueItem item)
        {
            _queue.Enqueue(item);
        }

        public QueueItem Remove()
        {
            return _queue.Dequeue();
        }

        public IEnumerator<QueueItem> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class QueueItem
    {
        public Type Type { get; set; }

        public object Item { get; set; }
    }
}
