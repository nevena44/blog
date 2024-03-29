﻿using Blog.Application.DTO.Post;
using Blog.Application.Interfaces;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.PostCommand
{
    public interface IGetPostCommandUnPagginate : ICommand<PostSearch,IEnumerable<PostDto>>
    {
    }
}
