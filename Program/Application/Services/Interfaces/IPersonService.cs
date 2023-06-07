using Application.DTOs;
using Application.Service;

namespace Application.Services.Interfaces;
public interface IPersonService {
    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
}
