using UnityEngine;
using UnityEngine.UI;

public class LoginPopup : View
{
    [SerializeField]
    private InputField _loginField;
    [SerializeField]
    private InputField _passwordField;

    [SerializeField]
    private Button _login;
    [SerializeField]
    private Button _register;
    [SerializeField]
    private Button _back;

    public override void OnCreate()
    {
        base.OnCreate();
        _login.onClick.AddListener(() => {

            var user = new User_Data();
            var par = new string[]
            {
                "0",
                _loginField.text,
                _passwordField.text,
                "0",
                "0"
            };
            user.SetData(par);

            if (Repository.Authorization(ref user))
            {
                if(user.Access_Level == 0)
                    Controller.OpenWindow<LoginPopup, MainPage>();
                else
                    Controller.OpenWindow<LoginPopup, Administration>();
            }
            else
                Debug.Log("Login Error");
            });
        _register.onClick.AddListener(() => Controller.OpenWindow<LoginPopup, RegistrationPopup>());
        _back.onClick.AddListener(() => Controller.OpenWindow<LoginPopup, MainPage>());
    }
}
