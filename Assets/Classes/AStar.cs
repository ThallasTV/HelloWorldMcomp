using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar
{
    public static PriorityQueue openList;
    public static HashSet<Node> closedList;

    // Calculates the cost between the two nodes
    private static float HeuristicEstimateCost(Node curNode, Node goalNode)
    {
        Vector3 vecCost = curNode.position - goalNode.position;
        return vecCost.magnitude;
    }

    public static ArrayList FindPath(Node start, Node goal)
    {
        openList = new PriorityQueue();
        // Push the 'start' value into the queue
        openList.Push(start);
        // Set the total cost of the 'start' node to 0
        start.nodeTotalCost = 0.0f;
        // Input the 'start' and 'goal' values into the 'HeuristicEstimateCost' method
        start.estimatedCost = HeuristicEstimateCost(start, goal);

        closedList = new HashSet<Node>();
        Node node = null;

        // Initialise the open and closed lists
        while (openList.Length != 0)
        {
            //Get the first nod from the 'openList'
            node = openList.First(); // F
            //Check if the current node is the target node 
            if (node.position == goal.position)
            {
                return CalculatePath(node);
            }

            //Create an ArrayList to store the neighboring nodes 
            ArrayList neighbours = new ArrayList();

            // Retrieves the neighbours from the grid
            GridManager.instance.GetNeighbours(node, neighbours);

            for (int i = 0; i < neighbours.Count; i++)
            {
                Node neighbourNode = (Node)neighbours[i];

                // Checks if the neighbouring nods are already in the 'closedList'
                //if not calculate the cost, update the node properties with the new cost values
                if (!closedList.Contains(neighbourNode))
                {
                    float cost = HeuristicEstimateCost(node, neighbourNode);

                    float totalCost = node.nodeTotalCost + cost;
                    float neighbourNodeEstCost = HeuristicEstimateCost(neighbourNode, goal);

                    neighbourNode.nodeTotalCost = totalCost;
                    neighbourNode.parent = node;
                    neighbourNode.estimatedCost = totalCost + neighbourNodeEstCost;
                    
                    // Push to the 'openList'
                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Push(neighbourNode);
                    }
                }
            }
            
            //Add the current node to the closed list 
            closedList.Add(node);
            //and remove it from openList 
            openList.Remove(node);
        }

        if (node.position != goal.position)
        {
            Debug.LogError("Goal Not Found");
            return null;
        }
        return CalculatePath(node);
    }

    // Traces through each node's parent node object and builds an array list
    private static ArrayList CalculatePath(Node node)
    {
        ArrayList list = new ArrayList();
        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }
        list.Reverse();
        return list;
    }
}