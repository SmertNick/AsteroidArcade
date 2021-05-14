using UnityEngine;

public class DamagedScore : MonoBehaviour, IDamaged
{
    private int score;
    private void Start()
    {
        score = GetComponent<Asteroid>().config.ScorePoints;
    }

    public void Damaged()
    {
        // Update score
        Events.AddScore(score);
    }
}
