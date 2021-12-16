using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Administration : View
{
    public ITable _currentTable = new Models();

    [SerializeField]
    private Button _exit;

    [SerializeField]
    private List<Button> _tables;

    [SerializeField]
    private GameObject content;
    [SerializeField]
    private ListItem listItemPrefab;
    private List<ListItem> items = new List<ListItem>();

    public override void OnCreate()
    {
        base.OnCreate();
        _exit.onClick.AddListener(() => Controller.OpenWindow<Administration, MainPage>());

        _tables[0].onClick.AddListener(() => CreateList<Models>());
        _tables[1].onClick.AddListener(() => CreateList<Orders>());
        _tables[2].onClick.AddListener(() => CreateList<Categories>());
        _tables[3].onClick.AddListener(() => CreateList<Design>());
        _tables[4].onClick.AddListener(() => CreateList<ScreenTable>());
        _tables[5].onClick.AddListener(() => CreateList<RAM>());
        _tables[6].onClick.AddListener(() => CreateList<StorageTypes>());
        _tables[7].onClick.AddListener(() => CreateList<Storage>());
        _tables[8].onClick.AddListener(() => CreateList<GraphicsTable>());
        _tables[9].onClick.AddListener(() => CreateList<Processors>());
    }

    public void CreateList<T>() where T : ITable, new()
    {
        foreach (var item in items)
            Destroy(item.gameObject);

        items.Clear();

        var tmp = new ArrayList();

        var zagluska = new T();
        _currentTable = zagluska;
        switch (zagluska)
        {
            case Models _:
                {
                    tmp.Add(Repository.GetAllModels());
                    break;
                }
            case Orders _:
                {
                    tmp.Add(Repository.GetAllOrders());
                    break;
                }
            case Categories _:
                {
                    tmp.Add(Repository.GetAllCategories());
                    break;
                }
            case Processors _:
                {
                    tmp.Add(Repository.GetAllCPU());
                    break;
                }
            case Design _:
                {
                    tmp.Add(Repository.GetAllDesign());
                    break;
                }
            case ScreenTable _:
                {
                    tmp.Add(Repository.GetAllScreen());
                    break;
                }
            case Storage _:
                {
                    tmp.Add(Repository.GetAllStorages());
                    break;
                }
            case GraphicsTable _:
                {
                    tmp.Add(Repository.GetAllGraphics());
                    break;
                }
            case RAM _:
                {
                    tmp.Add(Repository.GetAllRAM());
                    break;
                }
            case StorageTypes _:
                {
                    tmp.Add(Repository.GetAllStorageTypes());
                    break;
                }
        }

        foreach (var elem in (List<T>)tmp[0])
        {
            var compositionItem = (AdministrationItemWraper)Instantiate(listItemPrefab, content.transform);
            compositionItem.item = new AdministrationItem<T>(compositionItem.edit, compositionItem.delete);
            ((AdministrationItem<T>)compositionItem.item).table = elem;
            compositionItem.SetUp(null);
            items.Add(compositionItem);
        }
    }

    public override void Open()
    {
        base.Open();

        this.CreateList<Models>();
    }

    public override void Close()
    {
        base.Close();

        _currentTable = new Models();

        foreach (var item in items)
            Destroy(item.gameObject);

        items.Clear();
    }
}
