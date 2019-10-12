using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
	public Animator anim;
	public CharController2D ch2d;
	public Collision2D col;

	public int levelToLoad;
	private int AlreadyDid = 0;

	// Update is called once per frame
	//private void OnCollisionEnter2D (Collision2D col)
	//{
		//if (col.collider.tag == "GameOver") {
		//	FadeToScene (0);
		//	OnFadeComplete ();
		//	AlreadyDid = 0;
		//}
	//}

	private void Update ()
	{
		if (ch2d.rb.position.y < -2f) {
			FadeToScene (0);
			AlreadyDid++;
		}
	}

	void FadeToScene (int levelIndex)
	{
		levelToLoad = levelIndex;
		anim.SetTrigger ("FadeIn");
	}

		void OnFadeComplete ()
	{
		SceneManager.LoadScene (levelToLoad);
	}

}
