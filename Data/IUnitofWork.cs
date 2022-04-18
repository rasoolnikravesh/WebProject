namespace Data;

public interface IUnitOfWork : Base.IUnitOfWork
{
    //// **********
    IPostRepository PostRepository { get; }
    //// **********

    //// **********
    //IApplicationRepository ApplicationRepository { get; }
    // **********
}

