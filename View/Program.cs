using Database.Implement;
using Logic.BuisnessLogic;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormArticles>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IAuthor, AuthorLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IArticle, ArticleLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
