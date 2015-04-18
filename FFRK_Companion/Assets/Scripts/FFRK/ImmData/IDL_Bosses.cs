using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

////////////////////////////////
/// IDL_Bosses
/// Immutable data loader for
/// all bosses.
////////////////////////////////

public static class IDL_Bosses {
	private static List<ID_Boss> m_listData;
	
	////////////////////////////////
	/// GetBosses()
	////////////////////////////////
	public static List<ID_Boss> GetBosses() {
		if ( m_listData == null )
			LoadData();
		
		return m_listData;
	}

	////////////////////////////////
	/// GetBossesForRealm()
	////////////////////////////////
	public static List<ID_Boss> GetBossesForRealm( string i_strRealm ) {
		// get list of all bosses
		List<ID_Boss> listAllBosses = GetBosses();

		// if it's all, just return the list
		if ( i_strRealm == "All" )
			return listAllBosses;

		// otherwise, we need to trim this...
		List<ID_Boss> listBosses = new List<ID_Boss>();

		// go through every boss and check their realm against i_strRealm
		for ( int i = 0; i < listAllBosses.Count; ++i ) {
			ID_Boss boss = listAllBosses[i];
			ID_Dungeon dungeon = IDL_Dungeons.GetDungeonFromShortcut( boss.dungeon );

			if ( dungeon.realm == i_strRealm )
				listBosses.Add( boss );
		}

		return listBosses;
	}
	
	////////////////////////////////
	/// LoadData()
	////////////////////////////////
	private static void LoadData() {
		string strData = DataUtils.LoadFile( "bosses" );
		
		m_listData = JsonConvert.DeserializeObject<List<ID_Boss>>( strData );
	}
}
