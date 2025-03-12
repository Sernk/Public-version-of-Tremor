using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using TremorMod.Content.Items.CyberKing;
using TremorMod.Content.NPCs.Bosses;
using TremorMod.Content.NPCs.Bosses.AncienDragon;
using TremorMod.Content.NPCs.Bosses.Alchemaster;
using TremorMod.Content.Items.BossSumonItems;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.NPCs.Invasion.ParadoxTitan;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.NPCs.Bosses.CogLord;
using TremorMod.Content.Items.CogLordItems;

namespace TremorMod.Utilities
{
    public class ModSupport : ModSystem
    {
        public override void PostSetupContent()
        {
            DoBossChecklistIntegration();
        }

        private void DoBossChecklistIntegration()
        {

            if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
            {
                return;
            }

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            string internalName = "Alchemaster";

            float weight = 7.3f;

            Func<bool> downed = () => !TremorSpawnEnemys.downedAlchemaster;

            int bossType = ModContent.NPCType<Alchemaster>();

            int spawnItem = ModContent.ItemType<AncientMosaic>();

            List<int> collectibles = new List<int>()
            {
                ModContent.ItemType<TheGlorch>(),
                ModContent.ItemType<LongFuse>(),
                ModContent.ItemType<PlagueFlask>(),
                ModContent.ItemType<AlchemasterMask>(),
                ModContent.ItemType<BadApple>(),
                ModContent.ItemType<AlchemasterTreasureBag>(),
                ModContent.ItemType<AlchemasterTrophy>()
            };

            // By default, it draws the first frame of the boss, omit if you don't need custom drawing
            // But we want to draw the bestiary texture instead, so we create the code for that to draw centered on the intended location
            //var customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
            //    Texture2D texture = ModContent.Request<Texture2D>("ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview").Value;
            //    Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
            //    sb.Draw(texture, centered, color);
            //};

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalName,
                weight,
                downed,
                bossType,
                new Dictionary<string, object>()
                {
                    ["spawnItems"] = spawnItem,
                    ["collectibles"] = collectibles,
                    //["customPortrait"] = customPortrait
                    // Other optional arguments as needed are inferred from the wiki
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            string internalNameAncientDragon = "AncientDragon";

            float weightAncientDragon = 5.7f;

            Func<bool> downedAncientDragon = () => !TremorSpawnEnemys.downedAncienDragon;

            int bossTypeAncientDragon = ModContent.NPCType<Dragon_HeadB>();

            int spawnItemAncientDragon = ModContent.ItemType<RustyLantern>();

            List<int> collectiblesAncientDragon = new List<int>()
            {
                ModContent.ItemType<AncientDragonTrophy>(),
                ModContent.ItemType<AncientDragonMask>(),
                ModContent.ItemType<Swordstorm>(),
                ModContent.ItemType<DragonHead>(),
                ModContent.ItemType<AncientTimesEdge>(),
                ModContent.ItemType<AncientDragonBag>(),
            };

            //var customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
            //    Texture2D texture = ModContent.Request<Texture2D>("ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview").Value;
            //    Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
            //    sb.Draw(texture, centered, color);
            //};

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalNameAncientDragon,
                weightAncientDragon,
                downedAncientDragon,
                bossTypeAncientDragon,
                new Dictionary<string, object>()
                {
                    ["spawnItems"] = spawnItemAncientDragon,
                    ["collectibles"] = collectiblesAncientDragon,
                    //["customPortrait"] = customPortrait
                    // Other optional arguments as needed are inferred from the wiki
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            string internalNameCyberKing = "CyberKing";

            float weightCyberKing = 13.6f;

            Func<bool> downedCyberKing = () => !TremorSpawnEnemys.downedCyberKing;

            int bossTypeCyberKing = ModContent.NPCType<CyberKing>();

            int spawnItemCyberKing = ModContent.ItemType<AdvancedCircuit>();

            List<int> collectiblesCyberKing = new List<int>()
            {
                ModContent.ItemType<CyberKingTrophy>(),
                ModContent.ItemType<CyberKingMask>(),
                ModContent.ItemType<RedStorm>(),
                ModContent.ItemType<ShockwaveClaymore>(),
                ModContent.ItemType<CyberCutter>(),
                ModContent.ItemType<CyberKingBag>(),
            };

            //var customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
            //    Texture2D texture = ModContent.Request<Texture2D>("ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview").Value;
            //    Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
            //    sb.Draw(texture, centered, color);
            //};

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalNameCyberKing,
                weightCyberKing,
                downedCyberKing,
                bossTypeCyberKing,
                new Dictionary<string, object>()
                {
                    ["spawnItems"] = spawnItemCyberKing,
                    ["collectibles"] = collectiblesCyberKing,
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            string internalNameTitan = "Titan";

            float weightTitan = 18.5f;

            Func<bool> downedTitan = () => !TremorSpawnEnemys.downedTitan;

            int bossTypeTitan = ModContent.NPCType<Titan>();

            int spawnItemTitan = ModContent.ItemType<AncientWatch>();

            List<int> collectiblesTitan = new List<int>()
            {
                ModContent.ItemType<ParadoxTitanMask>(),
                ModContent.ItemType<TimeTissue>(),
                ModContent.ItemType<RocketWand>(),
                ModContent.ItemType<TheEtherealm>(),
                ModContent.ItemType<SoulFlames>(),
                ModContent.ItemType<ParadoxTitanTrophy>(),
                ModContent.ItemType<ParadoxTitanBag>(),
                ModContent.ItemType<VioleumWings>()
            };

            //var customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
            //    Texture2D texture = ModContent.Request<Texture2D>("ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview").Value;
            //    Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
            //    sb.Draw(texture, centered, color);
            //};

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalNameTitan,
                weightTitan,
                downedTitan,
                bossTypeTitan,
                new Dictionary<string, object>()
                {
                    ["spawnItems"] = spawnItemTitan,
                    ["collectibles"] = collectiblesTitan,
                    //["customPortrait"] = customPortrait
                    // Other optional arguments as needed are inferred from the wiki
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            string internalNameCogLord = "CogLord";

            float weightCogLord = 13.3f;

            Func<bool> downedCogLord = () => !TremorSpawnEnemys.downedCogLord;

            int bossTypeCogLord = ModContent.NPCType<CogLord>();

            int spawnItemCogLord = ModContent.ItemType<ArtifactEngine>();

            List<int> collectiblesCogLord = new List<int>()
            {
                ModContent.ItemType<CogLordTrophy>(),
                ModContent.ItemType<CogLordMask>(),
                ModContent.ItemType<BrassChip>(),
                ModContent.ItemType<BrassNugget>(),
                ModContent.ItemType<BrassRapier>(),
                ModContent.ItemType<BrassChainRepeater>(),
                ModContent.ItemType<BrassStave>(),
                ModContent.ItemType<CogLordBag>()
            };

            //var customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
            //    Texture2D texture = ModContent.Request<Texture2D>("ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview").Value;
            //    Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
            //    sb.Draw(texture, centered, color);
            //};

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalNameCogLord,
                weightCogLord,
                downedCogLord,
                bossTypeCogLord,
                new Dictionary<string, object>()
                {
                    ["spawnItems"] = spawnItemCogLord,
                    ["collectibles"] = collectiblesCogLord,
                    //["customPortrait"] = customPortrait
                    // Other optional arguments as needed are inferred from the wiki
                }
            );
        }
    }       
}