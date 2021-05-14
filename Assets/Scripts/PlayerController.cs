using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Reference to player stats
    [SerializeField] private PlayerConfig config;
    // Bullet pool
    private readonly List<GameObject> bullets = new List<GameObject>();
    // Where to spawn bullets when shooting
    [SerializeField] private Transform bulletSpawnPosition;

    // For player input
    private float forward = 0f, turn = 0f;
    private bool fireIsOnCooldown = false;
    
    // Temporary immunity after getting hit
    private bool isImmune = false;
    // OnDamage effects
    private IPlayer[] effects;

    // Component references
    private Rigidbody2D body;
    private Transform playerTransform;
    
    private void Awake()
    {
        // Cashing references
        body = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        effects = GetComponents<IPlayer>();
    }

    private void Start()
    {
        //Generate bullets pool
        GenerateBullets();
    }

    private void GenerateBullets()
    {
        // Generating pool of bullet objects
        for (int i = config.BulletsToGenerate; i > 0; i--)
        {
            var bullet = Instantiate(config.BulletPrefab);
            // Turning them off
            bullet.SetActive(false);
            // And adding to list
            bullets.Add(bullet);
        }
    }

    private void Update()
    {
        // Dealing with movement inputs
        forward = Mathf.Clamp(Input.GetAxisRaw("Vertical"), 0f, 1f);
        turn = Input.GetAxisRaw("Horizontal");
        
        // Dealing with firing input
        if (Input.GetButtonDown("Jump"))
            FireProjectile();
    }

    private void FixedUpdate()
    {
        // Rotating player in direction based on user input, around z-axis
        playerTransform.Rotate(Vector3.back, turn * Time.deltaTime * config.RotationSpeed);
        // Adding force "forward" based on rotation
        body.AddForce(forward * config.Acceleration * playerTransform.up, ForceMode2D.Force);
        // Clamping velocity
        body.velocity = Vector2.ClampMagnitude(body.velocity, config.MaxSpeed);
    }

    private void FireProjectile()
    {
        // Limiting fire rate
        if (fireIsOnCooldown) return;
        // If didn't fire recently - start cooldown t limit fire rate
        StartCoroutine((FireCooldown()));
        
        // Searching pool of bullets for first unused and enabling it
        foreach (var bullet in bullets.Where(bullet => !bullet.activeInHierarchy))
        {
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.transform.rotation = playerTransform.rotation;
            bullet.SetActive(true);
            Events.PlayFX(config.ShootingSound);
            return;
        }
    }

    private IEnumerator FireCooldown()
    {
        // Disabling firing
        fireIsOnCooldown = true;
        // Enabling firing after cooldown has passed
        yield return new WaitForSeconds(config.FireCooldownTime);
        fireIsOnCooldown = false;
    }

    public void Damage()
    {
        // If recently took damage - do nothing
        if (isImmune) return;
        // Else turn on immunity
        StartCoroutine(Immunity());
        // Get all onDamage effects
        if (effects == null) return;
        // Trigger them
        foreach (var effect in effects)
        {
            effect.Damaged();
        }
    }

    private IEnumerator Immunity()
    {
        isImmune = true;
        yield return new WaitForSeconds(config.ImmunityTime);
        isImmune = false;
    }
}