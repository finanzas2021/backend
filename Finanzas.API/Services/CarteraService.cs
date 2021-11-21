using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Respositories;
using Finanzas.API.Domain.Services;
using Finanzas.API.Domain.Services.Communication;

namespace Finanzas.API.Services
{
    public class CarteraService : ICarteraService
    {
        private readonly ICarteraRepository _carteraRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CarteraService(ICarteraRepository carteraRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _carteraRepository = carteraRepository;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cartera>> ListAsync()
        {
            return await _carteraRepository.ListAsync();
        }

        public async Task<IEnumerable<Cartera>> ListByUsuarioIdAsync(int usuario)
        {
            return await _carteraRepository.FindByUsuarioId(usuario);
        }

        public async Task<CarteraResponse> SaveAsync(Cartera cartera)
        {
            // VALIDATE USUARIOID
            
            var existingUsuario = _usuarioRepository.FindByIdAsync(cartera.UsuarioId);

            if (existingUsuario == null)
                return new CarteraResponse("Invalid Usuario.");

            try
            {
                await _carteraRepository.AddAsync(cartera);
                await _unitOfWork.CompleteAsync();

                return new CarteraResponse(cartera);
            }
            catch (Exception e)
            {
                return new CarteraResponse($"An error occurred while saving the cartera: {e.Message}");
            }
        }

        public async Task<CarteraResponse> UpdateAsync(int id, Cartera cartera)
        {
            // VALIDATE CARTERAID
            
            var existingCartera = await _carteraRepository.FindByIdAsync(id);

            if (existingCartera == null)
                return new CarteraResponse("Cartera not found.");
            
            // VALIDATE USUARIOID
            
            var existingUsuario = _usuarioRepository.FindByIdAsync(cartera.UsuarioId);

            if (existingUsuario == null)
                return new CarteraResponse("Invalid Usuario.");
            

            existingCartera.Monto = cartera.Monto;
            existingCartera.UsuarioId = cartera.UsuarioId;
            

            try
            {
                _carteraRepository.Update(existingCartera);
                await _unitOfWork.CompleteAsync();
                
                return new CarteraResponse(existingCartera);
            }
            catch (Exception e)
            {
                return new CarteraResponse($"An error occurred while updating the cartera: {e.Message}");

            }
        }

        public async Task<CarteraResponse> DeleteAsync(int id)
        {
            // VALIDATE CARTERAID
            
            var existingCartera = await _carteraRepository.FindByIdAsync(id);

            if (existingCartera == null)
                return new CarteraResponse("Cartera not found.");

            try
            {
                _carteraRepository.Remove(existingCartera);
                await _unitOfWork.CompleteAsync();
                
                return new CarteraResponse(existingCartera);
            }
            catch (Exception e)
            {
                return new CarteraResponse($"An error occurred while deleting the cartera: {e.Message}");

            }
        }
    }
}