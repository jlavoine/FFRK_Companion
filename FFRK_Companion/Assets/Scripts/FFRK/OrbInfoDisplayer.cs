using UnityEngine;
using System.Collections;

public class OrbInfoDisplayer : MonoBehaviour {
	public GameObject OrbInfoHolder;

	///////////////////////////////////////////
	/// Start()
	///////////////////////////////////////////
	void Start () {
		// listen for messages
		Messenger.AddListener( "PrepOrbInfo", OnOrbSelected );	
		Messenger.AddListener( "CloseOrbInfo", CloseInfo );	

		CloseInfo();
	}
	
	///////////////////////////////////////////
	/// OnDestroy()
	///////////////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener( "PrepOrbInfo", OnOrbSelected );
		Messenger.RemoveListener( "CloseOrbInfo", CloseInfo );	
	}

	private void OnOrbSelected() {
		// move the panel into place
		OrbInfoHolder.SetActive( true );
	}

	private void CloseInfo() {
		OrbInfoHolder.SetActive( false );
	}
}
