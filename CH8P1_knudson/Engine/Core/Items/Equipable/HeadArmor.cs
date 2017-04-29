namespace Engine.Core.Items.Equipable
{
    internal class HeadArmor : Armor
    {
        public HeadArmor(int id, string name, string description, double evasionMod = 0, double parryMod = 0, double blockMod = 0) : base(id, name, description)
        {
            EquipmentSlot = EquipmentSlot.Head;
            EvasionModifier = evasionMod;
            ParryModifier = parryMod;
            BlockModifier = blockMod;
        }
    }
}
