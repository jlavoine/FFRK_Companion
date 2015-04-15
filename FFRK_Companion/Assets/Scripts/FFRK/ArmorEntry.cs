using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArmorEntry : MonoBehaviour {
	public Image Icon;
	public Text Name;
	public Text Defense;
	public Text Location;
	
	public void Init( ID_Item i_item ) {
		string strName = i_item.itemname;
		int nDef = int.Parse(i_item.maxdef);
		Sprite spriteIcon = Resources.Load<Sprite>( i_item.realm + "_" + i_item.itemname );
		
		Icon.sprite = spriteIcon;
		Name.text = strName;
		
		string strDef = StringTableManager.Get( "MaxDef" );
		strDef = DrsStringUtils.Replace( strDef, "NUM", nDef );
		Defense.text = strDef;
		
		string strLoc = StringTableManager.Get( "RelicDrop" );
		if ( string.IsNullOrEmpty( i_item.location ) == false ) {
			strLoc = StringTableManager.Get( "Location" );
			strLoc = DrsStringUtils.Replace( strLoc, "DESC", i_item.location );
		}
		
		Location.text = strLoc;
	}
}
