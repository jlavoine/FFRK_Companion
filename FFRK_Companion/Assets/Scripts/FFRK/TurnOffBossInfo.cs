using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TurnOffBossInfo : MonoBehaviour, IPointerClickHandler {
	
	public void OnPointerClick( PointerEventData i_event ) {
		Messenger.Broadcast( "CloseBossInfo" );
	}
}
