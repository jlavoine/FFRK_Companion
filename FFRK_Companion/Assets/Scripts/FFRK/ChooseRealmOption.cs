using UnityEngine;
using System.Collections;
using UnityEngine.UI;

////////////////////////////////
/// ChooseRealmOption
/// This is the button that lets
/// the user choose a realm
/// they'd like to see the items
/// for.
////////////////////////////////

public class ChooseRealmOption : MonoBehaviour {
	// text for the button
	public Text ButtonText;
	
	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		// set the button's initial text
		string strChoose = StringTableManager.Get( "ChooseRealm_Button" );
		ButtonText.text = strChoose;
		
		// listen for messages
		Messenger.AddListener<string>( "RealmSelected", OnRealmSelected );
	}
	
	////////////////////////////////
	/// OnDestroy()
	////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener<string>( "RealmSelected", OnRealmSelected );
	}
	
	////////////////////////////////
	/// OnClicked()
	/// Callback for when this button
	/// is clicked.
	////////////////////////////////
	public void OnClicked() {
		// we want to show the panel full of realms for the user to choose from
		Messenger.Broadcast( "ShowChooseRealmPanel" );
	}
	
	////////////////////////////////
	/// OnRealmSelected()
	/// Callback for when the user
	/// choose a character.
	////////////////////////////////
	private void OnRealmSelected( string i_strRealm ) {
		ShowRealm( i_strRealm );
	}
	
	////////////////////////////////
	/// ShowRealm()
	/// Sets the proper name for the
	/// incoming realm.
	////////////////////////////////
	private void ShowRealm( string i_strName ) {
		ButtonText.text = i_strName;
	}
}
