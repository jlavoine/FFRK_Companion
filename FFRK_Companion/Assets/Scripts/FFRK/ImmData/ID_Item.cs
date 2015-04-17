using UnityEngine;
using System.Collections;

////////////////////////////////
/// ID_Item
/// Immutable data for an item.
////////////////////////////////

public class ID_Item {
	public string itemname;
	public string itemtype;
	public string realm;
	public string subtype;
	public string rarity;
	public string att;
	public string maxatt;
	public string def;
	public string maxdef;
	public string mag;
	public string maxmag;
	public string res;
	public string maxres;
	public string mnd;
	public string maxmnd;
	public string acc;
	public string maxacc;
	public string eva;
	public string maxeva;
	public string spd;
	public string maxspd;
	public string notes;
	public string location;

	////////////////////////////////
	/// GetBestAttack()
	/// Returns the best attack of
	/// this item; assuming max
	/// level and synergy.
	////////////////////////////////
	public int GetBestAttack() {
		// get the max level this item can be with and without synergy
		int nMaxLevel = GetMaxLevel( false );
		int nMaxLevelSynergy = GetMaxLevel( true );

		// figure out the level up bonus
		float fLevelUpBonus = ((float)int.Parse(maxatt) - int.Parse(att)) / (nMaxLevel - 1);

		// now get the best it can be...
		float fBest = fLevelUpBonus * ( nMaxLevelSynergy-1 ) + int.Parse(att);
		int nBest = Mathf.CeilToInt( fBest );

		return nBest;
	}

	////////////////////////////////
	/// GetMaxLevel()
	/// Returns the highest level
	/// this item can be (with
	/// synergy).
	////////////////////////////////
	public int GetMaxLevel( bool i_bSynergy ) {
		// effective max level is...ah fuck it I'm just going to do this
		int nRarity = int.Parse(rarity);
		int nMaxLevel;
		switch ( nRarity ) {
			case 1:
				nMaxLevel = i_bSynergy ? 40 : 10;
				break;
			case 2:
				nMaxLevel = i_bSynergy ? 55 : 15;
				break;
			case 3:
				nMaxLevel = i_bSynergy ? 70 : 20;
				break;
			case 4:
				nMaxLevel = i_bSynergy ? 85 : 25;
				break;
			default://case 5:
				nMaxLevel = i_bSynergy ? 100 : 30;
				break;
		}

		return nMaxLevel;
	}

}
