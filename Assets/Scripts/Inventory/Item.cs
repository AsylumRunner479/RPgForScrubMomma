
using UnityEngine;

public class Item
{
    
    
      #region Variables
    private int _id;
    //id of the item for programmers and developers
    private string _name;
    private string _description;
    //Amount of items of that type...Stackable
    private int _amount;
    //Buy and Sell Price
    private int _value;
    public static bool Money;
    private int _damage;
    private int _armour;
    private int _heal;
    private Texture2D _iconName;
    private GameObject _meshName;

    private ItemTypes _type;
    #endregion
    #region Properities
    public Texture2D IconName
    {
        get { return _iconName; }
        set { _iconName = value; }
    }
    public GameObject MeshName
    {
        get { return _meshName; }
        set { _meshName = value; }
    }
    public ItemTypes ItemType
    {
        get { return _type; }
        set { _type = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    
    #endregion


    // Start is called before the first frame update

}
  public enum ItemTypes 
    {
        Armour,
        Weapon,
        Potion,
        Money,
        Quest,
        Food,
        Ingredient,
        Craftable,
        Misc,
        
    }