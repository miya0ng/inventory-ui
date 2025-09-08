//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Newtonsoft.Json;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;

//public class UiInvenSlotList : MonoBehaviour
//{
//    public enum SortingOptions
//    {
//        CreationTimeAccending,
//        CreationTimeDeccending,
//        NameAccending,
//        NameDeccending,
//        CostAccending,
//        CostDeccending,
//    }

//    public enum FilteringOptions
//    {
//        None,
//        Weapon,
//        Euqip,
//        Consumable,
//    }

//    public readonly System.Comparison<SaveItemData>[] comparisons =
//    {
//        (lhs, rhs) => lhs.creationTime.CompareTo(rhs.creationTime),
//        (lhs, rhs) => rhs.creationTime.CompareTo(lhs.creationTime),
//        (lhs, rhs) => lhs.itemData.StringName.CompareTo(rhs.itemData.StringName),
//        (lhs, rhs) => rhs.itemData.StringName.CompareTo(lhs.itemData.StringName),
//        (lhs, rhs) => lhs.itemData.Cost.CompareTo(rhs.itemData.Cost),
//        (lhs, rhs) => rhs.itemData.Cost.CompareTo(lhs.itemData.Cost),
//    };

//    public readonly System.Func<SaveItemData, bool>[] filterings =
//    {
//        x => true,
//        x => x.itemData.Type == ItemTypes.Weapon,
//        x => x.itemData.Type == ItemTypes.Equip,
//        x => x.itemData.Type == ItemTypes.Consumable
//    };


//    public UiInvenSlot prefab;

//    public ScrollRect scrollRect;

//    private List<UiInvenSlot> slotList = new List<UiInvenSlot>();

//    public int maxCount = 30;

//    private List<SaveItemData> testItemList;

//    private SortingOptions sorting = SortingOptions.NameAccending;
//    private FilteringOptions filtering = FilteringOptions.None;

//    public SortingOptions Sorting 
//    { 
//        get => sorting;
//        set
//        {
//            sorting = value;
//            UpdateSlots(testItemList);
//        }
//    }
//    public FilteringOptions Filtering 
//    { 
//        get => filtering;
//        set
//        {
//            filtering = value;
//            UpdateSlots(testItemList);
//        }
//    }

//    private int selectedSlotIndex = -1;

//    public UnityEvent onUpdateSlots;
//    public UnityEvent<SaveItemData> onSelectSlot;

//    public void LoadData()
//    {
//        SaveLoadManager.Data = new SaveDataV3();
//        if (SaveLoadManager.Load(SaveLoadManager.SaveDataVersion - 1))
//        {
//            Debug.Log("Game Loaded");
//            testItemList = SaveLoadManager.Data.saveItemDatas ?? new List<SaveItemData>();
//        }
//        else
//        {
//            Debug.Log("No Save Data");
//        }
//        UpdateSlots(testItemList);
//    }
//    public void SaveData()
//    {
//        SaveLoadManager.Data = new SaveDataV3();
//        SaveLoadManager.Data.saveItemDatas = testItemList;
//        SaveLoadManager.Save(SaveLoadManager.SaveDataVersion - 1);
//    }
//    private void OnEnable()
//    {
//        //Load();
//        LoadData();
//    }

//    private void OnDisable()
//    {
//        //Save();
//        SaveData();
//    }

//    private void Awake()
//    {
       
//    }

//    private void UpdateSlots(List<SaveItemData> itemList)
//    {
//        var list = itemList.Where(filterings[(int)filtering]).ToList();
//        list.Sort(comparisons[(int)sorting]);

//        if (slotList.Count < list.Count)
//        {
//            for (int i = slotList.Count; i < list.Count; ++i)
//            {
//                var newSlot = Instantiate(prefab, scrollRect.content);
//                newSlot.slotIndex = i;
//                newSlot.SetEmpty();
//                newSlot.gameObject.SetActive(false);

//                var button = newSlot.GetComponent<Button>();
//                button.onClick.AddListener(() =>
//                {
//                    selectedSlotIndex = newSlot.slotIndex;
//                    onSelectSlot.Invoke(newSlot.ItemData);
//                });

//                slotList.Add(newSlot);
//            }
//        }

//        for (int i = 0; i < slotList.Count; ++i)
//        {
//            if (i < list.Count)
//            {
//                slotList[i].gameObject.SetActive(true);
//                slotList[i].SetItem(list[i]);
//            }
//            else
//            {
//                slotList[i].SetEmpty();
//                slotList[i].gameObject.SetActive(false);
//            }
//        }

//        selectedSlotIndex = -1;
//        onUpdateSlots.Invoke();
//    }

//    public void AddRandomItem()
//    {
//        var itemInstance = new SaveItemData();
//        itemInstance.itemData = DataTableManger.ItemTable.GetRandom();

//        testItemList.Add(itemInstance);
//        UpdateSlots(testItemList);
//    }

//    public void RemoveItem()
//    {
//        if (selectedSlotIndex == -1)
//            return;

//        testItemList.Remove(slotList[selectedSlotIndex].ItemData);
//        UpdateSlots(testItemList);
//    }

//}
