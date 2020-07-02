using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventoryItem
{
    public InventoryItem(string n, Sprite sp) { name = n; inventoryImage = sp; }

    public string name;
    public Sprite inventoryImage;
};

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance;

    public GameObject inventoryUI;

    public GameObject emptyItem;

    public bool openUI = false;

    public bool interactionEnabled = true;

    public List<InventoryItem> items;


    private const float startX = 0f;
    private const float startY = 3.49f;

    private const float offsetX = 1.23f - startX;
    private const float offsetY = 3.49f - startY;

    private const int itemsPerX = 2;
    private const int itemsPerY = 4;

    public const float flyAnimDuration = 1.0f;

    public void Start()
    {
        Instance = this;
        items = new List<InventoryItem>();
    }

    public Vector3 AddItem(InventoryItem item)
    {
        items.Add(item);
        int itemNo = items.Count - 1;
        Vector3 pos = new Vector3(startX + offsetX * (itemNo % itemsPerX), startY + offsetY * (itemNo / itemsPerX));

        GameObject obj = Instantiate(emptyItem, inventoryUI.transform, false);
        obj.transform.localPosition = pos;
        obj.GetComponent<SpriteRenderer>().sprite = item.inventoryImage;
        obj.GetComponent<SpriteRenderer>().DOFade(1.0f, flyAnimDuration);

        return pos;
    }

    public void UpdateState(bool open)
    {
        if (!interactionEnabled)
            return;
        if (open)
        {
            inventoryUI.transform.DOLocalMoveX(5.85f, 1.0f);
            CommunicationSystem.Instance.Show();
        }
        else
        {
            inventoryUI.transform.DOLocalMoveX(9.86f, 1.0f);
            CommunicationSystem.Instance.Hide();
        }
        openUI = open;
    }

}
