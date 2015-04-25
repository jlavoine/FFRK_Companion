using UnityEngine;
using System.Collections;

public class ID_Battle  {
	public string name;
	public string dungeon;
	public string exp;
	public string stamina;
	public string boss;
	public string elite;

	////////////////////////////////
	/// GetExpPerStamina()
	/// Returns the amount of xp
	/// gained per stamina for the
	/// incoming character.
	////////////////////////////////
	public int GetExpPerStamina( ID_Character i_char, int i_nPartyMembers ) {
		int nStam = int.Parse(stamina);
		int nEXP = int.Parse(exp) / i_nPartyMembers;
		string strRealm = GetRealm();

		// characters with synergy get 50% more xp...sweet!
		if ( strRealm == i_char.realm ) {
			nEXP = (int) ( nEXP * 1.5f );
		}

		int nXpPerStam = nEXP / nStam;
		return nXpPerStam;
	}

	////////////////////////////////
	/// GetRealm()
	/// Returns the realm for this
	/// battle.
	////////////////////////////////
	public string GetRealm() {
		ID_Dungeon dataDungeon = IDL_Dungeons.GetDungeon( dungeon );

		if ( dungeon != null )
			return dataDungeon.realm;
		else
			return "none";
	}

	////////////////////////////////
	/// GetDungeon()
	/// Returns the dungeon for this
	/// battle.
	////////////////////////////////
	public ID_Dungeon GetDungeon() {
		ID_Dungeon dataDungeon = IDL_Dungeons.GetDungeon( dungeon );
		return dataDungeon;
	}
}
