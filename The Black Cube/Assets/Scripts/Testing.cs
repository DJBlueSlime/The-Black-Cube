using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	[SerializeField] private LevelWindow lvlWin;
	private LevelSystem lvlSys;

	// Start is called before the first frame update
	private void Awake ()
	{
		lvlSys = new LevelSystem ();
		Debug.Log (lvlSys.GetLevelNumber ());
		lvlSys.AddExp (50);
		Debug.Log (lvlSys.GetLevelNumber ());
		lvlSys.AddExp (60);
		Debug.Log (lvlSys.GetLevelNumber ());

		lvlWin.SetLevelSystem (lvlSys);
	}

}
