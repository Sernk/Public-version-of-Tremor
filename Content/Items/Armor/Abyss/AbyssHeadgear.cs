using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;
using TremorMod;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Abyss
{
	[AutoloadEquip(EquipType.Head)]
	public class AbyssHeadgear : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        const int ShootType = 496; 
		const float ShootRange = 100.0f; 
		const float ShootKN = 1.0f; 
		const int ShootRate = 60; 
		const int ShootCount = 3; 
		const float ShootSpeed = 15f; 
		const int spread = 45; 
		const float spreadMult = 0.045f; 

		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 18000;
			Item.rare = 7;
			Item.defense = 11;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Abyss Headgear");
			/* Tooltip.SetDefault("14% increased minion damage\n" +
"Increases maximum health by 40"); */
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Allows to see hazards\n" +
			"Summons abyss magic to attack nearby enemies\n" +
			"Your Shadow Arms has 33% chance to inflict Shadowflame on enemies");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.14f;
			player.statLifeMax2 += 40;

		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AbyssBreastplate>() && legs.type == ModContent.ItemType<AbyssGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Allows to see hazards\n" +
			"Summons abyss magic to attack nearby enemies\n" +
			"Your Shadow Arms has 33% chance to inflict Shadowflame on enemies";
			TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>();
			modPlayer.shadowArmSF = true;
			player.dangerSense = false;

			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}

			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 65, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
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
				int i = Projectile.NewProjectile(Main.player[Item.playerIndexTheItemIsReservedFor].GetSource_FromThis(), Main.player[Item.playerIndexTheItemIsReservedFor].Center.X, Main.player[Item.playerIndexTheItemIsReservedFor].Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, Item.playerIndexTheItemIsReservedFor);
			}
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarknessCloth>(), 12);
            recipe.AddIngredient(ItemID.SoulofNight, 9);
            recipe.AddIngredient(ItemID.Amethyst, 7);
            recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 4);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}
