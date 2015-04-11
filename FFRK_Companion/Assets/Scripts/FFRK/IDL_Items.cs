using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

////////////////////////////////
/// IDL_Items
/// Data loader for ALL items.
////////////////////////////////

public static class IDL_Items {
	private static List<ID_Item> m_listItems;
	
	////////////////////////////////
	/// GetItems()
	////////////////////////////////
	public static List<ID_Item> GetItems() {
		if ( m_listItems == null )
			LoadItems();
		
		return m_listItems;
	}
	
	////////////////////////////////
	/// LoadItems()
	////////////////////////////////
	private static void LoadItems() {
		string strData = DataUtils.LoadFile( "items" );
		
		m_listItems = JsonConvert.DeserializeObject<List<ID_Item>>( strData );
	}
}
