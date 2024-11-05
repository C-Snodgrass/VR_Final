using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class FootprintUI : MonoBehaviour
{

    public GameObject infoPanel;

    public ParticleSystem gasEffect;

    public WallInterior interior;
    public WallExterior exterior;
    public Vehicles vehicles;
    public Heating heating;
    public Floor floor;
    public DriveWay driveway;
    public Trees trees;
    public TogglePanels panels;

    private TMP_Text[] infoTexts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infoTexts = infoPanel.transform.GetComponentsInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float totalEmissions = 0;

        MaterialData currentMat = exterior.GetCurrentMaterial();
        infoTexts[1].text = currentMat.materialName + " Exterior: " + currentMat.carbonFootprint + "g/m^3";
        totalEmissions += currentMat.carbonFootprint;

        currentMat = interior.GetCurrentMaterial();
        infoTexts[2].text = currentMat.materialName + " Interior: " + currentMat.carbonFootprint + "g/m^3";
        totalEmissions += currentMat.carbonFootprint;

        currentMat = floor.GetCurrentMaterial();
        infoTexts[3].text = currentMat.materialName + " Floor: " + currentMat.carbonFootprint + "g/m^3";
        totalEmissions += currentMat.carbonFootprint;

        currentMat = driveway.GetCurrentMaterial();
        infoTexts[4].text = currentMat.materialName + " Driveway: " + currentMat.carbonFootprint + "g/m^3";
        totalEmissions += currentMat.carbonFootprint;

        currentMat = vehicles.GetCurrentMaterial();
        infoTexts[5].text = currentMat.materialName + ": " + currentMat.carbonFootprint + "g/km";

        currentMat = heating.GetCurrentMaterial();
        infoTexts[6].text = currentMat.materialName + " Heating: " + currentMat.carbonFootprint + "g";

        //currentMat = lights.GetCurrentMaterial();
        //infoTexts[7].text = currentMat.name + " Heating: " + currentMat.carbonFootprint;

        string solarText = panels.gameObject.activeSelf ? "-" + panels.opCO2 + "g Over Lifetime" : "None";
        infoTexts[8].text = "Solar: " + solarText;

        string treeText = trees.treeCount > 0 ? "-" + trees.opCO2 * trees.treeCount + "g Over 50 Years" : "None";
        infoTexts[9].text = trees.treeCount + " Trees: " + treeText;

        infoTexts[10].text = "Yearly Offset: ";

        infoTexts[11].text = "Total Emissions: " + totalEmissions + "g/m^3";
    }

    public void ToggleParticles()
    {
        if (gasEffect.isPlaying)
        {
            gasEffect.Stop();
        } else
        {
            gasEffect.Play();
        }
    }
}
