﻿using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public interface IAssuranceService
    {
        Task<List<Assurance>> GetAllAssurancesAsync();
        Task<Assurance> GetAssuranceByIdAsync(int id);
        Task AddAssuranceAsync(Assurance assurance);
        Task UpdateAssuranceAsync(Assurance assurance);
        Task DeleteAssuranceAsync(int id);
<<<<<<< HEAD
=======
        Task<bool> AssuranceExistsAsync(int id); // Add this method
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
    }
}
