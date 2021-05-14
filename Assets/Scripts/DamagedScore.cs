using UnityEngine;
using UnityEngine.UI;

public class DamagedScore : MonoBehaviour, IDamaged
{
    [SerializeField] private Text scoreText;
    
    public void Damaged()
    {
        // TODO update score
    }
}
