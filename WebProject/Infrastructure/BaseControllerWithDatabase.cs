namespace Infrastructure;

public class BaseControllerWithDatabase : BaseController
{
    public BaseControllerWithDatabase(Data.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Data.IUnitOfWork UnitOfWork { get; }
}

