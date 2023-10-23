using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
    private static System.Random rng = new System.Random();

    public static void ShuffleTrials(Trial[] trials) 
    {
        Shuffle(trials);
        CheckRepeating(trials);
    }

    private static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private static bool IsValid(Trial previous, Trial current) 
    {
        if (previous.GetVib() == false || current.GetVib() == false) 
        {
            return true;
        }
        else 
        {
            return previous.GetVibrationSetting() != current.GetVibrationSetting();
        }
        
    }

    private static void CheckRepeating(Trial[] trials)
    {
        for (int i = 1; i < trials.Length; i++)
        {
            if (!IsValid(trials[i - 1], trials[i]))
            {
                int swapIndex = -1;

                // Find the next valid trial
                for (int j = i + 1; j < trials.Length; j++)
                {
                    if (IsValid(trials[i - 1], trials[j]))
                    {
                        swapIndex = j;
                        break;
                    }
                }

                // If a valid trial is found, swap it
                if (swapIndex != -1)
                {
                    Trial temp = trials[i];
                    trials[i] = trials[swapIndex];
                    trials[swapIndex] = temp;
                }
                else
                {
                    // Fallback strategy if no valid trial is found
                    // For simplicity, reshuffling the entire array is an option. 
                    // More efficient strategies can be designed based on the exact requirements.
                    //ShuffleTrials(trials);
                    // return;
                    Debug.LogWarning("Have not found a suitable spot for trials array element!");
                }
            }
        }
    }
}
