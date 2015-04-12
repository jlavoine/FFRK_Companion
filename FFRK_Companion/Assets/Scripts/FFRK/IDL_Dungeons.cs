using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

////////////////////////////////
/// IDL_Dungeons
/// Immutable data loader for
/// all dungeons.
////////////////////////////////

public static class IDL_Dungeons {
	private static List<ID_Dungeon> m_listDungeons;
	
	////////////////////////////////
	/// GetDungeons()
	////////////////////////////////
	public static List<ID_Dungeon> GetDungeons() {
		if ( m_listDungeons == null )
			LoadDungeons();
		
		return m_listDungeons;
	}
	
	////////////////////////////////
	/// LoadDungeons()
	////////////////////////////////
	private static void LoadDungeons() {
		string strData = DataUtils.LoadFile( "dungeons" );
		
		m_listDungeons = JsonConvert.DeserializeObject<List<ID_Dungeon>>( strData );
	}
}
