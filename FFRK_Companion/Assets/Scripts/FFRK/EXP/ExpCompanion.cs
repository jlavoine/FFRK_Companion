using UnityEngine;
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
	/// OnCharacterSelected()
	/// Callback for when a character
	/// is selected by the user.
	////////////////////////////////
	private void OnCharacterSelected( ID_Character i_char ) {
		// clear out everything in content area
		ContentArea.DestroyChildren();

		// get a list of the top 10 exp/stam dungeons
		List<ID_Battle> listBattles = IDL_Battles.GetBattles();

		// sort the battles by the exp earned
		listBattles.Sort(delegate(ID_Battle x, ID_Battle y) {
			int nXpX = x.GetExpPerStamina( i_char );
			int nXpY = y.GetExpPerStamina( i_char );

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
