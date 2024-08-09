﻿using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IVignetteService
{
    Task<IEnumerable<Vignette>> GetAllVignettesAsync();
    Task<Vignette> GetVignetteByIdAsync(int id);
    Task AddVignetteAsync(Vignette vignette);
    Task UpdateVignetteAsync(Vignette vignette);
    Task DeleteVignetteAsync(int id);
    Task<bool> VignetteExistsAsync(int id);
<<<<<<< HEAD
=======


 
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
}
