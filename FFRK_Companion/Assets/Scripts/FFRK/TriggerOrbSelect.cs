using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TriggerOrbSelect : MonoBehaviour, IPointerClickHandler {
	private int m_nRank;
	private string m_strOrb;

	public void Init( string i_strOrb, int i_nRank ) {
		m_strOrb = i_strOrb;
		m_nRank = i_nRank;
	}

	public void OnPointerClick( PointerEventData i_event ) {
		Messenger.Broadcast( "PrepOrbInfo" );
		Messenger.Broadcast<string, int>( "OrbSelected", m_strOrb, m_nRank );
	}

}
