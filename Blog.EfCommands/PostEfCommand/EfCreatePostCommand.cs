using Blog.Application.Commands.PostCommand;
using Blog.Application.DTO.Post;
using Blog.Domen;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfCommands.PostEfCommand
{
    public class EfCreatePostCommand : BaseEfCommand ,ICreatePostCommand
    {
        public EfCreatePostCommand(BlogContext context) : base(context)
        {
        }
        public void Execute(CreatePostDto request)
        {
            var post = new Post
            {

                Title = request.Title,
                SubTitle = request.SubTitle,
                Description = request.Description,
                IsDeleted = false,
                UserId = request.UserId,
                PictureId = request.PictureId
               
            };
            var id = post.Id;

            foreach (var ids in request.HasTagIds)
            {
                var vezna = new PostHashtag
                {
                    PostId = id,
                    HashtagId = ids
                };
            }
            Context.Posts.Add(post);
           

            Context.SaveChanges();
        }
    }
}
