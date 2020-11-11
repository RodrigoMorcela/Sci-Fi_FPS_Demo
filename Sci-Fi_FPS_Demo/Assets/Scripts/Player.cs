using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private NavMeshAgent _navAgent;

    [SerializeField]
    private float _speed;
    private float _gravity;
    
    [SerializeField]
    private GameObject _muzzelFlash;

    [SerializeField]
    private GameObject _gameObjWeapon;

    private Weapon _weapon;

    [SerializeField]
    private GameObject _hitMarkerPrefab;

    [SerializeField]
    private int _currentAmmo;

    private int _maxAmmo;

    private UIManager _uiManager;

    [SerializeField]
    private bool _hasCoin;

    [SerializeField]
    private GameObject _parentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _speed = 3.5f;

        _gravity = 9.81f;

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        _muzzelFlash.SetActive(false);

        _weapon = _gameObjWeapon.GetComponent<Weapon>();

        _maxAmmo = 150;

        _currentAmmo = _maxAmmo;

        _hasCoin = false;

        _parentWeapon.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        MouseInput();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentAmmo = _maxAmmo;

            _uiManager.UpdateAmmo(_currentAmmo);
        }

    }

    private void MouseInput()
    {

        if (Input.GetMouseButton(0) && _currentAmmo > 0)
        {
            Shoot();

            _currentAmmo--;

            _uiManager.UpdateAmmo(_currentAmmo);
            
        }
        else
        {
            _muzzelFlash.SetActive(false);

            _weapon.StopFire();
        }

    }

    private void Shoot()
    {
        _weapon.Fire();

        _muzzelFlash.SetActive(true);

        Ray originRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(originRay, out hitInfo))
        {
            print("Hit: " + hitInfo);

            GameObject newHitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            Destroy(newHitMarker, 1f);

            Destructable crate = hitInfo.transform.GetComponent<Destructable>();

            if(crate != null)
            {
                crate.DestroyCrate();
            }

        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        Vector3 velocity = direction * _speed;

        velocity.y -= _gravity;

        velocity = transform.transform.TransformVector(velocity);

        _navAgent.Move(velocity * Time.deltaTime);
    }

    public void GiveCoin()
    {
        _hasCoin = true;

        _uiManager.AddCoin();
    }

    public void GetCoin()
    {
        _hasCoin = false;

        _uiManager.RemoveCoin();
    }

    public bool HasCoin()
    {
        return _hasCoin;
    }

    public void GiveWeapon()
    {
        print("here");

        _parentWeapon.SetActive(true);
    }
}
