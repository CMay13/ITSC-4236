using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementCore : MonoBehaviour
{
    public float enemySpeed;
    public void moveRight()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
    }
    public void moveLeft()
    {
        transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
    }
    public void moveUp()
    {
        transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
    }
    public void moveDown()
    {
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
    }

}
