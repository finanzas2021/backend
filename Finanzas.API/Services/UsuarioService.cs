using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Respositories;
using Finanzas.API.Domain.Services;
using Finanzas.API.Domain.Services.Communication;

namespace Finanzas.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _usuarioRepository.ListAsync();
        }

        public async Task<UsuarioResponse> SaveAsync(Usuario usuario)
        {
            // VALIDATE NAME

            var existingUsuarioWithName = await _usuarioRepository.FindByNameAsync(usuario.Name);

            if (existingUsuarioWithName != null)
                return new UsuarioResponse("Usuario Name already exists.");

            try
            {
                await _usuarioRepository.AddAsync(usuario);
                await _unitOfWork.CompleteAsync();

                return new UsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred while saving the usuario: {e.Message}");
            }
        }

        public async Task<UsuarioResponse> UpdateAsync(int id, Usuario usuario)
        {
            // VALIDATE USUARIOID
            
            var existingUsuario = await _usuarioRepository.FindByIdAsync(id);

            if (existingUsuario == null)
                return new UsuarioResponse("Usuario not found.");
            
            // VALIDATE NAME

            var existingUsuarioWithName = await _usuarioRepository.FindByNameAsync(usuario.Name);

            if (existingUsuarioWithName != null)
                return new UsuarioResponse("Usuario Name already exists.");

            existingUsuario.Name = usuario.Name;
            existingUsuario.Username = usuario.Username;
            existingUsuario.Password = usuario.Password;
            existingUsuario.Email = usuario.Email;
            
            try
            {
                _usuarioRepository.Update(existingUsuario);
                await _unitOfWork.CompleteAsync();
                
                return new UsuarioResponse(existingUsuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred while updating the usuario: {e.Message}");

            }
        }

        public async Task<UsuarioResponse> DeleteAsync(int id)
        {
            // VALIDATE USUARIOID
            
            var existingUsuario = await _usuarioRepository.FindByIdAsync(id);

            if (existingUsuario == null)
                return new UsuarioResponse("Usuario not found.");
            
            try
            {
                _usuarioRepository.Update(existingUsuario);
                await _unitOfWork.CompleteAsync();
                
                return new UsuarioResponse(existingUsuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred while deleting the usuario: {e.Message}");

            }
            
        }
    }
}