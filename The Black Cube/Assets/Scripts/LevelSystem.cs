using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
	public event EventHandler OnExpChanged;
	public event EventHandler OnLvlChanged;

	private int lvl;
	private int exp;
	private int expToNextLvl;

	public LevelSystem ()
	{
		lvl = 1;
		exp = 0;
		expToNextLvl = 100;
	}

	public void AddExp(int amount)
	{
		exp += amount;
		if (exp >= expToNextLvl) {
			lvl++;
			exp -= expToNextLvl;
			if (OnLvlChanged != null) OnExpChanged (this, EventArgs.Empty);
		}
		if (OnExpChanged != null) OnExpChanged (this, EventArgs.Empty);
	}

	public int GetLevelNumber ()
	{
		return lvl;
	}

	public float GetExpNormalized ()
	{
		return (float)exp / expToNextLvl;
	}
}
