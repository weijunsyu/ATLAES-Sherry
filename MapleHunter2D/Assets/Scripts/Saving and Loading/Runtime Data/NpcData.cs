
public class NpcData
{
    // NPC Data
    private int[] bank = new int[GameConstants.PLAYER_BANK_SIZE]; // List of items in bank (index = ItemID, value = amount)
    private int goldInBank = 0; // Number of gold coins (money) the player owns in the bank
    private int[] npcConvo = new int[System.Enum.GetNames(typeof(NamedNPC)).Length]; // List of NPC conversation and interaction status (index = NamedNPC, value = progress along convo path)


    // Class Functions:
    public void ResetAllNpcData()
    {
        ResetBank();
        SetGoldInBank(0);
        ResetNpcConvo();
    }
    public int[] GetBank()
    {
        return bank;
    }
    public void ResetBank()
    {
        System.Array.Clear(bank, 0, bank.Length);
    }
    public bool SetBank(int[] array)
    {
        if (array.Length == bank.Length)
        {
            System.Array.Copy(array, bank, bank.Length);
            return true;
        }
        return false;
    }
    public int GetGoldInBank()
    {
        return goldInBank;
    }
    public void SetGoldInBank(int value)
    {
        goldInBank = value;
    }
    public int[] GetNpcConvo()
    {
        return npcConvo;
    }
    private void ResetNpcConvo()
    {
        System.Array.Clear(npcConvo, 0, npcConvo.Length);
    }
    public bool SetNpcConvo(int[] array)
    {
        if (array.Length == npcConvo.Length)
        {
            System.Array.Copy(array, npcConvo, npcConvo.Length);
            return true;
        }
        return false;
    }
}
