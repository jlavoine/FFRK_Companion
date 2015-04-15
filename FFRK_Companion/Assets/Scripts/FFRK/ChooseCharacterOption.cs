using UnityEngine;
using System.Collections;
using UnityEngine.UI;

////////////////////////////////
/// ChooseCharacterOption
/// This is the button that lets
/// the user choose a character
/// they'd like to see the items
/// for.
////////////////////////////////

public class ChooseCharacterOption : MonoBehaviour {
	// text for the button
	public Text ButtonText;

	// image for the button
	public Image ButtonImage;

	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		// set the button's initial text
		string strChoose = StringTableManager.Get( "ChooseCharacter_Button" );
		ButtonText.text = strChoose;

		// hide the image
		ButtonImage.enabled = false;

		// listen for messages
		Messenger.AddListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
	}

	////////////////////////////////
	/// OnDestroy()
	////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
	}

	////////////////////////////////
	/// OnClicked()
	/// Callback for when this button
	/// is clicked.
	////////////////////////////////
	public void OnClicked() {
		// we want to show the panel full of chars for the user to choose from
		Messenger.Broadcast( "ShowChooseCharacterPanel" );
	}

	////////////////////////////////
	/// OnCharacterSelected()
	/// Callback for when the user
	/// choose a character.
	////////////////////////////////
	private void OnCharacterSelected( ID_Character i_dataChar ) {
		ShowCharacter( i_dataChar );
	}

	////////////////////////////////
	/// ShowCharacter()
	/// Sets the proper name and
	/// image for the incoming
	/// character.
	////////////////////////////////
	private void ShowCharacter( ID_Character i_dataChar ) {
		string strName = StringTableManager.Get( "Name_" + i_dataChar.character );
		Sprite spriteImage = Resources.Load<Sprite>( i_dataChar.character );

		ButtonText.text = strName;
		ButtonImage.sprite = spriteImage;
		ButtonImage.enabled = true;
	}
}
