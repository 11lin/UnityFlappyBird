using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
	public GameObject columnPrefab;
	public int columnPoolSize = 5;
	public float spawnRate = 4f;
	public float columnMin = -2.7f;
	public float columnMax = 1.4f;
	public float spawnXPosition = 6f;

	private float spawnLastTime = 0f;
	private Vector2 objPoolPosition = new Vector2 (-15f, -25f);
	private short currentColumnIdx = 0;
	private GameObject[] columns;

	// Use this for initialization
	void Start () {
		columns = new GameObject [columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++) {
			columns [i] = (GameObject)Instantiate (columnPrefab, objPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.instance.currentStatus == EnumGameStatus.IN_GAME) {
			spawnLastTime += Time.deltaTime;
			if (spawnLastTime > spawnRate) {
				spawnLastTime = 0f;

				float yPos = Random.Range (columnMin, columnMax);
				columns [currentColumnIdx++].transform.position = new Vector2 (spawnXPosition, yPos);
				if (currentColumnIdx >= columnPoolSize)
					currentColumnIdx = 0;
			}
		}

	}
}
