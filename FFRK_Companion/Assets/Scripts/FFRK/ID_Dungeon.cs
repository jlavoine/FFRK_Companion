using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ID_Dungeon {
	public string name;
	public string version;
	public string realm;
	public string orbs;
	public string bossorbs;

	public bool HasOrb( string i_strOrb ) {
		//Debug.Log ("Looking for " + i_strOrb);
		List<string> listOrbs = Constants.ParseStringList( orbs );

		//for ( int i = 0; i < listOrbs.Count; ++i )
		//	Debug.Log ("checking against " + listOrbs[i]);

		bool bHas = listOrbs.Contains( i_strOrb );
		return bHas;
	}

	public bool HasOrbBoss( string i_strOrb ) {
		if ( string.IsNullOrEmpty(bossorbs) )
			return false;

		List<string> listOrbs = Constants.ParseStringList( bossorbs );
		
		bool bHas = listOrbs.Contains( i_strOrb );
		return bHas;
	}
}
