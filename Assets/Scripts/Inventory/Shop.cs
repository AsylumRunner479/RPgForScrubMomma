using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool showShop;
    public int[] itemsToSpawn;
    public List<Item> shopInv = new List<Item>();
    public Item selectedShopItem;
    // Start is called before the first frame update
    private void Start()
    {
        //itemsToSpawn = new int[Random.Range(1, 11)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            //itemsToSpawn[i] = Random.Range(0, 4);
            shopInv.Add(ItemData.CreateItem(itemsToSpawn[i]));

        }
    }
    private void OnGUI()
    {
if(showShop)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            GUI.Box(new Rect(6.5f*scr.x, 0.25f*scr.y, 3f * scr.x, 0.5f * scr.y), "$" + LinearInventory.money);
            for (int i = 0; i < shopInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.75f * scr.x, 0.25f * scr.y + i*(0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), shopInv[i].Name))
                {
                    selectedShopItem = shopInv[i];
                    
                }
                if(selectedShopItem == null)
                {
                    return;
                }
                else
                {
                    GUI.Box(new Rect(12.5f * scr.x, 6.5f * scr.y, 3f * scr.x, 0.5f * scr.y), "$" + 1.25f * selectedShopItem.Value);
                    if (GUI.Button(new Rect(12.5f * scr.x, 6f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Buy") && LinearInventory.money >= (selectedShopItem.Value * 1.25f))
                    {
                        LinearInventory.money -= (int)(selectedShopItem.Value * 1.25f);
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedShopItem.ID));
                        shopInv.Remove(selectedShopItem);
                        selectedShopItem = null;
                       

                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
