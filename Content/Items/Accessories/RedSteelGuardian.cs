using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class RedSteelGuardian : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 32;
			Item.value = 250;
			Item.rare = 1;
			Item.accessory = true;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Red Steel Guardian");
			// Tooltip.SetDefault("10% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
		}
		/*
		public override bool CanEquipAccessory(Player player, int slot) // странно за что оно отвечало? Возможно если надет один из них то тогда ни каких бонусов не должен получать игрок.
				{
					bool canequip = true;
					for (int l = 3; l < 8 + player.extraAccessorySlots; l++)
					{
						if (player.armor[l].type == mod.ItemType("BorealwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("CopperShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("EbonwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("EnchantedShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("GoldShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("IronShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("LeadShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("OrcishShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("PalmwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("PearlwoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("PlatinumGuardian"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("RichMahoganyShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("ShadewoodShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("SilverShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("TinShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("TungstenShield"))
						{
							canequip = false;
							break;
						}
						if (player.armor[l].type == mod.ItemType("WoodenShield"))
						{
							canequip = false;
							break;
						}
					}
					return canequip;

				}
		*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedSteelBar>(), 10);
			recipe.AddIngredient(ModContent.ItemType<FaultyRedSteelShield>(), 1);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
