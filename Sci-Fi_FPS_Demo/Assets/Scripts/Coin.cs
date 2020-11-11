using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = transform.GetComponent<AudioSource>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            
            Player player = other.GetComponent<Player>();

            player.GiveCoin();

            _audioSource.Play();

            Destroy(this.gameObject, 0.3f);

        }
    }
}
