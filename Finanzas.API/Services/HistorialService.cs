using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Repositories;
using Finanzas.API.Domain.Respositories;
using Finanzas.API.Domain.Services;
using Finanzas.API.Domain.Services.Communication;

namespace Finanzas.API.Services
{
    public class HistorialService : IHistorialService
    {
        private readonly IHistorialRepository _historialRepository;
        private readonly ICarteraRepository _carteraRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HistorialService(IHistorialRepository historialRepository, ICarteraRepository carteraRepository, IUnitOfWork unitOfWork)
        {
            _historialRepository = historialRepository;
            _carteraRepository = carteraRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Historial>> ListAsync()
        {
            return await _historialRepository.ListAsync();
        }

        public async Task<IEnumerable<Historial>> ListByCarteraIdAsync(int cartera)
        {
            return await _historialRepository.FindByCarteraId(cartera);
        }

        public async Task<HistorialResponse> SaveAsync(Historial historial)
        {
            // VALIDATE CARTERAID
            
            var existingCartera = _carteraRepository.FindByIdAsync(historial.CarteraId);

            if (existingCartera == null)
                return new HistorialResponse("Invalid Cartera.");

            try
            {
                await _historialRepository.AddAsync(historial);
                await _unitOfWork.CompleteAsync();

                return new HistorialResponse(historial);
            }
            catch (Exception e)
            {
                return new HistorialResponse($"An error occurred while saving the historial: {e.Message}");
            }
        }

        public async Task<HistorialResponse> UpdateAsync(int id, Historial historial)
        {
            // VALIDATE HISTORIALID
            
            var existingHistorial = await _historialRepository.FindByIdAsync(id);

            if (existingHistorial == null)
                return new HistorialResponse("Historial not found.");
            
            // VALIDATE CARTERAID
            
            var existingCartera = _carteraRepository.FindByIdAsync(historial.CarteraId);

            if (existingCartera == null)
                return new HistorialResponse("Invalid Cartera.");
            
            
            existingHistorial.CarteraId = historial.CarteraId;
            

            try
            {
                _historialRepository.Update(existingHistorial);
                await _unitOfWork.CompleteAsync();
                
                return new HistorialResponse(existingHistorial);
            }
            catch (Exception e)
            {
                return new HistorialResponse($"An error occurred while updating the historial: {e.Message}");

            }
        }

        public async Task<HistorialResponse> DeleteAsync(int id)
        {
            // VALIDATE HISTORIALID
            
            var existingHistorial = await _historialRepository.FindByIdAsync(id);

            if (existingHistorial == null)
                return new HistorialResponse("Historial not found.");

            try
            {
                _historialRepository.Remove(existingHistorial);
                await _unitOfWork.CompleteAsync();
                
                return new HistorialResponse(existingHistorial);
            }
            catch (Exception e)
            {
                return new HistorialResponse($"An error occurred while deleting the historial: {e.Message}");

            }
        }
    }
}