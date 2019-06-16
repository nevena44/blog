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
            var post = new Domen.Post
            {

                Title = request.Title,
                SubTitle = request.SubTitle,
                Description = request.Description,
                IsDeleted = false,
                UserId = request.UserId

            };

            foreach(var id in request.HasTagIds)
            {
                var vezna = new PostHashtag
                {
                    Post = post,
                    HashtagId = id
                };
            }
            Context.Posts.Add(post);

            Context.SaveChanges();
        }
    }
}
