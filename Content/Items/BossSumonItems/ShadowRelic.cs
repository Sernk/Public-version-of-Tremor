using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.NPCs.Bosses.WallofShadows;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class ShadowRelic : ModItem
	{
        public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 26;
			Item.rare = 7;
			Item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Shadow Relic");
			//Tooltip.SetDefault("Summons Wall of Shadows\n" +
			//"'Can be used in ritual of shadows if thrown into lava in underground and the Dryad is alive...'");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofNight, 16);
			recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 5);
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 12);
			recipe.AddIngredient(ItemID.Amethyst, 7);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddTile(26);
			//recipe.SetResult(this);
			recipe.Register();
		}

		public override void PostUpdate()
		{
			if (Item.lavaWet)
			{
				//if (Main.netMode != 1)
				//{
				for (int i = 0; i < 200; ++i)
				{
                    if (Main.npc[i].type == NPCID.Dryad && NPC.downedPlantBoss)
                    {
                        SpawnShadowWall(Item.position);
                        //Main.npc[i].StrikeNPC(9999, 10f, -Main.npc[i].direction, false, false, false);
                        Item.active = false;
                        Item.type = 0;
                        // item.name = ""; 
                        Item.stack = 0;
                        Main.NewText("The shadows are gathering around you...", 42, 10, 74);
                    }
                }
                //}
            }
		}

		public void SpawnShadowWall(Vector2 pos)
		{
            if (pos.Y / 16.0 < (Main.maxTilesY - 205) || Main.netMode == 1)

                return;
			int num1 = Player.FindClosest(pos, 16, 16);
			int num2 = 1;
			if (pos.X / 16.0 > (Main.maxTilesX / 2))
				num2 = -1;
			bool flag = false;
			int X = (int)pos.X;
			while (!flag)
			{
				flag = true;
				for (int index = 0; index < 255; ++index)
				{
					if (Main.player[index].active && Main.player[index].position.X > (X - 1200) && Main.player[index].position.X < (X + 1200))
					{
						X -= num2 * 16;
						flag = false;
					}
				}
				if (X / 16 < 20 || X / 16 > Main.maxTilesX - 20)
					flag = true;
			}
			int num3 = (int)pos.Y;
			int i = X / 16;
			int num4 = num3 / 16;
			int num5 = 0;
			try
			{
				for (; WorldGen.SolidTile(i, num4 - num5) || (int)Main.tile[i, num4 - num5].LiquidAmount >= 100; ++num5)
				{
					if (!WorldGen.SolidTile(i, num4 + num5) && Main.tile[i, num4 + num5].LiquidAmount < 100)
					{
						num4 += num5;
						goto label_21;
					}
				}
				num4 -= num5;
			}
			catch
			{
			}
			label_21:
			int Y = num4 * 16;
			NPC.SpawnOnPlayer(Main.myPlayer, ModContent.NPCType<WallOfShadow>());
		}

	}
}
