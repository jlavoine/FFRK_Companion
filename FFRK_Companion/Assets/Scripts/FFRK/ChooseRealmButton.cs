using UnityEngine;
using System.Collections;
using UnityEngine.UI;

////////////////////////////////
/// ChooseRealmButton
/// This button is on the panel
/// that shows all realms in
/// the game for the user to
/// choose from.
////////////////////////////////

public class ChooseRealmButton : MonoBehaviour {
	// text of the realm to be displayed
	public Text RealmName;
	
	// data associated with the realm
	private string m_strRealm;
	
	////////////////////////////////
	/// Init()
	////////////////////////////////
	public void Init( string i_strRealm ) {
		m_strRealm = i_strRealm;
	
		RealmName.text = i_strRealm;
	}
	
	////////////////////////////////
	/// RealmSelected()
	/// Function called when the user
	/// clicks on this button.
	////////////////////////////////
	public void RealmSelected() {
		// let everything else know a realm has been picked
		Messenger.Broadcast<string>( "RealmSelected", m_strRealm );
	}
}
