using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	public float upForce = 200f;
	private Rigidbody2D rb2d;
	private Animator anim;
	public static Bird instance;


	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		rb2d.velocity = Vector2.zero;
		rb2d.bodyType = RigidbodyType2D.Static;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.instance.currentStatus == EnumGameStatus.IN_GAME) {
			if (Input.GetMouseButtonDown (0)) {
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flap");
				AudioManager.instance.Play ("sfx_wing");
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
		rb2d.velocity = Vector2.zero;
		anim.SetTrigger ("Die");
		if (GameControl.instance.currentStatus != EnumGameStatus.GAME_OVER) {
			AudioManager.instance.Play ("sfx_die");
			AudioManager.instance.Play ("sfx_hit");
		}
		GameControl.instance.BirdDead ();
	}
	public void BeginFly(){
		rb2d.bodyType = RigidbodyType2D.Dynamic;
	}
}
