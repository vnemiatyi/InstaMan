using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.CompareTag("Cloud") || target.CompareTag("Deadly")) {
			target.gameObject.SetActive(false);
		}
	}

}
