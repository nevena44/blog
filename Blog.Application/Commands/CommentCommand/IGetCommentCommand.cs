using Blog.Application.DTO.Comment;
using Blog.Application.Interfaces;
using Blog.Application.PageResponses;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.CommentCommand
{
    public interface IGetCommentCommand : ICommand<CommentSearch,PageResponse<CommentDto>>
    {
    }
}
