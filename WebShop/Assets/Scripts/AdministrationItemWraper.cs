using JetBrains.Annotations;
using UnityEngine.UI;

public class AdministrationItemWraper : ListItem
{
    public ListItem item;
    public Text name;
    public Button edit;
    public Button delete;

    public override void SetUp(Text text)
    {
        item.SetUp(name);
    }
}
