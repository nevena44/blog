using Blog.Application.Commands.PostCommand;
using Blog.Application.DTO.Post;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.EfCommands.PostEfCommand
{
    public class EfGetPostCommand : BaseEfCommand, IGetPostCommand
    {
        public EfGetPostCommand(BlogContext context) : base(context)
        {
        }

        public IEnumerable<PostDto> Execute(PostSearch request)
        {
            var posts = Context.Posts
                .Include(p => p.PostHashtags)
                .Include(p => p.User).AsQueryable();

            if (request.StartDate.HasValue)
            {
                posts = posts.Where(p => p.CreatedAt >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                posts = posts.Where(p => p.CreatedAt <= request.EndDate.Value);
            }

            if (request.UserId != 0)
            {
                posts = posts.Where(p => p.UserId == request.UserId);
            }

            if (request.Title != null)
            {
                posts = posts.Where(p => p.Title.ToLower().Contains(request.Title.Trim().ToLower()));
            }

            if (request.SubTitle != null)
            {
                posts = posts.Where(p => p.SubTitle.ToLower().Contains(request.SubTitle.Trim().ToLower()));
            }

            return posts.Select(x => new PostDto {
                  Id = x.Id,
                  Title = x.Title,
                  SubTitle = x.SubTitle,
                  Description = x.Description,
                  Username = x.User.Username,
                  CommentItems = x.Comments.Select(c => new CommentItems {
                      Description = c.Description
                  }).ToList(),
                  PictureItems = x.Pictures.Select(p => new PictureItems {
                      Src = p.Src,
                      Alt = p.Alt 
                  }).ToList(),
                  HashtagItems = x.PostHashtags.Select(ph => new HashtagItems
                  {
                      Name = ph.Hashtag.Name
                  }).ToList()
            }).ToList();
        }
    }
}
