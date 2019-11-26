using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
    Grid grid;
    public Transform StartPosition;
    public Transform TargetPosition;
    List<Node> gridPath;
    List<Node> secondPath;

    private void Awake() {
        grid = GetComponent<Grid>();
    }
    private void Update() {
        secondPath = FindPath(StartPosition.position, TargetPosition.position);
        grid.Path = gridPath;
    }

    public List<Node> FindPath(Vector3 a_StartPos, Vector3 a_TargetPos) {
        Node StartNode = grid.NodeFromWorldPosition(a_StartPos);
        Node TargetNode = grid.NodeFromWorldPosition(a_TargetPos);

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();
        OpenList.Add(StartNode);

        while (OpenList.Count > 0) {
            Node CurrentNode = OpenList[0];

            for (int i = 1; i < OpenList.Count; i++) {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].hCost < CurrentNode.hCost) {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);
            if (CurrentNode == TargetNode) {
                gridPath = GetPath(StartNode, TargetNode);
                secondPath = GetPath(StartNode, TargetNode);
                return secondPath;
            }

            foreach (Node NeighborNode in grid.GetNeighboringNodes(CurrentNode)) {
                if (NeighborNode.IsWall || ClosedList.Contains(NeighborNode)) {
                    continue;
                }
                
                int MoveCost = CurrentNode.gCost + GetManhattenDistance(CurrentNode, NeighborNode);

                if (MoveCost < NeighborNode.gCost || !OpenList.Contains(NeighborNode)) {
                    NeighborNode.gCost = MoveCost;
                    NeighborNode.hCost = GetManhattenDistance(NeighborNode, TargetNode);
                    NeighborNode.Parent = CurrentNode;

                    if (!OpenList.Contains(NeighborNode)) {
                        OpenList.Add(NeighborNode);
                    }
                }
            }
        }
        return null;
    }

    List<Node> GetPath(Node a_StartingNode, Node a_EndNode) {
        List<Node> Path = new List<Node>();
        Node CurrentNode = a_EndNode;

        while (CurrentNode != a_StartingNode) {
            Path.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }

        Path.Reverse();

        return Path;

    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB) {
        int x = Mathf.Abs(a_nodeA.gridX - a_nodeB.gridX);
        int y = Mathf.Abs(a_nodeA.gridY - a_nodeB.gridY);

        return x + y;
    }
}
