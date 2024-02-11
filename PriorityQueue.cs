using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PriorityQueue<T>
{
    private List<T> elements = new List<T>();
    private readonly Comparison<T> comparison;

    public int Count => elements.Count;

    public PriorityQueue(Comparison<T> comparison)
    {
        this.comparison = comparison ?? throw new ArgumentNullException(nameof(comparison));
    }

    public void Enqueue(T item)
    {
        elements.Add(item);
        int i = elements.Count - 1;

        while (i > 0)
        {
            int parentIndex = (i - 1) / 2;

            if (comparison(elements[parentIndex], elements[i]) <= 0)
                break;

            Swap(parentIndex, i);
            i = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (elements.Count == 0)
            throw new InvalidOperationException("Priority queue is empty");

        T frontItem = elements[0];
        int lastIndex = elements.Count - 1;
        elements[0] = elements[lastIndex];
        elements.RemoveAt(lastIndex);

        int i = 0;
        while (true)
        {
            int leftChildIndex = 2 * i + 1;
            int rightChildIndex = 2 * i + 2;

            if (leftChildIndex >= elements.Count)
                break;

            int minIndex = leftChildIndex;
            if (rightChildIndex < elements.Count && comparison(elements[rightChildIndex], elements[leftChildIndex]) < 0)
                minIndex = rightChildIndex;

            if (comparison(elements[i], elements[minIndex]) <= 0)
                break;

            Swap(i, minIndex);
            i = minIndex;
        }

        return frontItem;
    }

    private void Swap(int i, int j)
    {
        T temp = elements[i];
        elements[i] = elements[j];
        elements[j] = temp;
    }

    public bool Contains(T item)
    {
        return elements.Contains(item);
    }
}