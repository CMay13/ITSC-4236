using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int gridX;//x in array
    public int gridY;//y in array
    public bool IsWall;// Is it a wall?
    public bool IsPotato;
    public Vector3 Position;//world position of node
    public Node Parent;//Previous node for sake of A*
    public int gCost;//cost to move to next square
    public int hCost;//distance from goal
    public int FCost { get { return gCost + hCost; } }// it calculates f cost
    public Node(bool a_IsWall,bool a_IsPotato, Vector3 a_Pos, int a_gridX, int a_gridY)//do i really need to comment what this does?
    {
        IsPotato = a_IsPotato;
        IsWall = a_IsWall;
        Position = a_Pos;
        gridX = a_gridX;
        gridY = a_gridY;
    }
}
