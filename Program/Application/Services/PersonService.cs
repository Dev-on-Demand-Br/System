using Application.DTOs;
using Application.DTOs.Validations;
using Application.Service;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;
public class PersonService : IPersonService {

    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper) {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO) {

        if (personDTO is null)
            return ResultService.Fail<PersonDTO>("Campo obrigatório.");

        var result = new PersonDTOValidator().Validate(personDTO);

        if (!result.IsValid)
            return ResultService.RequestError<PersonDTO>("Erro de Validação.", result);

        var person = _mapper.Map<Person>(personDTO);

        var data = await _personRepository.CreateAsync(person);

        return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
    }
}
