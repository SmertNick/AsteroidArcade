using UnityEngine;

public class DamagedParticles : MonoBehaviour, IDamaged
{
    [SerializeField] private GameObject particlesPrefab;
    
    public void Damaged()
    {
        // TODO emmit particles
    }
}
