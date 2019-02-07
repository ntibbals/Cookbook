﻿using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Services
{
    public class SavedRecipeService : ISavedRecipe
    {
        private CookbookDbContext _context { get; }

        public SavedRecipeService(CookbookDbContext context)
        {
            _context = context;
        }

        //read
        public async Task <IEnumerable<SavedRecipe>> GetSavedRecipe()
        {
            return await _context.SavedRecipe.ToListAsync();
        }

        public async Task<SavedRecipe> GetSavedRecipe(int? id)
        {
            return await _context.SavedRecipe.FirstOrDefaultAsync(s => s.SavedRecipeID == id); )
        }

        //delete
        public async Task DeleteSavedRecipe(int id)
        {
            SavedRecipe savedRecipe = _context.SavedRecipe.FirstOrDefault(s => s.SavedRecipeID == SavedRecipeID);
            _context.SavedRecipe.Remove(savedRecipe);
            await _context.SaveChangesAsync();
        }
        //confirm existence
        public bool SavedRecipeExists(int id)
        {
            return _context.SavedRecipe.Any(s => s.SavedRecipeID == id);

        }
    }
}
