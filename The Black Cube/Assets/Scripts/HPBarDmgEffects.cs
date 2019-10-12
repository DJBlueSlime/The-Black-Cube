using System;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using CodeMonkey;
using TMPro;

public class HPBarDmgEffects : MonoBehaviour
{
	private const float DAMAGED_HEALTH_SHRINK_TIMER_MAX = 1f;

	private TextMeshProUGUI hpAmount;
	private Image barImage;
	private Image damagedBarImage;
	private float damagedHealthShrinkTimer;
	[HideInInspector] public int hp = 100;
	[HideInInspector] public int wid;
	private HealthSystem healthSystem;
	private Animator anim;

	[HideInInspector]public bool IsHurt = false;

	private void Awake ()
	{
		hpAmount = transform.Find ("HP Amount").GetComponent<TextMeshProUGUI> ();
		barImage = transform.Find ("bar").GetComponent<Image> ();
		damagedBarImage = transform.Find ("damagedBar").GetComponent<Image> ();
		anim = GameObject.Find ("Player").GetComponent<Animator> ();
	}

	private void Start ()
	{
		healthSystem = new HealthSystem (100);
		damagedBarImage.fillAmount = barImage.fillAmount;
		healthSystem.OnDamaged += HealthSystem_OnDamaged;
		healthSystem.OnHealed += HealthSystem_OnHealed;
		SetHealth (healthSystem.GetHealthNormalized ());


		CMDebug.ButtonUI (new Vector2 (-100, -50), "Damage", () => healthSystem.Damage (10));
		CMDebug.ButtonUI (new Vector2 (+100, -50), "Heal", () => healthSystem.Heal (10));
	}

	private void Update ()
	{
		hpAmount.SetText ("100 / " + healthSystem.health);

		Debug.Log (healthSystem.health);
		if (IsHurt == true) {
			anim.SetBool ("Is Hurt", true);
			IsHurt = false;
		} else {
			anim.SetBool ("Is Hurt", false);
		}
		damagedHealthShrinkTimer -= Time.deltaTime;
		if (damagedHealthShrinkTimer < 0) {
			if (barImage.fillAmount < damagedBarImage.fillAmount) {
				float shrinkSpeed = 1.2f;
				damagedBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
			}
		}
	}

	private void HealthSystem_OnHealed (object sender, EventArgs e)
	{
		SetHealth (healthSystem.GetHealthNormalized ());
		damagedBarImage.fillAmount = barImage.fillAmount;
	}

	private void HealthSystem_OnDamaged (object sender, EventArgs e)
	{
		damagedHealthShrinkTimer = DAMAGED_HEALTH_SHRINK_TIMER_MAX;
		SetHealth (healthSystem.GetHealthNormalized());
		IsHurt = true;
	}

	private void SetHealth (float healthNormalized)
	{
		barImage.fillAmount = healthNormalized;
	}
}
