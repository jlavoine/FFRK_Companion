using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeaponEntry : MonoBehaviour {
	public Text Name;
	public Text Attack;
	public Text SubType;

	// where the dungeons entries go
	public GameObject DungeonContent;
	public GameObject DungeonEntry;

	public void Init( ID_Character i_char, ID_Item i_item ) {
		bool bAll = ItemCompanion.Instance.GetCurrentRealm() == "All";
		string strName = i_item.itemname;
		int nStat = bAll ? int.Parse(i_item.maxatt) : i_item.GetBestAttack();
		//Sprite spriteIcon = Resources.Load<Sprite>( i_item.realm + "_" + i_item.itemname );

		//Icon.sprite = spriteIcon;
		Name.text = strName;
		SubType.text = i_item.subtype;

		string strStatKey = "MaxAtt";
		if ( i_char.character == "BlackMage" || i_char.character == "Rydia" ) {
			strStatKey = "MaxMag";
			nStat = string.IsNullOrEmpty(i_item.maxmag) ? 0 : int.Parse(i_item.maxmag);
		}
		else if ( i_char.character == "WhiteMage" ) {
			strStatKey = "MaxMnd";
			nStat = string.IsNullOrEmpty(i_item.maxmnd) ? 0 : int.Parse(i_item.maxmnd);
		}

		string strMax = StringTableManager.Get( strStatKey );
		strMax = DrsStringUtils.Replace( strMax, "NUM", nStat );
		Attack.text = strMax;

		if ( string.IsNullOrEmpty( i_item.location ) == false ) {
			List<string> listLocs = Constants.ParseStringList( i_item.location );
			for ( int i = 0; i < listLocs.Count; ++i ) {
				string strLoc = listLocs[i];
				string[] array = strLoc.Split("_"[0]);
				bool bBoss = array.Length > 1;

				GameObject goEntry = GameObject.Instantiate( DungeonEntry );
				goEntry.transform.SetParent( DungeonContent.transform );

				ID_Dungeon dungeon = IDL_Dungeons.GetDungeonFromShortcut( array[0].Trim() );
				if ( dungeon == null )
					continue;

				DungeonIdentifier id = goEntry.GetComponent<DungeonIdentifier>();
				id.Init( dungeon, bBoss );
			}
		}
	}
}
