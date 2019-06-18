using Blog.Application.DTO.Comment;
using Blog.Application.Interfaces;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.CommentCommand
{
    public interface IGetCommentCommandUnpagge : ICommand<CommentSearch, IEnumerable<CommentDto>>
    {
    }
}
