using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OrbSeries : MonoBehaviour {
	public Text Name;
	public List<Button> Buttons;

	public void Init( string i_strOrbType ) {
		string strText = StringTableManager.Instance.Get( i_strOrbType );
		Name.text = strText;

		for ( int i = 0; i < Buttons.Count; ++i ) {
			Button button = Buttons[i];
			Image image = button.image;

			int nIndex = i+1;
			Sprite sprite = Resources.Load<Sprite>( i_strOrbType + "_" + nIndex );
			image.sprite = sprite;

			OrbButton scriptOrb = button.GetComponent<OrbButton>();
			scriptOrb.Init( i_strOrbType, nIndex );
		}
	}
}
