using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Grid grid;
    public Transform StartPosition1;
    public Transform StartPosition2;
    public Transform StartPosition3;
    public Transform StartPosition4;
    Transform[] positions;
        List<Node> path;
        Coroutine MoveIE;
    public Pathfinding finder;
        public float EnemySpeed;
    private void Start()
    {
        path = new List<Node>();
        positions[0] = StartPosition1;
        positions[1] = StartPosition2;
        positions[2] = StartPosition3;
        positions[3] = StartPosition4;
    }
    private void Awake()
        {
        Grid grid = GetComponentInChildren<Grid>();
        Pathfinding finder = GetComponentInChildren<Pathfinding>();
    }
    private void Update()
    {   
        StartCoroutine(movement());   
    }
    IEnumerator movement()
    {for (int j = 0; j < 1; j++)
        {
            for (int k = 0; k < 3; k++)
                path = finder.FindPath(positions[k].position, positions[k+1].position);
            for (int i = 0; i < path.Count; i++)
            {
                MoveIE = StartCoroutine(Moving(i));
                yield return MoveIE;
            }
        }
    }
    IEnumerator Moving(int currentPosition)
        {
            while (transform.position != path[currentPosition].Position)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[currentPosition].Position, EnemySpeed * Time.deltaTime);
                yield return null;
            }

        }
    }

