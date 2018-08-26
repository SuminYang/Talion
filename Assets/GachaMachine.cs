using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaMachine : MonoBehaviour
{
    private List<GachaBall> balls = new List<GachaBall>();

    [SerializeField]
    private GachaBall ballPrefab;

    //초기 공 생성수
    private int ballNum = 40;

    [SerializeField]
    private Transform spawnPosit;

    private void Start()
    {
        MakeBalls(ballNum);
    }
    
    private void MakeBalls(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GachaBall ball = MakeBall();
            balls.Add(ball);
        }

    }

    private GachaBall MakeBall()
    {
        GachaBall ball = Instantiate<GachaBall>(ballPrefab, this.transform);

        ball.transform.position = spawnPosit.position + ((Vector3)Random.insideUnitCircle);

        return ball;
    }


    private void RollBalls()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].AddForce(Vector3.left, 20f);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollBalls();
        }
    }
}
