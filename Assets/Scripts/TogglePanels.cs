using UnityEngine;

public class TogglePanels : MonoBehaviour
{
    public int footprint = 2500000;
    public int opCO2 = 5400000;

    public void TogglePanel()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
    }
}
