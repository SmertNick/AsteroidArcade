using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Asteroid : MonoBehaviour
{
    public AsteroidConfig config;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        // Getting reference to rigidbody
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Giving velocity "forward"
        body.AddForce(config.Speed * transform.up);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Dealing with hit
        var player = other.collider.GetComponent<PlayerController>();
        if (player == null) return;
        // TODO If we hit player do smth bad
        // Destroying
        Destroy(gameObject);
    }
}