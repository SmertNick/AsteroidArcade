using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private GridLayoutGroup grid;
    private readonly List<GameObject> livesIcons = new List<GameObject>();

    private void Awake()
    {
        grid = GetComponent<GridLayoutGroup>();
        var images = grid.GetComponentsInChildren<Image>();
        // Getting references to all livesIcons
        foreach (var image in images)
        {
            livesIcons.Add(image.gameObject);
        }
        // Subscribing to when lives are changed
        Events.LivesChanged += OnLivesChanged;
    }
    private void OnLivesChanged(int lives)
    {
        for (int i = livesIcons.Count - 1; i > -1; i--)
        {
            // Disabling extra lives 
            livesIcons[i].SetActive(i < lives);
        }
    }

    private void OnDestroy()
    {
        Events.LivesChanged += OnLivesChanged;
    }
}
