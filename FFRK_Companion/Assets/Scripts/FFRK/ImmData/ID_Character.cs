using UnityEngine;
using System.Collections;

////////////////////////////////
/// ID_Character
/// Immutable data for a character.
////////////////////////////////

public class ID_Character  {
	public string character;
	public string realm;
	public string axe;
	public string ball;
	public string book;
	public string bow;
	public string dagger;
	public string fist;
	public string hammer;
	public string instrument;
	public string katana;
	public string rod;
	public string spear;
	public string staff;
	public string sword;
	public string thrown;
	public string whip;
	public string armor;
	public string bracer;
	public string hat;
	public string helm;
	public string lightArmor;
	public string robe;
	public string shield;

	public bool CanUse( string i_strType ) {
		i_strType = i_strType.ToLower();

		// don't care about accessory for now
		if ( i_strType == "accessory" )
			return false;

		// special case for light armor
		if ( i_strType == "light armor" )
			i_strType = "lightArmor";

		bool bCanUse = false;

		switch ( i_strType ) {
		case "axe":
			bCanUse = string.IsNullOrEmpty( axe ) == false;
			break;
		case "ball":
			bCanUse = string.IsNullOrEmpty( ball ) == false;
			break;
		case "book":
			bCanUse = string.IsNullOrEmpty( book ) == false;
			break;
		case "bow":
			bCanUse = string.IsNullOrEmpty( bow ) == false;
			break;
		case "dagger":
			bCanUse = string.IsNullOrEmpty( dagger ) == false;
			break;
		case "fist":
			bCanUse = string.IsNullOrEmpty( fist ) == false;
			break;
		case "hammer":
			bCanUse = string.IsNullOrEmpty( hammer ) == false;
			break;
		case "instrument":
			bCanUse = string.IsNullOrEmpty( instrument ) == false;
			break;
		case "katana":
			bCanUse = string.IsNullOrEmpty( katana ) == false;
			break;
		case "rod":
			bCanUse = string.IsNullOrEmpty( rod ) == false;
			break;
		case "spear":
			bCanUse = string.IsNullOrEmpty( spear ) == false;
			break;
		case "staff":
			bCanUse = string.IsNullOrEmpty( staff ) == false;
			break;
		case "sword":
			bCanUse = string.IsNullOrEmpty( sword ) == false;
			break;
		case "thrown":
			bCanUse = string.IsNullOrEmpty( thrown ) == false;
			break;
		case "whip":
			bCanUse = string.IsNullOrEmpty( whip ) == false;
			break;
		case "armor":
			bCanUse = string.IsNullOrEmpty( armor ) == false;
			break;
		case "bracer":
			bCanUse = string.IsNullOrEmpty( bracer ) == false;
			break;
		case "hat":
			bCanUse = string.IsNullOrEmpty( hat ) == false;
			break;
		case "helm":
			bCanUse = string.IsNullOrEmpty( helm ) == false;
			break;
		case "shield":
			bCanUse = string.IsNullOrEmpty( shield ) == false;
			break;
		case "lightArmor":
			bCanUse = string.IsNullOrEmpty( lightArmor ) == false;
			break;
		case "robe":
			bCanUse = string.IsNullOrEmpty( robe ) == false;
			break;
		default:
			Debug.LogError("Missing case: " + i_strType);
			break;
		}

		return bCanUse;
	}
}
