using UnityEngine;
using UnityEngine.UI;

public class OrderPage : View
{
    [SerializeField]
    private Button _back;
    [SerializeField]
    private Button _complete;

    public override void OnCreate()
    {
        base.OnCreate();
        _back.onClick.AddListener(() => Controller.OpenWindow<OrderPage, CartPage>());
    }
}
