using System;
using System.Collections;
using UnityEngine;

namespace Player_Scripts
{
  public class EnemyDeactivator : MonoBehaviour
  {
    private Animator _playerAnimator;
    [SerializeField] private GameObject _flash; 

    void Awake() => _playerAnimator = GetComponent<Animator> ();
    
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Enemy"))
      {
        _playerAnimator.SetBool("Flash", true);
        other.gameObject.SetActive(false);
        _flash.SetActive(true);
        
        StartCoroutine(FlashBlip());
      }
    }

    IEnumerator FlashBlip()
    {
      yield return new WaitForSeconds(0.2f);
      
      _playerAnimator.SetBool("Walk", true);
      _flash.SetActive(false);
      
    }
  }
}