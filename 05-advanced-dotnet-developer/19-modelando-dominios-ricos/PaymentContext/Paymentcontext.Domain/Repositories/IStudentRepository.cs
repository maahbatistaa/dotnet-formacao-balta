using Paymentcontext.Domain.Entities;

namespace Paymentcontext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
    }
}