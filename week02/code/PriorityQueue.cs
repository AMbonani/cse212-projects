using System;
using System.Collections.Generic;

public class PriorityQueue
{
    // Represents an item in the priority queue
    private class Item
    {
        public string Value { get; }
        public int Priority { get; }

        public Item(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    // Internal list to hold the queue items
    private List<Item> _queue = new List<Item>();

    /// <summary>
    /// Adds an item with a given priority to the back of the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _queue.Add(new Item(value, priority));
    }

    /// <summary>
    /// Removes and returns the value of the item with the highest priority.
    /// If multiple items share the highest priority, the earliest added one is returned.
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
            
        }

        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }
}
