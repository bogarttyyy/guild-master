using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RandomCirclePos : MonoBehaviour
{
    [SerializeField] private int numberOfPositions = 1;
    [SerializeField] private float radius = 5f;
    [SerializeField] private GameObject posPrefab;
    [SerializeField] private Worker workerPrefab;
    
    private List<GameObject> randomCirclePos;
    
    private void Start()
    {
        randomCirclePos = new List<GameObject>();

    }

    public void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            GenerateRandomPos();
            GenerateUnit();
        }
    }

    private void GenerateUnit()
    {
        var count = randomCirclePos.Count;

        foreach (var pos in randomCirclePos)
        {
            workerPrefab.destPos = pos.transform.position;
            Instantiate(workerPrefab, Vector2.zero, Quaternion.identity);
        }
    }

    private void GenerateRandomPos()
    {
        ClearPos();

        var posList = RandomCirclePosGenerator.GeneratePositions(numberOfPositions, radius);
        
        foreach (var pos in posList)
            randomCirclePos.Add(Instantiate(posPrefab, pos, Quaternion.identity));
        
    }

    private void ClearPos()
    {
        if (randomCirclePos.Count > 0)
        {
            randomCirclePos.ForEach(Destroy);
            randomCirclePos.Clear();
        }
    }
}
