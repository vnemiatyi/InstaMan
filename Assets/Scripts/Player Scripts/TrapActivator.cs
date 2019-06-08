using System;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    [HideInInspector] private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        GameManager.instance.ScaleBuff();
        
        _audioSource.Play();
        
        var tempLocalScale = other.transform.localScale;
        tempLocalScale.x = GameManager.instance.PlayerScale;
        tempLocalScale.y = GameManager.instance.PlayerScale;
        
        other.transform.localScale = tempLocalScale;
        
        gameObject.SetActive(false);
      }
    }
}
