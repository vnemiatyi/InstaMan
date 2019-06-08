using System;
using System.Collections;
using UnityEngine;

namespace Player_Scripts
{
  public class TrapDeactivator : MonoBehaviour
  {
    [SerializeField] private Transform _player;
    [SerializeField] private BoxCollider2D _platformBoxCollider;
    [SerializeField] private Transform _platformPosition;
    
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
        
        ChangePlatform();
        
        StartCoroutine(ChangePlayer());
      }
    }

    void ChangePlatform()
    {
      var platformSize = _platformBoxCollider.size;
      platformSize.y *= 10;
      _platformBoxCollider.size = platformSize;

      var platformPosition = _platformPosition.localPosition;
      platformPosition.y = 0;
      _platformPosition.localPosition = platformPosition;
    }

    IEnumerator ChangePlayer()
    {
      yield return new WaitForEndOfFrame();
      
      var playerPosition = _player.localPosition;
      playerPosition.y += 0.3f;
      _player.localPosition = playerPosition;
    }
  }
}