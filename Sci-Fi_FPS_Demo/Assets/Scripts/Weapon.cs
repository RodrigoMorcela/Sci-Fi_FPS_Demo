using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private float _rotationMutiplier;

    private bool _recoiling;

    private Animator _animator;

    private AudioSource _audioSource;
    
    [SerializeField]
    private AudioClip _shootSound;

    // Start is called before the first frame update
    void Start()
    {

        _rotationMutiplier = 0.065f;

        _recoiling = false;

        _animator = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float mouseInputX = Input.GetAxis("Mouse X");

        Vector3 rotation = transform.localEulerAngles;

        rotation.y = mouseInputX * _rotationMutiplier;

        transform.localEulerAngles = rotation;
        
    }

    public void Fire()
    {
        _animator.SetTrigger("Recoil");

        _audioSource.clip = _shootSound;

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    public void StopFire()
    {
        _animator.SetTrigger("StopRecoil");

        _audioSource.Stop();
    }

    
}
