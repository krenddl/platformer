using UnityEngine;

public static class PlayerSession
{
    public static int UserId;
    public static string Login;
    public static string Name;
    public static int Coins;
    public static string Token;

    public static bool Level1Unlocked = true;
    public static bool Level2Unlocked = false;
    public static bool Level3Unlocked = false;

    public static bool IsAuthorized => UserId > 0 && !string.IsNullOrEmpty(Token);

    public static void SaveSession(int userId, string login, string name, int coins, string token)
    {
        UserId = userId;
        Login = login;
        Name = name;
        Coins = coins;
        Token = token;

        PlayerPrefs.SetInt("user_id", userId);
        PlayerPrefs.SetString("user_login", login);
        PlayerPrefs.SetString("user_name", name);
        PlayerPrefs.SetInt("user_coins", coins);
        PlayerPrefs.SetString("auth_token", token);
        PlayerPrefs.Save();
    }

    public static void LoadSession()
    {
        UserId = PlayerPrefs.GetInt("user_id", 0);
        Login = PlayerPrefs.GetString("user_login", "");
        Name = PlayerPrefs.GetString("user_name", "");
        Coins = PlayerPrefs.GetInt("user_coins", 0);
        Token = PlayerPrefs.GetString("auth_token", "");
    }

    public static void Clear()
    {
        UserId = 0;
        Login = "";
        Name = "";
        Coins = 0;
        Token = "";

        Level1Unlocked = true;
        Level2Unlocked = false;
        Level3Unlocked = false;

        PlayerPrefs.DeleteKey("user_id");
        PlayerPrefs.DeleteKey("user_login");
        PlayerPrefs.DeleteKey("user_name");
        PlayerPrefs.DeleteKey("user_coins");
        PlayerPrefs.DeleteKey("auth_token");
        PlayerPrefs.Save();
    }
}