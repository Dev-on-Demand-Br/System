using Domain.Validations;
using System.Diagnostics;
using System.Xml.Linq;

namespace Domain.Entities;
public class Purchase {
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int PersonId { get; private set; }
    public DateTime Date { get; private set; }

    public Person Person { get; set; }
    public Product Product { get; set; }


    public Purchase(int productId, int personId, DateTime? date) {
        Validation(productId, personId, date);
    }


    public Purchase(int id, int productId, int personId, DateTime? date) {
        DomainValidationException.When(id < 0, "Id inválido.");
        Id = id;
        Validation(productId, personId, date);
    }


    private void Validation(int productId, int personId, DateTime? date) {
        DomainValidationException.When(productId < 0, "Campo obrigatório.");
        DomainValidationException.When(personId < 0, "Campo obrigatório.");
        DomainValidationException.When(!date.HasValue, "Campo obrigatório.");

        ProductId = productId;
        PersonId = personId;
        Date = date.Value;
    }
}
