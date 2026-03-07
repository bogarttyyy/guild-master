using System;
using System.Collections.Generic;
using NSBLib.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


public class RandomCirclePos : MonoBehaviour
{
    [SerializeField] private int numberOfPositions = 1;
    [SerializeField] private float radius = 5f;
    [SerializeField] private List<GameObject> randomCirclePos;
    [SerializeField] private GameObject posPrefab;
    
    private void Start()
    {
        randomCirclePos = new List<GameObject>();

    }

    public void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            GenerateRandomPos();
        }
    }

    private void GenerateRandomPos()
    {
        ClearPos();
        
        for (int i = 0; i < numberOfPositions; i++)
        {
            var newPos = RandomPointCircle(radius);
            randomCirclePos.Add(Instantiate(posPrefab, newPos, Quaternion.identity));
            NSBLogger.Log("RandomCirclePos: " + newPos);
        }
    }

    private void ClearPos()
    {
        if (randomCirclePos.Count > 0)
        {
            randomCirclePos.ForEach(Destroy);
            randomCirclePos.Clear();
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
