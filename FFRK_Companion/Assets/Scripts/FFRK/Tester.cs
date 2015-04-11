using UnityEngine;
using System.Collections;
using System.IO;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string strData = "";
		string strPath = Application.streamingAssetsPath + "/items.json";

		if ( File.Exists( strPath ) ) {
			FileStream file = new FileStream( strPath, FileMode.Open, FileAccess.Read );
			StreamReader sr = new StreamReader( file );

			strData = sr.ReadToEnd();
			sr.Close();
			file.Close();
		}

		Debug.Log ("What's this: " + strData);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
