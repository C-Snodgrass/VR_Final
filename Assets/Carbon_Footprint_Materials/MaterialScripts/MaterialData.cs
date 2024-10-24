using UnityEngine;

[CreateAssetMenu(fileName = "MaterialData", menuName = "ScriptableObjects/MaterialData", order = 1)]
public class MaterialData : ScriptableObject
{
    // Reference to the material
    public Material material;

    // Carbon footprint value
    public float carbonFootprint;

    // Optional: Name or description of the material
    public string materialName;
}

