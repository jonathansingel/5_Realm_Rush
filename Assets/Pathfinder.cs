using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool isRunning = true;
    private Waypoint searchCenter;
    private List<Waypoint> path = new List<Waypoint>();

    [SerializeField] Waypoint startPoint, endPoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEndBlocks();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endPoint);

        Waypoint previous = endPoint.exploredFrom;
        while(previous != startPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startPoint);
        path.Reverse();
    }

    private void ColorStartAndEndBlocks()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            HaltIfEndFound();
            ExploreNeighbors();
        }



    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
        }
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>(); 
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    private void ExploreNeighbors()
    {
        if (isRunning)
        {
            foreach (Vector2Int direction in directions)
            {
                Vector2Int possiblePosition = searchCenter.GetGridPos() + direction;
                if(grid.ContainsKey(possiblePosition))
                {
                    QueueNewNeighbor(possiblePosition);
                }
            }
        }
    }

    private void QueueNewNeighbor(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (!neighbor.isExplored || queue.Contains(neighbor))
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
