using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

////////////////////////////////
/// IDL_Characters
/// Immutable data loader for
/// all characters.
////////////////////////////////

public static class IDL_Characters {
	private static List<ID_Character> m_listCharacters;

	////////////////////////////////
	/// GetCharacters()
	////////////////////////////////
	public static List<ID_Character> GetCharacters() {
		if ( m_listCharacters == null )
			LoadCharacters();

		return m_listCharacters;
	}

	////////////////////////////////
	/// LoadCharacters()
	////////////////////////////////
	private static void LoadCharacters() {
		string strData = DataUtils.LoadFile( "characters" );

		m_listCharacters = JsonConvert.DeserializeObject<List<ID_Character>>( strData );
	}
}
