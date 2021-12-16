using UnityEngine;
using UnityEngine.UI;

public class AdministrationItem<T> : ListItem where T : ITable, new()
{
    public T table;

    public AdministrationItem(Button edit, Button delete)
    {
        edit.onClick.AddListener(() => Debug.Log("Sheesh"));
        delete.onClick.AddListener(() => Debug.Log("Sheesh"));
    }

    public override void SetUp(Text name)
    {
        switch (table)
        {
            case Models obj:
                {
                    name.text = obj.Name;
                    break;
                }
            case Orders obj:
                {
                    name.text = obj.Name;
                    break;
                }
            case Categories obj:
                {
                    name.text = obj.Type;
                    break;
                }
            case Processors obj:
                {
                    name.text = obj.Model;
                    break;
                }
            case Design obj:
                {
                    name.text = obj.Material + " - " + obj.Color;
                    break;
                }
            case ScreenTable obj:
                {
                    name.text = obj.Diagonal + " " + obj.Resolution + " " + obj.Frequency + " " + obj.Surface + " " + obj.Technology;
                    break;
                }
            case Storage obj:
                {
                    name.text = obj.StorageID +". " + Repository.GetStorageTypeByID(obj.Type).Type + " " + obj.Volume + " ";
                    break;
                }
            case GraphicsTable obj:
                {
                    name.text = obj.Name;
                    break;
                }
            case RAM obj:
                {
                    name.text = obj.Type;
                    break;
                }
            case StorageTypes obj:
                {
                    name.text = obj.Type;
                    break;
                }
        }
    }
}
