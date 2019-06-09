using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;
	private Rigidbody2D myBody;
	private Animator anim;

	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		PlayerWalkKeyboard ();
	}

	void PlayerWalkKeyboard() {
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {

			if (vel < maxVelocity)
				forceX = speed;

			PlayerScale();

			anim.SetBool ("Walk", true);

		} else if (h < 0) {
		
			if (vel < maxVelocity)
				forceX = -speed;
			
			PlayerScale(-1);
			
			anim.SetBool ("Walk", true);

		} else {
			anim.SetBool ("Walk", false);
		}

		myBody.AddForce (new Vector2(forceX, 0));
		
	}

	void PlayerScale(int side = 1)
	{
		
		Vector3 temp = transform.localScale;
		temp.x = side * GameManager.instance.PlayerScale;
		temp.y = GameManager.instance.PlayerScale;
			
		transform.localScale = temp;
	}

} // Player














































