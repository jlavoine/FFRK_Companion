using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TurnOffOrbInfo : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick( PointerEventData i_event ) {
		Messenger.Broadcast( "CloseOrbInfo" );
	}
}
