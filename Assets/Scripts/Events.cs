

using System;

public static class Events
{
    public static event Func<int> OnGetLives;
    public static int GetLives() => OnGetLives?.Invoke() ?? 0;
   
    public static event Action<int> OnChangeLives;
    public static void ChangeLives(int givenLives)
    {
        OnChangeLives?.Invoke(givenLives);
    }
}
