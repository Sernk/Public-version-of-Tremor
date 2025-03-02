using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.AndasItems
{
	public class InfernoSoul : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 38;
			Item.value = 10000;
			Item.rare = 0;
			Item.maxStack = 999;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Soul");
			Tooltip.SetDefault("");
		}*/

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var tooltip in tooltips)
            {
                // Меняем цвет текста для названия предмета
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
                {
                    tooltip.OverrideColor = new Color(238, 194, 73); // Цвет золота
                }
            }
        }
    }
}
