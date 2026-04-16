using TMPro;
using UnityEngine;

public class CoinUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        PlayerSession.LoadSession();
        Refresh();
    }

    public void Refresh()
    {
        if (coinsText != null)
        {
            coinsText.text = "x " + PlayerSession.Coins;
        }
    }
}
