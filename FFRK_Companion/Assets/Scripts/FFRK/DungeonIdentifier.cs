using UnityEngine;
using UnityEngine.UI;
using System.Collections;

///////////////////////////////////////////
/// DugeonIdentifier
/// UI graphic that displays info about a
/// dungeon.
///////////////////////////////////////////

public class DungeonIdentifier : MonoBehaviour {
	// realm
	public Image RealmIcon;
	public Text RealmText;

	// name
	public Text Name;
	public Outline NameOutline;

	///////////////////////////////////////////
	/// Init()
	///////////////////////////////////////////
	public void Init( ID_Dungeon i_dungeon, bool i_bBoss = false ) {
		// set realm
		RealmText.text = i_dungeon.GetRealmAsText();

		// change color of the realm icon based on dungeon type
		string strColorKey = i_dungeon.version + "Color";
		Color color = Constants.GetConstant<Color>( strColorKey );
		RealmIcon.color = color;

		// set the name
		Name.text = i_dungeon.name;

		// if it's a boss, we want to turn the outline red
		if ( i_bBoss )
			NameOutline.effectColor = Color.red;
	}
	public void Init( ID_Battle i_battle ) {
		// get dungeon for this battle
		ID_Dungeon dungeon = i_battle.GetDungeon();

		// set realm
		RealmText.text = dungeon.GetRealmAsText();
		
		// change color of the realm icon based on dungeon type
		string strColorKey = dungeon.version + "Color";
		Color color = Constants.GetConstant<Color>( strColorKey );
		RealmIcon.color = color;
		
		// set the name
		Name.text = dungeon.name + ":" + i_battle.name;
		
		// if it's a boss, we want to turn the outline red
		if ( i_battle.boss == "Yes" )
			NameOutline.effectColor = Color.red;
	}
}
