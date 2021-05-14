using UnityEngine;

public static class Events
{
    public delegate void ScoreChangeDelegate(int score);
    public static event ScoreChangeDelegate ScoreChanged;
    public static void AddScore(int score)
    {
        ScoreChanged?.Invoke(score);
    }
    
    public delegate void FXDelegate (AudioClip clip);
    public static event FXDelegate FXPlayed;
    public static void PlayFX(AudioClip clip)
    {
        FXPlayed?.Invoke(clip);
    }
    
}
