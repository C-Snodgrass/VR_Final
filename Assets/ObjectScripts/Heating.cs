using UnityEngine;

public class Heating : MonoBehaviour
{
    // Array of materials to cycle through
    public MaterialData[] wallMaterials;

    // Reference to the different game objects
    public GameObject[] objects;

    // Current index of the active material
    public int currentMaterialIndex = 0;


    private void Awake()
    {
        // Get the Renderer component attached to this GameObject

        // Set the initial material
        if (wallMaterials.Length > 0)
        {
            // get the mat & carbon footprint from the array of material data
            objects[currentMaterialIndex].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CycleMaterial();
        }
    }

    // Method to handle poke interaction
    public void OnPoke()
    {
        Debug.Log("Poke gesture detected!");

        // Cycle to the next material
        CycleMaterial();
    }

    private void CycleMaterial()
    {
        objects[currentMaterialIndex].SetActive(false);
        // Increment the current material index
        currentMaterialIndex = (currentMaterialIndex + 1) % wallMaterials.Length;

        objects[currentMaterialIndex].SetActive(true);

        // Log the change
        Debug.Log($"Material changed to: {wallMaterials[currentMaterialIndex].name}");
    }

    public MaterialData GetCurrentMaterial()
    {
        return wallMaterials[currentMaterialIndex];
    }
}
