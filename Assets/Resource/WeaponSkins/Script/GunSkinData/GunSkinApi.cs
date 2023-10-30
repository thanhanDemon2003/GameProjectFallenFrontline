using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using GunSkinModel;

public class GunSkinApi
{
  private const string BaseURL = "https://darkdisquite.demondev.games/games/wardrobeplayer/652582884b678760d528928e";

  public static async Task<GunSkinData> GetAllSkins()
  {
    string url = BaseURL;
    
    
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {

      var operation = request.SendWebRequest();

      while (!operation.isDone)
        await Task.Delay(100);
        

      if (request.result != UnityWebRequest.Result.Success)
      {
        Debug.LogError(request.error);
        return null;
      }
      string json = request.downloadHandler.text;
      GunSkinData Skins = JsonUtility.FromJson<GunSkinData>(json);
      return Skins;
    }
  }
}
