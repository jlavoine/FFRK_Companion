using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponEntry : MonoBehaviour {
	public Image Icon;
	public Text Name;
	public Text Attack;
	public Text Location;

	public void Init( ID_Character i_char, ID_Item i_item ) {
		string strName = i_item.itemname;
		int nStat = int.Parse(i_item.maxatt);
		Sprite spriteIcon = Resources.Load<Sprite>( i_item.realm + "_" + i_item.itemname );

		Icon.sprite = spriteIcon;
		Name.text = strName;

		string strStatKey = "MaxAtt";
		if ( i_char.character == "BlackMage" || i_char.character == "Rydia" ) {
			strStatKey = "MaxMag";
			nStat = string.IsNullOrEmpty(i_item.maxmag) ? 0 : int.Parse(i_item.maxmag);
		}
		else if ( i_char.character == "WhiteMage" ) {
			strStatKey = "MaxMnd";
			nStat = string.IsNullOrEmpty(i_item.maxmnd) ? 0 : int.Parse(i_item.maxmnd);
		}

		string strMax = StringTableManager.Instance.Get( strStatKey );
		strMax = DrsStringUtils.Replace( strMax, "NUM", nStat );
		Attack.text = strMax;

		string strLoc = StringTableManager.Instance.Get( "RelicDrop" );
		if ( string.IsNullOrEmpty( i_item.location ) == false )
			strLoc = i_item.location;

		Location.text = strLoc;
	}
}
