using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.PostCommand;
using Blog.Application.DTO.Post;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;

namespace Blog.EfCommands.PostEfCommand
{
    public class EfGetOnePostCommand : BaseEfCommand, IGetOnePostCommand
    {
        public EfGetOnePostCommand(BlogContext context) : base(context)
        {
        }
        public PostDto Execute(int request)
        {
            var post = Context.Posts.Find(request);

            if(post == null)
            {
                throw new EntityNotFoundException("Post");
            }

            return Context.Posts.Select( p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                SubTitle = p.SubTitle,
                Description = p.Description,
                Username = p.User.Username,
                HashtagItems = p.PostHashtags.Select( h => new HashtagItems
                {
                    Name = h.Hashtag.Name
                }).ToList(),
                CommentItems = p.Comments.Select(c => new CommentItems
                {
                    Description = c.Description
                }).ToList(),
                PictureItems = p.Picture.Src
            }).Where(p => p.Id == request).First();
        }
    }
}
