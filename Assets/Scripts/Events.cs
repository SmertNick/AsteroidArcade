using UnityEngine;

public static class Events
{
    #region Score
    public delegate void ScoreChangeDelegate(int score);
    public static event ScoreChangeDelegate ScoreChanged;
    public static void AddScore(int score)
    {
        ScoreChanged?.Invoke(score);
    }
    #endregion

    #region Sound
    public delegate void FXDelegate (AudioClip clip);
    public static event FXDelegate FXPlayed;
    public static void PlayFX(AudioClip clip)
    {
        FXPlayed?.Invoke(clip);
    }
    #endregion

    #region Lives
    public delegate void LivesChangeDelegate(int lives);
    public static event LivesChangeDelegate LivesChanged;
    public static void ChangeLives(int lives)
    {
        LivesChanged?.Invoke(lives);
    }
    #endregion
}
