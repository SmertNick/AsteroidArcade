using UnityEngine;

public class PlayerDamagedSound : MonoBehaviour, IPlayer
{
    [SerializeField] private AudioClip hitSound;
    public void Damaged()
    {
        // TODO play sound;
    }
}
