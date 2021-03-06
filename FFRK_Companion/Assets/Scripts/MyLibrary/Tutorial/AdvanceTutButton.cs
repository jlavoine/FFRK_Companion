﻿using UnityEngine;
using System.Collections;

//////////////////////////////////////////
/// AdvanceTutButton
/// Really cheap and hacky OnGUI script
/// used to advanced tutorials.
//////////////////////////////////////////

public class AdvanceTutButton : MonoBehaviour {
	public float left;
	public float top;
	public float width;
	public float height;

	public GUIStyle style;

	void OnGUI() {
		// null check because I actually destroy this object on dev builds
		if ( FocusLostIcon.Instance != null ) {
			// because we can't control GUI layer objects, just don't show them if the game has lost focus
			bool bFocus = FocusLostIcon.Instance.IsGameFocused();
			if ( !bFocus )
				return;
		}

		if (GUI.Button (new Rect (left,top,width,height), "", style)) {
			Messenger.Broadcast( "OkPressed" ); 
		}
	}
}
