using UnityEngine;

[CreateAssetMenu(fileName = "Player Config.asset", menuName = "Asteroid Game/Player Config")]
public class PlayerConfig : ScriptableObject
{
    // In case we want to change players color
    [SerializeField] private Color playerColor = Color.white;
    public Color PlayerColor => playerColor;

    [SerializeField] private int maxLives = 3;
    public int MaxLives => maxLives;

    [SerializeField] private float acceleration = 1f;
    public float Acceleration => acceleration;

    [SerializeField] private float maxSpeed = 20f;
    public float MaxSpeed => maxSpeed;

    [SerializeField] private float rotationSpeed = 300f;
    public float RotationSpeed => rotationSpeed;

    [SerializeField] private float fireCooldownTime = 1f;
    public float FireCooldownTime => fireCooldownTime;

    // Bullet prefab from which object pool will be generated
    [SerializeField] private GameObject bulletPrefab;
    public GameObject BulletPrefab => bulletPrefab;

    // Amount of objects in the pool
    [SerializeField] private int bulletsToGenerate = 20;
    public int BulletsToGenerate => bulletsToGenerate;
}