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
			if((iPhone.generation.ToString()).IndexOf("iPad") > -1){
				Screen.SetResolution(1024,768,true);
			}
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
