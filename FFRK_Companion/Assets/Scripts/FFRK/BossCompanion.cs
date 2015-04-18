using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////
/// BossCompanion
/// Handles all the functionality
/// of the boss part of the app.
////////////////////////////////

public class BossCompanion : MonoBehaviour {
	// content area where entries go
	public GameObject ContentArea;
	
	// the entry prefab
	public GameObject BossEntryPrefab;
	
	// scroll rect for all entries
	public ScrollRect BossScrollArea;
	
	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		Messenger.AddListener<string>( "RealmSelected", OnRealmSelected );
	}
	
	////////////////////////////////
	/// OnDestroy()
	////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener<string>( "RealmSelected", OnRealmSelected );
	}
	
	////////////////////////////////
	/// OnRealmSelected()
	/// Callback for when a realm
	/// is selected by the user.
	////////////////////////////////
	private void OnRealmSelected( string i_strRealm ) {
		// destroy everything in the content area to refresh
		ContentArea.DestroyChildren();
		
		// reset the scroll area
		BossScrollArea.verticalNormalizedPosition = 1f;

		// get the bosses for the selected realm
		List<ID_Boss> listBosses = IDL_Bosses.GetBossesForRealm( i_strRealm );

		// add an entry for each boss
		for ( int i = 0; i < listBosses.Count; ++i ) {
			ID_Boss boss = listBosses[i];

			// create the entry
			GameObject goEntry = GameObject.Instantiate( BossEntryPrefab );
			goEntry.transform.SetParent( ContentArea.transform );

			// init the entry
			BossEntry script = goEntry.GetComponent<BossEntry>();
			script.Init( boss );
		}
	}
}
