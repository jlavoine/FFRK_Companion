using UnityEngine;
using UnityEngine.UI;
using System.Collections;

///////////////////////////////////////////
/// CharacterIdentifier
/// UI graphic that displays info about a
/// character.
///////////////////////////////////////////

public class CharacterIdentifier : MonoBehaviour {
	// realm
	public Image RealmIcon;
	public Text RealmText;
	
	// name
	public Text Name;
	public Outline NameOutline;
	
	///////////////////////////////////////////
	/// Init()
	///////////////////////////////////////////
	public void Init( ID_Character i_char ) {
		// set realm
		string strRealm = i_char.realm;
		if ( strRealm == "Core" )
			strRealm = "C";
		RealmText.text = strRealm;
		
		// change color of the realm icon based on the realm
		string strColorKey = "Color_" + i_char.realm;
		Color color = Constants.GetConstant<Color>( strColorKey );
		RealmIcon.color = color;
		
		// set the name
		string strName = StringTableManager.Get( "Name_" + i_char.character );
		Name.text = strName;
	}
}
