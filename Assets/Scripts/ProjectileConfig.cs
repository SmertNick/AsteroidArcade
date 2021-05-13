using UnityEngine;

[CreateAssetMenu(fileName = "Projectile config.asset", menuName = "Asteroid Game/Projectile Config")]
public class ProjectileConfig : ScriptableObject
{
    [SerializeField] private float speed = 300f;
    public float Speed => speed;

    [SerializeField] private float lifeTime = 2f;
    public float LifeTime => lifeTime;
}