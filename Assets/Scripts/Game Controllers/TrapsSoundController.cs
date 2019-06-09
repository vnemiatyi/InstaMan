using System.Collections.Generic;
using UnityEngine;

namespace Game_Controllers
{
  public class TrapsSoundController : MonoBehaviour
  {
    public static TrapsSoundController instance;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _trapsSoundsCollection;

    
    
    void Awake () {
      MakeSingleton ();
    }

    void MakeSingleton() {
      if (instance != null) {
        Destroy (gameObject);
      } else {
        instance = this;
        DontDestroyOnLoad(gameObject);
      }
    }	
    
    private void FixedUpdate()
    {
//      var keyUp = Input.GetKeyDown(KeyCode.Space);
//      if (keyUp)
//      {
//        _audioSource.clip = _trapsSoundsCollection[0];
//        _audioSource.Play();
//      }
    }
  }
}