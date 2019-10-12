using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class LevelWindow : MonoBehaviour
{
	private TextMeshProUGUI txt;
	private Image expBarImg;
	private LevelSystem lvlSys;

	private void Awake ()
	{
		txt = transform.Find ("lvlText").GetComponent<TextMeshProUGUI> ();
		expBarImg = transform.Find ("lvlBar").GetComponent<Image> ();
	}

	private void SetExpBarSize (float expNormalized)
	{
		expBarImg.fillAmount = expNormalized;
	}

	private void SetLvlNumber(int levelNumber)
	{
		txt.SetText ("Lvl: " + levelNumber);
	}

	public void SetLevelSystem (LevelSystem levelSystem)
	{
		this.lvlSys = levelSystem;

		SetLvlNumber (lvlSys.GetLevelNumber ());
		SetExpBarSize (lvlSys.GetExpNormalized ());

		lvlSys.OnExpChanged += LevelSystem_OnExpChanged;
		lvlSys.OnLvlChanged += LevelSystem_OnLvlChanged;
	}

	private void LevelSystem_OnLvlChanged (object sender, EventArgs e)
	{
		SetLvlNumber (lvlSys.GetLevelNumber ());
	}

	private void LevelSystem_OnExpChanged (object sender, EventArgs e)
	{
		SetExpBarSize (lvlSys.GetExpNormalized ());
	}
}
