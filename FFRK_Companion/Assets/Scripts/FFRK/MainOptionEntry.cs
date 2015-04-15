using UnityEngine;
using UnityEngine.UI;
using System.Collections;

///////////////////////////////////////////
/// MainOptionEntry
/// This is a single entry in the main 
/// menu that explains a feature to a user.
///////////////////////////////////////////

public class MainOptionEntry : MonoBehaviour {
	// button that user clicks to load scene this entry represents
	public GameObject SceneButton;

	// text on the button and description describing the feature
	public Text ButtonText;
	public Text Description;

	///////////////////////////////////////////
	/// Init()
	///////////////////////////////////////////
	public void Init( string i_strKey ) {
		// set the text on the button and desc field
		string strButtonText = StringTableManager.Get( i_strKey + "_Button" );
		string strDescText = StringTableManager.Get( i_strKey + "_Description" );

		ButtonText.text = strButtonText;
		Description.text = strDescText;

		// add the scene load script to the button
		LoadScene scriptLoad = SceneButton.AddComponent<LoadScene>();
		scriptLoad.SetScene( i_strKey );
	}
}
