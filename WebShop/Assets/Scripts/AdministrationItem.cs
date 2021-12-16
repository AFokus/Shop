using UnityEngine;
using UnityEngine.UI;

public class AdministrationItem<T> : ListItem where T : ITable, new()
{
    public T table;
    Button edit;
    Button delete;

    public AdministrationItem(Button edit, Button delete)
    {
        this.edit = edit;
        this.delete = delete;
    }

    public override void SetUp(Text name)
    {
        switch (table)
        {
            case Models obj:
                {
                    edit.onClick.AddListener(() => {
                        var view = Controller.OpenWindow<Administration, ModelPopup>();
                        view.Init(obj);
                        });

                    delete.onClick.AddListener(() => {
                        Repository.DeleteModel(obj.ModelId);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Name;
                    break;
                }
            case Orders obj:
                {
                    edit.onClick.AddListener(() => {
                        var view = Controller.OpenWindow<Administration, OrderPopup>();
                        view.Init(obj);
                    });

                    delete.onClick.AddListener(() => {
                        Repository.DeleteOrders(obj.OrderID);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Name;
                    break;
                }
            case Categories obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() => {
                        Repository.DeleteCategories(obj.CategoryId);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Type;
                    break;
                }
            case Processors obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() => {
                        Repository.DeleteProcessors(obj.ProcID);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Model;
                    break;
                }
            case Design obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() => {
                        Repository.DeleteDesign(obj.DesignID);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Material + " - " + obj.Color;
                    break;
                }
            case ScreenTable obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() =>
                    {
                        Repository.DeleteScreen(obj.ScreenID);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Diagonal + " " + obj.Resolution + " " + obj.Frequency + " " + obj.Surface + " " + obj.Technology;
                    break;
                }
            case Storage obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() => {
                        Repository.DeleteStorage(obj.StorageID);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.StorageID +". " + Repository.GetStorageTypeByID(obj.Type).Type + " " + obj.Volume + " ";
                    break;
                }
            case GraphicsTable obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() => {
                        Repository.DeleteGraphics(obj.GraphicId);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Name;
                    break;
                }
            case RAM obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() => {
                        Repository.DeleteRAM(obj.RAMID);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Type;
                    break;
                }
            case StorageTypes obj:
                {
                    //edit.onClick.AddListener(() => {
                    //    var view = Controller.OpenWindow<Administration, ModelPopup>();
                    //    view.Init(obj);
                    //});

                    delete.onClick.AddListener(() => {
                        Repository.DeleteStorage(obj.STID);
                        Destroy(this.gameObject);
                    });

                    name.text = obj.Type;
                    break;
                }
        }
    }
}
