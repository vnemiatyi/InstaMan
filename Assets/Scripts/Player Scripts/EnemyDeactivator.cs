
using System;
using UnityEngine;

namespace Player_Scripts
{
  public class EnemyDeactivator : MonoBehaviour
  {
    private Animator _playerAnimator;

    void Awake() => _playerAnimator = GetComponent<Animator> ();
    
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Enemy"))
      {
        _playerAnimator.SetBool("Flash", true);
        other.gameObject.SetActive(false);
      }
    }
  }
}
