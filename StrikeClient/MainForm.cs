#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using BrightIdeasSoftware;
using StrikeNET;
using StrikeNET.V2;

#endregion

namespace StrikeClient
{
    public partial class MainForm : Form
    {
        private class SearchQuery
        {
            public Category Category { get; private set; }
            public Subcategory Subcategory { get; private set; }

            public SearchQuery(Category category, Subcategory subcategory)
            {
                Category = category;
                Subcategory = subcategory;
            }
        }

        private readonly StrikeApi _strike;

        public MainForm()
        {
            InitializeComponent();

            _strike = new StrikeApi();

            cbCategories.ValueMember = null;
            cbCategories.DisplayMember = "Name";
            var cats = new List<Category>(Category.GetCategories());
            cats.Sort();
            cats.Insert(0, new Category("All Categories"));
            cbCategories.DataSource = new BindingList<Category>(cats);

            cbSubcategories.ValueMember = null;
            cbSubcategories.DisplayMember = "Name";
            var subCats = new List<Subcategory>(Subcategory.GetSubcategories());
            subCats.Sort();
            subCats.Insert(0, new Subcategory("All Subcategories"));
            cbSubcategories.DataSource = new BindingList<Subcategory>(subCats);

            olvColSize.AspectGetter = x => ((TorrentSearchResult) x).Size/1024;
            olvColDownloads.AspectGetter = x => ((TorrentSearchResult) x).DownloadCount;
            olvColUploadDate.AspectGetter = x => ((TorrentSearchResult) x).UploadDate;
            olvColSubcategory.AspectGetter = x => ((TorrentSearchResult) x).SubCategory;

            var textOverlay = lvResults.EmptyListMsgOverlay as TextOverlay;
            textOverlay.BorderWidth = 4.0f;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                var cat = cbCategories.SelectedIndex == 0 ? null : new Category(cbCategories.Text);
                var subCat = cbSubcategories.SelectedIndex == 0 ? null : new Subcategory(cbSubcategories.Text);

                var query = new SearchQuery(cat, subCat);

                if (!SearchBackgroundWorker.IsBusy)
                    SearchBackgroundWorker.RunWorkerAsync(query);
            }
        }

        private void lvResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var result = (TorrentSearchResult) lvResults.SelectedObject;
            Process.Start(result.Page.ToString());
        }

        private void copyMagnetLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = (TorrentSearchResult) lvResults.SelectedObject;
            Clipboard.SetText(result.MagnetUri.ToString());
        }

        private void SearchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var query = (SearchQuery) e.Argument;
            var results = _strike.Search(textBox1.Text, query.Category, query.Subcategory);
            e.Result = results;
        }

        private void SearchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                lvResults.SetObjects((TorrentSearchResult[]) e.Result);
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            if (SearchBackgroundWorker.IsBusy)
                SearchBackgroundWorker.CancelAsync();

            Application.Exit();
        }

        private void lvResults_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            e.MenuStrip = contextMenuStrip1;
        }
    }
}