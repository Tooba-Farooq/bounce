using UnityEngine;

public static class SavingCompletedLevel 
{
    private const string COMPLETED_LEVEL_KEY = "Level Completed";
    private const string STARS_NUMBER1_KEY = "No of Stars Level 1";
    private const string STARS_NUMBER2_KEY = "No of Stars Level 2";

    public static void SaveCompletedLevel(int newCompletedLevel)
    {
        PlayerPrefs.SetInt(COMPLETED_LEVEL_KEY, newCompletedLevel);
    }
    public static int LoadCompletedLevel()
    {

        return PlayerPrefs.GetInt(COMPLETED_LEVEL_KEY);
    }

    //public static void SaveNoOfStars1(int starsNo)
    //{
    //    PlayerPrefs.SetInt(STARS_NUMBER1_KEY, starsNo);
    //}

    //public static int LoadNoOfStars1()
    //{

    //    return PlayerPrefs.GetInt(STARS_NUMBER1_KEY);
    //}

    //public static void SaveNoOfStars2(int starsNo)
    //{
    //    PlayerPrefs.SetInt(STARS_NUMBER2_KEY, starsNo);
    //}

    //public static int LoadNoOfStars2()
    //{

    //    return PlayerPrefs.GetInt(STARS_NUMBER2_KEY);
    //}


}






