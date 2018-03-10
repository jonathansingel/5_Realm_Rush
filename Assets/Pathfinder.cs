using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool isRunning = true;

    [SerializeField] Waypoint startPoint, endPoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    // Use this for initialization
    void Start () {
        LoadBlocks();
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);

        Pathfind();
        //ExploreNeighbors(startPoint);
    }

    private void Pathfind()
    {
        queue.Enqueue(startPoint);

        Waypoint endFound;

        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from" + searchCenter);

            HaltIfEndFound(searchCenter);

            
        }

        print("Finished pathfinding?");


    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endPoint)
        {
            print("Searching from end node, therefore stopping");
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

    private void ExploreNeighbors(Waypoint waypoint)
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int possiblePosition = waypoint.GetGridPos() + direction;
            try
            {
                grid[possiblePosition].SetTopColor(Color.blue);
                print("Explorable block exists at " + possiblePosition);
            }
            catch
            {
                print("Explorable block does not exist at " + possiblePosition);
            }


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
