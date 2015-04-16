using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

////////////////////////////////
/// IDL_Orbs
/// Immutable data loader for
/// all orbs.
////////////////////////////////

public static class IDL_Orbs {
	private static List<ID_Orb> m_listData;
	
	////////////////////////////////
	/// GetOrbs()
	////////////////////////////////
	public static List<ID_Orb> GetOrbs() {
		if ( m_listData == null )
			LoadOrbs();
		
		return m_listData;
	}
	
	////////////////////////////////
	/// LoadOrbs()
	////////////////////////////////
	private static void LoadOrbs() {
		string strData = DataUtils.LoadFile( "orbs" );
		
		m_listData = JsonConvert.DeserializeObject<List<ID_Orb>>( strData );
	}
}
