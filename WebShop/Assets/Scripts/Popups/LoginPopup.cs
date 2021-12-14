using UnityEngine;
using UnityEngine.UI;

public class LoginPopup : View
{
    [SerializeField]
    private Button _login;
    [SerializeField]
    private Button _register;

    public override void OnCreate()
    {
        base.OnCreate();
        _login.onClick.AddListener(() => Controller.OpenWindow<LoginPopup, MainPage>());
        _register.onClick.AddListener(() => Controller.OpenWindow<LoginPopup, RegistrationPopup>());
    }
}
