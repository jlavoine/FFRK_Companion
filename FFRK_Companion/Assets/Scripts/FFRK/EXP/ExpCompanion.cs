using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////
/// ExpCompanion
/// In charge of the exp screen.
////////////////////////////////

public class ExpCompanion : Singleton<ExpCompanion> {
	// content area where entries go
	public GameObject ContentArea;

	// the entry prefab
	public GameObject ExpEntryPrefab;

	// the full party toggle
	public Toggle FullPartyToggle;

	// currently selected character
	private ID_Character m_charCurrent;

	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
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
	/// OnPartyToggleChanged()
	/// Callback for when user 
	/// changes the party size
	/// toggle.
	////////////////////////////////
	public void OnPartyToggleChanged() {
		// refresh the exp entries
		Refresh();
	}

	////////////////////////////////
	/// Refresh()
	/// If there was a character
	/// selected, refreshes the
	/// exp entry list.
	////////////////////////////////
	private void Refresh() {
		if ( m_charCurrent != null )
			OnCharacterSelected( m_charCurrent );
	}

	////////////////////////////////
	/// OnCharacterSelected()
	/// Callback for when a character
	/// is selected by the user.
	////////////////////////////////
	private void OnCharacterSelected( ID_Character i_char ) {
		m_charCurrent = i_char;

		// clear out everything in content area
		ContentArea.DestroyChildren();

		// get a list of the top 10 exp/stam dungeons
		List<ID_Battle> listBattles = IDL_Battles.GetBattles();

		// pretty hacky at the moment to find out if full party or solo
		int nMembers = ExpCompanion.Instance.FullPartyToggle.isOn ? 5 : 1;

		// sort the battles by the exp earned
		listBattles.Sort(delegate(ID_Battle x, ID_Battle y) {
			int nXpX = x.GetExpPerStamina( i_char, nMembers );
			int nXpY = y.GetExpPerStamina( i_char, nMembers );

			if ( nXpX == nXpY ) return 0;
			else if (nXpX < nXpY ) return 1;
			else return -1;
		});

		for ( int i = 0; i < 9; ++i ) {
			ID_Battle battle = listBattles[i];

			GameObject goEntry = GameObject.Instantiate( ExpEntryPrefab );
			goEntry.transform.SetParent( ContentArea.transform );

			ExpEntry entry = goEntry.GetComponent<ExpEntry>();
			entry.Init( battle, i_char );
		}
	}
}
