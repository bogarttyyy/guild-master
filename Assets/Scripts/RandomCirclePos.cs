using System.Collections.Generic;
using NSBLib.Helpers;
using UnityEngine;


public class RandomCirclePos : MonoBehaviour
{
    [SerializeField] private int numberOfPositions = 1;
    [SerializeField] private float radius = 5f;
    [SerializeField] private List<Vector2> randomCirclePos;
    [SerializeField] private GameObject posPrefab;
    
    private void Start()
    {
        randomCirclePos = new List<Vector2>();

        for (int i = 0; i < numberOfPositions; i++)
        {
            var newPos = RandomPointCircle(radius);
            Instantiate(posPrefab, newPos, Quaternion.identity);
            NSBLogger.Log("RandomCirclePos: " + newPos);
            randomCirclePos.Add(newPos);
        }
    }

    public static Vector2 RandomPointCircle(float radius)
    {
        var angle = Random.Range(0f, Mathf.PI * 2f);

        var x = Mathf.Cos(angle) * radius;
        var y = Mathf.Sin(angle) * radius;
        
        return new Vector2(x, y);
    }
}
