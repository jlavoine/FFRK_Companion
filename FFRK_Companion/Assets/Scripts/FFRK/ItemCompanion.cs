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

	public Toggle DropsOnly;


	public Weapons WeaponsPanel;
	public Armor ArmorPanel;

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
		string strTitle = StringTableManager.Instance.Get( "Title_Item" );
		TitleText.text = strTitle;

		Messenger.AddListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
		Messenger.AddListener<string>( "RealmSelected", OnRealmSelected );

		// set the drops only text
		string strDropsOnly = StringTableManager.Instance.Get( "DropsOnly" );
		DropsOnly.GetComponentInChildren<Text>().text = strDropsOnly;
	}

	void OnDestroy() {
		Messenger.RemoveListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
		Messenger.RemoveListener<string>( "RealmSelected", OnRealmSelected );
	}

	private void RefreshItems() {
		ArmorPanel.RefreshItems();
		WeaponsPanel.RefreshItems();
	}

	public void OnDropToggle( bool i_b ) {
		if ( m_char != null )
			RefreshItems();
	}

	private void OnRealmSelected( string i_strRealm ) {
		m_strRealm = i_strRealm;

		if ( m_char != null )
			RefreshItems();
	}

	private void OnCharacterSelected( ID_Character i_char ) {
		m_char = i_char;

		RefreshItems();
	}

}
