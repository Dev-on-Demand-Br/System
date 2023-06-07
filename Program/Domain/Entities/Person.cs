using Domain.Validations;

namespace Domain.Entities;
public sealed class Person {

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }

    public ICollection<Purchase> Purchases { get; set; }

    public Person(string name, string document, string phone) {
        Validation(name, document, phone);
    }

    public Person(int id, string name, string document, string phone) {
        DomainValidationException.When(id < 0, "Id inválido.");
        Id = id;
        Validation(name, document, phone);
    }

    private void Validation(string name, string document, string phone) {

        DomainValidationException.When(string.IsNullOrEmpty(name), "Campo obrigatório.");
        DomainValidationException.When(string.IsNullOrEmpty(document), "Campo obrigatório.");
        DomainValidationException.When(string.IsNullOrEmpty(phone), "Campo obrigatório.");

        Name = name;
        Document = document;
        Phone = phone;
    }
}
