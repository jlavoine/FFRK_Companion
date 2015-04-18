using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ArmorEntry : MonoBehaviour {
	public Text Name;
	public Text Defense;
	public Text SubType;

	// where the dungeons entries go
	public GameObject DungeonContent;
	public GameObject DungeonEntry;
	
	public void Init( ID_Item i_item ) {
		bool bAll = ItemCompanion.Instance.GetCurrentRealm() == "All";
		string strName = i_item.itemname + "(" + i_item.realm + ")";
		int nDef = bAll ? int.Parse(i_item.maxdef) : i_item.GetBestDefense();
		//Sprite spriteIcon = Resources.Load<Sprite>( i_item.realm + "_" + i_item.itemname );
		
		//Icon.sprite = spriteIcon;
		Name.text = strName;
		SubType.text = i_item.subtype;

		string strDef = StringTableManager.Get( "MaxDef" );
		strDef = DrsStringUtils.Replace( strDef, "NUM", nDef );
		Defense.text = strDef;
		
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
