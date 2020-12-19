﻿using Logic.BindingModel;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormArticle : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IArticle Article;

        private int? id;

        public FormArticle(IArticle Article)
        {
            InitializeComponent();
            this.Article = Article;
        }

        private void FormArticle_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = Article.Read(new ArticleBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Name;
                        textBoxSubject.Text = view.Type;
                        dateTimePicker1.Value = view.DateCreate;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSubject.Text))
            {
                //nas
                MessageBox.Show("Заполните тематику", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Article.CreateOrUpdate(new ArticleBindingModel
                {
                    Id = id,
                    Name = textBoxTitle.Text,
                    Type = textBoxSubject.Text,
                    DateCreate = dateTimePicker1.Value
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
