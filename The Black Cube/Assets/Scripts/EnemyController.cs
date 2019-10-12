using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public CharController2D chr2d;
	public bool isPC;
	public Transform PCCheck;
	public float PCFloat;
	public LayerMask Player;
	public bool isHit = false;
	public HealthSystem heSys;

	// Start is called before the first frame update
	void Start ()
	{
		//isPC = Physics2D.OverlapBox (PCCheck.position, PCCheck.localScale, Player);
	}

	// Update is called once per frame
	void Update ()
	{
			if (isPC && !isHit) {
				isHit = true;
			}
			
	}

	// Si la clase MonoBehaviour está habilitada, se llama a esta función en cada fotograma de velocidad de fotograma fija
	private void FixedUpdate ()
	{
		isPC = Physics2D.OverlapBox (PCCheck.position, PCCheck.localScale, Player);
	}
}
