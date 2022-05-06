using Data.IRepositories;

namespace Data;

public interface IUnitOfWork : Base.IUnitOfWork
{
    //// **********
    IPostRepository PostRepository { get; }
    //// **********

    // **********
    ICategoryRepository CategoryRepository { get; }
    // **********

    // **********
    IPermissionRepository PermissionRepository { get; }
    // **********

}

