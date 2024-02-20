using Core.Helpers.Result.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITagService
    {
        IResult Add(Tag tag);
        IResult Update(Tag tag);
        IResult Delete(Tag tag);
        IDataResult<List<Tag>> GetAll();
        IDataResult<Tag> GetById(int id);
    }
}
