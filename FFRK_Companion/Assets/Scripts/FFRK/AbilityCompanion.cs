using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////
/// AbilityCompanion
/// In charge of the abilities 
/// screen.
////////////////////////////////

public class AbilityCompanion : MonoBehaviour {
	// content area where entries go
	public GameObject ContentArea;
	
	// the entry prefab
	public GameObject AbilityEntryPrefab;

	// scroll rect for all abilities
	public ScrollRect AbilityScrollArea;
	
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
		// destroy everything in the content area to refresh
		ContentArea.DestroyChildren();

		// reset the scroll area
		AbilityScrollArea.verticalNormalizedPosition = 1f;

		// get list of character's abilities
		string strAbilities = i_char.abilities;
		AbilityList abilities = new AbilityList( strAbilities );

		// get all abilities in the game
		List<ID_Ability> listAllAbilities = IDL_Abilities.GetAbilities();

		// loop through abilities and add the ones this char can use to a list
		List<ID_Ability> listUsableAbilities = new List<ID_Ability>();
		for ( int i = 0; i < listAllAbilities.Count; ++i ) {
			ID_Ability ability = listAllAbilities[i];
			if ( abilities.CanUseAbility( ability ) )
				listUsableAbilities.Add( ability );
		}

		// creat an ability entry for each usable ability
		for ( int i = 0; i < listUsableAbilities.Count; ++i ) {
			ID_Ability ability = listUsableAbilities[i];

			GameObject goEntry = GameObject.Instantiate( AbilityEntryPrefab );
			goEntry.transform.SetParent( ContentArea.transform );

			AbilityEntry script = goEntry.GetComponent<AbilityEntry>();
			script.Init( ability );
		}
	}
}
