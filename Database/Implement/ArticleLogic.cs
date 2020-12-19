using Database.Models;
using Logic.BindingModel;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Implement
{
    public class ArticleLogic : IArticle
    {
        public void CreateOrUpdate(ArticleBindingModel model)
        {
            using (var context = new Database())
            {
                Article element = context.Articles.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть статья с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Articles.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Article();
                    context.Articles.Add(element);
                }
                element.Name = model.Name;
                element.Type = model.Type;
                element.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void Delete(ArticleBindingModel model)
        {
            using (var context = new Database())
            {
                Article element = context.Articles.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Articles.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<ArticleViewModel> Read(ArticleBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Articles
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new ArticleViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Type = rec.Type,
                    DateCreate = rec.DateCreate
                })
                .ToList();
            }
        }
    }
}
