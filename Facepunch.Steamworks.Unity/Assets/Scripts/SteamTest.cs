using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Facepunch.Steamworks;

public class SteamTest : MonoBehaviour
{
    private ServerList.Request serverRequest;
    private Leaderboard leaderBoard;

    private Vector2 achievementScrollPosition;


    void Start ()
	{
        //
        // Don't destroy this when loading new scenes
        //
        DontDestroyOnLoad( gameObject );

        //
        // Configure for Unity
        // This is VERY important - call this before 
        //
	    Facepunch.Steamworks.Config.ForUnity( Application.platform.ToString() );

        //
        // Create the steam client using Rust's AppId
        //
        new Facepunch.Steamworks.Client( 252490 );

        //
        // Make sure we started up okay
        //
        if ( Client.Instance == null )
        {
            Debug.LogError( "Error starting Steam!" );
            return;
        }

        //
        // Request a list of servers
        //
	    {
	        serverRequest = Client.Instance.ServerList.Internet();
	    }

        //
        // Request a leaderboard
        //
	    {
            leaderBoard = Client.Instance.GetLeaderboard( "TestLeaderboard", Client.LeaderboardSortMethod.Ascending, Client.LeaderboardDisplayType.Numeric );
        }
	}

    private void OnDestroy()
    {
        if ( Client.Instance != null )
        {
            Client.Instance.Dispose();
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea( new Rect( 16, 16, Screen.width - 32, Screen.height - 32 ) );

        if ( Client.Instance != null )
        {
            GUILayout.Label( "SteamId: " + Client.Instance.SteamId );
            GUILayout.Label( "Username: " + Client.Instance.Username );

            GUILayout.Label( "Friend Count: " + Client.Instance.Friends.AllFriends.Count() );
            GUILayout.Label( "Online Friend Count: " + Client.Instance.Friends.AllFriends.Count( x => x.IsOnline ) );

            //get the achievements
            GUILayout.Label("============== Achievements  ==============");
            GUILayout.Label("Achievement Count: " + Client.Instance.Achievements.All.Count() );
            
            //list all the achievements
            foreach ( var result in Client.Instance.Achievements.All )
            {
                GUILayout.Label("- " + result.Name);
            }

            GUILayout.Label("============================");

        
        }
        else
        {
            GUILayout.Label( "SteamClient Failed. Make sure appropriate files are in root, and steam is running and signed in." );
        }

        GUILayout.EndArea();
    }

    void Update()
    {
        if ( Client.Instance != null )
        {
            Client.Instance.Update();
        }
    }

}
