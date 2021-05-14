using UnityEngine;

public class DamagedSound : MonoBehaviour, IDamaged
{
    [SerializeField] private AudioClip explosionSound;

    public void Damaged()
    {
        // Play sound
        AudioSource.PlayClipAtPoint(explosionSound, new Vector3(0f, 0f, -25f), 1f);
    }
}
