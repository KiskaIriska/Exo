﻿using Database.Models;
using Logic.BindingModel;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Implement
{
    public class AuthorLogic : IAuthor
    {
        public void CreateOrUpdate(AuthorBindingModel model)
        {
            using (var context = new Database())
            {
                Author element = context.Authors.FirstOrDefault(rec => rec.AuthorName == model.AuthorName && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть автор с таким именем");
                }
                if (model.Id.HasValue)
                {
                    element = context.Authors.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Author();
                    context.Authors.Add(element);
                }
                element.AuthorName = model.AuthorName;
                element.Birthday = model.Birthday;
                element.Email = model.Email;
                element.Place = model.Place;
                element.ArticleId = model.ArticleId;
                context.SaveChanges();
            }
        }
        public void Delete(AuthorBindingModel model)
        {
            using (var context = new Database())
            {
                Author element = context.Authors.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Authors.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<AuthorViewModel> Read(AuthorBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Authors
                .Where(rec => model == null || rec.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Article.DateCreate >= model.DateFrom && rec.Article.DateCreate <= model.DateTo))
                .Select(rec => new AuthorViewModel
                {
                    Id = rec.Id,
                    ArticleId = rec.ArticleId,
                    AuthorName = rec.AuthorName,
                    Email = rec.Email,
                    Birthday = rec.Birthday,
                    Place = rec.Place,
                    Name = rec.Article.Name,
                    DateCreate = rec.Article.DateCreate
                })
                .ToList();
            }
        }
    }
}
