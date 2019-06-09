using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.Service
{
    public class ReviewService : IService<ReviewDTO>
    {
        IUnitOfWork Database { get; set; }

        public ReviewService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<ReviewDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDTO>>(Database.Reviews.GetAll());
        }

        public void Create(ReviewDTO model)
        {
            Review review = new Review
            {
                Comment = model.Comment,
                UserId = model.UserId
            };

            Database.Reviews.Create(review);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Reviews.Delete(id);
            Database.Save();
        }

        public void Update(ReviewDTO model)
        {
            Review review = new Review
            {
                Id = model.Id,
                Comment = model.Comment,
                UserId = model.UserId
            };

            Database.Reviews.Update(review);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ReviewDTO> Find(Func<ReviewDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(ReviewDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewDTO> GetByUserId(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review,ReviewDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDTO>>(Database.Reviews.GetByUserId(userId));
        }

        public ReviewDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public ReviewDTO CheckToExistUserEmail(ReviewDTO model)
        {
            throw new NotImplementedException();
        }

        public ReviewDTO CheckToExistUserEmailAndPassword(ReviewDTO model)
        {
            throw new NotImplementedException();
        }

        public ReviewDTO GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
