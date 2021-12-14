using UnityEngine;
using UnityEngine.UI;

public class MainPage : View
{
    [SerializeField]
    private Button _login;
    [SerializeField]
    private Button _cart;

    public override void OnCreate()
    {
        base.OnCreate();
        _login.onClick.AddListener(() => Controller.OpenWindow<MainPage, LoginPopup>());
        _cart.onClick.AddListener(() => Controller.OpenWindow<MainPage, CartPage>());
    }
}
