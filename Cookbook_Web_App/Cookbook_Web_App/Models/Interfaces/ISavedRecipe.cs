﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Interfaces
{
    public interface ISavedRecipe
    {
        //read
        Task<SavedRecipe> GetSavedRecipe(int? id);
        Task<IEnumerable<SavedRecipe>> GetSavedRecipes();


    }
}
