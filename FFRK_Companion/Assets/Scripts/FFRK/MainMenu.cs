using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

///////////////////////////////////////////
/// MainMenu
/// Script that creates all the options
/// on the main menu to display to the user.
///////////////////////////////////////////

[RequireComponent(typeof(ScrollRect))]
public class MainMenu : MonoBehaviour {
	// prefab for an option entry
	public GameObject OptionEntryPrefab;

	// list of options
	public List<string> Options;
	
	///////////////////////////////////////////
	/// Start()
	///////////////////////////////////////////
	void Start () {
		// set resolution if on windows
#if UNITY_STANDALONE_WIN
		Screen.SetResolution( 1136, 640, false );
#endif

		ScrollRect srect = GetComponent<ScrollRect>();
		GameObject goContent = srect.content.gameObject;

		// go through all options and set them up
		for ( int i = 0; i < Options.Count; ++i ) {
			string strKey = Options[i];

			// create the entry
			GameObject goOption = GameObject.Instantiate( OptionEntryPrefab );
			goOption.transform.SetParent( goContent.transform );

			// init the script
			MainOptionEntry option = goOption.GetComponent<MainOptionEntry>();
			option.Init( strKey );
		}
	}
}
