using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class BrassGlaive : ModItem
	{
		public override void SetDefaults()
		{
            Item.damage = 60;
			Item.width = 76;
			Item.height = 78;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<BrassGlaivePro>();
            Item.shootSpeed = 19f;
			Item.useAnimation = 30;
			Item.useStyle = 3;
			Item.knockBack = 6;
			Item.value = 1000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = false;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Glaive");
			Tooltip.SetDefault("");
		}*/

		public override void UpdateInventory(Player player)
		{
			if (player.HasBuff(ModContent.BuffType<SteamSwordBuff>()))
			{
				Item.damage = 85;
			}
			else
			{
				Item.damage = 60;
			}
		}
	}
}