using DATN.Data;
using DATN.Data.Viewmodel.CommentViewModel;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface ICommentService
    {
        public Task<Response> GetAll();

        public Task<Response> Add(CommentAddVM comment);

        public Task<Response> Update(CommentUpdateVM comment);

        public Task<Response> Delete(int Id);
    }
}