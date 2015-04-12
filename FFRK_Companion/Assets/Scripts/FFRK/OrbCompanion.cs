using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbCompanion : MonoBehaviour {
	public GameObject OrbSeriesContent;
	public GameObject OrbSeriesPrefab;

	// Use this for initialization
	void Start () {
		List<string> listOrbTypes = new List<string>() { "Power", "White", "Black", "Blue", "Summon", "Non", "Fire", "Ice", "Lightning", "Earth", "Wind", "Holy", "Dark" };
	
		for ( int i = 0; i < listOrbTypes.Count; ++i ) {
			string strOrbType = listOrbTypes[i];

			GameObject goEntry = GameObject.Instantiate( OrbSeriesPrefab );
			goEntry.transform.SetParent( OrbSeriesContent.transform );

			OrbSeries script = goEntry.GetComponent<OrbSeries>();
			script.Init( strOrbType );
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
