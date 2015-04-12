using UnityEngine;
using System.Collections;

public class OrbButton : MonoBehaviour {
	private string m_strKey;
	private int m_nIndex;

	public void Init( string i_strKey, int i_nIndex ) {
		m_strKey = i_strKey;
		m_nIndex = i_nIndex;
	}

	public void OnClick() {
		Messenger.Broadcast<string, int>( "OrbSelected", m_strKey, m_nIndex );
	}
}
