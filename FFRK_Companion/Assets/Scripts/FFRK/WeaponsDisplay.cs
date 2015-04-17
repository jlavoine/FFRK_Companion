using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeaponsDisplay : ItemDisplay {

	////////////////////////////////
	/// InitEntry()
	/// Inits the entry properly
	/// for this type of display.
	////////////////////////////////
	protected override void InitEntry( GameObject i_goEntry, ID_Item i_item ) {
		// use the currently selected character
		ID_Character character = ItemCompanion.Instance.GetCurrentCharacter();

		// init a weapon entry
		WeaponEntry entry = i_goEntry.GetComponent<WeaponEntry>();
		entry.Init( character, i_item );
	}

	////////////////////////////////
	/// SortItems()
	/// Sorts the incoming list of
	/// items as is proper for this
	/// type of display.
	////////////////////////////////
	protected override List<ID_Item> SortItems( List<ID_Item> i_listBest, ID_Character i_character ) {
		bool bAll = ItemCompanion.Instance.GetCurrentRealm() == "All";

		// sorting is a little complex...THANKS GAME
		i_listBest.Sort(delegate(ID_Item x, ID_Item y) {
			// sorting may require the attack, magic, or mind of the item...
			int nAttackX = bAll ? int.Parse( x.maxatt ) : x.GetBestAttack();
			int nAttackY = bAll ? int.Parse( y.maxatt ) : y.GetBestAttack();

			int nMagX = string.IsNullOrEmpty(x.maxmag) ? 0 : int.Parse( x.maxmag );
			int nMagY = string.IsNullOrEmpty(y.maxmag) ? 0 : int.Parse( y.maxmag );

			int nMndX = string.IsNullOrEmpty(x.maxmnd) ? 0 : int.Parse( x.maxmnd );
			int nMndY = string.IsNullOrEmpty(y.maxmnd) ? 0 : int.Parse( y.maxmnd );

			if ( i_character.character == "BlackMage" || i_character.character == "Rydia" ) {
				// if it's a BLM or rydia, we need to sort by magic
				if ( nMagX == nMagY ) return 0;
				else if (nMagX < nMagY ) return 1;
				else return -1;
			}
			else if ( i_character.character == "WhiteMage" ) {
				// if it's the WHM, sort by mnd
				if ( nMndX == nMndY ) return 0;
				else if (nMndX < nMndY ) return 1;
				else return -1;
			}
			else {
				// for all other chars, we want to sort by attack
				if ( nAttackX == nAttackY ) return 0;
				else if (nAttackX < nAttackY ) return 1;
				else return -1;
			}
		});

		return i_listBest;
	}
}
