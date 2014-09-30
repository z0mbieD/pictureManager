using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;

namespace PictureManager
{
    public class CommentAppService : ApplicationService, ICommentAppService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentAppService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public GetCommentsOutput GetComments(GetCommentsInput input)
        {
            var comments = _commentRepository.GetAllComments(input.PictureId, input.UserId);

            return new GetCommentsOutput
            {
                Comments = Mapper.Map<List<CommentDto>>(comments)
            };
        }

        public void AddComment(AddCommentInput input)
        {
            if (input != null)
            {
                var comment = new Comment
                {
                    Text = input.Text
                };

                if (input.UserId.HasValue)
                {
                    var user = new User
                    {
                        Id = input.UserId.Value
                    };

                    comment.AssignedUser = user;
                } 

                if (input.PictureId.HasValue)
                {
                    var picture = new Picture
                    {
                        Id = input.PictureId.Value
                    };

                    comment.AssignedPicture = picture;
                }

                _commentRepository.Insert(comment);
            }
        }
    }
}
