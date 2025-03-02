using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Banhammer : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 1;
			Item.useTurn = true;
			Item.useAnimation = 37;
			Item.useTime = 25;
			Item.hammer = 100;
			Item.width = 24;
			Item.height = 28;
			Item.damage = 485;
			Item.rare = 0;
			Item.knockBack = 5.5f;
			Item.scale = 1.2f;
			Item.UseSound = SoundID.Item1;
			Item.tileBoost = +3;
			Item.value = 520000;
            Item.DamageType = DamageClass.Melee;
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Banhammer");
			Tooltip.SetDefault("");
		}*/

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var line in tooltips)
            {
                if (line.Name == "ItemName") // Изменяем цвет названия предмета
                {
                    line.OverrideColor = new Color(238, 194, 73);
                }
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 226);
			}
		}
	}
}
