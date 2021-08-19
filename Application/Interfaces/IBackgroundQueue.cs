namespace Application.Interfaces
{
  public interface IBackgroundQueue<T>
  {
    /// <summary>
    /// Schedules a task which needs to be processed.
    /// </summary>
    /// <param name="item">Item to be executed.</param>
    void Enqueue(T item);

    /// <summary>
    /// Tries to remove and return the object at the beginning of the queue.
    /// </summary>
    /// <returns>If found, an item, otherwise null.</returns>
    T Dequeue();
  }
}