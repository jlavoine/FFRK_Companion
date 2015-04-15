using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

///////////////////////////////////////////
/// OrbSeries
/// An orb series is a list of all the orbs
/// for a given type (minor, lesser, etc).
///////////////////////////////////////////

public class OrbSeries : MonoBehaviour {
	// name for this type of orb
	public Text Name;

	// list of buttons, one for each level of the orb
	public List<Button> Buttons;

	///////////////////////////////////////////
	/// Init()
	///////////////////////////////////////////
	public void Init( string i_strOrbType ) {
		// name the orb properly
		string strText = StringTableManager.Get( i_strOrbType );
		Name.text = strText;

		// iterate through each button and load the appropriate graphic for the orb
		for ( int i = 0; i < Buttons.Count; ++i ) {
			Button button = Buttons[i];
			Image image = button.image;

			int nIndex = i+1;
			Sprite sprite = Resources.Load<Sprite>( i_strOrbType + "_" + nIndex );
			image.sprite = sprite;

			// also set the button up
			OrbButton scriptOrb = button.GetComponent<OrbButton>();
			scriptOrb.Init( i_strOrbType, nIndex );
		}
	}
}
