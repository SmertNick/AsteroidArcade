using UnityEngine;

public class PlayerDamagedLives : MonoBehaviour, IPlayer
{
    private int livesRemaining;

    private void Start()
    {
        livesRemaining = GetComponent<PlayerController>().config.MaxLives;
        Events.ChangeLives(livesRemaining);
    }

    public void Damaged()
    {
        // Manage remaining lives
        livesRemaining--;
        Events.ChangeLives(livesRemaining);
        if (livesRemaining < 0)
        {
            // TODO Handle Death state.
        }
    }
}
