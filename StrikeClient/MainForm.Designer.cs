namespace StrikeClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvResults = new BrightIdeasSoftware.ObjectListView();
            this.olvColTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColSeeds = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColLeeches = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColUploadDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDownloads = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCategory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColSubcategory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.cbSubcategories = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMagnetLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.lvResults)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search:";
            // 
            // lvResults
            // 
            this.lvResults.AllColumns.Add(this.olvColTitle);
            this.lvResults.AllColumns.Add(this.olvColSize);
            this.lvResults.AllColumns.Add(this.olvColSeeds);
            this.lvResults.AllColumns.Add(this.olvColLeeches);
            this.lvResults.AllColumns.Add(this.olvColUploadDate);
            this.lvResults.AllColumns.Add(this.olvColDownloads);
            this.lvResults.AllColumns.Add(this.olvColCategory);
            this.lvResults.AllColumns.Add(this.olvColSubcategory);
            this.lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColTitle,
            this.olvColSize,
            this.olvColSeeds,
            this.olvColLeeches,
            this.olvColUploadDate,
            this.olvColDownloads,
            this.olvColCategory,
            this.olvColSubcategory});
            this.lvResults.FullRowSelect = true;
            this.lvResults.Location = new System.Drawing.Point(12, 33);
            this.lvResults.Name = "lvResults";
            this.lvResults.ShowGroups = false;
            this.lvResults.Size = new System.Drawing.Size(965, 413);
            this.lvResults.TabIndex = 3;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            this.lvResults.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.lvResults_CellRightClick);
            this.lvResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvResults_MouseDoubleClick);
            // 
            // olvColTitle
            // 
            this.olvColTitle.AspectName = "TorrentTitle";
            this.olvColTitle.Text = "Title";
            this.olvColTitle.Width = 290;
            // 
            // olvColSize
            // 
            this.olvColSize.AspectName = "Size";
            this.olvColSize.Text = "Size (kb)";
            this.olvColSize.Width = 91;
            // 
            // olvColSeeds
            // 
            this.olvColSeeds.AspectName = "Seeds";
            this.olvColSeeds.Text = "Seeds";
            // 
            // olvColLeeches
            // 
            this.olvColLeeches.AspectName = "Leeches";
            this.olvColLeeches.Text = "Leeches";
            // 
            // olvColUploadDate
            // 
            this.olvColUploadDate.AspectToStringFormat = "{0:d}";
            this.olvColUploadDate.Text = "Upload Date";
            this.olvColUploadDate.Width = 126;
            // 
            // olvColDownloads
            // 
            this.olvColDownloads.AspectName = "";
            this.olvColDownloads.Text = "Downloads";
            this.olvColDownloads.Width = 75;
            // 
            // olvColCategory
            // 
            this.olvColCategory.AspectName = "TorrentCategory";
            this.olvColCategory.Text = "Category";
            this.olvColCategory.Width = 130;
            // 
            // olvColSubcategory
            // 
            this.olvColSubcategory.AspectName = "Subcategory";
            this.olvColSubcategory.Text = "Subcategory";
            this.olvColSubcategory.Width = 130;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemExit});
            this.menuItem1.Text = "&File";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 0;
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // cbCategories
            // 
            this.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(375, 6);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(121, 21);
            this.cbCategories.TabIndex = 4;
            // 
            // cbSubcategories
            // 
            this.cbSubcategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubcategories.FormattingEnabled = true;
            this.cbSubcategories.Location = new System.Drawing.Point(502, 6);
            this.cbSubcategories.Name = "cbSubcategories";
            this.cbSubcategories.Size = new System.Drawing.Size(121, 21);
            this.cbSubcategories.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(629, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMagnetLinkToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 26);
            // 
            // copyMagnetLinkToolStripMenuItem
            // 
            this.copyMagnetLinkToolStripMenuItem.Name = "copyMagnetLinkToolStripMenuItem";
            this.copyMagnetLinkToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyMagnetLinkToolStripMenuItem.Text = "Copy Magnet Link";
            this.copyMagnetLinkToolStripMenuItem.Click += new System.EventHandler(this.copyMagnetLinkToolStripMenuItem_Click);
            // 
            // SearchBackgroundWorker
            // 
            this.SearchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SearchBackgroundWorker_DoWork);
            this.SearchBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SearchBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 458);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbSubcategories);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.lvResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Strike Demo Client";
            ((System.ComponentModel.ISupportInitialize)(this.lvResults)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView lvResults;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.ComboBox cbSubcategories;
        private System.Windows.Forms.Button btnSearch;
        private BrightIdeasSoftware.OLVColumn olvColTitle;
        private BrightIdeasSoftware.OLVColumn olvColSize;
        private BrightIdeasSoftware.OLVColumn olvColSeeds;
        private BrightIdeasSoftware.OLVColumn olvColLeeches;
        private BrightIdeasSoftware.OLVColumn olvColCategory;
        private BrightIdeasSoftware.OLVColumn olvColDownloads;
        private BrightIdeasSoftware.OLVColumn olvColUploadDate;
        private BrightIdeasSoftware.OLVColumn olvColSubcategory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyMagnetLinkToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker SearchBackgroundWorker;
    }
}

