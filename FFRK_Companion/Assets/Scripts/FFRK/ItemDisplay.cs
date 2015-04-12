using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class ItemDisplay : MonoBehaviour {
	// pure abstracts
	protected abstract void InitEntry( GameObject i_goEntry, ID_Item i_item );
	protected abstract List<ID_Item> SortItems( List<ID_Item> i_listBest, ID_Character i_character );
	// ---

	// title of the display
	public Text Title;

	// content area where entries get placed
	public GameObject Content;

	// an entry within the display
	public GameObject Entry;

	// key for this display
	public string Key;

	////////////////////////////////
	/// Start()
	////////////////////////////////
	void Start () {
		// set the title of the display
		string strTitle = StringTableManager.Instance.Get( Key + "Display" );
		Title.text = strTitle;
	}

	////////////////////////////////
	/// RefreshItems()
	/// Destroys all old items and
	/// repopulates the display with
	/// whatever user settings are.
	////////////////////////////////
	public void RefreshItems() {
		// destroy everything within us
		Content.DestroyChildren();

		// reset the scroll rect so we start at the top
		ScrollRect sr = GetComponentInChildren<ScrollRect>();
		sr.verticalNormalizedPosition = 1f;
		
		// get the user settings
		ID_Character character = ItemCompanion.Instance.GetCurrentCharacter();
		string strRealm = ItemCompanion.Instance.GetCurrentRealm();
		bool bDropsOnly = ItemCompanion.Instance.DropsOnly.isOn;

		List<ID_Item> listItems = GetBestItems( character, strRealm, bDropsOnly );

		// display all the items
		for ( int i = 0; i < listItems.Count; ++i ) {
			ID_Item item = listItems[i];
			GameObject goEntry = GameObject.Instantiate( Entry );
			goEntry.transform.SetParent( Content.transform );

			// children must init the entry
			InitEntry( goEntry, item );
		}
	}

	////////////////////////////////
	/// GetBestItems()
	/// Returns a list of the best
	/// items, given the incoming
	/// parameters.
	////////////////////////////////
	private List<ID_Item> GetBestItems( ID_Character i_character, string i_strRealm, bool i_bDrop ) {
		// bruuuuute forceeeee!
		// first get all items
		List<ID_Item> listItems = IDL_Items.GetItems();
		
		// if we're free, cull the non-droppables
		List<ID_Item> listValid = new List<ID_Item>();
		if ( i_bDrop ) {
			listValid = TrimNonDrops( listItems );
		}
		else 
			listValid = listItems;
		
		// weapons only!
		List<ID_Item> listWeapons = TrimNonType( listValid, Key );
		
		// take out ones that don't fit the realm
		List<ID_Item> listFitRealm = TrimNonRealm( listWeapons, i_strRealm );
		
		// let's take out the ones this character can use
		List<ID_Item> listUsable = TrimNonUsable( listFitRealm, i_character );

		List<ID_Item> listBestSorted = SortItems( listUsable, i_character );

		return listBestSorted;
	}

	////////////////////////////////
	/// TrimNonDrops()
	/// Returns a list of items that
	/// have the non-droppable items
	/// removed.
	////////////////////////////////
	protected List<ID_Item> TrimNonDrops( List<ID_Item> i_listItems ) {
		List<ID_Item> listValid = new List<ID_Item>();
		for ( int i = 0; i < i_listItems.Count; ++i ) {
			ID_Item item = i_listItems[i];
			if ( string.IsNullOrEmpty( item.location ) == false )
				listValid.Add( item );
		}

		return listValid;
	}

	////////////////////////////////
	/// TrimNonType()
	/// Returns a list of items with
	/// the items NOT matching the
	/// incoming type removed.
	////////////////////////////////
	protected List<ID_Item> TrimNonType( List<ID_Item> i_listItems, string i_strType ) {
		List<ID_Item> listItems = new List<ID_Item>();
		for ( int i = 0; i < i_listItems.Count; ++i ) {
			ID_Item item = i_listItems[i];
			string strType = item.itemtype;
			if ( strType == i_strType )
				listItems.Add( item );
		}

		return listItems;
	}

	////////////////////////////////
	/// TrimNonRealm()
	/// Returns a list of items that
	/// has the items not matching
	/// the realm removed.
	////////////////////////////////
	protected List<ID_Item> TrimNonRealm( List<ID_Item> i_listItems, string i_strRealm ) {
		List<ID_Item> listFitRealm = new List<ID_Item>();
		if ( string.IsNullOrEmpty(i_strRealm) == false && i_strRealm != "All" ) {		
			for ( int i = 0; i < i_listItems.Count; ++i ) {
				ID_Item item = i_listItems[i];
				string strRealm = item.realm;
				if ( strRealm == i_strRealm )
					listFitRealm.Add( item );
			}
		}
		else
			listFitRealm = i_listItems;

		return listFitRealm;
	}

	protected List<ID_Item> TrimNonUsable( List<ID_Item> i_listItems, ID_Character i_character ) {
		List<ID_Item> listUsable = new List<ID_Item>();
		for ( int i = 0; i < i_listItems.Count; ++i ) {
			ID_Item item = i_listItems[i];
			string strType = item.subtype;
			if ( i_character.CanUse( strType ) )
				listUsable.Add( item );
		}

		return listUsable;
	}
}
