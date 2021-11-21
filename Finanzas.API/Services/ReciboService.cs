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
    public class ReciboService : IReciboService
    {
        private readonly IReciboRepository _reciboRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReciboService(IReciboRepository reciboRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _reciboRepository = reciboRepository;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Recibo>> ListAsync()
        {
            return await _reciboRepository.ListAsync();
        }

        public async Task<IEnumerable<Recibo>> ListByUsuarioIdAsync(int usuario)
        {
            return await _reciboRepository.FindByUsuarioId(usuario);
        }

        public async Task<ReciboResponse> SaveAsync(Recibo recibo)
        {
            // VALIDATE USUARIOID
            
            var existingUsuario = _usuarioRepository.FindByIdAsync(recibo.UsuarioId);

            if (existingUsuario == null)
                return new ReciboResponse("Invalid Usuario.");

            try
            {
                await _reciboRepository.AddAsync(recibo);
                await _unitOfWork.CompleteAsync();

                return new ReciboResponse(recibo);
            }
            catch (Exception e)
            {
                return new ReciboResponse($"An error occurred while saving the recibo: {e.Message}");
            }
        }

        public async Task<ReciboResponse> UpdateAsync(int id, Recibo recibo)
        {
            // VALIDATE RECIBOID
            
            var existingRecibo = await _reciboRepository.FindByIdAsync(id);

            if (existingRecibo == null)
                return new ReciboResponse("Recibo not found.");
            
            // VALIDATE USUARIOID
            
            var existingUsuario = _usuarioRepository.FindByIdAsync(recibo.UsuarioId);

            if (existingUsuario == null)
                return new ReciboResponse("Invalid Usuario.");
            
            
            //INICIALES
            existingRecibo.UsuarioId = recibo.UsuarioId;
            existingRecibo.F_Emision = recibo.F_Emision;
            existingRecibo.F_Pago = recibo.F_Pago;
            existingRecibo.Moneda = recibo.Moneda;
            existingRecibo.Monto = recibo.Monto;
            existingRecibo.T_Tasa = recibo.T_Tasa;
            existingRecibo.Tasa = recibo.Tasa;
            existingRecibo.Plazo_Tasa = recibo.Plazo_Tasa;
            //INTERMEDIOS
            existingRecibo.G_Iniciales = recibo.G_Iniciales;
            existingRecibo.G_Finales = recibo.G_Finales;
            //FINALES
            existingRecibo.Monto_Cobrar = recibo.Monto_Cobrar;
            existingRecibo.V_Entregado = recibo.V_Entregado;
            existingRecibo.TCEA = recibo.TCEA;
            existingRecibo.N_Dias = recibo.N_Dias;
            existingRecibo.T_Descontada = recibo.T_Descontada;
            existingRecibo.V_Neto = recibo.V_Neto;
            existingRecibo.Descuento = recibo.Descuento;
            

            try
            {
                _reciboRepository.Update(existingRecibo);
                await _unitOfWork.CompleteAsync();
                
                return new ReciboResponse(existingRecibo);
            }
            catch (Exception e)
            {
                return new ReciboResponse($"An error occurred while updating the recibo: {e.Message}");

            }
        }

        public async Task<ReciboResponse> DeleteAsync(int id)
        {
            // VALIDATE RECIBOID
            
            var existingRecibo = await _reciboRepository.FindByIdAsync(id);

            if (existingRecibo == null)
                return new ReciboResponse("Recibo not found.");

            try
            {
                _reciboRepository.Remove(existingRecibo);
                await _unitOfWork.CompleteAsync();
                
                return new ReciboResponse(existingRecibo);
            }
            catch (Exception e)
            {
                return new ReciboResponse($"An error occurred while deleting the recibo: {e.Message}");

            }
        }
    }
}