using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    public GameObject[] trees;

    private Trees treeData;

    private void Awake()
    {
        treeData = GetComponentInParent<Trees>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Seed")
        {
            int randomTree = Random.Range(0, trees.Length);
            Instantiate(trees[randomTree], transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            treeData.addTree();
        }
    }
}
