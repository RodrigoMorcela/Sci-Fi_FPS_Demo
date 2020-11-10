using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _ammoCount;


    [SerializeField]
    private GameObject _coin;

    public void UpdateAmmo(int count)
    {
        _ammoCount.text = (count / 3).ToString() + " / 50";
    }

    public void AddCoin()
    {
        _coin.SetActive(true);
    }

}
