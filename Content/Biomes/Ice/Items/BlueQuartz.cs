using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class BlueQuartz : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 17500;
			Item.rare = 1;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blue Quartz");
			//Tooltip.SetDefault("Increases maximum health by 50 \n" +
			//"6% increased damage if in Glacier or Snow biome");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateEquip(Player player)
		{
			if (player.ZoneSnow)
			{
                player.GetDamage(DamageClass.Melee) += 0.06f;
                player.GetDamage(DamageClass.Ranged) += 0.06f;
                player.GetDamage(DamageClass.Magic) += 0.06f;
                player.GetDamage(DamageClass.Throwing) += 0.06f;
                player.GetModPlayer<MPlayer>().alchemicalDamage += 0.06f;
            }
		}
	}
}
