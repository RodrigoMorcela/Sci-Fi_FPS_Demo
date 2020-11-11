using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{

    [SerializeField]
    private AudioSource _audioSource;

    private UIManager _uiManager;

    private bool _hastraded;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _hastraded = false;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Player player = other.GetComponent<Player>();

            if(Input.GetKeyDown(KeyCode.E) && player.HasCoin())
            {
                player.GetCoin();

                player.GiveWeapon();

                _uiManager.SharkThanks();

                _audioSource.Play();

                _hastraded = true;
            }

            if (_hastraded)
            {
                _uiManager.SharkThanks();
            }
            
            if(!_hastraded && !player.HasCoin())
            {
                _uiManager.SharkSaysToGetOut();
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.SharkStopLine();
        }
    }

}
