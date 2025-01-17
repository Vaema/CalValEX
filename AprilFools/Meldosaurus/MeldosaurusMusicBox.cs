﻿using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.AprilFools.Meldosaurus
{
	public class MeldosaurusMusicBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			SacrificeTotal = 1;
			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Meldosaurus"), ModContent.ItemType<MeldosaurusMusicBox>(), ModContent.TileType<MeldosaurusMusicBoxPlaced>());
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<MeldosaurusMusicBoxPlaced>();
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Yellow;
			Item.value = 100000;
			Item.accessory = true;
		}
	}
}