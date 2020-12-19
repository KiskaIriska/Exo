using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IAuthor
    {
        List<AuthorViewModel> Read(AuthorBindingModel model);
        void CreateOrUpdate(AuthorBindingModel model);
        void Delete(AuthorBindingModel model);
    }
}
