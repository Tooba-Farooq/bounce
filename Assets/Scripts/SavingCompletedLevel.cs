using UnityEngine;

public static class SavingCompletedLevel 
{
    private const string COMPLETED_LEVEL_KEY = "Level Completed";
    public static void SaveCompletedLevel(int newCompletedLevel)
    {
        PlayerPrefs.SetInt(COMPLETED_LEVEL_KEY, newCompletedLevel);
    }
    public static int LoadCompletedLevel()
    {

        return PlayerPrefs.GetInt(COMPLETED_LEVEL_KEY);
    }

}


    

   

