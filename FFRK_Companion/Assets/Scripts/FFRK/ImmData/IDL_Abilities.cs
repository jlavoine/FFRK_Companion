using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

////////////////////////////////
/// IDL_Abilities
/// Immutable data loader for
/// all abilities.
////////////////////////////////

public static class IDL_Abilities {
	private static List<ID_Ability> m_listData;
	
	////////////////////////////////
	/// GetAbilities()
	////////////////////////////////
	public static List<ID_Ability> GetAbilities() {
		if ( m_listData == null )
			LoadData();
		
		return m_listData;
	}
	
	////////////////////////////////
	/// LoadData()
	////////////////////////////////
	private static void LoadData() {
		string strData = DataUtils.LoadFile( "abilities" );
		
		m_listData = JsonConvert.DeserializeObject<List<ID_Ability>>( strData );
	}
}
