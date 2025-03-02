using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.DataStructures;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Tiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.WhiteGold
{
	[AutoloadEquip(EquipType.Head)]
	public class WhiteGoldHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        const int ShootType = ProjectileID.HeatRay; 
		const float ShootRange = 600.0f; 
		const float ShootKN = 1.0f; 
		const int ShootRate = 120; 
		const int ShootCount = 2; 
		const float ShootSpeed = 20f; 
		const int spread = 45; 
		const float spreadMult = 0.045f; 

		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 10000;
			Item.rare = 11;
			Item.defense = 30;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("White Gold Helmet");
			/* Tooltip.SetDefault("20% increased ranged damage\n" +
			"20% increased melee damage"); */
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Shoots dangerous gold daggers");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) += 0.2f;
			player.GetDamage(DamageClass.Melee) += 0.2f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<WhiteGoldBreastplate>() && legs.type == ModContent.ItemType<WhiteGoldGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Shoots dangerous gold daggers";

			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}
		}

		int GetTarget()
		{
			int Target = -1;
			for (int k = 0; k < Main.npc.Length; k++)
			{
				if (Main.npc[k].active && Main.npc[k].lifeMax > 5 && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].Distance(Main.player[Item.playerIndexTheItemIsReservedFor].Center) <= ShootRange && Collision.CanHitLine(Main.player[Item.playerIndexTheItemIsReservedFor].Center, 4, 4, Main.npc[k].Center, 4, 4))
				{
					Target = k;
					break;
				}
			}
			return Target;
		}

        int GetDamage()
        {
            return (10 * ((int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Magic).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Melee).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Summon).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Ranged).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Throwing).ApplyTo(1f))) + 15;
        }

        void Shoot(int Target, int Damage)
        {
            Vector2 velocity = Helper.VelocityToPoint(Main.player[Item.playerIndexTheItemIsReservedFor].Center, Main.npc[Target].Center, ShootSpeed);
            for (int l = 0; l < ShootCount; l++)
            {
                velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
                velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
                int i = Projectile.NewProjectile(Main.player[Item.playerIndexTheItemIsReservedFor].GetSource_FromThis(), Main.player[Item.playerIndexTheItemIsReservedFor].Center.X, Main.player[Item.playerIndexTheItemIsReservedFor].Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<WhiteGoldKnife>(), 100, ShootKN, Item.playerIndexTheItemIsReservedFor);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<WhiteGoldBar>(), 12);
            //recipe.SetResult(this);
            recipe.AddTile(ModContent.TileType<DivineForgeTile>());
            recipe.Register();
        }
    }
}
