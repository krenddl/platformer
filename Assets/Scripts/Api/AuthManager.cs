using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    [Header("Login Fields")]
    [SerializeField] private TMP_InputField loginInput;
    [SerializeField] private TMP_InputField passwordInput;

    [Header("Register Fields")]
    [SerializeField] private TMP_InputField registerLoginInput;
    [SerializeField] private TMP_InputField registerPasswordInput;
    [SerializeField] private TMP_InputField registerNameInput;

    [Header("UI")]
    [SerializeField] private TMP_Text messageText;

    [Header("Scene Names")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    public void OnLoginClicked()
    {
        string login = loginInput.text.Trim();
        string password = passwordInput.text;

        if (login == "")
        {
            SetMessage("Введите логин");
            return;
        }

        if (password == "")
        {
            SetMessage("Введите пароль");
            return;
        }

        Debug.Log("LOGIN CLICKED: " + loginInput.text);
        StartCoroutine(LoginCoroutine(login, password));
    }

    public void OnRegisterClicked()
    {
        string login = registerLoginInput.text.Trim();
        string password = registerPasswordInput.text;
        string name = registerNameInput.text.Trim();

        if (login == "" || password == "" || name == "")
        {
            SetMessage("Заполните все поля");
            return;
        }

        StartCoroutine(RegisterCoroutine(login, password, name));
    }

    private IEnumerator LoginCoroutine(string login, string password)
    {
        LoginRequest request = new LoginRequest
        {
            login = login,
            password = password
        };

        Debug.Log("LOGIN JSON: " + JsonUtility.ToJson(request));

        yield return ApiManager.Instance.PostRequest(
            ApiRoutes.Login,
            JsonUtility.ToJson(request),
            OnLoginSuccess,
            OnRequestError
        );
    }

    private IEnumerator RegisterCoroutine(string login, string password, string name)
    {
        RegisterRequest request = new RegisterRequest
        {
            login = login,
            password = password,
            name = name
        };

        yield return ApiManager.Instance.PostRequest(
            ApiRoutes.Register,
            JsonUtility.ToJson(request),
            OnRegisterSuccess,
            OnRequestError
        );
    }

    private void OnLoginSuccess(string responseJson)
    {
        Debug.Log("LOGIN RESPONSE: " + responseJson);

        AuthResponse response = JsonUtility.FromJson<AuthResponse>(responseJson);

        if (response != null && !string.IsNullOrEmpty(response.token))
        {
            PlayerSession.SaveSession(
                response.userId,
                response.login,
                response.name,
                response.coins,
                response.token
            );

            if (ProgressManager.Instance != null)
            {
                ProgressManager.Instance.LoadProgress();
            }

            SceneManager.LoadScene(mainMenuSceneName);
        }
        else
        {
            SetMessage("Ошибка авторизации");
        }
    }

    private void OnRegisterSuccess(string responseJson)
    {
        Debug.Log("REGISTER RESPONSE: " + responseJson);
        SetMessage("Регистрация успешна. Теперь войди.");
    }

    private void OnRequestError(string error)
    {
        Debug.LogError(error);
        SetMessage("Ошибка: " + error);
    }

    private void SetMessage(string text)
    {
        if (messageText != null)
            messageText.text = text;
    }

    public void LoadSignUp()
    {
        SceneManager.LoadScene("SignUp");
    }

    public void LoadSignIn()
    {
        SceneManager.LoadScene("AuthScene");
    }
}