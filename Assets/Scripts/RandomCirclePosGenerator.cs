using System.Collections.Generic;
using UnityEngine;

public static class RandomCirclePosGenerator
{
    public static List<Vector2> GeneratePositions(int numberOfPositions, float radius)
    {
        var posList = new List<Vector2>();

        for (int i = 0; i < numberOfPositions; i++)
        {
            posList.Add(RandomPointCircle(radius));
        }
        
        return posList;
    }
    
    public static Vector2 RandomPointCircle(float radius)
    {
        var angle = Random.Range(0f, Mathf.PI * 2f);

        var x = Mathf.Cos(angle) * radius;
        var y = Mathf.Sin(angle) * radius;
        
        return new Vector2(x, y);
    }
}