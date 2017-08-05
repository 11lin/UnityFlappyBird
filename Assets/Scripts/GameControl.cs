using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum EnumGameStatus 
{
	READY, //准备
	IN_GAME,//游戏中
	GAME_OVER,//游戏结束
};
public class GameControl : MonoBehaviour {
	public static GameControl instance;
	//public bool isGameOver = false;

	public GameObject gameOverText;
	public GameObject tapBeginObject;

	public float scrollSpeed = -1.5f;
	public Text scoreText;
	private int score = 0;

	public EnumGameStatus currentStatus = EnumGameStatus.READY;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
        //currentStatus = EnumGameStatus.READY;
    }
    public void BeginGame()
	{
		currentStatus = EnumGameStatus.IN_GAME;
		tapBeginObject.SetActive (false);
		AudioManager.instance.Play ("sfx_swooshing");
		Bird.instance.BeginFly ();
    }
    // Update is called once per frame
    void Update () {
		if(currentStatus == EnumGameStatus.READY && Input.GetMouseButtonDown(0))
		{
			BeginGame ();
		}else if (currentStatus == EnumGameStatus.GAME_OVER && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	public void BirdDead(){
		currentStatus = EnumGameStatus.GAME_OVER;
		gameOverText.SetActive (true);
	}
	public void BirdScored(){
		if (currentStatus != EnumGameStatus.IN_GAME)
			return;
		score++;
		scoreText.text = "Score:" + score.ToString ();
	}
}
