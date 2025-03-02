using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.AndasItems
{
	public class GehennaStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 455;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.width = 46;
			Item.height = 48;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.shoot = ModContent.ProjectileType<InfernoRift>();
			Item.shootSpeed = 12f;
			Item.value = 600000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = false;
			Item.useTurn = false;

		}
        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.channel = true;
            return true;
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gehenna Staff");
			Tooltip.SetDefault("Summons a controllable inferno rift that rapidly shoots molten bolts at nearby enemies");
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
