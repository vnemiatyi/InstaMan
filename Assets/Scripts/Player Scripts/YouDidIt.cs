using System;
using UnityEngine;

namespace Player_Scripts
{
  public class YouDidIt : MonoBehaviour
  {
    [SerializeField] private GameObject _fin;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        _fin.SetActive(true);
      }
    }
  }
}