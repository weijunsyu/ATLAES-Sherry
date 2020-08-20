
public class InventoryData
{
    // Inventory Data
    private int gold = 0; // Number of gold coins (money) the player owns
    private bool[] uniqueItems = new bool[GameConstants.TOTAL_NUMBER_UNIQUE_ITEMS]; // Unique items unlocked (items that do not respawn and only occur once in game but are not weapons)
    private int[] inventory = new int[GameConstants.PLAYER_INVENTORY_SIZE]; // List of items in player inventory (index = ItemID, value = amount)



    // Class Functions:
    public void ResetAllInventoryData()
    {
        SetGold(0);
        ResetUniqueItems();
        ResetInventory();
    }
    public int GetGold()
    {
        return gold;
    }
    public void ModifyGold(int value)
    {
        gold += value;
    }
    public void SetGold(int value)
    {
        gold = value;
    }
    public bool[] GetUniqueItems()
    {
        return uniqueItems;
    }
    public int[] GetInventory()
    {
        return inventory;
    }
    public void ResetInventory()
    {
        System.Array.Clear(inventory, 0, inventory.Length);
    }
    private void ResetUniqueItems()
    {
        System.Array.Clear(uniqueItems, 0, uniqueItems.Length);
    }
}
