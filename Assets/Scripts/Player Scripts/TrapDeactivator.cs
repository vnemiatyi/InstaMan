using System;
using UnityEngine;

namespace Player_Scripts
{
  public class TrapDeactivator : MonoBehaviour
  {
    [SerializeField] private Transform _player;
    [SerializeField] private BoxCollider2D _platformBoxCollider;
    [SerializeField] private Transform _platformPosition;
    
    [HideInInspector] private bool _isTrapAcive = true;
    private void FixedUpdate()
    {
      var keyDown = Input.GetKey(KeyCode.Tab);
      if (keyDown && _isTrapAcive)
      {
        Debug.Log("Trap deactivated!");

        ChangePlatform();
        ChangePlatform();
        
        _isTrapAcive = false;
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

    void ChangePlayer()
    {
      var playerPosition = _player.localPosition;
      playerPosition.y += 1;
      _player.localPosition = playerPosition;
    }
  }
}