using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

///////////////////////////////////////////
/// OrbCompanion
/// Main manager for the orb info screen.
///////////////////////////////////////////

public class OrbCompanion : MonoBehaviour {
	// title for this screen
	public Text TitleText;

	// where the orb series content goes, and the prefab for each entry
	public GameObject OrbSeriesContent;
	public GameObject OrbSeriesPrefab;

	///////////////////////////////////////////
	/// Start()
	///////////////////////////////////////////
	void Start () {
		// set the title
		string strTitle = StringTableManager.Get( "Title_Orb" );
		TitleText.text = strTitle;

		// hard-coded list of orbs, for the moment
		List<string> listOrbTypes = new List<string>() { "Power", "White", "Black", "Summon", "Non", "Fire", "Ice", "Lightning", "Earth", "Wind", "Holy", "Dark" };
	
		// loop through each orb type and create a series to display it
		for ( int i = 0; i < listOrbTypes.Count; ++i ) {
			string strOrbType = listOrbTypes[i];

			GameObject goEntry = GameObject.Instantiate( OrbSeriesPrefab );
			goEntry.transform.SetParent( OrbSeriesContent.transform );

			OrbSeries script = goEntry.GetComponent<OrbSeries>();
			script.Init( strOrbType );
		}
	}
}
