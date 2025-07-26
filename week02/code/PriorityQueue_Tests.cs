using System;
using Xunit;

public class PriorityQueue_Tests
{
    [Fact]
    public void Dequeue_Returns_Highest_Priority_Item()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 5);
        Assert.Equal("C", queue.Dequeue());
    }

    [Fact]
    public void Dequeue_Respects_FIFO_For_Equal_Priorities()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 4);
        queue.Enqueue("B", 4);
        queue.Enqueue("C", 4);
        Assert.Equal("A", queue.Dequeue());
        Assert.Equal("B", queue.Dequeue());
        Assert.Equal("C", queue.Dequeue());
    }

    [Fact]
    public void Dequeue_Throws_Exception_When_Empty()
    {
        var queue = new PriorityQueue();
        var ex = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        Assert.Equal("The queue is empty.", ex.Message);
    }

    [Fact]
    public void Enqueue_Dequeue_Mixed_Priority_Order()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);
        queue.Enqueue("D", 5);
        queue.Enqueue("E", 1);

        Assert.Equal("B", queue.Dequeue());
        Assert.Equal("D", queue.Dequeue());
        Assert.Equal("C", queue.Dequeue());
        Assert.Equal("A", queue.Dequeue());
        Assert.Equal("E", queue.Dequeue());
    }
}

