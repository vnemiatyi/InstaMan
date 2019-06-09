using System;
using System.Collections;
using UnityEngine;

namespace Player_Scripts
{
  public class TrapDeactivator : MonoBehaviour
  {
    [SerializeField] private Transform _player;
    
    [HideInInspector] private AudioSource _audioSource;
    [HideInInspector] private bool _isTrapAcive = true;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
      var keyDown = Input.GetKey(KeyCode.Tab);
      if (keyDown && _isTrapAcive)
      {
        _isTrapAcive = false;
        Debug.Log("Trap deactivated!");

        _audioSource.Play();
        
        ChangePlayer();
      }
    }

    void ChangePlayer()
    {
      var playerPosition = _player.localPosition;
      playerPosition.y += 0.3f;
      _player.localPosition = playerPosition;
    }
  }
}