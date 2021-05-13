using UnityEngine;

[CreateAssetMenu(fileName = "Asteroid Config.asset", menuName = "Asteroid Game/Asteroid Config")]
public class AsteroidConfig : ScriptableObject
{
    [SerializeField] private float speed = 75f;
    public float Speed => speed;

    [SerializeField] private int scorePoints = 100;
    public int ScorePoints => scorePoints;
}