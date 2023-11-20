using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public string success;
    public string nofication;
    public string data;
    public string url;
    public int stt;
    public string name;
    public string id;
    public string fb_id;
    public string id_discord;
    PlayerModel(string success, string nofication, string data, string url, int stt, string name, string id, string fb_id, string id_discord)
    {
        this.success = success;
        this.nofication = nofication;
        this.data = data;
        this.url = url;
        this.stt = stt;
        this.name = name;
        this.id = id;
        this.fb_id = fb_id;
        this.id_discord = id_discord;
    }
}