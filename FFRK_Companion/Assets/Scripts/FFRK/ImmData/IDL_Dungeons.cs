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

	public static ID_Dungeon GetDungeon( string i_strDungeon ) {
		if ( m_listDungeons == null )
			LoadDungeons();

		for ( int i = 0; i < m_listDungeons.Count; ++i ) {
			ID_Dungeon dungeon = m_listDungeons[i];
			if ( dungeon.name == i_strDungeon )
				return dungeon;
		}

		Debug.LogError( "Couldn't find dungeon for " + i_strDungeon );
		return null;
	}

	public static ID_Dungeon GetDungeonFromShortcut( string i_strShortcut ) {
		if ( m_listDungeons == null )
			LoadDungeons();
		
		for ( int i = 0; i < m_listDungeons.Count; ++i ) {
			ID_Dungeon dungeon = m_listDungeons[i];
			if ( dungeon.shortcut == i_strShortcut )
				return dungeon;
		}
		
		Debug.LogError( "Couldn't find dungeon for " + i_strShortcut );
		return null;
	}
	
	////////////////////////////////
	/// LoadDungeons()
	////////////////////////////////
	private static void LoadDungeons() {
		string strData = DataUtils.LoadFile( "dungeons" );
		
		m_listDungeons = JsonConvert.DeserializeObject<List<ID_Dungeon>>( strData );
	}
}
