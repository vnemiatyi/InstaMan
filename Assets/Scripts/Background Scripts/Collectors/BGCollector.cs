using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.CompareTag("Background")) {
			target.gameObject.SetActive(false);
		}
	}

}
