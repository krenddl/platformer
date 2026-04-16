using System;

[Serializable]
public class RegisterRequest
{
    public string login;
    public string password;
    public string name;
}

[Serializable]
public class LoginRequest
{
    public string login;
    public string password;
}

[Serializable]
public class AuthResponse
{
    public int userId;
    public string login;
    public string name;
    public string token;
    public int coins;
}

[Serializable]
public class UserDto
{
    public int id_User;
    public string login;
    public string name;
    public int coins;
}

[Serializable]
public class ProgressItem
{
    public int id;
    public int userId;
    public int levelNumber;
    public int stars;
    public bool isCompleted;
}

[Serializable]
public class CompleteLevelRequest
{
    public int userId;
    public int levelNumber;
    public int score;
    public int stars;
}

[Serializable]
public class CompleteLevelResponse
{
    public string message;
    public int coins;
}

[Serializable]
public class LeaderboardUser
{
    public int id_User;
    public string login;
    public string name;
    public int coins;
}