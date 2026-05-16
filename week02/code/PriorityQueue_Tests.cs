using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: enqueue 3 elements with different priorities (A, B, C) and then test that the top priority is dequeued first.
    // Expected Result: "A"
    // Defect(s) Found: 1, the RemoveAt function would have failed had I not ordered them.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 1);

        string topPriority = priorityQueue.Dequeue();
        Assert.AreEqual("A", topPriority);
    }

    [TestMethod]
    // Scenario: Add elements to the queue with the same priority but ensure that the item queued first is dequeued first.
    // Expected Result: "X"
    // Defect(s) Found: 1, dequeue wasn't finding the correct priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 3);
        priorityQueue.Enqueue("Y", 3);
        priorityQueue.Enqueue("Z", 1);

        string firstQueued = priorityQueue.Dequeue();
        Assert.AreEqual("X", firstQueued);
    }

    [TestMethod]
    // Scenario: Checks for exception handling
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: 0, passed
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}