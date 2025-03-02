using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class FrostLance : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.width = 76;
			Item.height = 76;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 35;
			Item.shoot = ModContent.ProjectileType<FrostLancePro>();
			Item.shootSpeed = 3f;
			Item.useAnimation = 35;
			Item.useStyle = 5;
			Item.knockBack = 9;
			Item.value = 1000;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Lance");
			Tooltip.SetDefault("");
		}*/

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            player.AddBuff(44, 60);
        }
    }
}
