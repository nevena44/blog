using Blog.Application.DTO.Comment;
using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.CommentCommand
{
    public interface ICreateCommentCommand : ICommand<DtoComment>
    {
    }
}
