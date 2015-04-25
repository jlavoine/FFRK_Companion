using UnityEngine;
using UnityEngine.UI;
using System.Collections;

////////////////////////////////
/// ExpEntry
/// UI for showing a dungeon/battle
/// along with the amount of xp
/// per stamina a character can
/// get.
////////////////////////////////

public class ExpEntry : MonoBehaviour {
	public DungeonIdentifier Dungeon;
	public Text ExpPerStamina;

	////////////////////////////////
	/// Init();
	////////////////////////////////
	public void Init( ID_Battle i_battle, ID_Character i_char ) {
		// create the dungeon/battle ui
		Dungeon.Init( i_battle );
	
		// pretty hacky at the moment to find out if full party or solo
		int nMembers = ExpCompanion.Instance.FullPartyToggle.isOn ? 5 : 1;

		// display the amount of xp the incoming character will get out of this battle
		int xp = i_battle.GetExpPerStamina( i_char, nMembers );
		ExpPerStamina.text = DrsStringUtils.FormatNumber( xp );
	}
}
