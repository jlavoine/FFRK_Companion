using UnityEngine;
using System.Collections;
using System.Collections.Generic;

///////////////////////////////////////////
/// ID_Dungeon
/// Immutable data for a single dungeon.
///////////////////////////////////////////

public class ID_Dungeon {
	public string name;
	public string version;
	public string realm;
	public string orbs;
	public string bossorbs;

	///////////////////////////////////////////
	/// HasOrb()
	/// Will check if this dungeon drops the
	/// incoming orb as a normal drop.
	///////////////////////////////////////////
	public bool HasOrb( string i_strOrb ) {
		// ugh...parse the list of strings...
		List<string> listOrbs = Constants.ParseStringList( orbs );

		bool bHas = listOrbs.Contains( i_strOrb );
		return bHas;
	}

	///////////////////////////////////////////
	/// HasOrb_Boss()
	/// Will check if this dungeon drops the
	/// incoming orb as a boss drop.
	///////////////////////////////////////////
	public bool HasOrb_Boss( string i_strOrb ) {
		// some dungeons may not have boss drops...
		if ( string.IsNullOrEmpty(bossorbs) )
			return false;

		// ugh...parse the list of strings...
		List<string> listOrbs = Constants.ParseStringList( bossorbs );
		
		bool bHas = listOrbs.Contains( i_strOrb );
		return bHas;
	}
}
