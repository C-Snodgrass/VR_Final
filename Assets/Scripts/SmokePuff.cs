using Unity.VisualScripting;
using UnityEngine;

public class SmokePuff : MonoBehaviour
{
    private ParticleSystem puff;

    private void Start()
    {
        puff = GetComponent<ParticleSystem>();    
    }

    public void OnEnable() {
        puff.Play();
    }
}
