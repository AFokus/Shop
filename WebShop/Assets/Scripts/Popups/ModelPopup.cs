using UnityEngine.UI;
using System.Linq;
using static UnityEngine.UI.Dropdown;

public class ModelPopup : View
{
    public int curId;

    public Button Conf;
    public Button Back;

    public InputField N;
    public InputField O;
    public InputField P;
    public InputField R;
    public InputField W;
    public Dropdown C;
    public Dropdown CPU;
    public Dropdown D;
    public Dropdown S;
    public Dropdown RAM;
    public Dropdown G;
    public Dropdown Stor;

    public override void OnCreate()
    {
        base.OnCreate();
        Back.onClick.AddListener(() => Controller.OpenWindow<ModelPopup, Administration>());
        Conf.onClick.AddListener(() => {
            CreateElem(curId);
            curId = 0;
        });

        C.options.AddRange(Repository.GetAllCategories().Select(elem => new OptionData(elem.Type)));
        CPU.options.AddRange(Repository.GetAllCPU().Select(elem => new OptionData(elem.Model)));
        D.options.AddRange(Repository.GetAllDesign().Select(obj => new OptionData(obj.Material + " - " + obj.Color)));
        S.options.AddRange(Repository.GetAllScreen().Select(obj => new OptionData(obj.Diagonal + " " + obj.Resolution + " " + obj.Frequency + " " + obj.Surface + " " + obj.Technology)));
        RAM.options.AddRange(Repository.GetAllRAM().Select(elem => new OptionData(elem.Type)));
        G.options.AddRange(Repository.GetAllGraphics().Select(elem => new OptionData(elem.Name)));
        Stor.options.AddRange(Repository.GetAllStorages().Select(obj => new OptionData(obj.StorageID + ". " + Repository.GetStorageTypeByID(obj.Type).Type + " " + obj.Volume)));
    }

    public void Init(Models data)
    {
        curId = data.ModelId;
        N.text = data.Name;
        O.text = data.Options;
        P.text = data.Price.ToString();
        R.text = data.Release_Date;
        W.text = data.Weight.ToString();
        C.value = data.CategoryId;
        CPU.value = data.CPUID;
        D.value = data.DesignID;
        S.value = data.ScreenID;
        RAM.value = data.RAMID;
        G.value = data.GraphicsID;
    }

    public void CreateElem(int id = 0)
    {
        var elem = new Models();
        var param = new string[]
        {
            $"{id}",
            N.text,
            O.text,
            P.text,
            C.value.ToString(),
            R.text,
            CPU.value.ToString(),
            D.value.ToString(),
            W.text,
            S.value.ToString(),
            RAM.value.ToString(),
            Stor.value.ToString(),
            G.value.ToString(),
        };
        elem.SetData(param);

        if (Repository.SetNewModel(elem))
            Controller.OpenWindow<ModelPopup, Administration>();
    }
}
