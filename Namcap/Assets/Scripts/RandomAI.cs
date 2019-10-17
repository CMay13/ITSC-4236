using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : MonoBehaviour
{
    int oldDirection;
    int curDirection;
    public float accelerationTime = 2f;
    private float timeLeft;
    public EnemyMovementCore emc;
    void getRandom(int direction)
    {
        switch (direction)
        {
            case 0:
                emc.moveRight();
                break;
            case 1:
                emc.moveLeft();
                break;
            case 2:
                emc.moveDown();
                break;
            case 3:
                emc.moveUp();
                break;
        }
    }
    void Start()
    {
        curDirection = Random.Range(0, 4);
        getRandom(curDirection);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            oldDirection = curDirection;
            curDirection = Random.Range(0, 4);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
        while (curDirection == oldDirection)
        {
            curDirection = Random.Range(0, 4);
        }
        getRandom(curDirection);
        Debug.Log(curDirection);
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            curDirection = Random.Range(0, 4);
            timeLeft = accelerationTime;
        }
        getRandom(curDirection);
    }
}
