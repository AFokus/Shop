using UnityEngine;
using UnityEngine.UI;

public class RegistrationPopup : View
{
    [SerializeField]
    private Button _register;
    public Button Log;
    public Button Back;

    public InputField Login;
    public InputField Password;

    public override void OnCreate()
    {
        base.OnCreate();
        _register.onClick.AddListener(() => {
            var user = new User_Data();
            var par = new string[]
            {
                "0",
                Login.text,
                Password.text,
                "0",
                "0"
            };
            user.SetData(par);

            if (Repository.SetNewUser(user))
                Controller.OpenWindow<LoginPopup, Administration>();
            else
                Debug.Log("Login Error");
            });
        Log.onClick.AddListener(() => Controller.OpenWindow<RegistrationPopup, LoginPopup>());
        Back.onClick.AddListener(() => Controller.OpenWindow<RegistrationPopup, LoginPopup>());
    }
}
