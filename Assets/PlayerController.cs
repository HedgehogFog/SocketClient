using System.Collections;
using System.Collections.Generic;
using Multiplayer.player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private SyncPlayer syncPlayer;
	private Vector3 _lastPos;
	
	public float speed = 5f;
	// Use this for initialization
	void Start () {
		syncPlayer = new SyncPlayer();
		_lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(
			Input.GetAxis("Horizontal"), 0,
			Input.GetAxis("Vertical")) * Time.deltaTime * speed;

		if (Vector3.Distance(transform.position, _lastPos) > 0.05f)
		{
			_lastPos = transform.position;
			syncPlayer.SendPos(transform.position.x, transform.position.y, transform.position.z);	
		}
	}
}
