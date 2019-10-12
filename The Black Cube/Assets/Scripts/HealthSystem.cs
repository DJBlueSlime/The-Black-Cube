using System;

public class HealthSystem
{
	public event EventHandler OnDamaged;
	public event EventHandler OnHealed;

	public int health;
	public int healthMax;
	
	public HealthSystem (int healthMax)
	{
		this.healthMax = healthMax;
		health = healthMax;
	}

	public int GetHealth ()
	{
		return health;
	}

	public float GetHealthNormalized ()
	{
		return (float)health / healthMax;
	}

	public void Damage(int damageAmount)
	{
		health -= damageAmount;
		if (health < 0) health = 0;
		if (OnDamaged != null) OnDamaged (this, EventArgs.Empty);
	}
	public void Heal (int healAmount)
	{
		health += healAmount;
		if (health > healthMax) health = healthMax;
		if (OnHealed != null) OnHealed (this, EventArgs.Empty);
	}

}
