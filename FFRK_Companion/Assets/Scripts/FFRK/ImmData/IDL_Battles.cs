using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class IDL_Battles : MonoBehaviour {
	private static List<ID_Battle> m_listData;
	
	////////////////////////////////
	/// GetBattle()
	////////////////////////////////
	public static List<ID_Battle> GetBattles() {
		if ( m_listData == null )
			LoadBattles();
		
		return m_listData;
	}
	
	////////////////////////////////
	/// LoadBattles()
	////////////////////////////////
	private static void LoadBattles() {
		string strData = DataUtils.LoadFile( "battles" );
		
		m_listData = JsonConvert.DeserializeObject<List<ID_Battle>>( strData );
	}
}
