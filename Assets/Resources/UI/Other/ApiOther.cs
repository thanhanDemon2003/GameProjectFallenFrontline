using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using TransactionModel;
using PaymentModel;

public class ApiOther 
{
    private const string BaseURL = "https://darkdisquitegame.andemongame.tech/games/";
    public static async Task<TransactionData> GetAllTransactionModel(string idPlayer)
    {
        string url = BaseURL+ "gettransactionplayer/" + idPlayer;  
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
            TransactionData transactionData = JsonUtility.FromJson<TransactionData>(json);
            return transactionData;
        }
    }
    public static async Task<PaymentData> GetAllPaymentModel(string idPlayer)
    {
        string url = BaseURL+ "getpaymentplayer?idPlayer=" + idPlayer;
        Debug.Log(url);
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
            PaymentData paymentData = JsonUtility.FromJson<PaymentData>(json);
            return paymentData;
        }
    }

}
