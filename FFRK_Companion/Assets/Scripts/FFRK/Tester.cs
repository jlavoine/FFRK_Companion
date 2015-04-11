using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Tester : MonoBehaviour {
	// Use this for initialization
	void Start () {
		//Sprite sprite = Resources.Load<Sprite>( "II_Bronze Helm" );
		//TestImage.sprite = sprite;

		string test = StringTableManager.Instance.Get( "Test" );
		Debug.Log (test);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
