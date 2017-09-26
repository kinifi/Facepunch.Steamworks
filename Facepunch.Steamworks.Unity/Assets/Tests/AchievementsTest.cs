using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Facepunch.Steamworks;

// public class AchievementsTest {

// 	[Test]
// 	public void AchievementsTestSimplePasses() {
// 		// Use the Assert class to test conditions.
// 	}

// 	// A UnityTest behaves like a coroutine in PlayMode
// 	// and allows you to yield null to skip a frame in EditMode
// 	[UnityTest]
// 	public IEnumerator AchievementsTestWithEnumeratorPasses() {
// 		// Use the Assert class to test conditions.
// 		// yield to skip a frame
// 		yield return null;
// 	}
// }

public class ClientTests
    {
		[UnityTest]
		public IEnumerator GetCurrentLanguage()
		{
			if ( Client.Instance == null )
			{
				Facepunch.Steamworks.Config.ForUnity( Application.platform.ToString() );
				new Facepunch.Steamworks.Client( 252490 );
				
				yield return new WaitForEndOfFrame();
			}
			if ( Client.Instance == null )
			{
				Debug.LogError( "Error starting Steam!" );
			}

			Assert.IsNotNull(Client.Instance.CurrentLanguage, "Current Language: " + Client.Instance.CurrentLanguage);
		}

		[UnityTest]
        public IEnumerator GetUserName()
        {
			if ( Client.Instance == null )
			{
				Facepunch.Steamworks.Config.ForUnity( Application.platform.ToString() );
				new Facepunch.Steamworks.Client( 252490 );
				
				yield return new WaitForEndOfFrame();
			}
			if ( Client.Instance == null )
			{
				Debug.LogError( "Error starting Steam!" );
			}
			
			Assert.IsNotNull(Client.Instance.Username, "UserName Found");
        }

		[UnityTest]
        public IEnumerator GetSteamID()
        {
			if ( Client.Instance == null )
			{
				Facepunch.Steamworks.Config.ForUnity( Application.platform.ToString() );
				new Facepunch.Steamworks.Client( 252490 );
				
				yield return new WaitForEndOfFrame();
			}

			if ( Client.Instance == null )
			{
				Debug.LogError( "Error starting Steam!" );
			}
			
			Assert.IsNotNull(Client.Instance.SteamId, "SteamID Found");
        }

    }
