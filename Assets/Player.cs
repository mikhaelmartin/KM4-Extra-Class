using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private void Start()
    {
        var json = PlayerPrefs.GetString("PlayerLastCheckpoint", "");

        if (json != "")
        {
            playerData.FromJson(json);
            this.transform.position = playerData.position;
        }
    }

    public void CheckPoint()
    {
        playerData.position = this.transform.position;
        var json = playerData.GetJson();
        PlayerPrefs.SetString("PlayerLastCheckpoint", json);
    }
}
