using System.Collections;
using UnityEngine;

namespace Player_Scripts
{
  public class TrapCollision : MonoBehaviour
  {
    [SerializeField] private AudioSource _audioSource;
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        _audioSource.Play();
      }
    }

  }
}