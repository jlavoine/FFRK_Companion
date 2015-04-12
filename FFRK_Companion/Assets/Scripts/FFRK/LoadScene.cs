using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public string Scene;

	public void OnClick() {
		Application.LoadLevel( Scene );
	}
}
