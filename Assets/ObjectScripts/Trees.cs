using UnityEngine;

public class Trees : MonoBehaviour
{
    public int treeCount;
    public int opCO2 = 1100000;

    public void addTree()
    {
        treeCount++;
    }

    public void RemoveTree()
    {
        treeCount--;
    }
}
