using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LoadScene : MonoBehaviour, IPointerClickHandler {
	public string Scene;
	public void SetScene( string i_strScene ) {
		Scene = i_strScene;
	}

	public void OnPointerClick( PointerEventData i_data ) {
		Application.LoadLevel( Scene );
	}
}
