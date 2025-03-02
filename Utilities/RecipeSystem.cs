using Terraria;
using Terraria.ID;
using System.Linq;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;
using TremorMod.Content.Items.Armor.Heaven;
using TremorMod.Content.Items.Buffs;
using TremorMod.Content.Items.Armor.Paladin;
using Terraria.ModLoader;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.BossLoot.TikiTotem;
using TremorMod.Content.Items.Armor.Meteor;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Armor.Zerokk;
using TremorMod.Content.Items.Armor.Hummer;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.BossSumonItems;
using TremorMod.Content.Items.CogLordItems;
using TremorMod.Content.Items;
using TremorMod.Content.Items.CraftingStations;
using TremorMod.Content.Items.Crystal;
using TremorMod.Content.Items.CyberKing;
using TremorMod.Content.Items.EvilCornItems;
using TremorMod.Content.Items.Fish;
using TremorMod.Content.Items.Fungus;
using TremorMod.Content.Items.HeaterOfWorldsItems;
using TremorMod.Content.Items.Key;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.SpaceWhaleItems;
using TremorMod.Content.Items.Tools;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Wood;
using TremorMod.Content.Tiles;
using TremorMod;

namespace TremorMod.Utilities
{
    public class RecipeSystem : ModSystem
    {
        public override void PostAddRecipes()
        {
            TremorConfig config = ModContent.GetInstance<TremorConfig>();

            // Проверяем, разрешено ли изменять рецепт Зенита
            if (!config.AllowZenithRecipeChange)
            {
                return;
            }
            // Отключения ванильного рецепта для Зенита
            foreach (var recipe in Main.recipe.ToList())
            {
                if (recipe.createItem.type == ItemID.Zenith)
                {
                    recipe.DisableRecipe();
                }

                if (recipe.createItem.type == ItemID.CelestialSigil)
                {
                    recipe.DisableRecipe();
                }
            }

            // Изменённый рецепт для Зенита
            Recipe newRecipe = Recipe.Create(ItemID.Zenith);
            newRecipe.AddIngredient(ItemID.Meowmere);
            newRecipe.AddIngredient(ItemID.StarWrath);
            newRecipe.AddIngredient(ModContent.ItemType<TrueTerraBlade>());
            newRecipe.AddIngredient(ItemID.InfluxWaver);
            newRecipe.AddIngredient(ItemID.TheHorsemansBlade);
            newRecipe.AddIngredient(ItemID.Seedler);
            newRecipe.AddIngredient(ItemID.EnchantedSword);
            newRecipe.AddIngredient(ItemID.BeeKeeper);
            newRecipe.AddIngredient(ItemID.Starfury);
            newRecipe.AddIngredient(ModContent.ItemType<DivineClaymore>());
            newRecipe.AddIngredient(ModContent.ItemType<TremorS>());
            newRecipe.AddTile(TileID.LunarCraftingStation);
            newRecipe.Register();

            Recipe newRecipe1 = Recipe.Create(ItemID.CelestialSigil);
            newRecipe1.AddIngredient(ItemID.FragmentVortex, 20);
            newRecipe1.AddIngredient(ItemID.FragmentNebula, 20);
            newRecipe1.AddIngredient(ItemID.FragmentSolar, 20);
            newRecipe1.AddIngredient(ItemID.FragmentSolar, 20);
            newRecipe1.AddIngredient(ModContent.ItemType<NovaFragment>(), 20);
            newRecipe1.AddTile(TileID.LunarCraftingStation);
            newRecipe1.Register();
        }

        public override void AddRecipes() 
        {
            Recipe newRecipe = Recipe.Create(ItemID.AvengerEmblem); // Новый рецепт для AvengerEmblem
            newRecipe.AddIngredient(ModContent.ItemType<ThrowerEmblem>());
            newRecipe.AddIngredient(ItemID.SoulofMight, 5);
            newRecipe.AddIngredient(ItemID.SoulofSight, 5);
            newRecipe.AddIngredient(ItemID.SoulofFright, 5);
            newRecipe.AddTile(TileID.TinkerersWorkbench);
            newRecipe.Register();

            Recipe newRecipe1 = Recipe.Create(ItemID.ToxicFlask);  // Новый рецепт для ToxicFlask
            newRecipe1.AddIngredient(ModContent.ItemType<ToxicFlask>());
            newRecipe1.Register();

            Recipe newRecipe3 = Recipe.Create(ItemID.AvengerEmblem); // Новый рецепт для AvengerEmblem
            newRecipe3.AddIngredient(ModContent.ItemType<AlchemistEmblem>());
            newRecipe3.AddIngredient(ItemID.SoulofMight, 5);
            newRecipe3.AddIngredient(ItemID.SoulofSight, 5);
            newRecipe3.AddIngredient(ItemID.SoulofFright, 5);
            newRecipe3.AddTile(TileID.TinkerersWorkbench);
            newRecipe3.Register();

            Recipe newRecipe4 = Recipe.Create(ItemID.MagicMirror);  // Новый рецепт для MagicMirror
            newRecipe4.AddIngredient(ItemID.SilverBar, 15);
            newRecipe4.AddIngredient(ItemID.Glass, 5);
            newRecipe4.AddIngredient(ItemID.ManaCrystal, 2);
            newRecipe4.Register();

            Recipe goldChestRecipe = Recipe.Create(ItemID.GoldChest);
            goldChestRecipe.AddIngredient(ItemID.Wood, 8);
            goldChestRecipe.AddIngredient(ItemID.GoldBar, 2);
            goldChestRecipe.AddTile(TileID.WorkBenches); 
            goldChestRecipe.Register();

            Recipe bandManaRecipe = Recipe.Create(111);
            bandManaRecipe.AddIngredient(ModContent.ItemType<Band>());
            bandManaRecipe.AddIngredient(ItemID.ManaCrystal, 2);
            bandManaRecipe.AddTile(TileID.Anvils);
            bandManaRecipe.Register();

            Recipe bandLifeRecipe = Recipe.Create(49);
            bandLifeRecipe.AddIngredient(ModContent.ItemType<Band>());
            bandLifeRecipe.AddIngredient(ItemID.LifeCrystal, 2);
            bandLifeRecipe.AddTile(TileID.Anvils);
            bandLifeRecipe.Register();

            Recipe agletTinRecipe = Recipe.Create(ItemID.Aglet);
            agletTinRecipe.AddIngredient(ItemID.TinBar, 5);
            agletTinRecipe.AddIngredient(ItemID.Wood);
            agletTinRecipe.AddTile(TileID.Anvils);
            agletTinRecipe.Register();

            Recipe agletCopperRecipe = Recipe.Create(ItemID.Aglet);
            agletCopperRecipe.AddIngredient(ItemID.CopperBar, 5);
            agletCopperRecipe.AddIngredient(ItemID.Wood);
            agletCopperRecipe.AddTile(TileID.Anvils);
            agletCopperRecipe.Register();

            Recipe slimeStaffRecipe = Recipe.Create(ItemID.SlimeStaff);
            slimeStaffRecipe.AddIngredient(ItemID.Wood, 10);
            slimeStaffRecipe.AddIngredient(ItemID.Gel, 25);
            slimeStaffRecipe.AddTile(TileID.Solidifier);
            slimeStaffRecipe.Register();

            Recipe demoniteToCrimtaneRecipe = Recipe.Create(ItemID.CrimtaneOre, 3);
            demoniteToCrimtaneRecipe.AddIngredient(ItemID.DemoniteOre, 5);
            demoniteToCrimtaneRecipe.AddTile(ModContent.TileType<MineralTransmutatorTile>());
            demoniteToCrimtaneRecipe.Register();

            Recipe crimtaneToDemoniteRecipe = Recipe.Create(ItemID.DemoniteOre, 3);
            crimtaneToDemoniteRecipe.AddIngredient(ItemID.CrimtaneOre, 5);
            crimtaneToDemoniteRecipe.AddTile(ModContent.TileType<MineralTransmutatorTile>());
            crimtaneToDemoniteRecipe.Register();

            Recipe megasharkRecipe = Recipe.Create(ItemID.Megashark);
            megasharkRecipe.AddIngredient(ModContent.ItemType<SoulofMind>(), 20);
            megasharkRecipe.AddIngredient(ItemID.SharkFin, 5);
            megasharkRecipe.AddIngredient(ItemID.IllegalGunParts);
            megasharkRecipe.AddIngredient(ItemID.Minishark);
            megasharkRecipe.AddTile(TileID.MythrilAnvil);
            megasharkRecipe.Register();

            Recipe terraBladeRecipe = Recipe.Create(ItemID.TerraBlade);
            terraBladeRecipe.AddIngredient(ItemID.HallowedBar, 18);
            terraBladeRecipe.AddIngredient(ItemID.SoulofFright);
            terraBladeRecipe.AddIngredient(ModContent.ItemType<SoulofMind>());
            terraBladeRecipe.AddIngredient(ItemID.SoulofSight);
            terraBladeRecipe.AddTile(TileID.MythrilAnvil);
            terraBladeRecipe.Register();

            Recipe warriorEmblemRecipe = Recipe.Create(935);
            warriorEmblemRecipe.AddIngredient(ItemID.WarriorEmblem);
            warriorEmblemRecipe.AddIngredient(ItemID.SoulofFright, 5);
            warriorEmblemRecipe.AddIngredient(ModContent.ItemType<SoulofMind>(), 5);
            warriorEmblemRecipe.AddIngredient(ItemID.SoulofSight, 5);
            warriorEmblemRecipe.AddTile(TileID.MythrilAnvil);
            warriorEmblemRecipe.Register();

            Recipe jungleKeyRecipe = Recipe.Create(ItemID.JungleKey);
            jungleKeyRecipe.AddIngredient(ItemID.TurtleShell);
            jungleKeyRecipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            jungleKeyRecipe.AddIngredient(ItemID.JungleSpores, 20);
            jungleKeyRecipe.AddIngredient(ItemID.Stinger, 18);
            jungleKeyRecipe.AddIngredient(ModContent.ItemType<KeyMold>());
            jungleKeyRecipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            jungleKeyRecipe.Register();

            Recipe corruptionKeyRecipe = Recipe.Create(ItemID.CorruptionKey);
            corruptionKeyRecipe.AddIngredient(ItemID.DemoniteBar, 25);
            corruptionKeyRecipe.AddIngredient(ItemID.ShadowScale, 25);
            corruptionKeyRecipe.AddIngredient(ItemID.EbonstoneBlock, 25);
            corruptionKeyRecipe.AddIngredient(ItemID.VilePowder, 25);
            corruptionKeyRecipe.AddIngredient(ModContent.ItemType<KeyMold>());
            corruptionKeyRecipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            corruptionKeyRecipe.Register();

            Recipe crimsonKeyRecipe = Recipe.Create(ItemID.CrimsonKey);
            crimsonKeyRecipe.AddIngredient(ItemID.CrimtaneBar, 25);
            crimsonKeyRecipe.AddIngredient(ItemID.TissueSample, 25);
            crimsonKeyRecipe.AddIngredient(ItemID.CrimstoneBlock, 25);
            crimsonKeyRecipe.AddIngredient(ItemID.ViciousPowder, 25);
            crimsonKeyRecipe.AddIngredient(ModContent.ItemType<KeyMold>());
            crimsonKeyRecipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            crimsonKeyRecipe.Register();

            Recipe hallowedKeyRecipe = Recipe.Create(ItemID.HallowedKey);
            hallowedKeyRecipe.AddIngredient(ItemID.HallowedBar, 15);
            hallowedKeyRecipe.AddIngredient(ItemID.SoulofLight, 10);
            hallowedKeyRecipe.AddIngredient(ItemID.SoulofNight, 10);
            hallowedKeyRecipe.AddIngredient(ItemID.PurificationPowder, 25);
            hallowedKeyRecipe.AddIngredient(ModContent.ItemType<KeyMold>());
            hallowedKeyRecipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            hallowedKeyRecipe.Register();

            Recipe frozenKeyRecipe = Recipe.Create(ItemID.FrozenKey);
            frozenKeyRecipe.AddIngredient(ItemID.FrostCore, 2);
            frozenKeyRecipe.AddIngredient(ItemID.SnowBlock, 30);
            frozenKeyRecipe.AddIngredient(ItemID.IceBlock, 30);
            frozenKeyRecipe.AddIngredient(ModContent.ItemType<KeyMold>());
            frozenKeyRecipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            frozenKeyRecipe.Register();

            Recipe boneRecipe = Recipe.Create(1320);
            boneRecipe.AddIngredient(ItemID.Bone, 80);
            boneRecipe.AddTile(TileID.BoneWelder);
            boneRecipe.Register();

            Recipe tikiTorchRecipe = Recipe.Create(3069);
            tikiTorchRecipe.AddIngredient(ItemID.Wood, 10);
            tikiTorchRecipe.AddIngredient(ItemID.Torch, 5);
            tikiTorchRecipe.AddTile(TileID.Anvils);
            tikiTorchRecipe.Register();

            Recipe iceRodRecipe = Recipe.Create(602);
            iceRodRecipe.AddIngredient(ItemID.CobaltBar, 12);
            iceRodRecipe.AddIngredient(ItemID.SnowBlock, 25);
            iceRodRecipe.AddIngredient(ItemID.IceBlock, 25);
            iceRodRecipe.AddIngredient(ItemID.SoulofLight, 6);
            iceRodRecipe.AddIngredient(ItemID.SoulofNight, 6);
            iceRodRecipe.AddIngredient(ItemID.Glass, 15);
            iceRodRecipe.AddTile(TileID.Anvils);
            iceRodRecipe.Register();

            Recipe woodenChairRecipe = Recipe.Create(2196);
            woodenChairRecipe.AddIngredient(ItemID.Wood, 30);
            woodenChairRecipe.AddTile(TileID.Sawmill);
            woodenChairRecipe.Register();


            Recipe newRecipe5 = Recipe.Create(2766); 
            newRecipe5.AddIngredient(1261, 75);
            newRecipe5.AddTile(134);
            newRecipe5.Register();
        }
    }
}