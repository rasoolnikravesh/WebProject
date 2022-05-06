using Data.IRepositories;
using Data.Repositores;
using Data.Repositories;
using Data.Tools;

namespace Data
{
    public class UnitofWork : Base.UnitOfWork, IUnitOfWork
    {
        public UnitofWork(Options options) : base(options)
        {
        }

        private IPostRepository? _postRepository;

        public IPostRepository PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository =
                        new PostRepository(DatabaseContext);
                }

                return _postRepository;
            }
        }

        private ICategoryRepository? _categoryRepository;

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(DatabaseContext);
                }
                return _categoryRepository;
            }
        }
        private IPermissionRepository? _permissionRepository;

        public IPermissionRepository PermissionRepository
        {
            get
            {
                if (_permissionRepository == null)
                {
                    _permissionRepository = new PermissionRepository(DatabaseContext);
                }
                return _permissionRepository;
            }
        }
    }
}
