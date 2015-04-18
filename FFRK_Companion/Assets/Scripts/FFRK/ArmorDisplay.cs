using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ArmorDisplay : ItemDisplay {

	////////////////////////////////
	/// InitEntry()
	/// Inits the entry properly
	/// for this type of display.
	////////////////////////////////
	protected override void InitEntry( GameObject i_goEntry, ID_Item i_item ) {
		// init an armor entry
		ArmorEntry entry = i_goEntry.GetComponent<ArmorEntry>();
		entry.Init( i_item );
	}

	////////////////////////////////
	/// SortItems()
	/// Sorts the incoming list of
	/// items as is proper for this
	/// type of display.
	////////////////////////////////
	protected override List<ID_Item> SortItems( List<ID_Item> i_listBest, ID_Character i_character ) {
		bool bAll = ItemCompanion.Instance.GetCurrentRealm() == "All";

		// sort simply by comparing defense of the items
		i_listBest.Sort(delegate(ID_Item x, ID_Item y)
		{
			int nDefX = bAll ? int.Parse( x.maxdef ) : x.GetBestDefense();
			int nDefY = bAll ? int.Parse( y.maxdef ) : y.GetBestDefense();
			
			if ( nDefX == nDefY ) return 0;
			else if (nDefX < nDefY ) return 1;
			else return -1;
		});

		return i_listBest;
	}
}
