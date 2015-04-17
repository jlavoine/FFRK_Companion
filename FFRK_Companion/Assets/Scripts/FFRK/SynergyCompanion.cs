using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SynergyCompanion : MonoBehaviour {
	public int NumTips;
	public string TipKey;

	public GameObject ContentArea;
	public GameObject TipPrefab;

	void Start() {
		for ( int i = 0; i < NumTips-1; ++i ) {
			GameObject goTip = GameObject.Instantiate( TipPrefab );
			goTip.transform.SetParent( ContentArea.transform );

			int nIndex = i+1;

			string strTitle = StringTableManager.Get( TipKey + "_" + nIndex + "_Title" );
			Text textTitle = goTip.FindInChildren( "TitleText" ).GetComponent<Text>();
			textTitle.text = strTitle;

			string strBody = StringTableManager.Get( TipKey + "_" + nIndex + "_Body" );
			Text textBody = goTip.FindInChildren( "BodyText" ).GetComponent<Text>();
			textBody.text = strBody;
		}
	}

}
