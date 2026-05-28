using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace GymManagement.Domain.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;

        private readonly ILogger<EnrollmentService> _logger;

        public EnrollmentService(
            IEnrollmentRepository repository,
            ILogger<EnrollmentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            _logger.LogInformation(
                "Consultando todas las inscripciones"
            );

            return await _repository.GetAllAsync();
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            _logger.LogInformation(
                "Consultando inscripción con ID {Id}",
                id
            );

            var enrollment = await _repository
                .GetByIdAsync(id);

            if (enrollment == null)
            {
                _logger.LogWarning(
                    "Inscripción con ID {Id} no encontrada",
                    id
                );
            }

            return enrollment;
        }

        public async Task<Enrollment> CreateAsync(
            Enrollment enrollment)
        {
            _logger.LogInformation(
                "Creando inscripción para MemberId {MemberId} en GymClassId {GymClassId}",
                enrollment.MemberId,
                enrollment.GymClassId
            );

            // VALIDACIONES
            if (enrollment.MemberId <= 0)
            {
                _logger.LogWarning(
                    "MemberId inválido"
                );

                throw new Exception(
                    "El MemberId es obligatorio"
                );
            }

            if (enrollment.GymClassId <= 0)
            {
                _logger.LogWarning(
                    "GymClassId inválido"
                );

                throw new Exception(
                    "El GymClassId es obligatorio"
                );
            }

            var created = await _repository
                .CreateAsync(enrollment);

            _logger.LogInformation(
                "Inscripción creada correctamente con ID {Id}",
                created.Id
            );

            var fullEnrollment =
                await _repository.GetByIdAsync(
                    created.Id
                );

            return fullEnrollment ?? created;
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation(
                "Eliminando inscripción con ID {Id}",
                id
            );

            var exists = await _repository
                .ExistsAsync(id);

            if (!exists)
            {
                _logger.LogWarning(
                    "Inscripción con ID {Id} no encontrada",
                    id
                );

                throw new KeyNotFoundException(
                    "Enrollment no encontrado"
                );
            }

            await _repository.DeleteAsync(id);

            _logger.LogInformation(
                "Inscripción con ID {Id} eliminada correctamente",
                id
            );
        }
    }
}