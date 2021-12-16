using UnityEngine.UI;

public class OrderPopup : View
{
    public int curId;

    public Button Conf;
    public Button Back;

    public InputField N;
    public InputField C;
    public InputField S;
    public InputField Cit;
    public InputField A;
    public InputField Z;
    public Toggle GW;

    public override void OnCreate()
    {
        base.OnCreate();
        Back.onClick.AddListener(() => {
            if (Controller.CurrentUser.Access_Level == 0)
                Controller.OpenWindow<OrderPopup, MainPage>();
            else
                Controller.OpenWindow<OrderPopup, Administration>();
        });
        Conf.onClick.AddListener(() => {
            CreateElem(curId);
            curId = 0;
        });
    
    }

    public void Init(Orders data)
    {
        curId = data.OrderID;
        N.text = data.Name;
        C.text = data.Country;
        S.text = data.State.ToString();
        Cit.text = data.City;
        A.text = data.Adress.ToString();
        Z.text = data.Zip;
        GW.enabled = data.GiftWrap;
    }

    public void CreateElem(int id = 0)
    {
        var elem = new Orders();
        var param = new string[]
        {
            $"{id}",
            N.text,
            C.text,
            S.text,
            Cit.text,
            A.text,
            Z.text,
            GW.enabled ? "1" : "0"
    };
        elem.SetData(param);

        if (Repository.SetNewOrders(elem)) {
            if (Controller.CurrentUser.Access_Level == 0)
                Controller.OpenWindow<OrderPopup, MainPage>();
            else
                Controller.OpenWindow<OrderPopup, Administration>();
        }
    }
}
