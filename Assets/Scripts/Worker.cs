using DG.Tweening;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Vector2 destPos;
    public Vector2 originPos;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPos = transform.position;
        
        var newSequence =  DOTween.Sequence();

        newSequence.Append(transform.DOMove(destPos, 0.5f));
        newSequence.Append(transform.DOMove(originPos, 0.5f));

        newSequence.Play();
        
        newSequence.onComplete += () => Destroy(gameObject);
        //
        // Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
