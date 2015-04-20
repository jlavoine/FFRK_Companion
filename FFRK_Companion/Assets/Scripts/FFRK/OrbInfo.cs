using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

///////////////////////////////////////////
/// OrbInfo
/// This screen contains detailed info on
/// a particular orb.
///////////////////////////////////////////

public class OrbInfo : MonoBehaviour {
	// name of the orb
	public Text Name;

	// icon of the orb
	public Image Icon;

	// where the orb can be found
	public Text Locations;

	// content area where dungeons go, showing where the orb is
	public GameObject DungeonContent;
	public GameObject DungeonEntry;

	///////////////////////////////////////////
	/// Start()
	///////////////////////////////////////////
	void Awake () {
		// listen for messages
		Messenger.AddListener<string, int>( "OrbSelected", OnOrbSelected );	
	}

	///////////////////////////////////////////
	/// OnDestroy()
	///////////////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener<string, int>( "OrbSelected", OnOrbSelected );
	}

	///////////////////////////////////////////
	/// OnOrbSelected()
	/// Callback for an an orb is selected.
	///////////////////////////////////////////
	private void OnOrbSelected( string i_strOrbKey, int i_nIndex ) {
		// build the final string of the orb based on its key and index
		string strOrb = i_strOrbKey + "_" + i_nIndex;

		// set the icon of the orb correctly
		//Sprite sprite = Resources.Load<Sprite>( strOrb );
		//Icon.sprite = sprite;

		// name the orb properly
		string strType = StringTableManager.Get( i_strOrbKey );
		string strPrefix = StringTableManager.Get( "Orb_" + i_nIndex );
		if ( i_nIndex == 3 )
			strPrefix = "";

		string strTitle = strPrefix + " " + strType;
		Name.text = strTitle + " Orb";

		// fill in the dungeon area
		ShowDungeons( strOrb );
	}

	private void ShowDungeons( string i_strOrb ) {
		// first delete everything
		DungeonContent.DestroyChildren();

		string strLocation = StringTableManager.Get( "OrbLocation" );
		Locations.text = strLocation;

		// get all dungeons and iterate through them, finding out which ones have the orb...
		List<ID_Dungeon> listDungeons = IDL_Dungeons.GetDungeons();
		for ( int i = 0; i < listDungeons.Count; ++i ) {
			ID_Dungeon dungeon = listDungeons[i];
			
			// add a normal location
			if ( dungeon.HasOrb( i_strOrb ) ) {
				GameObject goEntry = GameObject.Instantiate( DungeonEntry );
				goEntry.transform.SetParent( DungeonContent.transform );
				DungeonIdentifier identifier = goEntry.GetComponent<DungeonIdentifier>();
				identifier.Init( dungeon, false );
			}

			// add a boss location
			if ( dungeon.HasOrb_Boss( i_strOrb ) ) {
				GameObject goEntry = GameObject.Instantiate( DungeonEntry );
				goEntry.transform.SetParent( DungeonContent.transform );
				DungeonIdentifier identifier = goEntry.GetComponent<DungeonIdentifier>();
				identifier.Init( dungeon, true );
			}
		}
	}
}
