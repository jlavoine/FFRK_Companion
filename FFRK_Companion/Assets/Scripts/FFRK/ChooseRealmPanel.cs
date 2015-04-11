using UnityEngine;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////
/// ChooseRealmPanel
/// Panel that displays all
/// realms in the game for
/// the user to pick one from.
////////////////////////////////

public class ChooseRealmPanel : MonoBehaviour {
	// prefab for realm button
	public GameObject RealmButton;
	
	// rect where the buttons go
	public GameObject Content;
	
	// scrollable area that holds everything
	public GameObject ScrollArea;
	
	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		// we need to create a unique list of realms...let's cull it from the items
		List<ID_Item> listItems = IDL_Items.GetItems();
		List<string> listRealms = new List<string>();

		GameObject goButtonAll = GameObject.Instantiate( RealmButton );
		goButtonAll.transform.SetParent( Content.transform, false );
		
		ChooseRealmButton buttonAll = goButtonAll.GetComponent<ChooseRealmButton>();
		buttonAll.Init( "All" );

		for ( int i = 0; i < listItems.Count; ++i ) {
			ID_Item item = listItems[i];
			string strRealm = item.realm;

			if ( listRealms.Contains( strRealm ) == false ) {
				listRealms.Add( strRealm );

				// add the realm!
				GameObject goButton = GameObject.Instantiate( RealmButton );
				goButton.transform.SetParent( Content.transform, false );
				
				ChooseRealmButton button = goButton.GetComponent<ChooseRealmButton>();
				button.Init( strRealm );
			}
		}
		
		// listen for messages
		Messenger.AddListener<string>( "RealmSelected", OnRealmSelected );
		Messenger.AddListener( "ShowChooseRealmPanel", OnShowPanel );
		
		SetVis( false );
	}
	
	////////////////////////////////
	/// OnDestroy()
	////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener<string>( "RealmSelected", OnRealmSelected );
		Messenger.RemoveListener( "ShowChooseRealmPanel", OnShowPanel );
	}
	
	////////////////////////////////
	/// OnShowPanel()
	/// Callback for when something
	/// wants this panel to show.
	////////////////////////////////
	private void OnShowPanel() {
		// turn it on!
		SetVis( true );
	}
	
	////////////////////////////////
	/// SetVis()
	/// We control the visibility of
	/// this panel by setting the
	/// scroll area (which contains
	/// everything) on and off.
	////////////////////////////////
	private void SetVis( bool i_bVis ) {
		ScrollArea.SetActive( i_bVis );
	}
	
	////////////////////////////////
	/// OnRealmSelected()
	/// Callback for when the user
	/// picks a realm.
	////////////////////////////////
	private void OnRealmSelected( string i_strRealm ) {
		// this panel has served its purpose, so turn it off
		SetVis( false );
	}
}
