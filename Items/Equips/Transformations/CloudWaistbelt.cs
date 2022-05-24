﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;

namespace CalValEX.Items.Equips.Transformations
{
	public class CloudWaistbelt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Valkyrian Garments");
			Tooltip.SetDefault("Surrounds the wearer with clouds");
			SetupDrawing();
		}
		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 18);
				recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 47);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}*/
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, name: "Head");
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, name: "Body");
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, name: "Legs");
			}
		}
		private void SetupDrawing()
		{
			int equipSlotHead = EquipLoader.GetEquipSlot(Mod, "Head", EquipType.Head);
			int equipSlotBody = EquipLoader.GetEquipSlot(Mod, "Body", EquipType.Body);
			int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, "Legs", EquipType.Legs);

			ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
			ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
			ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
			ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.accessory = true;
			Item.rare = 5;
			Item.canBePlacedInVanityRegardlessOfConditions = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var p = player.GetModPlayer<CalValEXPlayer>();
			p.cloudTrans = true;
			p.cloudHide = hideVisual;
		}
		public override bool IsVanitySet(int head, int body, int legs) => true;

	}
}