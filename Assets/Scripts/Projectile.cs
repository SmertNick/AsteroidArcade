using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileConfig config;

    private Rigidbody2D body;
    
    private void Awake()
    {
        // Getting reference to rigidbody
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Shooting "forward"
        body.AddForce(config.Speed * transform.up);
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        // Deactivating after lifetime expires
        yield return new WaitForSeconds(config.LifeTime);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Dealing with hit
        var damageables = other.collider.GetComponents<IDamaged>();
        // Get all effects of being hit
        if (damageables == null) return;
        foreach (var damageable in damageables)
        {
            // Trigger all the effects of being hit
            damageable.Damaged();
        }
        // Destroy object after all effects are triggered
        Destroy(other.gameObject);
        // Switching off for later use
        gameObject.SetActive(false);
    }
}