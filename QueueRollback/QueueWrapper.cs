namespace QueueRollback
{
    public class QueueWrapper<T>
    {
        public T OriginalValue { get; set; }

        public T NewValue { get; set; }
    }
}
