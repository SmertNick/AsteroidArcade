using UnityEngine;

public class DamagedSplit : MonoBehaviour, IDamaged
{
    [SerializeField] private GameObject splitsInTo;
    [SerializeField] private float spawnOffset = .3f;
    
    public void Damaged()
    {
        GetComponent<Collider2D>().isTrigger = true;
        var offset1 = new Vector3(
            Random.Range(-spawnOffset, spawnOffset),
            Random.Range(-spawnOffset, spawnOffset),
            0f);
        var offset2 = new Vector3(
            Random.Range(-spawnOffset, spawnOffset),
            Random.Range(-spawnOffset, spawnOffset),
            0f);
        Instantiate(splitsInTo, transform.position + offset1, 
            Quaternion.LookRotation(Vector3.back, offset1));
        Instantiate(splitsInTo, transform.position - offset2,
            Quaternion.LookRotation(Vector3.back, -offset2));
    }
}
