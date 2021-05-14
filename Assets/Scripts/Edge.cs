using UnityEngine;

public enum Orientation {Horizontal = 0, Vertical = 1}
public class Edge : MonoBehaviour
{
    [SerializeField] private Orientation orientation;
    private Vector3 limit;

    private void Awake()
    {
        limit = transform.position;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var otherPosition = other.transform.position;
        var x = otherPosition.x;
        var y = otherPosition.y;
        
        if ((int)orientation == 0 && Mathf.Abs(y) > Mathf.Abs(limit.y))
        {
            other.transform.position = new Vector3(x, -limit.y-Mathf.Epsilon, 0f);
        }

        if ((int) orientation == 1 && Mathf.Abs(x) > Mathf.Abs(limit.x))
        {
            other.transform.position = new Vector3(-limit.x - Mathf.Epsilon, y, 0f);
        }
    }
}