using UnityEngine;
using UnityEngine.UI;

public class RegistrationPopup : View
{
    [SerializeField]
    private Button _register;

    public override void OnCreate()
    {
        base.OnCreate();
        _register.onClick.AddListener(() => Controller.OpenWindow<RegistrationPopup, LoginPopup>());
    }
}
