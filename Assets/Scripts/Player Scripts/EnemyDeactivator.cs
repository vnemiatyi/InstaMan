﻿using System;
using System.Collections;
using UnityEngine;

namespace Player_Scripts
{
  public class EnemyDeactivator : MonoBehaviour
  {
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _flash;
    private int counter;

    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Enemy"))
      {
        other.gameObject.SetActive(false);
        
        _audioSource.Play();
        _flash.SetActive(true);
        
        StartCoroutine(FlashBlip());

               
        counter++;
        GameplayController.instance.SetPhotoScore(counter);
      }
    }

    IEnumerator FlashBlip()
    {
      yield return new WaitForSeconds(0.2f);
      
      _flash.SetActive(false);
    }
  }
}