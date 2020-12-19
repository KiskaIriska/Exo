using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IArticle
    {
        List<ArticleViewModel> Read(ArticleBindingModel model);
        void CreateOrUpdate(ArticleBindingModel model);
        void Delete(ArticleBindingModel model);
    }
}
