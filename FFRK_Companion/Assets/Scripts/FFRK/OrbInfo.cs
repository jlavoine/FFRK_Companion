using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OrbInfo : MonoBehaviour {
	public Text Name;
	public Image Icon;
	public Text Locations;

	// Use this for initialization
	void Start () {
		Messenger.AddListener<string, int>( "OrbSelected", OnOrbSelected );	
	}

	void OnDestroy() {
		Messenger.RemoveListener<string, int>( "OrbSelected", OnOrbSelected );
	}

	private void OnOrbSelected( string i_strOrbKey, int i_nIndex ) {
		Sprite sprite = Resources.Load<Sprite>( i_strOrbKey + "_" + i_nIndex );
		Icon.sprite = sprite;

		string strType = StringTableManager.Instance.Get( i_strOrbKey );
		string strPrefix = StringTableManager.Instance.Get( "Orb_" + i_nIndex );
		string strTitle = strPrefix + " " + strType;
		Name.text = strTitle;

		string strOrb = i_strOrbKey + "_" + i_nIndex;
		string strLocation = StringTableManager.Instance.Get( "OrbLocation" );

		List<ID_Dungeon> listDungeons = IDL_Dungeons.GetDungeons();

		for ( int i = 0; i < listDungeons.Count; ++i ) {
			ID_Dungeon dungeon = listDungeons[i];
			string strRealm = dungeon.realm;
			string strName = dungeon.name;
			string strVersion = dungeon.version;

			if ( dungeon.HasOrb( strOrb ) ) {
				strLocation += "-" + strName + "(" + strRealm + ")(" + strVersion + ")";
			}

			if ( dungeon.HasOrbBoss( strOrb ) ) {
				strLocation += "-" + strName + "(" + strRealm + ")(" + strVersion + ")(Boss)";
			}
		}

		Locations.text = strLocation;
	}
}
