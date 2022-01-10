﻿using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Auric;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricBedItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Bed");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<AuricBed>();
            item.width = 12;
            item.height = 12;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(calamityMod.ItemType("CosmiliteBed"));
                recipe.AddIngredient(ModContent.ItemType<Items.Tiles.FurnitureSets.Bloodstone.BloodstoneBedItem>());
                recipe.AddIngredient(calamityMod.ItemType("BotanicBed"));
                recipe.AddIngredient(calamityMod.ItemType("SilvaBed"));
                recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 15);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("CosmicAnvil"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}