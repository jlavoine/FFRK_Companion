using UnityEngine;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////
/// ChooseCharacterPanel
/// Panel that displays all
/// characters in the game for
/// the user to pick one from.
////////////////////////////////

public class ChooseCharacterPanel : MonoBehaviour {
	// prefab for character button
	public GameObject CharacterButton;

	// rect where the characters go
	public GameObject Content;

	// scrollable area that holds everything
	public GameObject ScrollArea;

	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		// fill in the panel with all our characters!
		List<ID_Character> listChars = IDL_Characters.GetCharacters();

		// loop through all the characters and create a button for each
		for ( int i = 0; i < listChars.Count; ++i ) {
			ID_Character dataCharacter = listChars[i];
			GameObject goButton = GameObject.Instantiate( CharacterButton );
			goButton.transform.SetParent( Content.transform, false );

			ChooseCharacterButton button = goButton.GetComponent<ChooseCharacterButton>();
			button.Init( dataCharacter );
		}

		// listen for messages
		Messenger.AddListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
		Messenger.AddListener( "ShowChooseCharacterPanel", OnShowPanel );

		SetVis( false );
	}

	////////////////////////////////
	/// OnDestroy()
	////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
		Messenger.RemoveListener( "ShowChooseCharacterPanel", OnShowPanel );
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
	/// OnCharacterSelected()
	/// Callback for when the user
	/// picks a char.
	////////////////////////////////
	private void OnCharacterSelected( ID_Character i_dataChar ) {
		// this panel has served its purpose, so turn it off
		SetVis( false );
	}
}
