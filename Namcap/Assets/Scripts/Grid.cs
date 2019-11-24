using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask WallMask;//what layer are obstacles?
    public Vector2 gridWorldSize;//How big grid?
    public float nodeRadius;//how big node?
    public float Distance;//how far node from node
    Node[,] grid;
    public List<Node> Path;
    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;
    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }
    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector2 bottomLeft = ((Vector2)transform.position) - Vector2.right * gridWorldSize.x / 2 - Vector2.up * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPoint = bottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool Wall = false;
                if (Physics2D.OverlapCircle(worldPoint, nodeRadius, WallMask))
                {
                    Wall = true;
                }
                grid[x, y] = new Node(Wall, worldPoint, x, y);
            }
        }
    }
    public Node NodeFromWorldPosition(Vector3 a_WorldPosition)
    {
        float xpoint = ((a_WorldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float ypoint = ((a_WorldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y);

        xpoint = Mathf.Clamp01(xpoint);
        ypoint = Mathf.Clamp01(ypoint);
        int x = Mathf.RoundToInt((gridSizeX - 1) * xpoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * ypoint);

        return grid[x, y];
    }
    public List<Node> GetNeighboringNodes(Node a_NeighborNode)
    {
        List<Node> NeighborList = new List<Node>();
        int checkX;
        int checkY;
        checkX = a_NeighborNode.gridX + 1;
        checkY = a_NeighborNode.gridY;
        if (checkX >= 0 && checkX < gridSizeX)
        {
            if (checkY >= 0 && checkY < gridSizeY)
            {
                NeighborList.Add(grid[checkX, checkY]);
            }
        }
        checkX = a_NeighborNode.gridX - 1;
        checkY = a_NeighborNode.gridY;
        if (checkX >= 0 && checkX < gridSizeX)
        {
            if (checkY >= 0 && checkY < gridSizeY)
            {
                NeighborList.Add(grid[checkX, checkY]);
            }
        }
        checkX = a_NeighborNode.gridX;
        checkY = a_NeighborNode.gridY + 1;
        if (checkX >= 0 && checkX < gridSizeX)
        {
            if (checkY >= 0 && checkY < gridSizeY)
            {
                NeighborList.Add(grid[checkX, checkY]);
            }
        }
        checkX = a_NeighborNode.gridX;
        checkY = a_NeighborNode.gridY - 1;
        if (checkX >= 0 && checkX < gridSizeX)
        {
            if (checkY >= 0 && checkY < gridSizeY)
            {
                NeighborList.Add(grid[checkX, checkY]);
            }
        }

        return NeighborList;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y));
        if (grid != null)
        {
            foreach(Node n in grid)
            {
                if(n.IsWall)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }

                if (Path != null)
                {
                    if (Path.Contains(n))
                    {
                        Gizmos.color = Color.blue;
                    }
                }

                Gizmos.DrawWireCube(n.Position, new Vector3(1*(nodeDiameter - Distance), 1* (nodeDiameter - Distance)));
            }
        }
    }
    


}
