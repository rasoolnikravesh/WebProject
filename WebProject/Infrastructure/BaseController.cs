namespace Infrastructure;

public class BaseController : Microsoft.AspNetCore.Mvc.Controller
{
	public BaseController(Data.IUnitOfWork unitOfWork) : base()
	{
		UnitOfWork = unitOfWork;
	}

	protected Data.IUnitOfWork UnitOfWork { get; }
}

