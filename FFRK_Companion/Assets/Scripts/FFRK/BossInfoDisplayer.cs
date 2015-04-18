using UnityEngine;
using System.Collections;

public class BossInfoDisplayer : MonoBehaviour {
	public GameObject Holder;
	
	///////////////////////////////////////////
	/// Start()
	///////////////////////////////////////////
	void Start () {
		// listen for messages
		Messenger.AddListener( "PrepBossInfo", OnBossSelected );	
		Messenger.AddListener( "CloseBossInfo", CloseInfo );	
		
		CloseInfo();
	}
	
	///////////////////////////////////////////
	/// OnDestroy()
	///////////////////////////////////////////
	void OnDestroy() {
		// remove messages
		Messenger.RemoveListener( "PrepBossInfo", OnBossSelected );
		Messenger.RemoveListener( "CloseBossInfo", CloseInfo );	
	}
	
	private void OnBossSelected() {
		// move the panel into place
		Holder.SetActive( true );
	}
	
	private void CloseInfo() {
		Holder.SetActive( false );
	}
}
