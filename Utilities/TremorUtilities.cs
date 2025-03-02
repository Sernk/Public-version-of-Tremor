using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.Utilities;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.NPCs;

namespace TremorMod
{
    public static class TremorUtilities
    {
        public static bool NextBool(Random rand, int chance)
        {
            return rand.Next(chance) == 0;
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                    yield return element;
            }
        }
        public static void DisplayLocalizedText(string key, Color messageColor)
        {
            string message = Language.GetTextValue(key);
            Main.NewText(message, messageColor);
        }      
    } 

    /// <summary>
	/// Defines a weighted object, stores the object and the weight (double)
	/// Default weight: 1
	/// </summary>
	public class WeightedObject<T>
    {
        public T Obj;
        public double Weight;

        public static Tuple<T, double> Tuple(T obj, double weight = 1d)
            => new Tuple<T, double>(obj, weight);

        public Tuple<T, double> Tuple()
            => Tuple(Obj, Weight);

        public WeightedObject(T obj, double weight = 1d)
        {
            this.Obj = obj;
            this.Weight = weight;
        }
    }

    /// <summary>
    /// Houses a number of utility functions used throughout the code
    /// Utility functions are often used in multiple places, thus it is more efficient to define them once
    /// </summary>
    public static class TremorUtils // ?
    {
        /// <summary>
        /// Tries finding name from constant value: FindNameByConstant(typeof(ItemID), type) => name
        /// Also caches values, taken from Mirsario so credit where due. The caching is a nice feature
        /// </summary>
        private static readonly Dictionary<Type, Dictionary<int, string>> NameFromConstCache = new Dictionary<Type, Dictionary<int, string>>();
        private static readonly Type[] IntTypes = new Type[] { typeof(byte), typeof(sbyte), typeof(ushort), typeof(short), typeof(uint), typeof(int), typeof(ulong), typeof(long) };
        public static string FindNameByConstant(this Type classType, int id)
        {
            Dictionary<int, string> cache;
            if (!NameFromConstCache.ContainsKey(classType))
            {
                FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).Where(f => f.IsLiteral && !f.IsInitOnly && IntTypes.Contains(f.FieldType)).ToArray();
                cache = new Dictionary<int, string>();
                for (int i = 0; i < fields.Length; i++)
                {
                    int val = Convert.ToInt32(fields[i].GetRawConstantValue());
                    string name = fields[i].Name;
                    if (name != "Count" && !cache.ContainsKey(val))
                    {
                        cache.TryAdd(val, name);
                    }
                }
                NameFromConstCache[classType] = cache;
            }
            else
            {
                cache = NameFromConstCache[classType];
            }
            string result;
            if (cache.TryGetValue(id, out result))
            {
                return result;
            }
            return "UNDEFINED";
        }

        /// <summary>
        /// MoreLINQ distinct by: .DistinctBy( x => x.prop )
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Adds to dict if not present
        /// </summary>
        public static void TryAdd<T1, T2>(this Dictionary<T1, T2> dict, T1 key, T2 value)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
        }

        /// <summary>
        ///  Does player have buff?  Usable in SetDefaults because of the hacks
        /// </summary>
        public static bool HasBuff(this Player player, int buffType)
        {
            if (player.whoAmI != -1 || buffType < 0 || buffType >= player.buffImmune.Length)
                return false;

            return player.FindBuffIndex(buffType) != -1;
        }

        /// <summary>
        /// Add item to a chest, if an empty slot is present. Returns succession
        /// </summary>
        public static bool AddItem(this Chest chest, int type, int? stack = null)
        {
            foreach (var item in chest.item)
            {
                if (item.IsAir)
                {
                    item.SetDefaults(type);
                    if (stack.HasValue)
                        item.stack = stack.Value;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Transforms namespace to a path, but skips the first segment
        /// </summary>
        public static string NamespaceToPathSkipFirst(this Type type)
        {
            string input = type.NamespaceToPath();
            int i = input.IndexOf('.');
            return i >= 0
                ? input.Substring(input.IndexOf('.') + 1)
                : input;
        }

        /// <summary>
        /// Transforms namespace to a path
        /// </summary>
        public static string NamespaceToPath(this Type type)
            => type.Namespace?.Replace('.', '/');

        /// <summary>
        /// Transforms the given collection of strings, and optional collection of weights, to a collection of Weighted string Objects
        /// </summary>
        public static WeightedObject<string>[] ToWeightedStringCollection(this string[] strings, params double[] weights)
        {
            WeightedObject<string>[] chats = new WeightedObject<string>[strings.Length];
            int weightCount = weights.Length;
            for (int i = 0; i < strings.Length; i++)
            {
                chats[i] = new WeightedObject<string>(strings[i], i < weightCount ? weights[i] : 1d);
            }
            return chats;
        }

        /// <summary>
        /// Transforms the given collection of Weighted string Objects to a WeightedRandom
        /// </summary>
        public static WeightedRandom<string> ToWeightedCollection(this WeightedObject<string>[] strings)
            => new WeightedRandom<string>(strings.Select(x => new Tuple<string, double>(x.Obj, x.Weight)).ToArray());

        /// <summary>
        /// Transforms the given string collection to a WeightedRandom
        /// Parses the weight given in the string in the format: string:weight
        /// Weight defaults to 1
        /// </summary>
        public static WeightedRandom<string> ToWeightedCollectionWithWeight(this string[] strings)
        {
            WeightedRandom<string> weightedCollection = new WeightedRandom<string>();
            for (int i = 0; i < strings.Length; i++)
            {
                string str = strings[i];
                string[] split = str.Split(':');
                double weight = split.Length > 1 ? Double.Parse(split[1]) : 1d;
                weightedCollection.Add(split[0], weight);
            }
            return weightedCollection;
        }

        /// <summary>
        /// Transforms the given string collection to a WeightedRandom
        /// The weight defaults to 1 and is not modifiable in this utility function
        /// </summary>
        public static WeightedRandom<string> ToWeightedCollection(this string[] strings)
            => new WeightedRandom<string>(strings.Select(x => x.ToWeightedTuple()).ToArray());

        /// <summary>
        /// Transforms the given string to a WeightedTuple, holding the string and its weight
        /// </summary>
        public static Tuple<string, double> ToWeightedTuple(this string message, double weight = 1d)
            => WeightedObject<string>.Tuple(message, weight);

        /// <summary>
        /// Spawns a new NPC at the given ModItem's position, and returns the instance
        /// </summary>
        public static NPC NewNPC(this ModItem item, IEntitySource source, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
        {
            Vector2 position = item.Item.position + new Vector2(offsetX, offsetY);
            int npcIndex = NPC.NewNPC(source, (int)position.X, (int)position.Y, type, start, ai0, ai1, ai2, ai3, target);
            return Main.npc[npcIndex];
        }

        /// <summary>
        /// Spawns a new NPC at the given ModPlayer's position, and returns the instance
        /// </summary>
        public static NPC NewNPC(this ModPlayer plr, IEntitySource source, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
        {
            Vector2 position = plr.Player.position + new Vector2(offsetX, offsetY);
            int npcIndex = NPC.NewNPC(source, (int)position.X, (int)position.Y, type, start, ai0, ai1, ai2, ai3, target);
            return Main.npc[npcIndex];
        }

        /// <summary>
        /// Spawns a new NPC at the given ModProjectile's position, and returns the instance
        /// </summary>
        public static NPC NewNPC(this ModProjectile proj, IEntitySource source, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
        {
            Vector2 position = proj.Projectile.position + new Vector2(offsetX, offsetY);
            int npcIndex = NPC.NewNPC(source, (int)position.X, (int)position.Y, type, start, ai0, ai1, ai2, ai3, target);
            return Main.npc[npcIndex];
        }

        /// <summary>
        /// Spawns a new NPC at the given ModNPC's position, and returns the instance
        /// </summary>
        public static NPC NewNPC(this ModNPC npc, IEntitySource source, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
        {
            Vector2 position = npc.NPC.position + new Vector2(offsetX, offsetY);
            int npcIndex = NPC.NewNPC(source, (int)position.X, (int)position.Y, type, start, ai0, ai1, ai2, ai3, target);
            return Main.npc[npcIndex];
        }


        /// <summary>
        /// Spawns a new NPC on the given Entity's position, and returns the instance
        /// </summary>
        public static NPC NewNPC(this Entity entity, IEntitySource source, int type, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f, int target = 255, int start = 0, float offsetX = 0f, float offsetY = 0f)
        {
            int x = (int)(entity.position.X + offsetX);
            int y = (int)(entity.position.Y + offsetY);
            int npcIndex = NPC.NewNPC(source, x, y, type, start, ai0, ai1, ai2, ai3, target);
            return Main.npc[npcIndex];
        }



        /// <summary>
        /// Spawns an item on the given Entity's position, and returns the instance
        /// </summary>
        public static Item NewItem(this Entity entity, IEntitySource source, int type, int stack = 1)
        {
            return Main.item[Item.NewItem(
                source,
                new Vector2(entity.position.X, entity.position.Y), // Позиция
                new Vector2(entity.width, entity.height),          // Размер
                type,
                stack
            )];
        }

        /// <summary>
        /// Spawns an item on the given position and returns the instance.
        /// </summary>
        public static Item NewItem(IEntitySource source, Vector2 position, Vector2 size, int type, int stack = 1)
        {
            return Main.item[Item.NewItem(
                source,
                position,  // Позиция
                size,      // Размер
                type,
                stack
            )];
        }

        /*/// <summary>
        /// Get an ID for a sound name from a Mod's registered sounds
        /// </summary>
        public static int GetIdForModSound(Mod mod, string soundName)
        {
            if (mod == null)
                throw new ArgumentNullException(nameof(mod));

            var soundEntries = mod.GetContent<ModSound>();

            int index = 0;
            foreach (var sound in soundEntries)
            {
                if (sound.Name.EndsWith(soundName, StringComparison.OrdinalIgnoreCase))
                    return index;
                index++;
            }
            return -1; // Вернуть -1, если звук не найден
        }*/


        /// <summary>
        /// Returns if the next random value is equal to 0
        /// </summary>
        public static bool NextBool(this UnifiedRandom rand, int total)
            => rand.Next(total) == 0;

        /// <summary>
        /// Returns if the next random value is below or equal to the chance
        /// </summary>
        public static bool NextBool(this UnifiedRandom rand, int chance, int total)
            => rand.Next(total) <= chance;

        /// <summary>
        /// Draws an NPC glowmask
        /// </summary>
        public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture)
        {
            var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
                             Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
        }

        /// <summary>
        /// Draws an armor glowmask for a player, used in PlayerLayers
        /// </summary>
        public static void DrawArmorGlowMask(EquipType type, Texture2D texture, PlayerDrawSet info)
        {
            Vector2 screenOffset = info.Position - Main.screenPosition;

            switch (type)
            {
                case EquipType.Head:
                    {
                        if (!info.drawPlayer.invis)
                        {
                            Vector2 position = screenOffset + info.drawPlayer.headPosition + info.headVect;
                            DrawData drawData = new DrawData(
                                texture,
                                position,
                                info.drawPlayer.bodyFrame,
                                info.colorArmorHead, // Используйте актуальное свойство для цвета головы
                                info.drawPlayer.headRotation,
                                info.headVect,
                                1f,
                                info.playerEffect,
                                0
                            );
                            drawData.shader = info.cHead;
                            info.DrawDataCache.Add(drawData);
                        }
                        break;
                    }
                case EquipType.Body:
                    {
                        if (!info.drawPlayer.invis)
                        {
                            Vector2 position = screenOffset + info.drawPlayer.bodyPosition + new Vector2(info.drawPlayer.bodyFrame.Width / 2, info.drawPlayer.bodyFrame.Height / 2);
                            Rectangle bodyFrame = info.drawPlayer.bodyFrame;

                            DrawData drawData = new DrawData(
                                texture,
                                position,
                                bodyFrame,
                                info.colorArmorBody, // Используйте актуальное свойство для цвета тела
                                info.drawPlayer.bodyRotation,
                                info.bodyVect,
                                1f,
                                info.playerEffect,
                                0
                            );
                            drawData.shader = info.cBody;
                            info.DrawDataCache.Add(drawData);
                        }
                        break;
                    }
                case EquipType.Legs:
                    {
                        if (!info.drawPlayer.invis)
                        {
                            Vector2 position = screenOffset + info.drawPlayer.legPosition + info.legVect;
                            DrawData drawData = new DrawData(
                                texture,
                                position,
                                info.drawPlayer.legFrame,
                                info.colorArmorLegs, // Используйте актуальное свойство для цвета ног
                                info.drawPlayer.legRotation,
                                info.legVect,
                                1f,
                                info.playerEffect,
                                0
                            );
                            drawData.shader = info.cLegs;
                            info.DrawDataCache.Add(drawData);
                        }
                        break;
                    }
            }
        }


        /// <summary>
        /// Draws an item glowmask for the item a player is holding, used in PlayerLayers
        /// </summary>
        public static void DrawItemGlowMask(Texture2D texture, PlayerDrawSet info)
        {
            Item item = info.drawPlayer.HeldItem;
            if (info.shadow != 0f || info.drawPlayer.frozen || ((info.drawPlayer.itemAnimation <= 0 || item.useStyle == 0) && (item.holdStyle <= 0 || info.drawPlayer.pulley))/*||item.type<=0*/|| info.drawPlayer.dead || item.noUseGraphic || (info.drawPlayer.wet && item.noWet))
            {
                return;
            }
            Vector2 offset = new Vector2();
            float rotOffset = 0;
            Vector2 origin = new Vector2();
            if (item.useStyle == 5)
            {
                if (Item.staff[item.type])
                {
                    rotOffset = 0.785f * info.drawPlayer.direction;
                    if (info.drawPlayer.gravDir == -1f) { rotOffset -= 1.57f * info.drawPlayer.direction; }
                    origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);
                    int num86 = -(int)origin.X;
                    ItemLoader.HoldoutOrigin(info.drawPlayer, ref origin);
                    offset = new Vector2(origin.X + num86, 0);
                }
                else
                {
                    offset = new Vector2(10, texture.Height / 2);
                    ItemLoader.HoldoutOffset(info.drawPlayer.gravDir, item.type, ref offset);
                    origin = new Vector2(-offset.X, texture.Height / 2);
                    if (info.drawPlayer.direction == -1)
                    {
                        origin.X = texture.Width + offset.X;
                    }
                    offset = new Vector2(texture.Width / 2, offset.Y);
                }
            }
            else
            {
                origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);
            }
            /*Main.playerDrawData.Add
			(
				new DrawData
				(
					texture,
					info.ItemLocation-Main.screenPosition+offset,
					texture.Bounds,
					new Color(250,250,250,item.alpha),
					info.drawPlayer.itemRotation+rotOffset,
					origin,
					item.scale,info.playerEffect,0
				)
			);*/
        }

        /// <summary>
        /// Draws an item glowmask that is in the world
        /// </summary>
        /// <summary>
        /// Draws an item glowmask in the world
        /// </summary>
        public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale)
        {
            Vector2 position = item.position - Main.screenPosition + new Vector2(item.width / 2, item.height - (texture.Height / 2) + 2f);

            spriteBatch.Draw(
                texture,
                position,
                new Rectangle(0, 0, texture.Width, texture.Height),
                new Color(250, 250, 250, 255 - item.alpha), // Учитываем прозрачность предмета
                rotation,
                new Vector2(texture.Width / 2, texture.Height / 2),
                scale,
                SpriteEffects.None,
                0f
            );
        }


        // DO NOT remove this method
        // The trick here is to reference System.Core is some way, in any class
        // This is a trick to get the mod to compile with extension methods
        // Normally you would get an error, this is a workaround trick for now
        public static void RedundantFunc()
        {
            var something = Enumerable.Range(1, 10);
        }
    }
}