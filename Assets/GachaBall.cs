using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GachaBall : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> ballList;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        SetBallColor();
    }

    private void SetBallColor()
    {
        spriteRenderer.sprite = ballList[Random.Range(0, ballList.Count)];
    }

    public void AddForce(Vector3 forceDirection, float power)
    {
        rb.AddForce(forceDirection * power, ForceMode2D.Impulse);
        rb.AddTorque(5f, ForceMode2D.Impulse);      
    }

    private void StopTorque()
    {
       // rb.AddTorque(0f, ForceMode2D.Impulse);
        rb.angularVelocity =0f;
    }




}
