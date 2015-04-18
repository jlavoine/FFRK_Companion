using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AbilityEntry : MonoBehaviour {
	public Text Name;
	public Text Multiplier;
	public Text Desc;
	public GameObject OrbsRequiredArea;
	public GameObject OrbRequiredPrefab;

	public void Init( ID_Ability i_ability ) {
		// set some basic info
		Name.text = i_ability.name;
		string strMultiplier = StringTableManager.Get( "Multiplier" );
		Multiplier.text = DrsStringUtils.Replace( strMultiplier, "NUM", i_ability.multiplier );
		Desc.text = i_ability.desc;

		// we need to create a list of orb buttons for each orb required for the ability
		List<string> listOrbs = Constants.ParseStringList( i_ability.orbs );
		for ( int i = 0; i < listOrbs.Count; ++i ) {
			string strOrbData = listOrbs[i];
			string[] arrayData = strOrbData.Split("_"[0]);
			int nOrbRank = int.Parse( arrayData[1] );
			string strRank = StringTableManager.Get( "Orb_" + nOrbRank );
			string strOrbType = StringTableManager.Get( arrayData[0] );
			string strOrb = strRank + " " + strOrbType;

			GameObject goEntry = GameObject.Instantiate( OrbRequiredPrefab );
			goEntry.transform.SetParent( OrbsRequiredArea.transform );

			Text textButton = goEntry.GetComponentInChildren<Text>();
			textButton.text = strOrb;

			TriggerOrbSelect scriptTrigger = goEntry.AddComponent<TriggerOrbSelect>();
			scriptTrigger.Init( strOrbType, nOrbRank );
		}
	}
}
