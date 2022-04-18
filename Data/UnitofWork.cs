using Data.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
