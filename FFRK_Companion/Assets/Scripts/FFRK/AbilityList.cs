using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityList  {
	private Dictionary<string, int> m_dictAbilities;

	public AbilityList( string i_strAbilities ) {
		m_dictAbilities = new Dictionary<string, int>();

		List<string> listAbilities = Constants.ParseStringList( i_strAbilities );
		for ( int i = 0; i < listAbilities.Count; ++i ) {
			string strAbility = listAbilities[i];
			string[] arrayAbility = strAbility.Split("_"[0]);
			string strAbilityName = arrayAbility[0];
			int nAbilityRank = int.Parse( arrayAbility[1] );
			m_dictAbilities.Add( strAbilityName, nAbilityRank );
		}
	}

	public bool CanUseAbility( ID_Ability i_ability ) {
		bool bCanUse = false;

		if ( m_dictAbilities.ContainsKey( i_ability.school ) ) {
			int nRank = m_dictAbilities[i_ability.school];
			if ( nRank >= int.Parse(i_ability.rank) )
				return true;
		}

		return bCanUse;
	}
}
