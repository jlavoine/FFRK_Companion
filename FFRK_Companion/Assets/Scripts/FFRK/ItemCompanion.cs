using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json;

////////////////////////////////
/// ItemCompanion
/// In charge of the item screen.
////////////////////////////////

public class ItemCompanion : Singleton<ItemCompanion> {
	// title text
	public Text TitleText;

	// toggle for whether the user just wants to see items that are dropped by mobs
	public Toggle DropsOnly;

	// these are the areas where the weapons and armor are displayed
	public WeaponsDisplay WeaponsPanel;
	public ArmorDisplay ArmorPanel;

	// currently selected character
	private ID_Character m_char;
	public ID_Character GetCurrentCharacter() {
		return m_char;
	}

	// currently selected realm
	private string m_strRealm;
	public string GetCurrentRealm() {
		return m_strRealm;
	}

	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		// set the title
		string strTitle = StringTableManager.Get( "Title_Item" );
		TitleText.text = strTitle;

		Messenger.AddListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
		Messenger.AddListener<string>( "RealmSelected", OnRealmSelected );

		// set the drops only text
		string strDropsOnly = StringTableManager.Get( "DropsOnly" );
		DropsOnly.GetComponentInChildren<Text>().text = strDropsOnly;
	}

	////////////////////////////////
	/// OnDestroy()
	////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
		Messenger.RemoveListener<string>( "RealmSelected", OnRealmSelected );
	}

	////////////////////////////////
	/// RefreshItems()
	/// Refreshes all the item
	/// displays so they display
	/// items with the user's current
	/// settings.
	////////////////////////////////
	private void RefreshItems() {
		ArmorPanel.RefreshItems();
		WeaponsPanel.RefreshItems();
	}

	////////////////////////////////
	/// OnDropToggle()
	/// Callback for when the user
	/// changes the "Drop only"
	/// toggle.
	////////////////////////////////
	public void OnDropToggle( bool i_b ) {
		// refresh the items as long as a char is selected
		if ( m_char != null )
			RefreshItems();
	}

	////////////////////////////////
	/// OnRealmSelected()
	/// Callback for when the user
	/// selects a realm.
	////////////////////////////////
	private void OnRealmSelected( string i_strRealm ) {
		// set the current realm
		m_strRealm = i_strRealm;

		// refresh items if there is a char selected
		if ( m_char != null )
			RefreshItems();
	}

	////////////////////////////////
	/// OnCharacterSelected()
	/// Callback for when a character
	/// is selected by the user.
	////////////////////////////////
	private void OnCharacterSelected( ID_Character i_char ) {
		// save the current character
		m_char = i_char;

		// refresh all items
		RefreshItems();
	}

}
