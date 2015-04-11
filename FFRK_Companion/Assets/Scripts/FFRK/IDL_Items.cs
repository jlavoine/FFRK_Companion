using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class IDL_Items {

	public static void LoadItems() {
		string strData = "";
		string strPath = Application.streamingAssetsPath + "/items.json";
		
		if ( File.Exists( strPath ) ) {
			FileStream file = new FileStream( strPath, FileMode.Open, FileAccess.Read );
			StreamReader sr = new StreamReader( file );
			
			strData = sr.ReadToEnd();
			sr.Close();
			file.Close();
		}
	}
}
