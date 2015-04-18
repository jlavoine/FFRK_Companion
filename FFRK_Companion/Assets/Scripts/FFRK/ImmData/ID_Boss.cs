using UnityEngine;
using System.Collections;

////////////////////////////////
/// ID_Boss
/// Immutable data for one boss.
////////////////////////////////

public class ID_Boss {
	public string name;
	public string dungeon;
	public string victory;
	public string attacks;
	public string resist;
	public string vuln;
	public string absorb;
	public string debuffimm;
	public string notes;

	public ID_Dungeon GetDungeon() {
		ID_Dungeon dataDungeon = IDL_Dungeons.GetDungeonFromShortcut( dungeon );
		return dataDungeon;
	}
}
