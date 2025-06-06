using UnityEngine;

public static class CompletedLevelAndStarsEarned
{
    private const string STAR_LEVEL_PREFIX = "Stars_Level_";

    public static void SaveCompletedLevel(int newCompletedLevelNo, int isLevelCompleted)
    {
        PlayerPrefs.SetInt($"LEVEL{newCompletedLevelNo}", isLevelCompleted);
    }
    public static int LoadCompletedLevel(int levelNo)
    {

        return PlayerPrefs.GetInt($"LEVEL{levelNo}");
    }
    public static void SaveStarsForLevel(int level, int stars)
    {
        PlayerPrefs.SetInt(STAR_LEVEL_PREFIX + level, stars);
    }

    public static int LoadStarsForLevel(int level)
    {
        return PlayerPrefs.GetInt(STAR_LEVEL_PREFIX + level);
    }
}
