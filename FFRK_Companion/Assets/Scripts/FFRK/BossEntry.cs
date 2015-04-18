using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

////////////////////////////////
/// BossEntry
/// UI entry for a single boss.
////////////////////////////////

public class BossEntry : MonoBehaviour, IPointerClickHandler {
	public Image RealmIcon;
	public Text RealmText;
	public Text DungeonName;
	public Text BossName;

	private ID_Boss m_boss;

	////////////////////////////////
	/// Init()
	////////////////////////////////
	public void Init( ID_Boss i_boss ) {
		m_boss = i_boss;

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
	}

	public void OnPointerClick( PointerEventData i_event ) {
		Messenger.Broadcast( "PrepBossInfo" );
		Messenger.Broadcast<ID_Boss>( "BossSelected", m_boss );
	}
}
