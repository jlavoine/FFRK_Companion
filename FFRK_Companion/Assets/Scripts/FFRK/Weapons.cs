using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Weapons : MonoBehaviour {
	public Text Title;

	public GameObject WeaponContent;
	public GameObject WeaponsEntry;

	// Use this for initialization
	void Start () {
		string strTitle = StringTableManager.Instance.Get( "Weapons" );
		Title.text = strTitle;
	}

	public void RefreshItems() {
		// destroy everything within us
		WeaponContent.DestroyChildren();

		ScrollRect sr = GetComponentInChildren<ScrollRect>();
		sr.verticalNormalizedPosition = 1f;

		// get the current character and realm selected
		ID_Character character = ItemCompanion.Instance.GetCurrentCharacter();
		string strRealm = ItemCompanion.Instance.GetCurrentRealm();
		bool bDropsOnly = ItemCompanion.Instance.DropsOnly.isOn;

		//Debug.Log ("Going to show weapons for " + character.character + " and realm " + strRealm + " and " + bDropsOnly );

		List<ID_Item> listItems = GetBestItems( character, strRealm, bDropsOnly );

		for ( int i = 0; i < listItems.Count; ++i ) {
			ID_Item item = listItems[i];
			GameObject goEntry = GameObject.Instantiate( WeaponsEntry );
			goEntry.transform.SetParent( WeaponContent.transform );

			WeaponEntry entry = goEntry.GetComponent<WeaponEntry>();
			entry.Init( character, item );
		}
	}

	private List<ID_Item> GetBestItems( ID_Character i_character, string i_strRealm, bool i_bDrop ) {
		// bruuuuute forceeeee!
		// first get all items
		List<ID_Item> listItems = IDL_Items.GetItems();

		// if we're free, cull this
		List<ID_Item> listValid = new List<ID_Item>();
		if ( i_bDrop ) {
			for ( int i = 0; i < listItems.Count; ++i ) {
				ID_Item item = listItems[i];
				if ( string.IsNullOrEmpty( item.location ) == false )
					listValid.Add( item );
			}
		}
		else 
			listValid = listItems;

		// weapons only!
		List<ID_Item> listWeapons = new List<ID_Item>();
		for ( int i = 0; i < listValid.Count; ++i ) {
			ID_Item item = listValid[i];
			string strType = item.itemtype;
			if ( strType == "Weapon" )
				listWeapons.Add( item );
		}

		// take out ones that don't fit the realm
		List<ID_Item> listFitRealm = new List<ID_Item>();
		if ( string.IsNullOrEmpty(i_strRealm) == false && i_strRealm != "All" ) {		
			for ( int i = 0; i < listWeapons.Count; ++i ) {
				ID_Item item = listWeapons[i];
				string strRealm = item.realm;
				if ( strRealm == i_strRealm )
					listFitRealm.Add( item );
			}
		}
		else
			listFitRealm = listWeapons;

		// let's take out the ones this character can use
		List<ID_Item> listUsable = new List<ID_Item>();
		for ( int i = 0; i < listFitRealm.Count; ++i ) {
			ID_Item item = listFitRealm[i];
			string strType = item.subtype;
			if ( i_character.CanUse( strType ) )
			    listUsable.Add( item );
		}

		// now let's go through the list usable and sort it based on attack...yikes!
		listUsable.Sort(delegate(ID_Item x, ID_Item y)
		{
			int nAttackX = int.Parse( x.maxatt );
			int nAttackY = int.Parse( y.maxatt );

			int nMagX = string.IsNullOrEmpty(x.maxmag) ? 0 : int.Parse( x.maxmag );
			int nMagY = string.IsNullOrEmpty(y.maxmag) ? 0 : int.Parse( y.maxmag );

			int nMndX = string.IsNullOrEmpty(x.maxmnd) ? 0 : int.Parse( x.maxmnd );
			int nMndY = string.IsNullOrEmpty(y.maxmnd) ? 0 : int.Parse( y.maxmnd );

			if ( i_character.character == "BlackMage" || i_character.character == "Rydia" ) {
				if ( nMagX == nMagY ) return 0;
				else if (nMagX < nMagY ) return 1;
				else return -1;
			}
			else if ( i_character.character == "WhiteMage" ) {
				if ( nMndX == nMndY ) return 0;
				else if (nMndX < nMndY ) return 1;
				else return -1;
			}
			else {
				if ( nAttackX == nAttackY ) return 0;
				else if (nAttackX < nAttackY ) return 1;
				else return -1;
			}
		});

		//for ( int i = 0; i < listUsable.Count; ++i ) {
		//	ID_Item item = listUsable[i];
		//	Debug.Log(item.itemname);
		//}

		return listUsable;
	}
}
