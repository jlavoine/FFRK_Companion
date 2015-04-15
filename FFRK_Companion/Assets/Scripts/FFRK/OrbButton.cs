using UnityEngine;
using System.Collections;

///////////////////////////////////////////
/// OrbButton
/// This is a button that represents an orb.
///////////////////////////////////////////

public class OrbButton : MonoBehaviour {
	private string m_strKey;
	private int m_nIndex;

	///////////////////////////////////////////
	/// Init()
	///////////////////////////////////////////
	public void Init( string i_strKey, int i_nIndex ) {
		m_strKey = i_strKey;
		m_nIndex = i_nIndex;
	}

	///////////////////////////////////////////
	/// OnClick()
	///////////////////////////////////////////
	public void OnClick() {
		Messenger.Broadcast<string, int>( "OrbSelected", m_strKey, m_nIndex );
	}
}
