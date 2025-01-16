namespace poc.dapper.api.Repository.UnitOfWork;

public interface IUnitOfWork
{
    ICustomerRepository Customers { get; }
    int Commit();
}