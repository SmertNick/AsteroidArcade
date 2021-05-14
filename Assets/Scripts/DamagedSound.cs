using UnityEngine;

public class DamagedSound : MonoBehaviour, IDamaged
{
    [SerializeField] private AudioClip explosionSound;

    public void Damaged()
    {
        // Play sound
        Events.PlayFX(explosionSound);
    }
}
