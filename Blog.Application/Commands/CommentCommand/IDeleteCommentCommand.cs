using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.CommentCommand
{
    public interface IDeleteCommentCommand : ICommand<int>
    {
    }
}
