using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a list with items that should be removed in the correct order.
    // Expected Result: Bob and Josh, the results dequeue follows fist in first out order
    // Defect(s) Found: start from queue and loop until end of the queue, and missing
    // removing from the queue.
    public void TestPriorityQueue_QueueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Jonh", 1);
        string result1 = priorityQueue.Dequeue();
        string result2 = priorityQueue.Dequeue();

        Assert.AreEqual(result1, "Bob");
        Assert.AreEqual(result2, "Jonh");
    }

    [TestMethod]
    // Scenario: Create a queue with the following priorities Jonh with priority 2,
    // Bob with priority 1, and Jane with priority 1, the highest priority shall be
    // removed from the queue first, keeping the queue order when highest priority
    // takes place.
    // Expected Result: Jonh, Josh, and Bob, the results dequeue with priority and
    // follows the first in first out order.
    // Defect(s) Found: keep the queue order for high priority.
    public void TestPriorityQueue_HighPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Jonh", 2);
        priorityQueue.Enqueue("Josh", 2);
        priorityQueue.Enqueue("Jane", 1);
        string result1 = priorityQueue.Dequeue();
        string result2 = priorityQueue.Dequeue();
        string result3 = priorityQueue.Dequeue();

        Assert.AreEqual(result1, "Jonh");
        Assert.AreEqual(result2, "Josh");
        Assert.AreEqual(result3, "Bob");
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue
    // Expected Result: The queue is empty.
    // Defect(s) Found: none.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException exception)
        {
            Assert.AreEqual("The queue is empty.", exception.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception exception)
        {
            Assert.Fail(
                 string.Format(
                    "Unexpected exception of type {0} caught: {1}",
                    exception.GetType(), exception.Message
                )
            );
        }
    }
}