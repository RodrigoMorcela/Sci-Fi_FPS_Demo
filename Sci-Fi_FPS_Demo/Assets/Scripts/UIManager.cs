using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _ammoCount;

    [SerializeField]
    private Text _sharkDialog;


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

    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }

    public void SharkSaysToGetOut()
    {
        _sharkDialog.text = "Get out of Here! \n Come back when you have something to give me";
    }

    public void SharkThanks()
    {
        _sharkDialog.text = "Thank you, It wasnt me who sold you this \n If you say something, I know your face";
    }

    public void SharkStopLine()
    {
        _sharkDialog.text = "";
    }

}
