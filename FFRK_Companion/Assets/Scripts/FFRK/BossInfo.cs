using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BossInfo : MonoBehaviour {
	public Image RealmIcon;
	public Text RealmText;
	public Text DungeonName;
	public Text BossName;

	public GameObject VictoryConditionContent;
	public GameObject VictoryConditionPrefab;

	public List<GameObject> Elements;

	public GameObject StatusPrefab;
	public GameObject StatusContent;

	public Text Notes;

	void Awake() {
		Messenger.AddListener<ID_Boss>( "BossSelected", OnBossSelected );
	}

	void OnDestroy() {
		Messenger.RemoveListener<ID_Boss>( "BossSelected", OnBossSelected );
	}

	public void OnBossSelected( ID_Boss i_boss ) {
		// set boss name
		BossName.text = i_boss.name;
		
		// set dungeon related stuff
		ID_Dungeon dungeon = i_boss.GetDungeon();
		DungeonName.text = dungeon.name;
		RealmText.text = dungeon.GetRealmAsText();
		
		// set the color of the realm icon based on the realm
		string strKey = "Color_" + dungeon.realm;
		Color color = Constants.GetConstant<Color>( strKey );
		RealmIcon.color = color;

		// clear victory condition content and then add in this boss' conditions
		VictoryConditionContent.DestroyChildren();
		string strConditions = i_boss.victory;
		if ( string.IsNullOrEmpty( strConditions ) == false ) {
			List<string> listConditions = Constants.ParseStringList( strConditions );
			for ( int i = 0; i < listConditions.Count; ++i ) {
				string strCondition = listConditions[i];
				GameObject goCondition = GameObject.Instantiate( VictoryConditionPrefab );
				goCondition.transform.SetParent( VictoryConditionContent.transform );

				Text textCondition = goCondition.GetComponentInChildren<Text>();
				textCondition.text = strCondition;
			}
		}

		// do elements
		SetUpElementChart( i_boss );

		// do debuffs
		SetUpStatusChart( i_boss );

		// set the notes, if there are any
		string strNotes = i_boss.notes;
		if ( string.IsNullOrEmpty( strNotes )  )
		    Notes.text = "";
		else
			Notes.text = strNotes;
	}

	private void SetUpStatusChart( ID_Boss i_boss ) {
		// clear the old statuses
		StatusContent.DestroyChildren();

		// get list of status immunities from the boss
		string strImmunities = i_boss.debuffimm;
		if ( string.IsNullOrEmpty( strImmunities ) == false ) {
			List<string> listImmunities = Constants.ParseStringList( strImmunities );

			// go through and create an entry for each immunity
			for ( int i = 0; i < listImmunities.Count; ++i ) {
				string strStatus = listImmunities[i];

				GameObject goEntry = GameObject.Instantiate( StatusPrefab );
				goEntry.transform.SetParent( StatusContent.transform );

				Text textStatus = goEntry.GetComponentInChildren<Text>();
				textStatus.text = strStatus;
			}
		}

	}

	private void SetUpElementChart( ID_Boss i_boss ) {
		Color colorVuln = Constants.GetConstant<Color>( "Color_Vulnerable" );
		Color colorResist = Constants.GetConstant<Color>( "Color_Resist" );
		Color colorAbsorb = Constants.GetConstant<Color>( "Color_Absorb" );

		List<string> listVuln = new List<string>();
		List<string> listResist = new List<string>();
		List<string> listAbsorb = new List<string>();

		if ( string.IsNullOrEmpty( i_boss.vuln ) == false )
			listVuln = Constants.ParseStringList( i_boss.vuln );

		if ( string.IsNullOrEmpty( i_boss.resist ) == false )
			listResist = Constants.ParseStringList( i_boss.resist );

		if ( string.IsNullOrEmpty( i_boss.absorb ) == false )
			listAbsorb = Constants.ParseStringList( i_boss.absorb );

		for ( int i = 0; i < Elements.Count; ++i ) {
			GameObject goElement = Elements[i];
			Image image = goElement.GetComponent<Image>();
			Text text = goElement.GetComponentInChildren<Text>();
			string strElem = text.text;

			if ( listVuln.Contains( strElem ) )
				image.color = colorVuln;
			else if ( listResist.Contains( strElem ) )
				image.color = colorResist;
			else if ( listAbsorb.Contains( strElem ) )
				image.color = colorAbsorb;
		}
	}
}
