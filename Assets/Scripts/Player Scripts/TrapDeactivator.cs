using UnityEngine;

namespace Player_Scripts
{
  public class TrapDeactivator : MonoBehaviour
  {
    [SerializeField] private Transform _player;
    [HideInInspector] private AudioSource _audioSource;
    

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
//      var keyUp = Input.GetKeyUp(KeyCode.Space);
//      if (keyUp)
//      {
//        _audioSource.Play();
//        
//        ChangePlayer();
//      }
    }

    void ChangePlayer()
    {
      Debug.Log("Trap deactivated!");
      var playerPosition = _player.localPosition;
      playerPosition.y += 0.3f;
      _player.localPosition = playerPosition;
    }
  }
}