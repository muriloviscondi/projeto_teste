namespace Projeto.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
