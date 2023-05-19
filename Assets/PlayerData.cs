using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public int HP;
    public int SP;
    public List<string> items;

    public string GetJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void FromJson(string json)
    {
        var data = JsonUtility.FromJson<PlayerData>(json);
        if (data != null)
        {
            this.position = data.position;
            this.HP = data.HP;
            this.SP = data.SP;
            this.items = data.items;
        }
        else
        {
            Debug.LogError("Error: failed to read player data json");
        }
    }
}
