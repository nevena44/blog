using Blog.Application.Commands.PostCommand;
using Blog.Application.DTO.Post;
using Blog.Application.Exceptions;
using Blog.Domen;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.EfCommands.PostEfCommand
{
    public class EfEditPostCommand : BaseEfCommand, IEditPostCommand
    {
        public EfEditPostCommand(BlogContext context) : base(context)
        {
        }
        public void Execute(CreatePostDto request)
        {
            var post = Context.Posts.Find(request.Id);

            if (post == null)
            {
                throw new EntityNotFoundException("Post");
            }

            if (!Context.Users.Any(u => u.Id == request.UserId))
            {
                throw new EntityNotFoundException("User");
            }

            if (post.IsDeleted == true)
            {
                throw new EntityNotFoundException("Post");
            }


            post.Title = request.Title;
            post.SubTitle = request.SubTitle;
            post.Description = request.Description;
            post.IsDeleted = false;
            post.ModifiedAt = DateTime.Now;
            post.UserId = request.UserId;

            foreach (var id in request.HasTagIds)
            {
                var vezna = new PostHashtag
                {
                    Post = post,
                    HashtagId = id
                };
            }

            Context.SaveChanges();
            
        }
    }
}
