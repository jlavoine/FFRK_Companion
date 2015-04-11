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

	// currently selected character
	private ID_Character m_char;
	public ID_Character GetCurrentCharacter() {
		return m_char;
	}

	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		// set the title
		string strTitle = StringTableManager.Instance.Get( "Title_Item" );
		TitleText.text = strTitle;

		Messenger.AddListener<ID_Character>( "CharacterSelected", OnCharacterSelected );

		/*List<ID_Character> test = new List<ID_Character>();
		ID_Character a = new ID_Character();
		a.character = "Cloud";
		ID_Character b = new ID_Character();
		b.character = "Tifa";
		
		test.Add(a);
		test.Add(b);

		string json = JsonConvert.SerializeObject(test, Formatting.Indented);
		Debug.Log (json);*/
	}

	void OnDestroy() {
		Messenger.RemoveListener<ID_Character>( "CharacterSelected", OnCharacterSelected );
	}

	private void OnCharacterSelected( ID_Character i_char ) {
		m_char = i_char;
	}

}
