using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public Grid grid;
    public float EnemySpeed;
    List<Node> follow;
    Coroutine MoveIE;
    private void Awake()
    {
       Grid grid = GetComponentInChildren<Grid>();
    }
    private void Update()
    {
        follow = grid.Path;
        StartCoroutine(movement());
    }
    IEnumerator movement()
    {
        for (int i = 0; i < follow.Count; i++)
        {
            MoveIE = StartCoroutine(Moving(i));
            yield return MoveIE;
        }
    }

    IEnumerator Moving(int currentPosition)
    {
        while (transform.position != follow[currentPosition].Position)
        {
            transform.position = Vector3.MoveTowards(transform.position, follow[currentPosition].Position, EnemySpeed * Time.deltaTime);
            yield return null;
        }

    }
}
