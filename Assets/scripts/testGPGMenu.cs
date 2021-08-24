using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class testGPGMenu : MonoBehaviour {
    
    //public GUISkin skin;
    public int incrementalCount = 5;

    //leaderboard strings
    private string leaderboard = "CgkI6bvEmZEIEAIQAg";
    //achievement strings
    private string achievement = "CgkI6bvEmZEIEAIQAA";
    private string incremental = "CgkI6bvEmZEIEAIQAQ";

    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();
    }

    // Update is called once per frame
    public void OnGUI()
    {
        //GUI.skin = skin;
        //skin.button.fixedWidth = Screen.width - 25;
        //skin.textField.fixedWidth = Screen.width - 25;
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        GUILayout.BeginVertical("box");

        GUILayout.Label("Official Google Play Games Services");

        GUILayout.FlexibleSpace();

        //Share Status
        if (GUILayout.Button("Log In", GUILayout.Height(50f)))
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("You've successfully logged in");
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }

        GUILayout.Space(20);

        
        //Achievement
        if (GUILayout.Button("Unlock Achievement", GUILayout.Height(50f)))
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportProgress(achievement, 100.0f, (bool success) =>
                {
                    if (success)
                    {
                        Debug.Log("You've successfully logged in");
                    }
                    else
                    {
                        Debug.Log("Login failed for some reason");
                    }
                });
            }
        }

        GUILayout.FlexibleSpace();

        //Incremental Achievement
        if (GUILayout.Button("Press " + incrementalCount + "more times to unlock incremental acheivment", GUILayout.Height(50f)))
        {
            if (Social.localUser.authenticated)
            {
                ((PlayGamesPlatform)Social.Active).IncrementAchievement(incremental, 5, (bool success) =>
                {
                    //The achievement unlocked successfully
                });
            }
        }

        GUILayout.FlexibleSpace();

        //Leaderboard
        if (GUILayout.Button("Post your 5000 points to the leaderboard", GUILayout.Height(50f)))
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportScore(5000, leaderboard, (bool success) =>
                {
                    if (success)
                    {
                        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
                    }
                    else
                    {
                        //Debug.Log("Login failed for some reason");
                    }
                });
            }
        }

        GUILayout.FlexibleSpace();

        // Show Leaderboard
        if (GUILayout.Button("Show Leaderboard", GUILayout.Height(50f)))
        {
            Social.ShowLeaderboardUI();
        }

        GUILayout.FlexibleSpace();

        //Show Specific Leaderboard
        if (GUILayout.Button("Show Specific Leaderboard", GUILayout.Height(50f)))
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
        }

        GUILayout.FlexibleSpace();

        //Show Achievments
        if (GUILayout.Button("Show Achievments", GUILayout.Height(50f)))
        {
            Social.ShowAchievementsUI();
        }

        GUILayout.FlexibleSpace();
        
        //Sign Out
        if (GUILayout.Button("Sign Out", GUILayout.Height(50f)))
        {
            ((PlayGamesPlatform)Social.Active).SignOut();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
    
}
