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
	// text and image of the character to be displayed
	public Text CharacterName;
	public Image CharacterImage;

	// data associated with the character
	private ID_Character m_dataCharacter;

	////////////////////////////////
	/// Init()
	////////////////////////////////
	public void Init( ID_Character i_dataCharacter ) {
		m_dataCharacter = i_dataCharacter;

		string strKey = i_dataCharacter.character;

		string strName = StringTableManager.Get( "Name_" + strKey );
		Sprite spriteImage = Resources.Load<Sprite>( strKey );

		CharacterName.text = strName;
		CharacterImage.sprite = spriteImage;
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
