using UnityEngine;

public class DriveWay : MonoBehaviour
{
    // Array of materials to cycle through
    public MaterialData[] wallMaterials;

    // Current index of the active material
    public int currentMaterialIndex = 0;

    // Reference to the Renderer component
    private Renderer renderer;

    private void Awake()
    {
        // Get the Renderer component attached to this GameObject
        renderer = GetComponent<Renderer>();

        // Set the initial material
        if (wallMaterials.Length > 0)
        {
            // get the mat & carbon footprint from the array of material data
            
                renderer.material = wallMaterials[currentMaterialIndex].material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
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
        // Increment the current material index
        currentMaterialIndex = (currentMaterialIndex + 1) % wallMaterials.Length;

        // Update the wall's material
        renderer.material = wallMaterials[currentMaterialIndex].material;

        // Log the change
        Debug.Log($"Material changed to: {wallMaterials[currentMaterialIndex].name}");
    }

    public MaterialData GetCurrentMaterial()
    {
        return wallMaterials[currentMaterialIndex];
    }
}
