namespace SchoolworkOrganizer.Panels
{
    partial class ReviewerPanel
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
            panel4 = new Panel();
            refreshBtn = new Button();
            selectedFileLabel = new TextBox();
            openFileBtn = new Button();
            editFileBtn = new Button();
            fileLabel = new Label();
            editSubjectCBox = new ComboBox();
            subjectLabel = new Label();
            panel5 = new Panel();
            label3 = new Label();
            cancelBtn = new Button();
            deleteBtn = new Button();
            saveBtn = new Button();
            addBtn = new Button();
            reviewerTxtBox = new TextBox();
            reviewerLabel = new Label();
            panel8 = new Panel();
            panel2 = new Panel();
            table = new DataGridView();
            ReviewerName = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            FilePath = new DataGridViewButtonColumn();
            panel1 = new Panel();
            subjectCBox = new ComboBox();
            mainPanel.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(panel8);
            mainPanel.Controls.Add(panel4);
            mainPanel.Margin = new Padding(5, 3, 5, 3);
            // 
            // panel4
            // 
            panel4.Controls.Add(refreshBtn);
            panel4.Controls.Add(selectedFileLabel);
            panel4.Controls.Add(openFileBtn);
            panel4.Controls.Add(editFileBtn);
            panel4.Controls.Add(fileLabel);
            panel4.Controls.Add(editSubjectCBox);
            panel4.Controls.Add(subjectLabel);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(cancelBtn);
            panel4.Controls.Add(deleteBtn);
            panel4.Controls.Add(saveBtn);
            panel4.Controls.Add(addBtn);
            panel4.Controls.Add(reviewerTxtBox);
            panel4.Controls.Add(reviewerLabel);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(252, 626);
            panel4.TabIndex = 1;
            // 
            // refreshBtn
            // 
            refreshBtn.BackColor = Color.FromArgb(52, 63, 82);
            refreshBtn.FlatAppearance.BorderSize = 0;
            refreshBtn.FlatStyle = FlatStyle.Flat;
            refreshBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshBtn.ForeColor = Color.FromArgb(231, 231, 231);
            refreshBtn.Location = new Point(154, 444);
            refreshBtn.Margin = new Padding(4, 3, 4, 3);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(88, 27);
            refreshBtn.TabIndex = 15;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // selectedFileLabel
            // 
            selectedFileLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectedFileLabel.Location = new Point(107, 129);
            selectedFileLabel.Margin = new Padding(4, 3, 4, 3);
            selectedFileLabel.Multiline = true;
            selectedFileLabel.Name = "selectedFileLabel";
            selectedFileLabel.ReadOnly = true;
            selectedFileLabel.Size = new Size(134, 52);
            selectedFileLabel.TabIndex = 14;
            // 
            // openFileBtn
            // 
            openFileBtn.BackColor = Color.FromArgb(52, 63, 82);
            openFileBtn.FlatAppearance.BorderSize = 0;
            openFileBtn.FlatStyle = FlatStyle.Flat;
            openFileBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            openFileBtn.ForeColor = Color.FromArgb(231, 231, 231);
            openFileBtn.Location = new Point(107, 225);
            openFileBtn.Margin = new Padding(4, 3, 4, 3);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(134, 27);
            openFileBtn.TabIndex = 13;
            openFileBtn.Text = "Open File";
            openFileBtn.UseVisualStyleBackColor = false;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // editFileBtn
            // 
            editFileBtn.BackColor = Color.FromArgb(52, 63, 82);
            editFileBtn.FlatAppearance.BorderSize = 0;
            editFileBtn.FlatStyle = FlatStyle.Flat;
            editFileBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editFileBtn.ForeColor = Color.FromArgb(231, 231, 231);
            editFileBtn.Location = new Point(107, 192);
            editFileBtn.Margin = new Padding(4, 3, 4, 3);
            editFileBtn.Name = "editFileBtn";
            editFileBtn.Size = new Size(134, 27);
            editFileBtn.TabIndex = 11;
            editFileBtn.Text = "Edit File";
            editFileBtn.UseVisualStyleBackColor = false;
            editFileBtn.Click += editFileBtn_Click;
            // 
            // fileLabel
            // 
            fileLabel.AutoSize = true;
            fileLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileLabel.Location = new Point(77, 133);
            fileLabel.Margin = new Padding(4, 0, 4, 0);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(27, 15);
            fileLabel.TabIndex = 10;
            fileLabel.Text = "File:";
            // 
            // editSubjectCBox
            // 
            editSubjectCBox.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editSubjectCBox.FormattingEnabled = true;
            editSubjectCBox.Location = new Point(107, 99);
            editSubjectCBox.Margin = new Padding(4, 3, 4, 3);
            editSubjectCBox.Name = "editSubjectCBox";
            editSubjectCBox.Size = new Size(134, 23);
            editSubjectCBox.TabIndex = 9;
            // 
            // subjectLabel
            // 
            subjectLabel.AutoSize = true;
            subjectLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectLabel.Location = new Point(18, 103);
            subjectLabel.Margin = new Padding(4, 0, 4, 0);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(80, 15);
            subjectLabel.TabIndex = 8;
            subjectLabel.Text = "Subject Name:";
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(252, 62);
            panel5.TabIndex = 7;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Roboto", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(252, 62);
            label3.TabIndex = 6;
            label3.Text = "Reviewers";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.FromArgb(52, 63, 82);
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.FromArgb(231, 231, 231);
            cancelBtn.Location = new Point(154, 312);
            cancelBtn.Margin = new Padding(4, 3, 4, 3);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(88, 27);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.FromArgb(171, 37, 51);
            deleteBtn.Enabled = false;
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.FlatStyle = FlatStyle.Flat;
            deleteBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deleteBtn.ForeColor = Color.FromArgb(231, 231, 231);
            deleteBtn.Location = new Point(10, 312);
            deleteBtn.Margin = new Padding(4, 3, 4, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(88, 27);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.FromArgb(52, 63, 82);
            saveBtn.Enabled = false;
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.FromArgb(231, 231, 231);
            saveBtn.Location = new Point(154, 278);
            saveBtn.Margin = new Padding(4, 3, 4, 3);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(88, 27);
            saveBtn.TabIndex = 3;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(95, 192, 170);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.FromArgb(231, 231, 231);
            addBtn.Location = new Point(10, 277);
            addBtn.Margin = new Padding(4, 3, 4, 3);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(88, 27);
            addBtn.TabIndex = 2;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // reviewerTxtBox
            // 
            reviewerTxtBox.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reviewerTxtBox.Location = new Point(107, 69);
            reviewerTxtBox.Margin = new Padding(4, 3, 4, 3);
            reviewerTxtBox.Name = "reviewerTxtBox";
            reviewerTxtBox.Size = new Size(134, 22);
            reviewerTxtBox.TabIndex = 1;
            // 
            // reviewerLabel
            // 
            reviewerLabel.AutoSize = true;
            reviewerLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reviewerLabel.Location = new Point(7, 73);
            reviewerLabel.Margin = new Padding(4, 0, 4, 0);
            reviewerLabel.Name = "reviewerLabel";
            reviewerLabel.Size = new Size(87, 15);
            reviewerLabel.TabIndex = 0;
            reviewerLabel.Text = "Reviewer Name:";
            // 
            // panel8
            // 
            panel8.Controls.Add(panel2);
            panel8.Controls.Add(panel1);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(252, 0);
            panel8.Margin = new Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(837, 626);
            panel8.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.Controls.Add(table);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 43);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(12);
            panel2.Size = new Size(837, 583);
            panel2.TabIndex = 8;
            // 
            // table
            // 
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToResizeRows = false;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Columns.AddRange(new DataGridViewColumn[] { ReviewerName, Subject, FilePath });
            table.Dock = DockStyle.Fill;
            table.Location = new Point(12, 12);
            table.Margin = new Padding(4, 3, 4, 3);
            table.MultiSelect = false;
            table.Name = "table";
            table.ReadOnly = true;
            table.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            table.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            table.Size = new Size(813, 559);
            table.TabIndex = 6;
            // 
            // ReviewerName
            // 
            ReviewerName.HeaderText = "Reviewer";
            ReviewerName.Name = "ReviewerName";
            ReviewerName.ReadOnly = true;
            // 
            // Subject
            // 
            Subject.HeaderText = "Subject";
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            // 
            // FilePath
            // 
            FilePath.HeaderText = "File";
            FilePath.Name = "FilePath";
            FilePath.ReadOnly = true;
            FilePath.Resizable = DataGridViewTriState.True;
            FilePath.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            panel1.Controls.Add(subjectCBox);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(12);
            panel1.Size = new Size(837, 43);
            panel1.TabIndex = 7;
            // 
            // subjectCBox
            // 
            subjectCBox.Dock = DockStyle.Fill;
            subjectCBox.Font = new Font("Roboto Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectCBox.FormattingEnabled = true;
            subjectCBox.Location = new Point(12, 12);
            subjectCBox.Margin = new Padding(4, 3, 4, 3);
            subjectCBox.Name = "subjectCBox";
            subjectCBox.Size = new Size(813, 26);
            subjectCBox.TabIndex = 0;
            subjectCBox.SelectedIndexChanged += subjectCBox_SelectedIndexChanged;
            // 
            // ReviewerPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Margin = new Padding(5, 3, 5, 3);
            Name = "ReviewerPanel";
            Text = "Reviewer";
            mainPanel.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox reviewerTxtBox;
        private System.Windows.Forms.Label reviewerLabel;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewButtonColumn FilePath;
        private System.Windows.Forms.Button editFileBtn;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.ComboBox editSubjectCBox;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.ComboBox subjectCBox;
        private System.Windows.Forms.TextBox selectedFileLabel;
        private System.Windows.Forms.Button refreshBtn;
    }
}