using Logic.BindingModel;
using Logic.HelperInfo;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BuisnessLogic
{
    public class ReportLogic
    {
        private readonly IArticle Article;
        private readonly IAuthor Author;
        public ReportLogic(IArticle Article, IAuthor Author)
        {
            this.Article = Article;
            this.Author = Author;
        }
        public List<AuthorViewModel> GetAuthors(ReportBindingModel model)
        {
            var Authors = Author.Read(new AuthorBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var list = new List<AuthorViewModel>();
            foreach (var rec in Authors)
            {
                var record = new AuthorViewModel
                {
                    AuthorName = rec.AuthorName,
                    Name = rec.Name,
                    Birthday = rec.Birthday,
                    Place = rec.Place,
                    DateCreate = rec.DateCreate
                };
                list.Add(record);
            }
            return list;
        }
        public async void SaveAuthorsToPdfFile(ReportBindingModel model)
        {
            //названия
            string title = "Статья и ее авторы";

            await Task.Run(() =>
            {
                SaveToPdf.CreateDoc(new PdfInfo
                {
                    FileName = model.FileName,
                    Title = title,
                    Authors = GetAuthors(model),
                });
            });
        }
    }
}
