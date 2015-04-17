using UnityEngine;
using System.Collections;
using UnityEngine.UI;

////////////////////////////////
/// ChooseCharacterButton
/// This button is on the panel
/// that shows all characters in
/// the game for the user to
/// choose from.
////////////////////////////////

public class ChooseCharacterButton : MonoBehaviour {
	// data associated with the character
	private ID_Character m_dataCharacter;

	// identifier
	public CharacterIdentifier Identifier;

	////////////////////////////////
	/// Init()
	////////////////////////////////
	public void Init( ID_Character i_dataCharacter ) {
		m_dataCharacter = i_dataCharacter;
	
		// init the identifier
		Identifier.Init( i_dataCharacter );
	}

	////////////////////////////////
	/// CharacterSelected()
	/// Function called when the user
	/// clicks on this button.
	////////////////////////////////
	public void CharacterSelected() {
		// let everything else know a char has been picked
		Messenger.Broadcast<ID_Character>( "CharacterSelected", m_dataCharacter );
	}
}
