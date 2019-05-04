using UnityEngine;
using System.Collections;


public enum Mode
{
	Easy = 0,
	Medium = 1,
	Hard = 2,
}

public class CameraScript : MonoBehaviour {

	private float speed = 1.0f;
	private float acceleration = 0.2f;
	private float maxSpeed = 3.2f;

	[HideInInspector]
	public bool moveCamera;

	private float easySpeed = 3.2f;
	private float mediumSpeed = 3.7f;
	private float hardSpeed = 4.2f;

	[SerializeField]
	private Transform _player;

	private int _mode = 0;
	
	void Start () {

		if (GamePreferences.GetEasyDifficultyState () == 0) {
			maxSpeed = easySpeed;
		}

		if (GamePreferences.GetMediumDifficultyState () == 0) {
			maxSpeed = mediumSpeed;
		}

		if (GamePreferences.GetHardDifficultyState () == 0) {
			maxSpeed = hardSpeed;
		}

		moveCamera = true;
	}

	void Update ()
	{
		if (moveCamera) 
		{
			MoveCamera (_mode);	
		}
	}

	void MoveCamera(int mode) {
		
		var temp = transform.position;
		
		var oldY = temp.y;
		
		var newY = NewCameraY(temp.y);
		
		temp.y = Mathf.Clamp (temp.y, oldY, newY);
		
		transform.position = temp;
		
		speed += acceleration * Time.deltaTime;
		
		if (speed > maxSpeed)
			speed = maxSpeed;
		
	}

	float NewCameraY(float posY)
	{
		switch (_mode)
		{
			case (int) Mode.Easy:
				return _player.position.y;
			case (int) Mode.Medium:
				return _player.position.y;
			case (int) Mode.Hard:
				return posY - (speed * Time.deltaTime);
			default:
				return _player.position.y;
		}
	}
} // CameraScript















































