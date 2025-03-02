using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Utilities
{
    public class MiniGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Bone) 
            {
                item.ammo = ItemID.Bone; 
                item.consumable = true;  
            }
        }

        public override bool CanRightClick(Item item)
        {
            if (item.type == ItemID.DefenderMedal)
            {
                return true; // Разрешаем класть в Piggy Bank
            }
            return base.CanRightClick(item);
        }

    }
}