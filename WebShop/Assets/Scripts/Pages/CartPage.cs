using UnityEngine;
using UnityEngine.UI;

public class CartPage : View
{
    [SerializeField]
    private Button _back;
    [SerializeField]
    private Button _checkOut;

    public override void OnCreate()
    {
        base.OnCreate();
        _back.onClick.AddListener(() => Controller.OpenWindow<CartPage, MainPage>());
    }
}
