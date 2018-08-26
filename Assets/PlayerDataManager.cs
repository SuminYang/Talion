using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public const string CoinKey = "Coin";
}

public static class PlayerDataManager
{

#if UNITY_EDITOR
    [UnityEditor.MenuItem("PlayerData/ResetCoin")]
    static void CreateExampleAssetInstance()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
#endif

    public static int NowCoinNum
    {
        get
        {
            return PlayerPrefs.GetInt(Constants.CoinKey, 0);
        }
    }

    public static void GetCoin(int num)
    {
        int prefCoin = PlayerPrefs.GetInt(Constants.CoinKey, 0);

        prefCoin += num;

        PlayerPrefs.SetInt(Constants.CoinKey, prefCoin);
    }


    public static void UseCoin(int num)
    {
        int prefCoin = PlayerPrefs.GetInt(Constants.CoinKey, 0);

        prefCoin -= num;

        PlayerPrefs.SetInt(Constants.CoinKey, prefCoin);
    }

    public static bool CanBuyItem(int price)
    {
        int nowCoinNum = PlayerPrefs.GetInt(Constants.CoinKey, 0);

        nowCoinNum -= price;

        return nowCoinNum >= 0 ? true : false;
    }

}
