using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovementDelta
{
    private int bufferSize;
    private Queue<Vector3> positionBuffer;
    private Vector3 startingValue;
    public MovementDelta(Vector3 startingValue, int bufferSize)
    {
        this.bufferSize = bufferSize;
        positionBuffer = new Queue<Vector3>(this.bufferSize);
        this.startingValue = startingValue;
    }

    public void InitializeBufer()
    {
        for (int i = 0; i < this.bufferSize; i++)
        {
            positionBuffer.Enqueue(startingValue);
        }
    }

    public void AddValue(Vector3 value) 
    {
        if (positionBuffer.Count >= bufferSize)
        {
            positionBuffer.Dequeue();
        }

        positionBuffer.Enqueue(value);
    }

    public Vector3 CalculateAverageMovementDelta()
    {
        Vector3 SumOfDeltas = Vector3.zero;
        Vector3 previousPosition = positionBuffer.Peek();

        foreach (var position in positionBuffer)
        {
            Vector3 delta = position - previousPosition;
            SumOfDeltas += delta;
            previousPosition = position;
        }

        return SumOfDeltas / (positionBuffer.Count - 1);
    }
}
