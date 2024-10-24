using UnityEngine;

public class WallInterior : MonoBehaviour
{
    // Array of materials to cycle through
    public MaterialData[] wallMaterials;

    // Current index of the active material
    private int currentMaterialIndex = 0;

    // Reference to the Renderer component
    private Renderer wallRenderer;

    public float carbonFootprint;

    private void Awake()
    {
        // Get the Renderer component attached to this GameObject
        wallRenderer = GetComponent<Renderer>();

        // Set the initial material
        if (wallMaterials.Length > 0)
        {
            // get the mat & carbon footprint from the array of material data
            wallRenderer.material = wallMaterials[currentMaterialIndex].material;
            carbonFootprint = wallMaterials[currentMaterialIndex].carbonFootprint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the poke gesture is detected
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) // Change to the appropriate button for your poke gesture
        {
            // Call your poke method
            OnPoke();
        }
    }

    // Method to handle poke interaction
    private void OnPoke()
    {
        Debug.Log("Poke gesture detected!");

        // Cycle to the next material
        CycleMaterial();
    }

    private void CycleMaterial()
    {
        // Increment the current material index
        currentMaterialIndex++;

        // Loop back to the first material if we've reached the end
        if (currentMaterialIndex >= wallMaterials.Length)
        {
            currentMaterialIndex = 0;
        }

        // Update the wall's material
        wallRenderer.material = wallMaterials[currentMaterialIndex].material;
        carbonFootprint= wallMaterials[currentMaterialIndex].carbonFootprint;

        // Log the change
        Debug.Log($"Material changed to: {wallMaterials[currentMaterialIndex].name}");
    }
}
