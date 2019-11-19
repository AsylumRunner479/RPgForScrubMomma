using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public int itemId = 0;
    public ItemTypes itemType;
    public int amount = 1;
    public void OnCollection()
    {
        //money will be added as an addition to a variable rather then an individual item
        if (itemType == ItemTypes.Money)
        {
            LinearInventory.money += amount;
        }
        //most items will be stored in the inventory as a a certain type which can stack.
        else if (itemType == ItemTypes.Craftable || itemType == ItemTypes.Food || itemType == ItemTypes.Potion || itemType == ItemTypes.Ingredient)
        {
            int found = 0;
            int addIndex = 0;
            for (int i = 0; i < LinearInventory.inv.Count; i++)
            {
                if (itemId == LinearInventory.inv[i].ID)
                {
                    found = 1;
                    addIndex = i;
                    break;
                }
            }
                if (found == 1)
                {
                    LinearInventory.inv[addIndex].Amount += amount;
                }
                else
                {
                    LinearInventory.inv.Add(ItemData.CreateItem(itemId));
                    if (amount > 1)
                    {
                        for (int i = 0; i < LinearInventory.inv.Count; i++)
                        {
                            if (itemId == LinearInventory.inv[i].ID)
                            {
                                LinearInventory.inv[i].Amount = amount;
                            }
                        }

                    }
                }
            
        }
        //when you grab an item it is added to your inventory and it is destroyed in the game.
        else
        {
            LinearInventory.inv.Add(ItemData.CreateItem(itemId));
        }
               
            Destroy(gameObject);
        
    }
    
}

