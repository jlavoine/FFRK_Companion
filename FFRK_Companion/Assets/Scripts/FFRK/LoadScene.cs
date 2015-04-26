using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

// co-opting this class hard core as the first thing that happens on app load...

public class LoadScene : MonoBehaviour, IPointerClickHandler {
	public bool Instant;

	void Start() {
		if ( Instant ) {
			Application.LoadLevel( Scene );

#if UNITY_IOS
			if((UnityEngine.iOS.Device.generation.ToString()).IndexOf("iPad") > -1){
				Screen.SetResolution(1024,768,true);
			}
			else if ( UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone6Plus )
				Screen.SetResolution(1104,621,true);
#endif
		}
	}

	public string Scene;
	public void SetScene( string i_strScene ) {
		Scene = i_strScene;
	}

	public void OnPointerClick( PointerEventData i_data ) {
		Application.LoadLevel( Scene );
	}
}
