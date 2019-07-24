using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

    public Color pathColor;
    public bool drawNodes = true;
    public bool drawLines = true;
    private List<Transform> nodes;

    void OnDrawGizmos()
    {
        Gizmos.color = pathColor;

        nodes =  getNodes();

        drawLinesAndNodes();


    }

    public List<Transform> getNodes()
    {
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        List<Transform> allNodes = new List<Transform>();

        foreach (Transform t in pathTransform)
        {
            if (t != transform)
            {
                allNodes.Add(t);
            }
        }
        return allNodes;
    }

    private void drawLinesAndNodes()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;
            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }

            if (drawNodes)
                Gizmos.DrawWireSphere(currentNode, 0.3f);
            if (drawLines)
                Gizmos.DrawLine(previousNode, currentNode);
        }
    }
 
}
