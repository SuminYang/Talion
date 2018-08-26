using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGoinInfo : MonoBehaviour
{
    [SerializeField]
    private Text coinText;

    void Start()
    {
        UpdateCoinData();
    }

    public void OnClickGainCoinButton()
    {
        PlayerDataManager.GetCoin(1);
        UpdateCoinData();
    }

    public void UpdateCoinData()
    {
        coinText.text = PlayerDataManager.NowCoinNum.ToString();
    }

 
}
